#include "stm32f10x.h"
#include "hw_config.h"
#include "logger.h"

extern void p10RGB_Scan(void);
extern void p10_Scan(void);

void hwPinModeOutput(GPIO_TypeDef* port,uint16_t pin)
{
	GPIO_InitTypeDef GPIO_InitStructure;
	
	GPIO_InitStructure.GPIO_Pin = pin;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(port, &GPIO_InitStructure );	
}

void TIM3_IRQHandler(void)
{
	if (TIM_GetITStatus(TIM3, TIM_IT_Update) != RESET)
	{	
		TIM_ClearITPendingBit(TIM3, TIM_IT_Update);
		p10RGB_Scan();
	}
}

