#ifndef _UART_PARSER_H_
#define _UART_PARSER_H_

#include "stm8l15x.h"

#define UART_MSG_MAX_SIZE        80

extern char buffIKY[UART_MSG_MAX_SIZE];

void UART_ComnandParser(char c);
uint8_t UART_GetInfo(void);
#endif /* _UART_PARSER_H_ */
