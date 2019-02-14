
#include "exti.h"



void EXTI_Config(void)
{
	AFIO->EXTICR[0] &= ~AFIO_EXTICR1_EXTI0;   // clear used pin
	AFIO->EXTICR[1] &= ~AFIO_EXTICR1_EXTI1;   // clear used pin
	AFIO->EXTICR[2] &= ~AFIO_EXTICR1_EXTI2;   // clear used pin
	AFIO->EXTICR[3] &= ~AFIO_EXTICR1_EXTI3;    // clear used pin


	/*Use PA10 is Radio INT*/
	EXTI->PR = EXTI_Line10;
	AFIO->EXTICR[2] |= AFIO_EXTICR3_EXTI10_PA;           // set pin to use
	EXTI->IMR       &= ~EXTI_Line10;             // mask interrupt
	EXTI->EMR       &= ~EXTI_Line10;             // mask event
	EXTI->IMR       |= 	EXTI_Line10;             // mask interrupt
	EXTI->EMR       |= EXTI_Line10;             // mask event
	EXTI->RTSR      |= EXTI_Line10;            	// set rising edge
	EXTI->FTSR      |= EXTI_Line10;            // set falling edge
	/* preemption = RADIO_PRIORITY, sub-priority = 1 */
	NVIC_SetPriority(EXTI15_10_IRQn, ((0x01<<3)| 3));
	NVIC_EnableIRQ(EXTI15_10_IRQn);
	
//	/*Use PA8 is Radio INT*/
//	EXTI->PR = EXTI_Line8;
//	AFIO->EXTICR[2] |= AFIO_EXTICR3_EXTI8_PA;           // set pin to use
//	EXTI->IMR       &= ~EXTI_Line8;             // mask interrupt
//	EXTI->EMR       &= ~EXTI_Line8;             // mask event
//	EXTI->IMR       |= 	EXTI_Line8;             // mask interrupt
//	EXTI->EMR       |= EXTI_Line8;             // mask event
//	EXTI->RTSR      |= EXTI_Line8;            	// set rising edge
//	EXTI->FTSR      |= EXTI_Line8;            // set falling edge
//	/* preemption = RADIO_PRIORITY, sub-priority = 1 */
//	NVIC_SetPriority(EXTI9_5_IRQn, ((0x01<<3)| 3));
//	NVIC_EnableIRQ(EXTI9_5_IRQn);
}

void EXTI9_5_IRQHandler(void)
{	
//	uint16_t cnt;
//	uint8_t state;
	if(EXTI_GetITStatus(EXTI_Line8) != RESET)	
	{
//		cnt = TIM_GetCounter(TIM4);
//		state = GPIO_ReadInputDataBit(GPIOA,GPIO_Pin_8);
//		receive_rf_packet_callback(cnt);
//		receive_rf_china_packet_callback(cnt,state);
//		TIM_SetCounter(TIM4,0x0000);		
		EXTI_ClearITPendingBit(EXTI_Line8);
	}
}

void EXTI15_10_IRQHandler(void)
{	
//	uint16_t cnt;
//	uint16_t state;
	if(EXTI_GetITStatus(EXTI_Line10) != RESET)	
	{
//		cnt = TIM_GetCounter(TIM4);
//		state = GPIO_ReadInputDataBit(GPIOA,GPIO_Pin_10);
//		receive_rf_china_packet_callback(cnt,state);
//		TIM_SetCounter(TIM4,0x0000);
		EXTI_ClearITPendingBit(EXTI_Line10);
	}
}

