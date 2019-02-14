
#include "rf_packet.h"
//
RINGBUF rrp_rx_ringbuff;
uint8_t __rrp_rx_ringbuff[64];
uint8_t rrpBuff[6];
uint8_t rrpFlag = 0;
//
uint8_t rrp_state = 0;
uint8_t rrp_cnt = 0;
//
uint8_t rf_cn_pulse_buff[50];
uint8_t rf_cn_bit_buff[25];
uint8_t rf_cn_pulse_index = 0;


#define PULSE_HIGH_SHORT		1
#define PULSE_HIGH_LONG			2
#define PULSE_LOW_SHORT			5
#define PULSE_LOW_LONG			6
#define WIDTH_PULSE_MIN			30
#define WIDTH_PULSE_MID			75
#define WIDTH_PULSE_MAX			250
#define WIDTH_PULSE_START_MIN			1200
#define WIDTH_PULSE_START_MAX			1900

typedef enum _RF433{
	WAIT_HEADER_PULSE,
	WAIT_LONG_BIT,
	GET_DATA_RF433,
	FINISH_RF433
}ID433SM;
ID433SM SMRF433 = WAIT_HEADER_PULSE;


Radio_433_CN_Typedef rf_cn_packet;

void TIM4_IRQHandler(void)
{
	if(TIM4->SR & 1)
	{
		TIM4->SR = (uint16_t)~0x0001;		
	}
}

static void TIMER4_Init(uint32_t pclk)
{	
	RCC->APB1ENR |= RCC_APB1ENR_TIM4EN;                     // enable clock for TIM4
	TIM4->PSC = (uint16_t)(pclk/100000) - 1;            													// set prescaler
	TIM4->ARR = (uint16_t)0xFFFF;  																		// set auto-reload
	TIM4->CR1 = 0;                                          // reset command register 1
	TIM4->CR2 = 0;                                          // reset command register 2
//		TIM4->DIER = 1;                             
//		NVIC_SetPriority (TIM4_IRQn,((0x01<<3) | 4));
//		NVIC_EnableIRQ(TIM4_IRQn);															// enable interrupt
	TIM4->EGR = 1;																					// update
	TIM4->CR1 |= 1;                              						// enable timer                             						// enable timer
	TIM4->CNT = 0;
}

static void receive_rf_timer(void)
{
	TIMER4_Init(SystemCoreClock);
}

static void receive_rf_init(void)
{
  RINGBUF_Init(&rrp_rx_ringbuff,__rrp_rx_ringbuff,sizeof(__rrp_rx_ringbuff));
	rf_cn_packet.flag = 0;
}

/**
  * @brief  RECEIVE_RF_PACKET_INIT
  * @param  None
  * @retval None
  */
void receive_rf_packet_init(void)
{
	receive_rf_timer();
	receive_rf_init();
  rrp_cnt = 0;
  rrp_state = RRP_WAIT_START_PULSE;
}
/**
  * @brief  RECEIVE_RF_PACKET_CALLBACK
  * @param  None
  * @retval None
  */
void receive_rf_packet_callback(uint16_t cnt)
{
  static uint8_t rrp_data;
  static uint8_t rrp_bits;
  static uint8_t rrp_bytes;
  uint8_t i = 0;
  switch(rrp_state)
  {
    case RRP_WAIT_START_PULSE:
      if(cnt > 500 || cnt < 400) 
      {
        rrp_cnt = 0;
        break;
      }
      else
      {
        rrp_cnt++;
        if(rrp_cnt == 2)
        {
          rrp_cnt = 0;
          rrp_data = 0;
          rrp_bits = 8;
          rrp_bytes = 6;
          rrp_state = RRP_RECORD_8_BITS;
        }
      }
      break;
      
    case RRP_RECORD_8_BITS:
      if(cnt > 500 || cnt < 150) // if >=200uS, is unexpected start pulse!      
      {
        rrp_state = RRP_WAIT_START_PULSE;
        break;  
      }
      if(cnt < 299) rrp_data &= ~(0x01);    // 61 = 122uS
      else                rrp_data |= 0x01;
      rrp_bits--;                   // and record 1 more good bit done
      if(rrp_bits)rrp_data = (rrp_data << 1);   // save the good bit into rrp_data
      else              // else 8 good bits were received
      {
        rrp_bytes--;
        rrpBuff[rrp_bytes] = rrp_data;
        if(rrp_bytes)
        {
          rrp_data = 0;
          rrp_bits = 8;
          rrp_state = RRP_RECORD_8_BITS;
        }
        else
        {
          for(i=0;i<6;i++) RINGBUF_Put(&rrp_rx_ringbuff,rrpBuff[5-i]);
          rrp_state = RRP_WAIT_START_PULSE;
        }
      }
      break;
      
    default:
      rrp_cnt = 0;
			rrp_state = RRP_WAIT_START_PULSE;
      break;
  }
}


void receive_rf_china_packet_callback(uint16_t cnt, uint8_t status)
{
	uint8_t *u8pt;
	uint8_t i;
	switch(SMRF433)
	{
			case WAIT_HEADER_PULSE:
				if(!status) break;
				if(cnt > WIDTH_PULSE_START_MAX || cnt < WIDTH_PULSE_START_MIN) 
				{
					break;
				}
				rf_cn_pulse_index = 0;
				SMRF433 = WAIT_LONG_BIT;				
				break;
			case WAIT_LONG_BIT:
				if(cnt > WIDTH_PULSE_MAX || cnt < WIDTH_PULSE_MIN) 
				{
						SMRF433 = WAIT_HEADER_PULSE;
						break;
				}
				
				if(cnt < WIDTH_PULSE_MID)
				{
					if(!status)
					{
							rf_cn_pulse_buff[rf_cn_pulse_index] = PULSE_HIGH_SHORT;
					}
					else
					{
							rf_cn_pulse_buff[rf_cn_pulse_index] = PULSE_LOW_SHORT;
					}
				}
				else				
				{
					if(!status)
					{
							rf_cn_pulse_buff[rf_cn_pulse_index] = PULSE_HIGH_LONG;
					}
					else
					{
							rf_cn_pulse_buff[rf_cn_pulse_index] = PULSE_LOW_LONG;
					}
				}
				rf_cn_pulse_index++;
				if(rf_cn_pulse_index >= 48)
				{
					SMRF433 = GET_DATA_RF433;
				}
				break;
			case GET_DATA_RF433:
				for(i=0;i<12;i++)
				{		
					if(rf_cn_pulse_buff[i*4 + 0] == PULSE_HIGH_LONG)
					{
						rf_cn_bit_buff[i] = 1;
					}
					else if(rf_cn_pulse_buff[i*4 + 2] == PULSE_HIGH_SHORT)
					{
						rf_cn_bit_buff[i] = 0;
					}
					else
					{
						rf_cn_bit_buff[i] = 2;
					}
				}				 
				rf_cn_packet.addr[0] = ((rf_cn_bit_buff[0]<<4)&0xF0) | (rf_cn_bit_buff[1]&0x0F);
				rf_cn_packet.addr[1] = ((rf_cn_bit_buff[2]<<4)&0xF0) | (rf_cn_bit_buff[3]&0x0F);
				rf_cn_packet.addr[2] = ((rf_cn_bit_buff[4]<<4)&0xF0) | (rf_cn_bit_buff[5]&0x0F);
				rf_cn_packet.addr[3] = ((rf_cn_bit_buff[6]<<4)&0xF0) | (rf_cn_bit_buff[7]&0x0F);
				rf_cn_packet.addr[4] = 0;
				u8pt = (uint8_t*)&rf_cn_packet.data;
				u8pt[0] = rf_cn_bit_buff[8];
				u8pt[1] = rf_cn_bit_buff[9];
				u8pt[2] = rf_cn_bit_buff[10];
				u8pt[3] = rf_cn_bit_buff[11];
				rf_cn_packet.flag = 1;
				SMRF433 = FINISH_RF433;
				break;
			case FINISH_RF433:
				if(rf_cn_packet.flag) break;
				SMRF433 = WAIT_HEADER_PULSE;
				break;
			default: break;				
	}
}
/*****END OF FILE****/

