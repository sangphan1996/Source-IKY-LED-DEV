#ifndef __HW_CONFIG_H
#define __HW_CONFIG_H
#include <stdbool.h>
#include <stdio.h>
#include <stdint.h>
#include "../stm32_lib/button.h"
#include "../stm32_lib/uart1.h"
#include "../stm32_lib/exti.h"

#define BUTTON_1_PIN							GPIO_Pin_8
#define BUTTON_1_PORT            	GPIOA

void hw_config(void);
#endif //__HW_CONFIG_H
/*******************************************************************************
	*END FILE
********************************************************************************/
