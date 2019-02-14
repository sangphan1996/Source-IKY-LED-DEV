#ifndef __RF_PARSER_H
#define __RF_PARSER_H
#include "stm32f10x.h"
#include "ringbuf.h"
#include "rf_packet.h"

typedef enum{
	RADIO_CMD_NEW_STATE,	
	RADIO_CMD_GET_DATA,
	RADIO_CMD_CRC_CHECK,
	RADIO_CMD_WAITING_SATRT_CODE
}RADIO_CMD_STATE_TYPE;

typedef struct
{
	RADIO_CMD_STATE_TYPE state;
	uint8_t len;
	uint8_t lenMax;
	uint8_t cnt;
	uint8_t opcode;
	uint8_t crc;
} RADIO_PARSER_PACKET_TYPE;

typedef struct
{
	uint8_t start;
	uint8_t length;
	uint8_t opcode;
	uint8_t *dataPt;
	uint8_t crc;
} RADIO_PACKET_TYPE;
//
void rf_parser_init(void);
void rf_parser_task(void);
uint8_t rf_parser_packet(RADIO_PARSER_PACKET_TYPE *parserPacket,RADIO_PACKET_TYPE *cfgProtoRecv,uint8_t c);
void rf_parser_data(RADIO_PACKET_TYPE *cfgProtoRecv);
void rf_433_cn_parser_data(Radio_433_CN_Typedef *radio_pack);
void rf_433_cn_parser_task(void);
#endif //__RF_PARSER_H
/*******************************************************************************
	*END FILE
********************************************************************************/
