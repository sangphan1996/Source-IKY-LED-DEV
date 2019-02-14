#include "display_task.h"
#include "rtc.h" 
#include "logger.h"
#include "system_config.h"


extern uint8_t remoteIndex;

void BotLineDisplayTask(void);
void TopLineDisplayTask(void);




DISPLAY_STATE_TYPE displayState = DISP_HOME;

Timeout_Type tDispCheckOut;
Timeout_Type tRefresh;

uint8_t dot_effect = 0;
uint32_t TotalDuration = 0; //unit sec
uint32_t TimeLeft = 0;
uint32_t TimeStart = 0;

void DisplayTask_Init(void)
{
	InitTimeout(&tRefresh,SYSTICK_TIME_MS(100));
}

void DisplayTask(void)
{
	uint32_t TimeElapsed = 0;
	uint16_t i;
	uint8_t is_Space = 1;
		
	if(CheckTimeout(&tRefresh) != SYSTICK_TIMEOUT) return;			
	InitTimeout(&tRefresh,SYSTICK_TIME_MS(250));
	
	switch(displayState)
	{
		case DISP_HOME:		
			strcpy((char*)screen.top_msg,(char*)sysCfg.Greeting);
			screen.topScroll = 1;
			
			sprintf((char*)screen.bot_msg,STRING_LINE_EMPTY);
		
			displayState = DISP_COUNTDOWN;
			break;
		
		case DISP_COUNTDOWN:	
			
			TimeElapsed = SysTick_GetSec() - TimeStart;
			if(TimeElapsed > TotalDuration)TimeLeft = 0;
			else TimeLeft = TotalDuration - TimeElapsed;
		
			if(TimeLeft == 0)
			{
				displayState = DISP_HOME;
				break;
			}			
							
			for(i=0;i<strlen((char*)sysCfg.GuestInf);i++)
			{
				if(sysCfg.GuestInf[i] != ' ') 
				{
					is_Space = 0; break;
				}
			}
			
			if(is_Space)
			{
				strcpy((char*)screen.top_msg,(char*)sysCfg.Greeting);
			}
			else
			{
				strcpy((char*)screen.top_msg,(char*)sysCfg.GuestInf);
			}
		
			if(TimeLeft < 60*60)
			{
					sprintf((char*)screen.bot_msg,"%2d:%02d",(TimeLeft/60)%60,(TimeLeft)%60); //sec
			}
			else
			{
					sprintf((char*)screen.bot_msg,"%2d:%02d",(TimeLeft/60/60)%24,(TimeLeft/60)%60); //minute				
			}					
			break;
			
		case DISP_SETUP_ID:
			sprintf((char*)screen.top_msg,"ID:%02d  ",sysCfg.DevID);
			screen.topScroll = 0;
			sprintf((char*)screen.bot_msg,STRING_LINE_EMPTY);
			break;
		
		case DISP_CHECKOUT:
			if(CheckTimeout(&tDispCheckOut) == SYSTICK_TIMEOUT)
			{
				displayState = DISP_HOME;
				break;
			}			
			strcpy((char*)screen.top_msg,(char*)sysCfg.CheckOut);
			screen.topScroll = 1;
			
			sprintf((char*)screen.bot_msg,STRING_LINE_EMPTY);
			break;
		
		case DISP_SELFTEST:
			break;
		
		default:
			displayState = DISP_HOME;
			break;
	}
}



