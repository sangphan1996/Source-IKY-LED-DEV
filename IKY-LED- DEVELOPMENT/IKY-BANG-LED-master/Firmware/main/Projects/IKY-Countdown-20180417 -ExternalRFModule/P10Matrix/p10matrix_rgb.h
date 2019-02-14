

#ifndef P10_MATRIX_RGB_H_
#define P10_MATRIX_RGB_H_
#include <stdint.h>

void p10RGB_begin(void);



//Private
void p10RGB_SelCh(uint8_t ch);
void p10RGB_DispOn(void);
void p10RGB_DispOff(void);
void p10RGB_Latch(void);
void p10RGB_Write(uint8_t data, uint8_t line);
void p10RGB_Pulse(void);
#endif /* P10_MATRIX_RGB_H_ */
