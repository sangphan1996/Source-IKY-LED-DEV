#include "io_control.h"

extern __IO uint32_t systems_tick;

IO_TOGGLE_TYPE io_bell;
uint32_t IO_ProcessTick = 0;

void IO_ToggleSetStatus(IO_TOGGLE_TYPE *ioCtrl,uint32_t onTime,uint32_t offTime,uint32_t enable,uint32_t times)		
{
  ioCtrl->onTime = onTime;
  ioCtrl->offTime = offTime;
  ioCtrl->counter = 0;
  ioCtrl->enable = enable;
  ioCtrl->times = times;
}													
											
uint8_t IO_ToggleProcess(IO_TOGGLE_TYPE *ioCtrl, uint32_t preodic)	
{
  if(ioCtrl->enable == IO_TOGGLE_ENABLE) 
  {
    if(ioCtrl->counter > preodic)
      ioCtrl->counter -= preodic;
    else ioCtrl->counter = 0;
				
    if(ioCtrl->counter == 0) 
    {
      if(ioCtrl->times) 
      {
        ioCtrl->times--;
        ioCtrl->counter = ioCtrl->offTime + ioCtrl->onTime;
        ioCtrl->status = IO_STATUS_ON;
      }
      else
      {
        ioCtrl->enable = IO_TOGGLE_DISABLE;
        ioCtrl->status = IO_STATUS_OFF;
      }
    }
    else if(ioCtrl->counter <= ioCtrl->offTime) 
    {
      ioCtrl->status = IO_STATUS_OFF;
    }
  }
  else if(ioCtrl->enable == IO_TOGGLE_DISABLE) 
  {
    ioCtrl->enable = IO_TOGGLE_NOCONTROL;
    ioCtrl->status = IO_STATUS_OFF;
  }
  else
  {
    ioCtrl->status = IO_STATUS_NOCONTROL;
  }
  return ioCtrl->status;
}

void IO_ToggleInit(void)
{  
        IO_ToggleSetStatus(&io_bell,100,100,IO_TOGGLE_ENABLE,2);
}

void IO_FilterInit(IOFilterType *IOFilter,uint8_t filter_cnt,uint8_t status)
{	
  IOFilter->lowCnt = 0;
  IOFilter->highCnt = 0;
  IOFilter->io_filter_cnt = filter_cnt;  
  IOFilter->bitOld = status;
  IOFilter->bitNew = status;
  IOFilter->newUpdate = 0;
  IOFilter->updateCnt = 0;
}

void IO_FilterUpdate(IOFilterType *IOFilter,uint8_t status)
{
  if (status)
  {
    IOFilter->highCnt++;
    IOFilter->lowCnt = 0;
  }
  else
  {
    IOFilter->highCnt = 0;
    IOFilter->lowCnt++;
  }
  if (IOFilter->highCnt >= IOFilter->io_filter_cnt)
  {
    IOFilter->bitNew = 1;
    IOFilter->highCnt = 0;
  }
  else if (IOFilter->lowCnt >= IOFilter->io_filter_cnt)
  {
    IOFilter->lowCnt = 0;
    IOFilter->bitNew = 0;
  }
  if (IOFilter->bitNew != IOFilter->bitOld)
  {
    IOFilter->newUpdate = 1;
    if(IOFilter->bitNew)
    {
      IOFilter->updateCnt++;
    }
    IOFilter->bitOld = IOFilter->bitNew;
  }
}

void IO_ProcessTask(void)
{
        uint8_t u8tmp = 0;
        uint32_t period = 0;        
        if(systems_tick - IO_ProcessTick > TIMER_PERIOD)
        {
                period = systems_tick - IO_ProcessTick;
                IO_ProcessTick = systems_tick;
    
                u8tmp = IO_ToggleProcess(&io_bell,period);
                if(u8tmp == IO_STATUS_ON)
                {
                        BELL_PIN_SET;
                }
                else if(u8tmp == IO_STATUS_OFF)
                {
                        BELL_PIN_CLR;
                }
        }
}