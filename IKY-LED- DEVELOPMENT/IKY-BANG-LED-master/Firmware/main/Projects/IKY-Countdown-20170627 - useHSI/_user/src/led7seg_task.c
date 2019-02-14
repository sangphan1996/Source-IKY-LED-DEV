#include "led7seg_task.h"
#include "rtc.h" 
#include "sys_tick.h"
#include "logger.h"
#include "system_config.h"

#define LED7SEG_Info(...)  		//DbgCfgPrintf(__VA_ARGS__)

#define LED7SEG_LIN_1				0

#define LED7SEG_TIME_DISPLAY_SHORT		SYSTICK_TIME_MS(200)
#define LED7SEG_TIME_DISPLAY_NORMAL		SYSTICK_TIME_MS(500)
#define LED7SEG_TIME_DISPLAY_LONG			SYSTICK_TIME_MS(1000)
#define LED7SEG_REFRESH_INTERVAL_1S		SYSTICK_TIME_MS(1000)

LED7SEG_STATE_TYPE led7SegState = LED7SEG_IDLE;
Timeout_Type tLed7SegDisplay;

uint32_t TotalDuration = 0; //unit sec
uint32_t TimeLeft = 0;
uint32_t TimeStart = 0;

void led7SegStateChange(LED7SEG_STATE_TYPE newState)
{
	led7SegState = newState;
}

LED7SEG_STATE_TYPE led7SegStateGet(void)
{
	return led7SegState;
}

void TimeSecCountDown_Task(void)
{
	uint32_t TimeElapsed = 0;
	if(led7SegState == LED7SEG_IDLE)
	{
		TimeElapsed = SysTick_GetSec() - TimeStart;
		if(TimeElapsed > TotalDuration)TimeLeft = 0;
		else TimeLeft = TotalDuration - TimeElapsed;
	}
}

void Led7SegTask_Init(void)
{
	memset(LED7Seg.buffer_1,0,sizeof(LED7Seg.buffer_1));
	sprintf((char*)LED7Seg.buffer_1,"    ");
	LED7Seg.dot_effect = 0;
	LED7Seg.scan_index = 1;
	Led7Seg_Init();
	LED7Seg.enable = 1;
	InitTimeout(&tLed7SegDisplay,SYSTICK_TIME_MS(500));
}

void Led7SegTask(void)
{
	static uint8_t ToggleFlag = 0;
	switch(led7SegState)
	{
		case LED7SEG_IDLE:			
			if(CheckTimeout(&tLed7SegDisplay) != SYSTICK_TIMEOUT) break;			
			InitTimeout(&tLed7SegDisplay,LED7SEG_REFRESH_INTERVAL_1S);
	
			if(TimeLeft == 0)
			{
				LED7Seg.dot_effect = 0;
				sprintf((char*)LED7Seg.buffer_1,"----");
			}
			else
			{
				if(TimeLeft < 60*60)
				{
					sprintf((char*)LED7Seg.buffer_1,"%2d%02d",(TimeLeft/60)%60,(TimeLeft)%60); //sec
				}
				else
				{
					sprintf((char*)LED7Seg.buffer_1,"%2d%02d",(TimeLeft/60/60)%24,(TimeLeft/60)%60); //minute				
				}
				LED7Seg.dot_effect |= 0x02;
			}
			break;
		
		case LED7SEG_SETUP:	
			if(CheckTimeout(&tLed7SegDisplay) != SYSTICK_TIMEOUT) break;
			InitTimeout(&tLed7SegDisplay,LED7SEG_TIME_DISPLAY_NORMAL);	
			if(ToggleFlag)
			{
				sprintf((char*)LED7Seg.buffer_1,"%2d  ",(TimeLeft/60/60)%24); //minute
			}
			else
			{
				sprintf((char*)LED7Seg.buffer_1,"%2d%02d",(TimeLeft/60/60)%24,(TimeLeft/60)%60); //minute
			}
			LED7Seg.dot_effect |= 0x02;
			ToggleFlag = ~ToggleFlag;
			break;
		
		case LED7SEG_SETUP_ID:
			if(CheckTimeout(&tLed7SegDisplay) != SYSTICK_TIMEOUT) break;
			InitTimeout(&tLed7SegDisplay,LED7SEG_TIME_DISPLAY_NORMAL);
			sprintf((char*)LED7Seg.buffer_1,"id%02d",sysCfg.DevID);			
			break;
			
		case LED7SEG_SELFTEST:
			if(CheckTimeout(&tLed7SegDisplay) != SYSTICK_TIMEOUT) break;
			InitTimeout(&tLed7SegDisplay,LED7SEG_TIME_DISPLAY_NORMAL);
			sprintf((char*)LED7Seg.buffer_1,"8888");
			LED7Seg.dot_effect |= 0x0F;
			break;
		
		default:
			break;
	}
}
/*******************************************************************************
	*END FILE
********************************************************************************/
