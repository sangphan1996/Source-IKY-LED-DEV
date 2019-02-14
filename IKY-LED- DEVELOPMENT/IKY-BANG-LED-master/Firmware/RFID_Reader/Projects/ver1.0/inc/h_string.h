#ifndef __H_STRING__H__
#define __H_STRING__H__
#include "stm8s.h"

void h_memcpy(uint8_t * src, uint8_t *des, uint16_t size);
void h_memset(uint8_t * src, uint8_t var, uint16_t size);
uint8_t h_memcmp(uint8_t * src1, uint8_t *src2, uint16_t size);
#endif //__H_STRING__H__

