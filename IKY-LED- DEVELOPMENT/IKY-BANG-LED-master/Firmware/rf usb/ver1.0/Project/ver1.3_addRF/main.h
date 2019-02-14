#ifndef __MAIN_H
#define __MAIN_H
/* Includes ------------------------------------------------------------------*/
#include "stm8l15x.h"


// LED
#define LED_PORT                GPIOB
#define LED_PIN                 GPIO_Pin_3
#define LED_On()                GPIO_SetBits(LED_PORT, LED_PIN)
#define LED_Off()               GPIO_ResetBits(LED_PORT, LED_PIN)
#define LED_Init()              GPIO_Init(LED_PORT, LED_PIN, GPIO_Mode_Out_PP_Low_Fast)
#define LED_DeInit()            GPIO_Init(LED_PORT, LED_PIN, GPIO_Mode_Out_PP_Low_Slow)
//

#endif /* __MAIN_H */

/*****END OF FILE****/