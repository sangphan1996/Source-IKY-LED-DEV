#include "stm32f10x.h"
#include "matrix_task.h"
#include "logger.h"
#include "system_config.h"
#include "logger.h"
#include "led7seg_task.h"

#define LEDMT_DBG(...)  		//DbgCfgPrintf(__VA_ARGS__)

#define LEDMATRIX_REFRESH_TIMEOUT		500

extern uint8_t remoteIndex;

mLedMatrix_State_Typedef mLedMatrix_State = LEDMATRIX_DISP_NORMAL;
mLedMatrix_State_Typedef mLedMatrix_State_Last;
Timeout_Type tLEDMatrixRefresh;
Timeout_Type tLEDMatrixDispCheckOut;

void LedMatrix_Disp_Init(void)
{
	memset(LEDMatrix.buffer_1,0,sizeof(LEDMatrix.buffer_1));
	memset(LEDMatrix.buffer_2,0,sizeof(LEDMatrix.buffer_2));
	#if(MATRIX_CELL_ON)
	memset(LEDMatrix.dram_1,0x00,sizeof(LEDMatrix.dram_1));
	memset(LEDMatrix.dram_2,0x00,sizeof(LEDMatrix.dram_2));
	#else
	memset(LEDMatrix.dram_1,0xFF,sizeof(LEDMatrix.dram_1));
	memset(LEDMatrix.dram_2,0xFF,sizeof(LEDMatrix.dram_2));
	#endif
	InitTimeout(&tLEDMatrixRefresh,LEDMATRIX_REFRESH_TIMEOUT);
	LEDMatrix.enable = 1;
	LEDMatrix.effect = 0;
	LEDMatrix.column_pos = 0;
	LEDMatrix.column_shift = 0;
	MaTrix_IOInit();
}

mLedMatrix_State_Typedef LedMatrix_State_Get(void)
{
	return mLedMatrix_State;
}

void LedMatrix_State_Change(mLedMatrix_State_Typedef state)
{
	mLedMatrix_State = state;
}

void LedMatrix_Disp_Task(void)
{
	uint16_t i;
	uint8_t is_Space = 1;
	if(CheckTimeout(&tLEDMatrixRefresh) != SYSTICK_TIMEOUT) return;
	InitTimeout(&tLEDMatrixRefresh,LEDMATRIX_REFRESH_TIMEOUT);
	
	switch(mLedMatrix_State)
	{
		case LEDMATRIX_DISP_NORMAL:			
			memset(LEDMatrix.buffer_2,0,sizeof(LEDMatrix.buffer_2));
			for(i=0;i<strlen((char*)sysCfg.GuestInf);i++)
			{
				if(sysCfg.GuestInf[i] != ' ') 
				{
					is_Space = 0; break;
				}
			}
			if(TimeLeft == 0)
			{
				strcpy((char*)LEDMatrix.buffer_2,(char*)sysCfg.Greeting);
			}
			else if(is_Space)
			{
				strcpy((char*)LEDMatrix.buffer_2,(char*)sysCfg.Greeting);
			}
			else
			{
				strcpy((char*)LEDMatrix.buffer_2,(char*)sysCfg.GuestInf);
			}
			LEDMatrix.effect = 1;
			break;
		
		case LEDMATRIX_DISP_CHECKOUT:		
			if(CheckTimeout(&tLEDMatrixDispCheckOut) == SYSTICK_TIMEOUT)
			{
				mLedMatrix_State = LEDMATRIX_DISP_NORMAL;
				break;
			}
			memset(LEDMatrix.buffer_2,0,sizeof(LEDMatrix.buffer_2));
			strcpy((char*)LEDMatrix.buffer_2,(char*)sysCfg.CheckOut);			
			LEDMatrix.effect = 1;
			break;
			
		case LEDMATRIX_DISP_CFG_ID:
			sprintf((char*)LEDMatrix.buffer_2,"ID: %02d  ",sysCfg.DevID);
			LEDMatrix.effect = 0;
			break;
		
		case LEDMATRIX_DISP_CFG_REMOTE:			
			sprintf((char*)LEDMatrix.buffer_2,"REMOTE %d",remoteIndex+1);
			LEDMatrix.effect = 0;
			break;
		
		case LEDMATRIX_DISP_SELFTEST:
			if(mLedMatrix_State_Last == mLedMatrix_State) break;
			LEDMatrix.effect = 0;
			LEDMatrix.column_pos = 0;
			memset(LEDMatrix.buffer_1,0x00,sizeof(LEDMatrix.buffer_1));
			memset(LEDMatrix.buffer_2,0x00,sizeof(LEDMatrix.buffer_2));
			__disable_irq();
			#if(MATRIX_CELL_ON)
			memset(LEDMatrix.dram_1,0xFF,sizeof(LEDMatrix.dram_1));
			memset(LEDMatrix.dram_2,0xFF,sizeof(LEDMatrix.dram_2));
			#else
			memset(LEDMatrix.dram_1,0x00,sizeof(LEDMatrix.dram_1));
			memset(LEDMatrix.dram_2,0x00,sizeof(LEDMatrix.dram_2));
			#endif
			__enable_irq();
			break;
		
		default:
			mLedMatrix_State = LEDMATRIX_DISP_NORMAL;
			break;
	}
	if(memcmp(LEDMatrix.buffer_1,LEDMatrix.buffer_2,sizeof(LEDMatrix.buffer_1)) != 0)
	{
		LEDMatrix.column_pos = 0;
		memcpy(LEDMatrix.buffer_1,LEDMatrix.buffer_2,sizeof(LEDMatrix.buffer_1));
		LEDMatrix.strlen = strlen((char*)LEDMatrix.buffer_1)*6;
		MaTrix_VRam_Update();
//		LEDMT_DBG("\r\nMT UPDATE %d \r\n",LEDMatrix.strlen);
	}
	mLedMatrix_State_Last = mLedMatrix_State;
}
/*******************************************************************************
	*END FILE
********************************************************************************/
