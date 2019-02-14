#ifndef __LED7SEG_TASK_H
#define __LED7SEG_TASK_H
#include "stm32f10x.h"
#include "led7seg_driver.h"

typedef enum {
	LED7SEG_IDLE,
	LED7SEG_SETUP,	
	LED7SEG_SETUP_ID,
	LED7SEG_SELFTEST,
}LED7SEG_STATE_TYPE;

#define TIME_STEP_UP						10*60
#define TIME_STEP_DOWN					10*60


extern uint32_t TotalDuration;
extern uint32_t TimeLeft;
extern uint32_t TimeStart;

void TimeSecCountDown_Task(void);
void led7SegStateChange(LED7SEG_STATE_TYPE newState);
LED7SEG_STATE_TYPE led7SegStateGet(void);
void Led7SegTask_Init(void);
void Led7SegTask(void);
#endif //__LED7SEG_TASK_H
/*******************************************************************************
	*END FILE
********************************************************************************/
