
#include "rfid_report.h"
#include "uart1.h"

REPORT_PROTOCOL_TYPE rptProtoSend;
uint8_t rptBuffSend[16];

void rptTaskInit(void)
{		
	rptProtoSend.length = 0;
	rptProtoSend.start = 0xCA;
        rptProtoSend.opcode = 0x90;        
	rptProtoSend.dataPt = rptBuffSend;
}

void rptSendData(REPORT_PROTOCOL_TYPE *data)
{
	uint16_t i;
	if(data->length)
	{
		USART1_PutChar(data->start);
		USART1_PutChar(((uint8_t *)&data->length)[1]);
		USART1_PutChar(((uint8_t *)&data->length)[0]);
		USART1_PutChar(data->opcode);
		for(i = 0;i < data->length;i++)
			USART1_PutChar(data->dataPt[i]);
		USART1_PutChar(data->crc);
		data->length = 0;
	}
}


void rptCallback(uint8_t *data)
{
        uint8_t i;
        rptProtoSend.length = 5;
        for(i=0;i<rptProtoSend.length;i++)
        {
                rptProtoSend.dataPt[i] = data[i];                 
        }
        rptProtoSend.crc = rptCalcCheckSum(rptProtoSend.dataPt,rptProtoSend.length);
        rptSendData(&rptProtoSend);
}

uint8_t rptCalcCheckSum(uint8_t *buff, uint32_t length)
{
	uint32_t i;
	uint8_t crc = 0;
	for(i = 0;i < length; i++)
	{
		crc += buff[i];
	}
	return crc;
}

/*----------------------------------------------------------------------------
 * end of file
 *---------------------------------------------------------------------------*/




