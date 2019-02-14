#ifndef __USART1_H__
#define __USART1_H__
#include "stm8l15x.h"

void Uart1_init(void);
uint8_t USART1_PutChar (uint8_t ch);
void USART1_PutString (uint8_t *s);

#endif

