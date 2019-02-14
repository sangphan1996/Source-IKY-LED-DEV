#ifndef __DISPLAY_TASK_H
#define __DISPLAY_TASK_H

#include "stm32f10x.h"
#include "framebuffer.h"
#include "sys_tick.h"

typedef enum{
	DISP_HOME = 0,
	DISP_COUNTDOWN,
	DISP_SETUP_ID,
	DISP_CHECKOUT,
	DISP_SELFTEST,
}DISPLAY_STATE_TYPE;

#define TIME_STEP_UP						10*60
#define TIME_STEP_DOWN					10*60


extern uint32_t TotalDuration;
extern uint32_t TimeLeft;
extern uint32_t TimeStart;

extern DISPLAY_STATE_TYPE displayState;
extern Timeout_Type tDispCheckOut;

void DisplayTask_Init(void);
void DisplayTask(void);

#endif //__DISPLAY_TASK_H

