#ifndef __CC1101_RECEIVER_H
#define __CC1101_RECEIVER_H
#include <stdbool.h>
#include <stdio.h>
#include <stdint.h>
#include "cc1101.h"

extern uint8_t rfDataIncomingFlag;

typedef struct{
	uint8_t start;
	uint8_t opcode;
	uint8_t length;
	uint8_t *dataPt;
	uint8_t crc;
}TAG_PACKET_TYPE;

void RfRecive_Task(void);
#endif //__CC1101_RECEIVER_H
/*******************************************************************************
	*END FILE
********************************************************************************/
