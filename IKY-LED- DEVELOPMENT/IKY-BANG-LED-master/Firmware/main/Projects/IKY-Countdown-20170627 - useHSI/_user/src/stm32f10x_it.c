#include "stm32f10x_it.h"
#include "logger.h"
#include "logger.h"
#include "sys_tick.h"
#include "hw_config.h"
#include "matrix_driver.h"


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
  * @brief  This function handles Memory Manage exception.
  * @param  None
  * @retval None
  */
void MemManage_Handler(void)
{
  /* Go to infinite loop when Memory Manage exception occurs */
  while (1)
  {
  }
}

/**
  * @brief  This function handles Bus Fault exception.
  * @param  None
  * @retval None
  */
void BusFault_Handler(void)
{
  /* Go to infinite loop when Bus Fault exception occurs */
  while (1)
  {
  }
}

/**
  * @brief  This function handles Usage Fault exception.
  * @param  None
  * @retval None
  */
void UsageFault_Handler(void)
{
  /* Go to infinite loop when Usage Fault exception occurs */
  while (1)
  {
  }
}

/**
  * @brief  This function handles SVCall exception.
  * @param  None
  * @retval None
  */
void SVC_Handler(void)
{
}

/**
  * @brief  This function handles Debug Monitor exception.
  * @param  None
  * @retval None
  */
void DebugMon_Handler(void)
{
}

/**
  * @brief  This function handles PendSV_Handler exception.
  * @param  None
  * @retval None
  */
void PendSV_Handler(void)
{
}

/**
  * @brief  This function handles SysTick Handler.
  * @param  None
  * @retval None
  */
void SysTick_Handler(void)
{
	SysTick_Task();
	MaTrix_ColPos_Callback();
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
		rfDataIncomingFlag = 1;
		EXTI_ClearITPendingBit(EXTI_Line3);
	}
}

/******************* (C) COPYRIGHT 2011 STMicroelectronics *****END OF FILE****/
