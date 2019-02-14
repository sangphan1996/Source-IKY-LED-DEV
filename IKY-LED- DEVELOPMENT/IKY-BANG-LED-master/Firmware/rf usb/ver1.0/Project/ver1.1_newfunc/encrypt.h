#ifndef __ENCRYPT_H__
#define __ENCRYPT_H__
#include "stm8l15x.h"

void Encode(uint8_t *data, uint8_t len);
void Decode(uint8_t *data, uint8_t len);

#endif //__ENCRYPT_H__

