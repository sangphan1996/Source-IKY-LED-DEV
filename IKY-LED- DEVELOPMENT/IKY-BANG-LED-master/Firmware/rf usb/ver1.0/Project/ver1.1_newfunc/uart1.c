/**
* \file
*         uart1 driver
* \author
*         IKY Company
*/
#include "uart1.h"

void Uart1_init(void)
{
    /* Enable USART clock */
  CLK_PeripheralClockConfig((CLK_Peripheral_TypeDef)CLK_Peripheral_USART1, ENABLE);

  /* Configure USART Tx as alternate function push-pull  (software pull up)*/
  GPIO_ExternalPullUpConfig(GPIOC, GPIO_Pin_5, ENABLE);

  /* Configure USART Rx as alternate function push-pull  (software pull up)*/
  GPIO_ExternalPullUpConfig(GPIOC, GPIO_Pin_6, ENABLE);

  USART_Init(USART1,
    (uint32_t)115200,
    USART_WordLength_8b,
    USART_StopBits_1,
    USART_Parity_No,
    (USART_Mode_TypeDef)(USART_Mode_Tx | USART_Mode_Rx));
  
  /* Enable general interrupts */
  enableInterrupts();
  
  USART_ITConfig(USART1,USART_IT_RXNE, ENABLE);
  USART_Cmd(USART1, ENABLE);
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
	while (USART_GetFlagStatus(USART1, USART_FLAG_TC) == RESET);
	USART_SendData8(USART1, ch);
#endif
	return (ch);
}

/*----------------------------------------------------------------------------
 * end of file
 *---------------------------------------------------------------------------*/




