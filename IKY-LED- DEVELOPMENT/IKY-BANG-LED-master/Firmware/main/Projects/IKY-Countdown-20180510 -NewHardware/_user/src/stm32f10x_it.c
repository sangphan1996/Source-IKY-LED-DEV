#include "stm32f10x_it.h"
#include "logger.h"
#include "logger.h"
#include "sys_tick.h"
#include "hw_config.h"

extern uint8_t rfDataIncomingFlag;
/**
  * @brief  This function handles Hard Fault exception.
  * @param  None
  * @retval None
  */
void HardFault_Handler(void)
{
  NVIC_SystemReset();
	while(1);
}

/**
  * @brief  This function handles SysTick Handler.
  * @param  None
  * @retval None
  */
void SysTick_Handler(void)
{
	SysTick_Task();
	TM_BUTTON_Update(&TM_Button_1);
}


/**
  * @brief  This function handles External interrupt Line 3 request.
  * @param  None
  * @retval None
  */
void EXTI3_IRQHandler(void)
{
	if(EXTI_GetITStatus(EXTI_Line3) != RESET)
	{
//		rfDataIncomingFlag = 1;
		EXTI_ClearITPendingBit(EXTI_Line3);
	}
}

/******************* (C) COPYRIGHT 2011 STMicroelectronics *****END OF FILE****/
