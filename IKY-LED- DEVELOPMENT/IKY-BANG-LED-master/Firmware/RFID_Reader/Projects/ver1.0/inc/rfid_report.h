#ifndef __RFID_REPORT_H__
#define __RFID_REPORT_H__
#include "stm8s.h"

typedef struct
{
	uint8_t start;
	uint16_t length;
	uint8_t opcode;
	uint8_t *dataPt;
	uint8_t crc;
} REPORT_PROTOCOL_TYPE;

void rptTaskInit(void);
void rptCallback(uint8_t *data);
uint8_t rptCalcCheckSum(uint8_t *buff, uint32_t length);
#endif //__RFID_REPORT_H__

