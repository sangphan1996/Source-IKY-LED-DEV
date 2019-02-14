#include "rf_parser.h"
#include "logger.h"
#include "system_config.h"
#include "matrix_task.h"
#include "led7seg_task.h"
#include "sys_tick.h"

#define RADIO_DBG(...)  		//DbgCfgPrintf(__VA_ARGS__)

#define RF_PAERSER_PACKET_MAX_LEN       8
#define rF_433_CN_TIMEOUT								250

#define PACKET_LENGTH           4
#define REMOTE_OPCODE           4

#define CONFIG_VOLUME_ACCEL     1
#define CONFIG_ALARM            2

Timeout_Type rf_433_cn_timeout;
//
RADIO_PARSER_PACKET_TYPE rf_parser;
RADIO_PACKET_TYPE rf_receive;
uint8_t rfProtoRecvBuff[RF_PAERSER_PACKET_MAX_LEN];
uint8_t cpd_process_index = 0;
//
void rf_parser_init(void)
{	
	receive_rf_packet_init();
  rf_receive.dataPt = rfProtoRecvBuff;
  rf_parser.state = RADIO_CMD_WAITING_SATRT_CODE;
	InitTimeout(&rf_433_cn_timeout,rF_433_CN_TIMEOUT);
}

void rf_parser_task(void)
{
  uint8_t c;

  if(RINGBUF_Get(&rrp_rx_ringbuff,&c) == 0)
  {
      if(rf_parser_packet(&rf_parser,&rf_receive,c) == 0)
      {
          rf_parser_data(&rf_receive);
      }
  }
}

uint8_t rf_parser_packet(RADIO_PARSER_PACKET_TYPE *parserPacket,RADIO_PACKET_TYPE *cfgProtoRecv,uint8_t c)
{
  switch(parserPacket->state)
  {
      case RADIO_CMD_WAITING_SATRT_CODE:
        if(c == 0xCA)
        {
          parserPacket->state = RADIO_CMD_GET_DATA;
          parserPacket->len = PACKET_LENGTH;
          parserPacket->opcode = REMOTE_OPCODE;
          parserPacket->crc = 0;
          parserPacket->cnt = 0;
        }
        break;
  
      case RADIO_CMD_GET_DATA:
        if(parserPacket->cnt >= parserPacket->len)
        {
          parserPacket->state = RADIO_CMD_WAITING_SATRT_CODE;
        }
        else
        {
          parserPacket->crc += c;
          cfgProtoRecv->dataPt[parserPacket->cnt]= c;
          parserPacket->cnt++;
          cfgProtoRecv->dataPt[parserPacket->cnt]= 0;
          if(parserPacket->cnt == parserPacket->len)
          {
            parserPacket->state = RADIO_CMD_CRC_CHECK;						
          }
        }
        break;
  
      case RADIO_CMD_CRC_CHECK:
        parserPacket->state= RADIO_CMD_WAITING_SATRT_CODE;
        if(parserPacket->crc  == c)
        {          
          cfgProtoRecv->length = parserPacket->len;
          cfgProtoRecv->opcode = parserPacket->opcode;
          return 0;
        }
        break;
        
      default:
        parserPacket->state = RADIO_CMD_WAITING_SATRT_CODE;
        break;
  }
  return 0xff;
}

void rf_parser_data(RADIO_PACKET_TYPE *cfgProtoRecv)
{
  uint32_t u32ID = 0;        
  uint8_t *u8pt;
  
  if(cfgProtoRecv->length >= 4)
  {
      u8pt = (uint8_t*)&u32ID;
      u8pt[0] = cfgProtoRecv->dataPt[0];
      u8pt[1] = cfgProtoRecv->dataPt[1];
      u8pt[2] = cfgProtoRecv->dataPt[2];
      u8pt[3] = 0;
  }
//	RADIO_DBG("RADIO PACKET\r\n");
  switch(cfgProtoRecv->opcode)
  {
        case REMOTE_OPCODE:                  
            break;

        default:
            break;
  }
  cfgProtoRecv->opcode = 0;
}


void rf_433_cn_parser_data(Radio_433_CN_Typedef *radio_pack)
{	
  if(radio_pack->flag)
	{
//		RADIO_DBG("CN PACKET %02X-%02X-%02X-%02X-%02X   %08X\r\n",
//										radio_pack->addr[0],
//										radio_pack->addr[1],
//										radio_pack->addr[2],
//										radio_pack->addr[3],
//										radio_pack->addr[4],
//										radio_pack->data);
		if(CheckTimeout(&rf_433_cn_timeout) != SYSTICK_TIMEOUT)
		{
			radio_pack->flag = 0;
			return;
		}
		RADIO_DBG("RADIO PACKET\r\n");
		if(LedMatrix_State_Get() == LEDMATRIX_DISP_CFG_REMOTE)
		{
				memcpy(sysCfg.RemoteCN,radio_pack->addr,5);
				LedMatrix_State_Change(LEDMATRIX_DISP_NORMAL);
				saveConfigFlag = 1;
		}
		else if(memcmp(sysCfg.RemoteCN,radio_pack->addr,5) == 0)
		{
			if(radio_pack->data == REMOTE_CN_BTN3_VALUE)
			{
				if(led7SegStateGet() == LED7SEG_SETUP)
				{
					if(TimeSecCountDown > TIME_STEP_DOWN) 
						TimeSecCountDown -= TIME_STEP_DOWN;
					else 
						TimeSecCountDown = 0;
//					RADIO_DBG((uint8_t*)"TimeSecCountDown %d\r\n",TimeSecCountDown);
				}
			}
			else if(radio_pack->data == REMOTE_CN_BTN4_VALUE)
			{
				if(led7SegStateGet() == LED7SEG_SETUP)
				{
					TimeSecCountDown += TIME_STEP_UP;
//					RADIO_DBG((uint8_t*)"TimeSecCountDown %d\r\n",TimeSecCountDown);
				}
			}
			else
			{
				if(led7SegStateGet() != LED7SEG_SETUP)
				{
					led7SegStateChange(LED7SEG_SETUP);
//					RADIO_DBG((uint8_t*)"led7SegStateChange(LED7SEG_SETUP)\r\n");
				}
				else
				{				
					led7SegStateChange(LED7SEG_IDLE);
//					RADIO_DBG((uint8_t*)"led7SegStateChange(LED7SEG_IDLE)\r\n");
				}
			}
		}
		InitTimeout(&rf_433_cn_timeout,rF_433_CN_TIMEOUT);
		radio_pack->flag = 0;
		return;
	}
}

void rf_433_cn_parser_task(void)
{
  rf_433_cn_parser_data(&rf_cn_packet);
}

