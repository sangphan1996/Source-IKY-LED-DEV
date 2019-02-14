#include "cc1101_parser.h"
#include "display_task.h"
#include "logger.h"
#include "display_task.h"
#include "system_config.h"
#include <stdlib.h>
#include "sys_tick.h"

#define RF_PARSER_APPLOG(...)  		NRF_LOG_PRINTF(__VA_ARGS__)

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
		RF_PARSER_APPLOG("%02X",c);
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
				parserPacket->state = CFG_CMD_GET_OPCODE;
				parserPacket->len = 0;
				parserPacket->crc = 0;
				parserPacket->cnt = 0;
			}
			break;
		
		case CFG_CMD_GET_OPCODE:
			parserPacket->opcode = c;
			parserPacket->state = CFG_CMD_GET_LENGTH;
			break;
			
		case CFG_CMD_GET_LENGTH:
			parserPacket->len = c;
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
			else
			{
					RF_PARSER_APPLOG("CRC ERR\r\n");
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
	uint32_t u32Value;
	uint32_t u32Value1;
	uint8_t u8Temp1[32];
	uint8_t u8Temp2[32];
	uint8_t u8Temp3[32];
	

	RF_PARSER_APPLOG("\r\nopcode : 0x%02X\r\n",cfgProtoRecv->opcode);
	RF_PARSER_APPLOG("\r\nData :%s\r\n",cfgProtoRecv->dataPt);
	
	switch(cfgProtoRecv->opcode)
	{
		case OPCODE_PC_COMM: 
			if(cfgProtoRecv->length < MSG_MAX_LENGTH)
			{
				RF_PARSER_APPLOG ("rf: %s\r\n",(char*)cfgProtoRecv->dataPt);
				sscanf((char*)cfgProtoRecv->dataPt,"%02d,%[^,\t\n\r],%[^,\t\n\r],%[^,\t\n\r#]",&u32Value,u8Temp1,u8Temp2,u8Temp3);
				RF_PARSER_APPLOG("para: %d-%s-%s-%s\r\n",u32Value,u8Temp1,u8Temp2,u8Temp3);
				if(sysCfg.DevID != u32Value)
				{
					break;
				}
				sprintf((char*)sysCfg.GuestInf,"%s %s",u8Temp1,u8Temp2);				
				sscanf((char*)u8Temp3,"%02d:%02d",&u32Value,&u32Value1);
				RF_PARSER_APPLOG("Time: %d-%d\r\n",u32Value,u32Value1);
				TotalDuration = u32Value*60*60 + u32Value1*60; //
				TimeStart = SysTick_GetSec(); //Chỉ thời gian bắt đầu 1 lần khi nhận dc lệnh đầu tiên
				if(displayState == DISP_CHECKOUT)
				{
					displayState = DISP_HOME;
				}
				saveConfigFlag = 1;
			}
			break;
		
		case OPCODE_CFG_PC_COMM:			
			sscanf((char*)cfgProtoRecv->dataPt,"%02d,%[^,\t\n\r]",&u32Value,u8Temp1);			
			if(sysCfg.DevID != u32Value)
			{
					break;
			}
			sprintf((char*)sysCfg.Greeting,"%s",(char*)u8Temp1);
			saveConfigFlag = 1;
			break;
		
		case OPCODE_CFG_TIME: //Tăng giảm thời gian sửa chữa
			sscanf((char*)cfgProtoRecv->dataPt,"%02d,%[^,\t\n\r],%[^,\t\n\r]",&u32Value,u8Temp1,u8Temp2);
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
			sscanf((char*)cfgProtoRecv->dataPt,"%02d,%[^,\t\n\r]",&u32Value,u8Temp1);			
			if(sysCfg.DevID != u32Value)
			{
					RF_PARSER_APPLOG("ID INCORRECT %d | %d\r\n",u32Value,sysCfg.DevID);
					break;
			}
			RF_PARSER_APPLOG("str %s\r\n",u8Temp1);
			InitTimeout(&tDispCheckOut,SYSTICK_TIME_SEC(120));
			displayState = DISP_CHECKOUT;
			sprintf((char*)sysCfg.CheckOut,"%s",(char*)u8Temp1);
			TotalDuration = 0;
			break;
			
		default:
			break;
	}
	cfgProtoRecv->opcode = 0;	
	return 0;
}
