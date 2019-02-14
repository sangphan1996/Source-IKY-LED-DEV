
#include "rfid_decode.h"
#include "main.h"
#include "io_control.h"
#include "h_string.h"

typedef enum{
  RFID_DECODE_WAIT_STOP_BIT,
  RFID_DECODE_WAIT_HEADER,
  RFID_DECODE_GET_DATA,
  RFID_DECODE_WAIT_PROCESS,
}RFID_DECODE_PHASE;

uint8_t RFID_DECODE_PULSE_WITH_COUTER_400KHz[] = {70,130,170,230};
uint8_t RFID_DECODE_PULSE_WITH_COUTER_250KHz[] = {44,81,106,145};

RFID_DECODE_PHASE rfidDecodePhase = RFID_DECODE_WAIT_STOP_BIT;

uint8_t rfid_decode_header_cnt;

uint8_t rfid_decode_pulse_min_low = 70;
uint8_t rfid_decode_pulse_max_low = 130;
uint8_t rfid_decode_pulse_min_high = 170;
uint8_t rfid_decode_pulse_max_high = 230;

uint8_t rfid_decode_logic_cnt = 0;
uint8_t rfid_decode_change_cnt = 0;

uint8_t rfid_decode_data[6] = {0};
uint8_t rfid_decode_data_point = 0;

uint8_t rfid_decode_chuc = 0;
uint8_t rfid_decode_dv = 0;
uint8_t rfid_decode_crc_row = 0;

uint8_t rfid_decode_wait_process = 0;

void rfid_decode_packet_init(void)
{
        uint8_t *u8pt = RFID_DECODE_PULSE_WITH_COUTER_250KHz;
        
        rfid_decode_pulse_min_low = u8pt[0];
        rfid_decode_pulse_max_low = u8pt[1];
        rfid_decode_pulse_min_high = u8pt[2];
        rfid_decode_pulse_max_high = u8pt[3];

        rfidDecodePhase = RFID_DECODE_WAIT_STOP_BIT;
}

void rfid_decode_packet_packet_callback(uint16_t cnt)
{
   switch(rfidDecodePhase)
  {
    case RFID_DECODE_WAIT_STOP_BIT:
      if(!RFID_INPUT_STATUS)
      {
        if(cnt > rfid_decode_pulse_min_high)
        {
          rfid_decode_header_cnt = 0;
          rfidDecodePhase = RFID_DECODE_WAIT_HEADER;
        }
      }
      break;
      
    case RFID_DECODE_WAIT_HEADER:
      if(cnt > rfid_decode_pulse_min_low && cnt < rfid_decode_pulse_max_low) 
      {
        rfid_decode_header_cnt++;
      }
      else
      {
        rfidDecodePhase = RFID_DECODE_WAIT_STOP_BIT;
        break;
      }
      if(rfid_decode_header_cnt == 16)
      {        
        rfidDecodePhase = RFID_DECODE_GET_DATA;
        rfid_decode_chuc = 0;
        rfid_decode_dv = 0;
        rfid_decode_crc_row = 0;
        rfid_decode_change_cnt = 0;
        rfid_decode_logic_cnt = 0;
        rfid_decode_data_point = 0;
      }
      break;
      
    case RFID_DECODE_GET_DATA:
      if(cnt > rfid_decode_pulse_min_low && cnt < rfid_decode_pulse_max_low) 
      {
        rfid_decode_logic_cnt++;
        if(rfid_decode_logic_cnt == 2)
        {
          if(rfid_decode_dv != 4) 
          {
            rfid_decode_data[rfid_decode_chuc] = rfid_decode_data[rfid_decode_chuc] << 1;
          }
          rfid_decode_logic_cnt = 0;
          rfid_decode_data_point++;
          rfid_decode_dv++;
          if(!RFID_INPUT_STATUS)
          {
            if(rfid_decode_dv != 5)
            {
              rfid_decode_data[rfid_decode_chuc]++;
            }
            rfid_decode_crc_row++;
          }	
          if(rfid_decode_dv == 5)
          {
            if(rfid_decode_crc_row == 1 || rfid_decode_crc_row == 3 ||rfid_decode_crc_row == 5) 
            {
              rfidDecodePhase = RFID_DECODE_WAIT_STOP_BIT; //error
            }
            rfid_decode_dv = 0;
            rfid_decode_change_cnt++;
            if(rfid_decode_change_cnt == 2)
            {
              rfid_decode_chuc++;
              rfid_decode_change_cnt = 0;
            }
            rfid_decode_crc_row = 0;
          }
          if(rfid_decode_data_point >= 54)
          {
            rfid_decode_wait_process = 1;
            rfidDecodePhase = RFID_DECODE_WAIT_PROCESS;   //decode success         
          }
        }
      }
      else if(cnt > rfid_decode_pulse_min_high && cnt < rfid_decode_pulse_max_high)
      {
        if(rfid_decode_dv != 4)
        {
          rfid_decode_data[rfid_decode_chuc] = rfid_decode_data[rfid_decode_chuc]<<1;
        }
        rfid_decode_logic_cnt = 0;
        rfid_decode_data_point++;
        rfid_decode_dv++;
        if(!RFID_INPUT_STATUS)
        {
          if(rfid_decode_dv != 5)
          {
            rfid_decode_data[rfid_decode_chuc]++;
          }
          rfid_decode_crc_row++;
        }
        if(rfid_decode_dv == 5)
        {
          if(rfid_decode_crc_row == 1 || rfid_decode_crc_row ==3 ||rfid_decode_crc_row ==5)
          {
            rfidDecodePhase = RFID_DECODE_WAIT_STOP_BIT; //error
          }
          rfid_decode_dv = 0;
          rfid_decode_change_cnt++;
          if(rfid_decode_change_cnt == 2)
          {
            rfid_decode_chuc++;
            rfid_decode_change_cnt = 0;
          }
          rfid_decode_crc_row = 0;
        }
        if(rfid_decode_data_point >= 54)
        {
          rfid_decode_wait_process = 1;
          rfidDecodePhase = RFID_DECODE_WAIT_PROCESS;   //decode success 
        }
      }
      else	        
      {
        rfidDecodePhase = RFID_DECODE_WAIT_STOP_BIT;
//        GPIO_WriteReverse(LED_DBG_PORT,LED_DBG_PIN);
      }
      break;
      
    case RFID_DECODE_WAIT_PROCESS:
      if(rfid_decode_wait_process == 0)
      {
        h_memset(rfid_decode_data,0,6);
        rfidDecodePhase = RFID_DECODE_WAIT_STOP_BIT;
      }
      break;
      
    default: break;
  }
}


/*****END OF FILE****/
