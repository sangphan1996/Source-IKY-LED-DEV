#ifndef __MATRIX_TASK_H
#define __MATRIX_TASK_H
#include "matrix_driver.h"
#include "sys_tick.h"

typedef enum{
	LEDMATRIX_DISP_NORMAL = 0,
	LEDMATRIX_DISP_CFG_ID,
	LEDMATRIX_DISP_CFG_REMOTE,
	LEDMATRIX_DISP_SELFTEST,
	LEDMATRIX_DISP_CHECKOUT,
}mLedMatrix_State_Typedef;

extern Timeout_Type tLEDMatrixDispCheckOut;

void LedMatrix_Disp_Init(void);
void LedMatrix_Disp_Task(void);
mLedMatrix_State_Typedef LedMatrix_State_Get(void);
void LedMatrix_State_Change(mLedMatrix_State_Typedef state);
#endif //__MATRIX_TASK_H
/*******************************************************************************
	*END FILE
********************************************************************************/
