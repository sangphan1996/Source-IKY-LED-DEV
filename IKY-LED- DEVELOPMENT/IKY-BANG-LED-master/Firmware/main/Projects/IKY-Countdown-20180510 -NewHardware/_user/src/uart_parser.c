#include "uart_parser.h"
#include "uart1.h"
#include <string.h>
#include "logger.h"
#include "uart1.h"
#include "uart3.h"

uint8_t IKY_gotDataFlag = 0;
uint8_t Greetings_gotDataFlag = 0;
uint8_t Time_gotDataFlag = 0;
uint8_t Ctr_gotDataFlag = 0;

#define UART_CMD_COUNT          (sizeof (UART_ProcessCmd) / sizeof (UART_ProcessCmd[0]))
#define UART_CMD_PARSER_SIZE     16


char buffIKY[UART_MSG_MAX_SIZE] = {0};
char GreetingsBuffer[UART_MSG_MAX_SIZE] = {0};
char TimeBuffer[20] = {0};
char CtrBuffer[UART_MSG_MAX_SIZE] = {0};

char Greetings_Process(char c);
char IKY_Process(char c);
char Time_Process(char c);
char Ctr_Process(char c);

void RfPacket_Prepare(uint8_t opcode,uint8_t *data,uint16_t length);
/* Command definitions structure. */
typedef struct _UART_PARSER_STRUCT {
   char cmdInfo[16];
   char (*func)(char c);
} UART_PARSER_STRUCT;

static const UART_PARSER_STRUCT UART_ProcessCmd[] = {
  "#LED,", IKY_Process,
  "#CFG,", Greetings_Process,
  "#TIME,", Time_Process,
  "#CTR,", Ctr_Process
};

uint8_t UART_cmdCnt[UART_CMD_COUNT];
uint8_t UART_numCmd;
uint16_t UART_cmdRecvLength;


enum{
	UART_CMD_NEW_STATE,
	UART_CMD_WAIT_FINISH,
	UART_CMD_FINISH
}UART_cmdState = UART_CMD_FINISH;

char Ctr_Process(char c)
{
  if(Ctr_gotDataFlag) return 0;
  switch(c)
  {
      case '*':
        Ctr_gotDataFlag = 1;
        return 0;
        
      default:
        break;
  }
  CtrBuffer[UART_cmdRecvLength] = c;
  CtrBuffer[UART_cmdRecvLength + 1] = 0;
  return 0xff;
}

char Time_Process(char c)
{
  if(Time_gotDataFlag) return 0;
  switch(c)
  {
      case '*':
        Time_gotDataFlag = 1;
        return 0;
        
      default:
        break;
  }
  TimeBuffer[UART_cmdRecvLength] = c;
  TimeBuffer[UART_cmdRecvLength + 1] = 0;
  return 0xff;
}

char Greetings_Process(char c)
{
  if(Greetings_gotDataFlag) return 0;
  switch(c)
  {
      case '*':
        Greetings_gotDataFlag = 1;
        return 0;
        
      default:
        break;
  }
  GreetingsBuffer[UART_cmdRecvLength] = c;
  GreetingsBuffer[UART_cmdRecvLength + 1] = 0;
  return 0xff;
}

char IKY_Process(char c)
{
  if(IKY_gotDataFlag) return 0;
	
  switch(c)
  {
      case '*':
        IKY_gotDataFlag = 1;
        return 0;
        
      default:
        break;
  }
  buffIKY[UART_cmdRecvLength] = c;
  buffIKY[UART_cmdRecvLength + 1] = 0;
  return 0xff;
}

void UART_ComnandParser(char c)
{
    uint32_t i;
//		NRF_LOG_PRINTF("%c",c);
    switch(UART_cmdState)
    {
        case UART_CMD_FINISH:
            for(i = 0; i < UART_CMD_COUNT;i++)
            {
              if(c == UART_ProcessCmd[i].cmdInfo[UART_cmdCnt[i]])
              {
                UART_cmdCnt[i]++;
                if(UART_ProcessCmd[i].cmdInfo[UART_cmdCnt[i]] == '\0')
                {
                  UART_numCmd = i;
                  UART_cmdState = UART_CMD_WAIT_FINISH;
                  UART_cmdRecvLength = 0;
                }
              }
              else
              {
                UART_cmdCnt[i] = 0;
              }
            }
            break;

    case UART_CMD_WAIT_FINISH:
      if(UART_ProcessCmd[UART_numCmd].func(c) == 0)
      {
        UART_cmdState = UART_CMD_FINISH;
        for(i = 0; i < UART_CMD_COUNT;i++)
        {
          UART_cmdCnt[i] = 0;
        }
      }
      UART_cmdRecvLength++;		
      if(UART_cmdRecvLength >= UART_MSG_MAX_SIZE)
      {
        UART_cmdState = UART_CMD_FINISH;
        for(i = 0; i < UART_CMD_COUNT;i++)
        {
          UART_cmdCnt[i] = 0;
        }
      }
      break;
      
    default:
      UART_cmdState = UART_CMD_FINISH;
      for(i = 0; i < UART_CMD_COUNT;i++)
      {
        UART_cmdCnt[i] = 0;
      }
      break;
    }	
}


uint8_t UART_GetInfo(void)
{
    if(IKY_gotDataFlag)
    {
				NRF_LOG_PRINTF(buffIKY);
				USART1_PutString(buffIKY);
        RfPacket_Prepare(0xB5,(uint8_t*)buffIKY,strlen(buffIKY));
        IKY_gotDataFlag = 0;
        return 1;
    }
    if(Greetings_gotDataFlag)
    {	
        RfPacket_Prepare(0xB6,(uint8_t*)GreetingsBuffer,strlen(GreetingsBuffer));
        Greetings_gotDataFlag = 0;
        return 1;
    }
    if(Time_gotDataFlag)
    {	
        NRF_LOG_PRINTF(TimeBuffer);
				USART1_PutString(TimeBuffer);
        RfPacket_Prepare(0xB7,(uint8_t*)TimeBuffer,strlen(TimeBuffer));
        Time_gotDataFlag = 0;
        return 1;
    }
    if(Ctr_gotDataFlag)
    {	
        NRF_LOG_PRINTF(CtrBuffer);
				USART1_PutString(CtrBuffer);
        RfPacket_Prepare(0xB8,(uint8_t*)CtrBuffer,strlen(CtrBuffer));
        Ctr_gotDataFlag = 0;
        return 1;
    }
    return 0;
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
  USART3_PutChar(0xCA );
  USART3_PutChar(opcode );
  USART3_PutChar(length);
  //
  for(i=0;i<length;i++)
  {    
    USART3_PutChar(data[i]);
  }
  //
  USART3_PutChar(CalcCheckSum(data,length));	
}

