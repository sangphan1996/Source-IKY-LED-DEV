

#include "stm32f10x.h"
#include "p10matrix.h"
#include "hw_config.h"
#include "framebuffer.h"

uint32_t led_on = 0;
uint8_t p10_ch = 0;


void p10SelCh(uint8_t ch);
void p10DispOff(void);
void p10DispOn(void);
void HC595Pulse(void);
void HC595Latch(void);
void HC595Write(uint8_t data);

void p10matrix_timer_init(uint32_t period)
{
	TIM_TimeBaseInitTypeDef TIM_TimeBaseStructure;
	NVIC_InitTypeDef NVIC_InitStructure;
  TIM_DeInit(TIM3);
  TIM_TimeBaseStructInit(&TIM_TimeBaseStructure);
    /* TIM5 clock enable */
  RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM3, ENABLE);
  /* Time base configuration */
  TIM_TimeBaseStructure.TIM_Prescaler = 48 - 1; // 48 MHz / 1200 = 40 KHz
  TIM_TimeBaseStructure.TIM_Period = period - 1;  // 40 KHz / 20 = 2 KHz;
  TIM_TimeBaseStructure.TIM_ClockDivision = 0;
  TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up;
  TIM_TimeBaseInit(TIM3, &TIM_TimeBaseStructure);
    
  TIM_Cmd(TIM3, ENABLE);	
	TIM_ClearITPendingBit(TIM3, TIM_IT_Update);  
  TIM_ITConfig(TIM3, TIM_IT_Update, ENABLE);
      
  NVIC_InitStructure.NVIC_IRQChannel = TIM3_IRQn;
  NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 1;
  NVIC_InitStructure.NVIC_IRQChannelSubPriority = 1;
  NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
  NVIC_Init(&NVIC_InitStructure);
}

void p10matrix_pinout_init(void)
{
	hwPinModeOutput(P10_OE_PORT,P10_OE_PIN);
	hwPinModeOutput(P10_A_PORT,P10_A_PIN);
	hwPinModeOutput(P10_B_PORT,P10_B_PIN);
	hwPinModeOutput(P10_SHIFT_PORT,P10_SHIFT_PIN);
	hwPinModeOutput(P10_STORE_PORT,P10_STORE_PIN);
	hwPinModeOutput(P10_DATA_PORT,P10_DATA_PIN);
	
	p10DispOff();
	
	p10SelCh(3);
}

void p10matrix_begin(void)
{
	p10matrix_pinout_init();	
	p10matrix_timer_init(500);
}

void p10_Scan(void)
{
	uint8_t i;

	p10DispOff();
	
	for(i=0;i<16;i++)
	{
			HC595Write(framebuffer_displaybuffer[(i*4+p10_ch)]);			
	}
   	
	HC595Latch();
   
	p10SelCh(3-p10_ch);
   
	p10DispOn();
   
	p10_ch++;
   
	if(p10_ch >= 4) p10_ch = 0;

}

void p10SelCh(uint8_t ch)
{
	switch(ch)
	{
		case 0:
			GPIO_ResetBits(P10_A_PORT,P10_A_PIN);
			GPIO_ResetBits(P10_B_PORT,P10_B_PIN);
			break;
		case 1:
			GPIO_SetBits(P10_A_PORT,P10_A_PIN);
			GPIO_ResetBits(P10_B_PORT,P10_B_PIN);
			break;
		case 2:
			GPIO_ResetBits(P10_A_PORT,P10_A_PIN);
			GPIO_SetBits(P10_B_PORT,P10_B_PIN);
			break;
		case 3:
			GPIO_SetBits(P10_A_PORT,P10_A_PIN);
			GPIO_SetBits(P10_B_PORT,P10_B_PIN);
			break;
		default: 
			break;
			
	}
}


void p10DispOff(void)
{
	GPIO_ResetBits(P10_OE_PORT,P10_OE_PIN);
}

void p10DispOn(void)
{
	GPIO_SetBits(P10_OE_PORT,P10_OE_PIN);
}

//Sends a clock pulse on SH_CP line
void HC595Pulse(void)
{
    GPIO_SetBits(P10_SHIFT_PORT,P10_SHIFT_PIN);
    GPIO_ResetBits(P10_SHIFT_PORT,P10_SHIFT_PIN);//LOW
}

//Sends a clock pulse on ST_CP line
void HC595Latch(void)
{
   GPIO_SetBits(P10_STORE_PORT,P10_STORE_PIN);
   GPIO_ResetBits(P10_STORE_PORT,P10_STORE_PIN);
}



void HC595Write(uint8_t data)
{
    uint8_t i=0;
   for(i=0;i<8;i++)
   {
      if(data & 0x80)
      {
         GPIO_SetBits(P10_DATA_PORT,P10_DATA_PIN);
      }
      else
      {
         GPIO_ResetBits(P10_DATA_PORT,P10_DATA_PIN);
      }

      HC595Pulse();  //Pulse the Clock line
      data=data<<1;  //Now bring next bit at MSB position

   }
}
