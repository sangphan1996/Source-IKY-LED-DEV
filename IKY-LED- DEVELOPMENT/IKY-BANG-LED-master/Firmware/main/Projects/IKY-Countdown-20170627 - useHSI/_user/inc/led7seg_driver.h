#ifndef __LED7SEG_DRIVER_H
#define __LED7SEG_DRIVER_H
#include "stm32f10x.h"
#include <stdbool.h>
#include <stdio.h>
#include <stdint.h>

#define LED_7SEG_1_PIN             	GPIO_Pin_13
#define LED_7SEG_1_PORT            	GPIOB

#define LED_7SEG_3_PIN             	GPIO_Pin_14
#define LED_7SEG_3_PORT            	GPIOB

#define LED_7SEG_2_PIN             	GPIO_Pin_15
#define LED_7SEG_2_PORT            	GPIOB

#define LED_7SEG_4_PIN             	GPIO_Pin_15
#define LED_7SEG_4_PORT            	GPIOA

#define LED_7SEG_DAT_PIN						GPIO_Pin_3
#define LED_7SEG_DAT_PORT						GPIOB

#define LED_7SEG_CLK_PIN						GPIO_Pin_5
#define LED_7SEG_CLK_PORT						GPIOB

#define LED_7SEG_LATCH_PIN					GPIO_Pin_4
#define LED_7SEG_LATCH_PORT					GPIOB

#define LED7SEG_NUM									4

typedef struct {
    uint8_t buffer_1[64];
		uint8_t buffer_2[64];
		uint8_t dot_effect;
		uint8_t enable;
		uint8_t scan_index;
		uint8_t dram_1[64];
		uint8_t dram_2[64];
}LED7Seg_Typedef;

extern LED7Seg_Typedef LED7Seg;

void Led7Seg_Init(void);
void Led7Seg_Scan_Init(void);
void Led7Seg_WriteData(uint8_t Data);
void Led7Seg_WriteChar(uint8_t Data,uint8_t Dot);
void Led7Seg_Select(uint8_t Led);
void Led7Seg_Scan(void);
#endif
/*******************************************************************************
	*END FILE
********************************************************************************/
