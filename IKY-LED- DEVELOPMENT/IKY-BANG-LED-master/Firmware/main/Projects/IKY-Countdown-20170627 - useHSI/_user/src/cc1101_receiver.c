#include "stm32f10x.h"
#include "cc1101_receiver.h"
#include "logger.h"
#include "led7seg_task.h"
#include "cc1101_parser.h"
#include "sys_tick.h"

#define RF_RECV_DBG(...)  		NRF_LOG_PRINTF(__VA_ARGS__)

#define RF_FIFO_MAX_LEN			64

enum{
	RF_RECEIVE_IDLE = 0,
	RF_RECEIVE_READ_FIFO,
	RF_RECEIVE_PARSER,
	RF_RECEIVE_FINISH
}RF_Receive_Phase = RF_RECEIVE_IDLE;

uint32_t receiveTick = 0;
uint8_t rfDataIncomingFlag = 0;
uint16_t rfPacketLength = 0;
uint8_t rfRxBuffer[RF_FIFO_MAX_LEN];
uint8_t rfStatus[2];
Timeout_Type tRadioTimeout;

void RfRecive_Task(void)
{
	uint8_t i;
	switch (RF_Receive_Phase)
	{
	case RF_RECEIVE_IDLE:
		if (rfDataIncomingFlag)
		{
			receiveTick = SysTick_Get();
			rfDataIncomingFlag = 0;
			RF_Receive_Phase = RF_RECEIVE_READ_FIFO;
		}
		else if ((SysTick_Get() - receiveTick) > 5000)
		{
			receiveTick = SysTick_Get();
			RF_Receive_Phase = RF_RECEIVE_READ_FIFO;
		}
		break;

	case RF_RECEIVE_READ_FIFO:
		if (CC1101_ReadStatusReg(CC1101_RXBYTES) == 0)
		{
			RF_Receive_Phase = RF_RECEIVE_FINISH;
			break;
		}
		rfPacketLength = CC1101_ReadReg(CC1101_RXFIFO);
		if (rfPacketLength == 0 || rfPacketLength > RF_FIFO_MAX_LEN)
		{
			CC1101_Strobe(CC2500_SIDLE);
			CC1101_Strobe(CC2500_SFRX);
			CC1101_Strobe(CC2500_SRX);
			RF_Receive_Phase = RF_RECEIVE_IDLE;
			break;
		}
		CC1101_ReadFifo(rfRxBuffer, rfPacketLength);
		CC1101_ReadFifo(rfStatus, 2);

		RF_Receive_Phase = RF_RECEIVE_PARSER;
		break;

	case RF_RECEIVE_PARSER:
		RF_RECV_DBG("rfPacketLength %d\r\n",rfPacketLength);
		for(i=1;i<rfPacketLength;i++)
		{
			RINGBUF_Put(&rfParser_RxRingBuff,rfRxBuffer[i]);RF_RECV_DBG("%02x",rfRxBuffer[i]);
		}
		RF_RECV_DBG("\r\n");
		RF_Receive_Phase = RF_RECEIVE_FINISH;
		break;

	case RF_RECEIVE_FINISH:
		CC1101_Strobe(CC2500_SIDLE);
		CC1101_Strobe(CC2500_SRX);
		RF_Receive_Phase = RF_RECEIVE_IDLE;
		break;

	default:
		RF_Receive_Phase = RF_RECEIVE_IDLE;
		break;
	}
}
