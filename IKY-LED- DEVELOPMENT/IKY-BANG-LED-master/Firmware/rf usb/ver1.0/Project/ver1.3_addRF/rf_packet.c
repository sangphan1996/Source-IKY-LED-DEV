/**
* \file
*         CC2500 communication
* \author
*         IKY Company
*/
#include "rf_packet.h"
#include "main.h"
#include <stdio.h>
#include "ringbuf.h"
#include "sys_tick.h"
#include "softuart.h"


RINGBUF rfTXRingBuff;
uint8_t __rfTXRingBuff[64];

void RfPacket_Init(void)
{
  RINGBUF_Init(&rfTXRingBuff,__rfTXRingBuff,sizeof(__rfTXRingBuff));
}

uint8_t CalcCheckSum(uint8_t *buff, uint32_t length)
{
	uint32_t i;
	uint8_t crc = 0;
	for(i = 0;i < length; i++)
	{
		crc += buff[i];
	}
	return crc;
}

void RfPacket_Prepare(uint8_t opcode,uint8_t *data,uint16_t length)
{
  uint8_t i;  
  //
  softuart_putchar(&softuart1, 0xCA );
  softuart_putchar(&softuart1, opcode );
  softuart_putchar(&softuart1, length);
  //
  for(i=0;i<length;i++)
  {    
    softuart_putchar(&softuart1, data[i]);
  }
  //
  softuart_putchar(&softuart1, CalcCheckSum(data,length));	
}

/*****END OF FILE****/
