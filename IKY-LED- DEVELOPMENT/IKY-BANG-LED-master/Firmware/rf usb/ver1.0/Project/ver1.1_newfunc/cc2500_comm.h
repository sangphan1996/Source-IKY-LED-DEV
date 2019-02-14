#ifndef __CC2500_COMM_H__
#define __CC2500_COMM_H__
#include "stm8l15x.h"
#include "cc2500_spi.h"

// Strobe commands
#define CC2500_SRES             0x30        // Reset chip.

// Function
void CC2500_Comm_Init(void);
void CC2500_Comm_DeInit(void);
uint8_t halSpiWriteByte(uint8_t Data);
#endif //__CC2500_COMM_H__

