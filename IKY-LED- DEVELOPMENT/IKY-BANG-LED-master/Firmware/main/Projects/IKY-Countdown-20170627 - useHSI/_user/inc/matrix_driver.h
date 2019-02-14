#ifndef __MATRIX_DRIVER_H
#define __MATRIX_DRIVER_H
#include <stdbool.h>
#include <stdio.h>
#include <stdint.h>

#define MATRIX_CELL_ON						0

#define MATRIX_STRING_MAX_LEN			64
#define MATRIX_8x8_NUM						6
#define WIDTH_OF_FONT							6
#define	GFX_STRING_SPACING				"     "
//
#define LED_MATRIX_ROW_DAT_PIN						GPIO_Pin_7
#define LED_MATRIX_ROW_DAT_PORT						GPIOB

#define LED_MATRIX_ROW_CLK_PIN						GPIO_Pin_0
#define LED_MATRIX_ROW_CLK_PORT						GPIOA

#define LED_MATRIX_ROW_LATCH_PIN         	GPIO_Pin_9
#define LED_MATRIX_ROW_LATCH_PORT        	GPIOB

#define LED_MATRIX_ROW_RESET_PIN         	GPIO_Pin_0
#define LED_MATRIX_ROW_RESET_PORT        	GPIOB
//
#define LED_MATRIX_COL_DAT_PIN						GPIO_Pin_1
#define LED_MATRIX_COL_DAT_PORT						GPIOA

#define LED_MATRIX_COL_CLK_PIN						GPIO_Pin_1
#define LED_MATRIX_COL_CLK_PORT						GPIOB

#define LED_MATRIX_COL_LATCH_PIN         	GPIO_Pin_6
#define LED_MATRIX_COL_LATCH_PORT        	GPIOB

#define LED_MATRIX_COL_RESET_PIN         	GPIO_Pin_8
#define LED_MATRIX_COL_RESET_PORT        	GPIOB

typedef struct {
    uint8_t buffer_1[64];
		uint8_t buffer_2[64];
		uint8_t effect;
		uint16_t strlen;
		uint8_t enable;
		uint16_t column_pos;
		uint32_t column_shift;
		uint8_t dram_1[64];
		uint8_t dram_2[64];
}LEDMatrix_Typedef;

extern LEDMatrix_Typedef LEDMatrix;

void MaTrix_IOInit(void);
void MaTrix_StringUpdate(uint8_t * newString,uint8_t len);
void MaTrix_WriteData(uint8_t Data,uint8_t Line);
void MaTrix_SelectRow(uint8_t Row);

void MaTrix_Row_WriteData(uint8_t Data);
void MaTrix_Column_Select(uint8_t Row);
void MaTrix_VRam_Update(void);
void MaTrix_Task(void);
void MaTrix_Scan(void);
void MaTrix_ColPos_Callback(void);
#endif
/*******************************************************************************
	*END FILE
********************************************************************************/
