/**
* \file
*         uart1 driver
* \author
*         IKY Company
*/
#include "uart1.h"
#include <stdarg.h>
#include "stdio.h"

#ifdef _RAISONANCE_
#define PUTCHAR_PROTOTYPE int putchar (char c)
#define GETCHAR_PROTOTYPE int getchar (void)
#elif defined (_COSMIC_)
#define PUTCHAR_PROTOTYPE char putchar (char c)
#define GETCHAR_PROTOTYPE char getchar (void)
#else /* _IAR_ */
#define PUTCHAR_PROTOTYPE int putchar (int c)
#define GETCHAR_PROTOTYPE int getchar (void)
#endif /* _RAISONANCE_ */

void USART1_Init(void) 
{
#ifdef DEBUG_MODE
  UART1_Init((uint32_t)115200,
		UART1_WORDLENGTH_8D,
		UART1_STOPBITS_1,
		UART1_PARITY_NO,
		UART1_SYNCMODE_CLOCK_DISABLE,
		UART1_MODE_TX_ENABLE);
#endif
}

void USART1_PutString (uint8_t *s) 
{
#ifdef DEBUG_MODE
   while(*s){
		USART1_PutChar(*s++);
	}
#endif
}
   
uint8_t USART1_PutChar (uint8_t ch) 
{
#ifdef DEBUG_MODE
	while (UART1_GetFlagStatus(UART1_FLAG_TXE) == RESET);
	UART1_SendData8(ch);
#endif
	return (ch);
}

/**
  * @brief Retargets the C library printf function to the UART.
  * @param c Character to send
  * @retval char Character sent
  */
PUTCHAR_PROTOTYPE
{
  /* Write a character to the UART1 */
  USART1_PutChar(c);
  return (c);
}       
        
void u8toHexAscii(uint8_t Value)
{
	USART1_PutChar(((Value >> 4) & 0x0F) < 0x0A ? (((Value >> 4) & 0x0F) + '0') : (((Value >> 4) & 0x0F) + 'A' - 0x0A));
	USART1_PutChar(((Value) & 0x0F) < 0x0A ? ((Value & 0x0F) + '0') : ((Value & 0x0F) + 'A' - 0x0A));
}

void u32toHexAscii(uint32_t Value)
{
	uint8_t *u8pt;
	u8pt = (uint8_t*)&Value;
	u8toHexAscii(u8pt[0]);
	u8toHexAscii(u8pt[1]);
	u8toHexAscii(u8pt[2]);
	u8toHexAscii(u8pt[3]);
}

void u16toHexAscii(uint16_t Value)
{
	uint8_t *u8pt;
	u8pt = (uint8_t*)&Value;
	u8toHexAscii(u8pt[0]);
	u8toHexAscii(u8pt[1]);
}
/*----------------------------------------------------------------------------
 * end of file
 *---------------------------------------------------------------------------*/




