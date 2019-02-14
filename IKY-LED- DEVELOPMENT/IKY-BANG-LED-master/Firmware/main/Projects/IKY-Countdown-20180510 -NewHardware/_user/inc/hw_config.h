#ifndef __HW_CONFIG_H
#define __HW_CONFIG_H
#include <stdbool.h>
#include <stdio.h>
#include <stdint.h>
#include "button.h"
#include "uart1.h"
#include "exti.h"

#define BUTTON_1_PIN							GPIO_Pin_11
#define BUTTON_1_PORT            	GPIOA

#define RFID_EN_PIN								GPIO_Pin_2
#define RFID_EN_PORT            	GPIOA

//------------------->HUB75 Pinout
// control
#define HUB75_OE_PIN									GPIO_Pin_12
#define HUB75_OE_PORT            			GPIOB

#define HUB75_CLK_PIN									GPIO_Pin_13
#define HUB75_CLK_PORT            		GPIOB

#define HUB75_LAT_PIN									GPIO_Pin_14
#define HUB75_LAT_PORT            		GPIOB

// select
#define HUB75_A_PIN										GPIO_Pin_3
#define HUB75_A_PORT            			GPIOB

#define HUB75_B_PIN										GPIO_Pin_15
#define HUB75_B_PORT            			GPIOA

#define HUB75_C_PIN										GPIO_Pin_8
#define HUB75_C_PORT            			GPIOA

//#define HUB75_D_PIN										GPIO_Pin_15
//#define HUB75_D_PORT            			GPIOB

// color
#define HUB75_R1_PIN									GPIO_Pin_9
#define HUB75_R1_PORT            			GPIOB

#define HUB75_G1_PIN									GPIO_Pin_8
#define HUB75_G1_PORT            			GPIOB

#define HUB75_B1_PIN									GPIO_Pin_7
#define HUB75_B1_PORT            			GPIOB

#define HUB75_R2_PIN									GPIO_Pin_6
#define HUB75_R2_PORT            			GPIOB

#define HUB75_G2_PIN									GPIO_Pin_5
#define HUB75_G2_PORT            			GPIOB

#define HUB75_B2_PIN									GPIO_Pin_4
#define HUB75_B2_PORT            			GPIOB

//// control
//#define HUB75_OE_PIN									GPIO_Pin_15
//#define HUB75_OE_PORT            		GPIOA

//#define HUB75_CLK_PIN								GPIO_Pin_14
//#define HUB75_CLK_PORT            		GPIOB

//#define HUB75_LAT_PIN								GPIO_Pin_3
//#define HUB75_LAT_PORT            		GPIOB

//// select
//#define HUB75_A_PIN									GPIO_Pin_13
//#define HUB75_A_PORT            			GPIOB

//#define HUB75_B_PIN									GPIO_Pin_1
//#define HUB75_B_PORT            			GPIOB

//#define HUB75_C_PIN									GPIO_Pin_15
//#define HUB75_C_PORT            			GPIOB

//#define HUB75_D_PIN									GPIO_Pin_4
//#define HUB75_D_PORT            			GPIOB

//// color
//#define HUB75_R1_PIN									GPIO_Pin_0
//#define HUB75_R1_PORT            		GPIOA

//#define HUB75_G1_PIN									GPIO_Pin_8
//#define HUB75_G1_PORT            		GPIOB

//#define HUB75_B1_PIN									GPIO_Pin_7
//#define HUB75_B1_PORT            		GPIOB

//#define HUB75_R2_PIN									GPIO_Pin_9
//#define HUB75_R2_PORT            		GPIOB

//#define HUB75_G2_PIN									GPIO_Pin_6
//#define HUB75_G2_PORT            		GPIOB

//#define HUB75_B2_PIN									GPIO_Pin_1
//#define HUB75_B2_PORT            		GPIOA

//<------------------HUB75 Pinout

//// control
//#define P5_OE_PIN									GPIO_Pin_15
//#define P5_OE_PORT            		GPIOA

//#define P5_CLK_PIN								GPIO_Pin_14
//#define P5_CLK_PORT            		GPIOB

//#define P5_LAT_PIN								GPIO_Pin_3
//#define P5_LAT_PORT            		GPIOB

//// select
//#define P5_A_PIN									GPIO_Pin_13
//#define P5_A_PORT            			GPIOB

//#define P5_B_PIN									GPIO_Pin_1
//#define P5_B_PORT            			GPIOB

//#define P5_C_PIN									GPIO_Pin_15
//#define P5_C_PORT            			GPIOB

//#define P5_D_PIN									GPIO_Pin_4
//#define P5_D_PORT            			GPIOB

//// color
//#define P5_R1_PIN									GPIO_Pin_0
//#define P5_R1_PORT            		GPIOA

//#define P5_G1_PIN									GPIO_Pin_8
//#define P5_G1_PORT            		GPIOB

//#define P5_B1_PIN									GPIO_Pin_7
//#define P5_B1_PORT            		GPIOB

//#define P5_R2_PIN									GPIO_Pin_9
//#define P5_R2_PORT            		GPIOB

//#define P5_G2_PIN									GPIO_Pin_6
//#define P5_G2_PORT            		GPIOB

//#define P5_B2_PIN									GPIO_Pin_1
//#define P5_B2_PORT            		GPIOA

//------------------->P10 Pinout

#define P10_OE_PIN								GPIO_Pin_9
#define P10_OE_PORT            		GPIOB

#define P10_A_PIN									GPIO_Pin_8
#define P10_A_PORT            		GPIOB

#define P10_B_PIN									GPIO_Pin_7
#define P10_B_PORT            		GPIOB

#define P10_SHIFT_PIN							GPIO_Pin_13
#define P10_SHIFT_PORT            GPIOB

#define P10_STORE_PIN							GPIO_Pin_15
#define P10_STORE_PORT            GPIOA

#define P10_DATA_PIN							GPIO_Pin_15
#define P10_DATA_PORT            	GPIOB

//#define P10_OE_PIN								GPIO_Pin_13
//#define P10_OE_PORT            		GPIOB

//#define P10_A_PIN									GPIO_Pin_3
//#define P10_A_PORT            		GPIOB

//#define P10_B_PIN									GPIO_Pin_4
//#define P10_B_PORT            		GPIOB

//#define P10_SHIFT_PIN							GPIO_Pin_15
//#define P10_SHIFT_PORT            GPIOA

//#define P10_STORE_PIN							GPIO_Pin_14
//#define P10_STORE_PORT            GPIOB

//#define P10_DATA_PIN							GPIO_Pin_15
//#define P10_DATA_PORT            	GPIOB

//<------------------P10 Pinout
void hwPinModeOutput(GPIO_TypeDef* port,uint16_t pin);
void hw_config(void);
#endif //__HW_CONFIG_H
/*******************************************************************************
	*END FILE
********************************************************************************/
