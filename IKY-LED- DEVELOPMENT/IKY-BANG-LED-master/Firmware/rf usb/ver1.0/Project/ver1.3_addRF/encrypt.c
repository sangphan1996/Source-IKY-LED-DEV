/**
* \file
*         encrypt data
* \author
*         IKY Company
*/
#include "encrypt.h"

void Encode(uint8_t *data, uint8_t len)
{	
	uint8_t i;
	uint8_t posStart  = 0;
	uint8_t PosEnd = len - 1;
	//
	data[PosEnd] = data[PosEnd] + data[posStart];
	for (i = posStart; i < PosEnd - 1; i++) data[i] = data[i] - data[PosEnd];
	for (i = posStart + 1; i < PosEnd; i++) data[i] = data[i] - data[PosEnd] + data[posStart];
}

void Decode(uint8_t *data, uint8_t len)
{
	uint8_t i;
	uint8_t posStart = 0;
	uint8_t PosEnd = len - 1;
	//
	for (i = posStart + 1; i < PosEnd; i++) data[i] = data[i] + data[PosEnd] - data[posStart];
	for (i = posStart; i < PosEnd - 1; i++) data[i] = data[i] + data[PosEnd];
	data[PosEnd] = data[PosEnd] - data[posStart];
}


