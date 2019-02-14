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

#define PACKET_MAX_LEN          16
#define RF_SEND_INTERVAL        50 
#define WAIT_GD0_TIMEOUT        30000 //1000 ~ 2ms
#define WAIT_SEND_TIMEOUT       60000 //1000 ~ 2ms
Rf_MSG_Typedef Rf_MSG; 

#ifdef TAG_ADMIN 
uint8_t Number_Code[7] = { 0xA5, 0xA5, 0xA5, 0xEE, 0xCC, 0xBB, 0xDD };
#else
uint8_t Number_Code[7] = { 0xA5, 0xA5, 0xA5, 0x11, 0x33, 0x36, 0x32 };
#endif
uint8_t rfPacketFIFO[64];
uint8_t rfPacketSendBuff[64];
uint8_t rfDataBuff[64];
RINGBUF rfTXRingBuff;
uint8_t __rfTXRingBuff[64];
uint8_t rfDataIncomingFlag = 0;
uint32_t tRfSendTimeout = 0;

void RfPacket_Init(void)
{
  uint8_t i;
  Rf_MSG.start = 0xCA;
  Rf_MSG.length = 0;
  Rf_MSG.dataPt = rfDataBuff;
  for(i=0;i<4;i++)
  {
    Rf_MSG.dataPt[i] = Number_Code[3 + i];
  }
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

void RfPacket_Prepare(Rf_MSG_Typedef *packet,uint8_t opcode,uint8_t *data,uint16_t length)
{
  uint8_t i;
  //
  packet->start = 0xCA;
  packet->opcode = opcode;
  packet->length = length + 4;
  //
  for(i=0;i<length;i++)
  {
    packet->dataPt[4+i] = data[i];
  }
  //
  packet->crc = CalcCheckSum(packet->dataPt,packet->length);	
}

uint16_t RfPack(Rf_MSG_Typedef *data,uint8_t *buff)
{
	uint16_t i = 0;
        uint16_t len = 0;
	if(data->length)
	{
		buff[len++] = (*(uint8_t *)&data->start);
		buff[len++] = (((uint8_t *)&data->length)[0]);
		buff[len++] = (((uint8_t *)&data->length)[1]);
		buff[len++] = (*(uint8_t *)&data->opcode);
		for(i = 0;i < data->length;i++)
			buff[len++] = (*(uint8_t *)&data->dataPt[i]);
		buff[len++] = (*(uint8_t *)&data->crc);
		data->length = 0;
	}
        return len;
}

void RfPacket_Send(void)
{
  uint8_t i = 0;
  uint16_t length;
  //
  length = RfPack(&Rf_MSG,rfPacketSendBuff);
  for(i=0;i<length;i++)
  {
    RINGBUF_Put(&rfTXRingBuff,rfPacketSendBuff[i]);
  }
}

uint8_t rfPacket_Send(uint8_t *buff,uint8_t length)
{
  uint32_t timeout = 0;
  uint8_t i = 0;
  // Length
  rfPacketFIFO[PACKET_TX_LENGTH_POSITION] = length + 1; // addr+len
  // RF Addr
  rfPacketFIFO[PACKET_TX_ADDR_POSITION] = RF_ADDRESS;
  // Counter
  for(i = 0; i < length; i++)
  {
    rfPacketFIFO[PACKET_TX_DATA_POSITION + i] = buff[i];
  }
  //printf("/* Force IDLE */\r\n");
  halRfStrobe(CC2500_SIDLE);
  Delay(1000);
  //printf("/* Write packet to transmit FIFO */\r\n");
  halRfWriteFifo(rfPacketFIFO, length + 2);
  //printf("/* Issue the TX strobe. */\r\n");
  halRfStrobe(CC2500_STX);
  //printf("/* Wait for transmit to complete 1*/\r\n");
  timeout = WAIT_GD0_TIMEOUT;
  while (!CC2500_GDO_0_STATUS && timeout){timeout--;};
  timeout = WAIT_GD0_TIMEOUT;
  while (CC2500_GDO_0_STATUS && timeout){timeout--;};  
  Delay(WAIT_SEND_TIMEOUT);
  halRfStrobe(CC2500_SIDLE);
  return 1;
}

void rfSend_Task(void)
{
  uint8_t c;
  uint8_t i;
  if(SysTick_Get() - tRfSendTimeout < RF_SEND_INTERVAL) return;
  tRfSendTimeout = SysTick_Get();
  //
  if(RINGBUF_GetFill(&rfTXRingBuff) > 0){
    LED_On();
    for(i=0;i<PACKET_MAX_LEN;i++)
    {
      if(RINGBUF_Get(&rfTXRingBuff,&c) == 0)
        rfPacketSendBuff[i] = c;
      else 
        break;
    }
    rfPacket_Send(rfPacketSendBuff,i);
    LED_Off();    
  }
}
/*****END OF FILE****/
