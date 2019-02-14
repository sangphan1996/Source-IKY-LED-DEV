
#ifndef __LOGGER_H
#define __LOGGER_H
#include "stm32f10x.h"
#include "../stm32_lib/uart1.h"
#include "rtt_log.h"

uint32_t  DbgCfgPrintf(const uint8_t *format, ...);

#endif //__LOGGER_H

