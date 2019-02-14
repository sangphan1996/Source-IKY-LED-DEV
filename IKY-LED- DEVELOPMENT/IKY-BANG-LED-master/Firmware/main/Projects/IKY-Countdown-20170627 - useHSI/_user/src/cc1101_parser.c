#include "cc1101_parser.h"
#include "led7seg_task.h"
#include "logger.h"
#include "matrix_task.h"
#include "system_config.h"
#include <stdlib.h>

#define RF_PARSER_DBG(...)  		NRF_LOG_PRINTF(__VA_ARGS__)

extern uint8_t remoteIndex;

uint8_t _rfParser_RxRingBuff[256];
RINGBUF rfParser_RxRingBuff;
PARSER_PACKET_TYPE rfParserPacket;
CFG_PROTOCOL_TYPE rfProtoRecv;
uint8_t rfDataBuff[256];

uint8_t CfgParserPacket_v1(PARSER_PACKET_TYPE *parserPacket,CFG_PROTOCOL_TYPE *cfgProtoRecv,uint8_t c);
uint8_t CfgParserPacket(PARSER_PACKET_TYPE *parserPacket,CFG_PROTOCOL_TYPE *cfgProtoRecv,uint8_t c);;

void rfParserTask_Init(void)
{
	RINGBUF_Init(&rfParser_RxRingBuff,_rfParser_RxRingBuff,sizeof(_rfParser_RxRingBuff));
	rfProtoRecv.dataPt = rfDataBuff;
	rfParserPacket.state = CFG_CMD_WAITING_SATRT_CODE;
	rfParserPacket.lenMax = sizeof(rfDataBuff);
}

void rfParserTask(void)
{
	uint8_t c;

	if(RINGBUF_Get(&rfParser_RxRingBuff,&c) == 0)
	{
		if(CfgParserPacket_v1(&rfParserPacket,&rfProtoRecv,c) == 0)
		{
			CfgProcessData(&rfProtoRecv,NULL,NULL,rfParserPacket.lenMax - 4,1);
		}
	}
}

uint8_t CfgParserPacket_v1(PARSER_PACKET_TYPE *parserPacket,CFG_PROTOCOL_TYPE *cfgProtoRecv,uint8_t c)
{
	switch(parserPacket->state)
	{
		case CFG_CMD_WAITING_SATRT_CODE:
			if(c == 0xCA)
			{
				parserPacket->state = CFG_CMD_GET_LENGTH;
				parserPacket->len = 0;
				parserPacket->crc = 0;
				parserPacket->cnt = 0;
			}
			break;
			
		case CFG_CMD_GET_LENGTH:
			if(parserPacket->cnt == 0)
			{
					parserPacket->len |= (uint16_t)c<<8;
					parserPacket->cnt ++;
			}
			else
			{
					parserPacket->len |= (uint16_t)c;
					parserPacket->state = CFG_CMD_GET_OPCODE;
					parserPacket->cnt = 0;
			}
			break;
		
		case CFG_CMD_GET_OPCODE:
			parserPacket->opcode = c;
			parserPacket->state = CFG_CMD_GET_DATA;
			break;
		
		case CFG_CMD_GET_DATA:
			if((parserPacket->cnt >= parserPacket->len) || (parserPacket->len > parserPacket->lenMax))
			{
					parserPacket->state = CFG_CMD_WAITING_SATRT_CODE;
			}
			else
			{
					parserPacket->crc += c;
					cfgProtoRecv->dataPt[parserPacket->cnt]= c;
					parserPacket->cnt++;
					cfgProtoRecv->dataPt[parserPacket->cnt]= 0;
					if(parserPacket->cnt == parserPacket->len)
					{
						parserPacket->state = CFG_CMD_CRC_CHECK;						
					}
			}
			break;
			
		case CFG_CMD_CRC_CHECK:
			parserPacket->state= CFG_CMD_WAITING_SATRT_CODE;
			if(parserPacket->crc  == c)
			{	
					cfgProtoRecv->length = parserPacket->len;
					cfgProtoRecv->opcode = parserPacket->opcode;
					return 0;
			}
			break;
			
		default:
			parserPacket->state = CFG_CMD_WAITING_SATRT_CODE;
			break;				
	}
	return 0xff;
}

uint8_t CfgParserPacket(PARSER_PACKET_TYPE *parserPacket,CFG_PROTOCOL_TYPE *cfgProtoRecv,uint8_t c)
{
	switch(parserPacket->state)
	{
		case CFG_CMD_WAITING_SATRT_CODE:
			if(c == 0xCA)
			{
				parserPacket->state = CFG_CMD_GET_LENGTH;
				parserPacket->len = 0;
				parserPacket->crc = 0;
				parserPacket->cnt = 0;
			}
			break;
			
		case CFG_CMD_GET_LENGTH:
			parserPacket->len = c;
			parserPacket->state = CFG_CMD_GET_OPCODE;
			parserPacket->cnt = 0;
			break;
		
		case CFG_CMD_GET_OPCODE:
			parserPacket->opcode = c;
			parserPacket->state = CFG_CMD_GET_DATA;
			break;
		
		case CFG_CMD_GET_DATA:
			if((parserPacket->cnt >= parserPacket->len) || (parserPacket->len > parserPacket->lenMax))
			{
					parserPacket->state = CFG_CMD_WAITING_SATRT_CODE;
			}
			else
			{
					parserPacket->crc += c;
					cfgProtoRecv->dataPt[parserPacket->cnt]= c;
					parserPacket->cnt++;
					cfgProtoRecv->dataPt[parserPacket->cnt]= 0;
					if(parserPacket->cnt == parserPacket->len)
					{
						parserPacket->state = CFG_CMD_CRC_CHECK;						
					}
			}
			break;
			
		case CFG_CMD_CRC_CHECK:
			parserPacket->state= CFG_CMD_WAITING_SATRT_CODE;
			if(parserPacket->crc  == c)
			{	
					cfgProtoRecv->length = parserPacket->len;
					cfgProtoRecv->opcode = parserPacket->opcode;
					return 0;
			}
			break;
			
		default:
			parserPacket->state = CFG_CMD_WAITING_SATRT_CODE;
			break;				
	}
	return 0xff;
}

uint8_t CfgProcessData(CFG_PROTOCOL_TYPE *cfgProtoRecv,CFG_PROTOCOL_TYPE *cfgProtoSend,uint8_t *cfgSendDataBuff,uint32_t maxPacketSize,uint8_t logSendEnable)
{
	static uint8_t flagCfgProcessInUse = 0;	
	uint32_t u32ID = 0;        
  uint8_t *u8pt;
	uint32_t u32Value;
	uint32_t u32Value1;
	uint8_t u8Temp1[32];
	uint8_t u8Temp2[32];
	uint8_t u8Temp3[32];
	uint8_t u8Temp4[64];
	if(flagCfgProcessInUse) 
	{
		cfgProtoRecv->opcode = 0;
		return 0;
	}
	if(cfgProtoRecv->opcode)RF_PARSER_DBG((uint8_t*)"opcode 0x%02X\r\n",cfgProtoRecv->opcode);
	flagCfgProcessInUse = 1;
	if(cfgProtoRecv->length >= 4)
	{
      u8pt = (uint8_t*)&u32ID;
      u8pt[0] = cfgProtoRecv->dataPt[0];
      u8pt[1] = cfgProtoRecv->dataPt[1];
      u8pt[2] = cfgProtoRecv->dataPt[2];
      u8pt[3] = cfgProtoRecv->dataPt[3];
  }
	switch(cfgProtoRecv->opcode)
	{
		case 0x00:
			break;
		
		case OPCODE_REMOTE_BTN_PRESS:
			if(LedMatrix_State_Get() == LEDMATRIX_DISP_CFG_REMOTE)
			{
				sysCfg.Remote[remoteIndex] = u32ID;
				remoteIndex++;
				if(remoteIndex > 1)
				{
					LedMatrix_State_Change(LEDMATRIX_DISP_NORMAL);
					saveConfigFlag = 1;
				}
				break;
			}
			if(u32ID != sysCfg.Remote[0] && u32ID != sysCfg.Remote[1])
			{
				break;
			}
			if(cfgProtoRecv->dataPt[4] == REMOTE_BTN1_PRESS_VALUE)
			{
				if(led7SegStateGet() == LED7SEG_SETUP)
				{
					if(TotalDuration > TIME_STEP_DOWN) 
						TotalDuration -= TIME_STEP_DOWN;
					else 
						TotalDuration = 0;
				}
			}
			else if(cfgProtoRecv->dataPt[4] == REMOTE_BTN2_PRESS_VALUE)
			{
				if(led7SegStateGet() == LED7SEG_SETUP)
				{
					TotalDuration += TIME_STEP_UP;
				}
			}
			else if(cfgProtoRecv->dataPt[4] == REMOTE_BTN3_PRESS_VALUE)
			{
				if(led7SegStateGet() != LED7SEG_SETUP)
				{
					led7SegStateChange(LED7SEG_SETUP);
				}
				else
				{				
					led7SegStateChange(LED7SEG_IDLE);
				}
			}
			break;
			
		case OPCODE_PC_COMM: 
			if(cfgProtoRecv->length < MATRIX_STRING_MAX_LEN)
			{
				RF_PARSER_DBG ((uint8_t*)"rf: %s\r\n",(char*)&cfgProtoRecv->dataPt[4]);
				sscanf((char*)&cfgProtoRecv->dataPt[4],"%02d,%[^,\t\n\r],%[^,\t\n\r],%[^,\t\n\r#]",&u32Value,u8Temp1,u8Temp2,u8Temp3);
				RF_PARSER_DBG((uint8_t*)"para: %d-%s-%s-%s\r\n",u32Value,u8Temp1,u8Temp2,u8Temp3);
				if(sysCfg.DevID != u32Value)
				{
					break;
				}
				sprintf((char*)u8Temp4,"%s %s",u8Temp1,u8Temp2);
				MaTrix_StringUpdate(u8Temp4,strlen((char*)u8Temp4));
				sscanf((char*)u8Temp3,"%02d:%02d",&u32Value,&u32Value1);
				RF_PARSER_DBG((uint8_t*)"Time: %d-%d\r\n",u32Value,u32Value1);
				TotalDuration = u32Value*60*60 + u32Value1*60; //
				TimeStart = SysTick_GetSec(); //Chỉ thời gian bắt đâu 1 lần khi nhận đc lệnh đầu tiên
				if(LedMatrix_State_Get() == LEDMATRIX_DISP_CHECKOUT)
				{
					LedMatrix_State_Change(LEDMATRIX_DISP_NORMAL);
				}
			}
			break;
		
		case OPCODE_CFG_PC_COMM:			
			sscanf((char*)&cfgProtoRecv->dataPt[4],"%02d,%[^,\t\n\r]",&u32Value,u8Temp1);			
			if(sysCfg.DevID != u32Value)
			{
					break;
			}
			sprintf((char*)sysCfg.Greeting,"%s%s",(char*)u8Temp1,GFX_STRING_SPACING);
			saveConfigFlag = 1;
			break;
		
		case OPCODE_CFG_TIME: //Chỉnh tăng giảm thời gian sửa chữa
			sscanf((char*)&cfgProtoRecv->dataPt[4],"%02d,%[^,\t\n\r],%[^,\t\n\r]",&u32Value,u8Temp1,u8Temp2);
			if(sysCfg.DevID != u32Value)
			{
					break;
			}
			u32Value = (atoi((char*)u8Temp2) * 60);
			if(u8Temp1[0] == '1')
			{
				TotalDuration += u32Value;
			}
			else
			{
				if(u32Value > TotalDuration)
					TotalDuration = 0;
				else
					TotalDuration -= u32Value;
			}
			break;
			
		case OPCODE_CFG_CHECKOUT:		
			sscanf((char*)&cfgProtoRecv->dataPt[4],"%02d,%[^,\t\n\r]",&u32Value,u8Temp1);			
			if(sysCfg.DevID != u32Value)
			{
					break;
			}
			RF_PARSER_DBG((uint8_t*)"str %s\r\n",u8Temp1);
			InitTimeout(&tLEDMatrixDispCheckOut,SYSTICK_TIME_SEC(120));
			LedMatrix_State_Change(LEDMATRIX_DISP_CHECKOUT);
			sprintf((char*)sysCfg.CheckOut,"%s%s",(char*)u8Temp1,GFX_STRING_SPACING);
			break;
			
		default:
			break;
	}
	cfgProtoRecv->opcode = 0;
	flagCfgProcessInUse = 0;
	return 0;
}
