#ifndef __USART1_H__
#define __USART1_H__
#include "stm8s.h"
#include "stdio.h"

void USART1_Init(void);
uint8_t USART1_PutChar (uint8_t ch);
void USART1_PutString (uint8_t *s);
uint32_t  DbgCfgPrintf(const uint8_t *format, ...);
void u8toHexAscii(uint8_t Value);
void u32toHexAscii(uint32_t Value);
void u16toHexAscii(uint16_t Value);
#endif

