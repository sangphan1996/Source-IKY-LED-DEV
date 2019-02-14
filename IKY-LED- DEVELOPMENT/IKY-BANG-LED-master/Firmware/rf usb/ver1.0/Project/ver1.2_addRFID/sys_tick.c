/**
* \file
*         tick driver
* \author
*         IKY Company
*/

#include "sys_tick.h"
#include "stm8l15x_tim4.h"

#define TIM4_PERIOD       155

volatile uint32_t sysTickCounter32 = 0;


void SysTick_Init(uint32_t timeMs) 
{
  /* TIM4 configuration:
   - TIM4CLK is set to 16 MHz, the TIM4 Prescaler is equal to 128 so the TIM1 counter
   clock used is 16 MHz / 128 = 125 000 Hz
  - With 125 000 Hz we can generate time base:
      max time base is 2.048 ms if TIM4_PERIOD = 255 --> (255 + 1) / 125000 = 2.048 ms
      min time base is 0.016 ms if TIM4_PERIOD = 1   --> (  1 + 1) / 125000 = 0.016 ms
  - In this example we need to generate a time base equal to 1 ms
   so TIM4_PERIOD = (0.001 * 125000 - 1) = 124 */
  /* Enable TIM4 CLK */
  CLK_PeripheralClockConfig(CLK_Peripheral_TIM4, ENABLE);
  /* Time base configuration */
  TIM4_TimeBaseInit(TIM4_Prescaler_1024, TIM4_PERIOD); //10ms
  /* Clear TIM4 update flag */
  TIM4_ClearFlag(TIM4_FLAG_Update);
  /* Enable update interrupt */
  TIM4_ITConfig(TIM4_IT_Update, ENABLE);
  /* enable interrupts */
  enableInterrupts();
  /* Enable TIM4 */
  TIM4_Cmd(ENABLE);
}

void SysTick_Task(void)
{
  sysTickCounter32++;
}

uint32_t SysTick_Get(void)
{
  return sysTickCounter32;
}

void SysTick_DelayMs(uint32_t ms)
{
   	uint32_t currentTicks = SysTick_Get();
		while(SysTick_Get()- currentTicks < ms);
}

