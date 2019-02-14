#ifndef __CC1101_PARSER_H
#define __CC1101_PARSER_H
#include "stm32f10x.h"
#include "ringbuf.h"

//
#define REMOTE_BTN1_PRESS_VALUE         0x01 //Turn off bell
#define REMOTE_BTN2_PRESS_VALUE         0x02 //Turn off protect mode
#define REMOTE_BTN3_PRESS_VALUE         0x03 //Turn on protect mode
//PIR Detect
#define PIR_ACTIVE_VALUE                0x01
#define PIR_INACTIVE_VALUE              0x02
//DOOR Detect
#define DOOR_CLOSE_VALUE                0x01
#define DOOR_OPEN_VALUE                 0x02
//Opcode Table
#define OPCODE_REMOTE_BTN_PRESS         0x01
#define OPCODE_PIR_REPORT               0x02
#define OPCODE_DOOR_SENSOR              0x03
#define OPCODE_PIR_BTN_PRESS            0x05
#define OPCODE_PC_COMM	            		0xB5
#define OPCODE_CFG_PC_COMM	            0xB6
#define OPCODE_CFG_TIME	            		0xB7
#define OPCODE_CFG_CHECKOUT	            0xB8

typedef enum{
	CFG_CMD_NEW_STATE,
	CFG_CMD_GET_OPCODE,
	CFG_CMD_GET_LENGTH,	
	CFG_CMD_GET_DATA,
	CFG_CMD_CRC_CHECK,
	CFG_CMD_WAITING_SATRT_CODE
}CFG_CMD_STATE_TYPE;

typedef struct
{
	CFG_CMD_STATE_TYPE state;
	uint8_t len;
	uint16_t lenMax;
	uint16_t cnt;
	uint8_t opcode;
	uint8_t crc;
} PARSER_PACKET_TYPE;

typedef struct
{
	uint8_t start;
	uint8_t length;
	uint8_t opcode;
	uint8_t *dataPt;
	uint8_t crc;
} CFG_PROTOCOL_TYPE;

extern RINGBUF rfParser_RxRingBuff;

void rfParserTask_Init(void);
void rfParserTask(void);
uint8_t CfgProcessData(CFG_PROTOCOL_TYPE *cfgProtoRecv,CFG_PROTOCOL_TYPE *cfgProtoSend,uint8_t *cfgSendDataBuff,uint32_t maxPacketSize,uint8_t logSendEnable);
#endif //__CC1101_PARSER_H
/*******************************************************************************
	*END FILE
********************************************************************************/
