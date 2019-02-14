#include "rtc.h"
#include "logger.h"
#include <time.h>
#include <stdio.h>
#include "led7seg_task.h"

//#define USE_LSE

uint32_t rtcTimeSec = 0;
/**  * @brief  Configures the RTC.
  		-Side Effect : access to BKP Domain
  * @param  None
  * @retval None
  */
void rtcConfigUseLSE(void)
{
  /* Enable PWR and BKP clocks */
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_PWR | RCC_APB1Periph_BKP, ENABLE);

	/* Allow access to BKP Domain */
	PWR_BackupAccessCmd(ENABLE);

	/* Reset Backup Domain */
	BKP_DeInit();

	/* Enable LSE */
	RCC_LSEConfig(RCC_LSE_ON);
	/* Wait till LSE is ready */
	while (RCC_GetFlagStatus(RCC_FLAG_LSERDY) == RESET)
	{}

	/* Select LSE as RTC Clock Source */
	RCC_RTCCLKConfig(RCC_RTCCLKSource_LSE);

	/* Enable RTC Clock */
	RCC_RTCCLKCmd(ENABLE);

	/* Wait for RTC registers synchronization */
	RTC_WaitForSynchro();

	/* Wait until last write operation on RTC registers has finished */
	RTC_WaitForLastTask();

	/* Enable the RTC Second */
	RTC_ITConfig(RTC_IT_SEC, ENABLE);

	/* Wait until last write operation on RTC registers has finished */
	RTC_WaitForLastTask();

	/* Set RTC prescaler: set RTC period to 1sec */
	RTC_SetPrescaler(32767); /* RTC period = RTCCLK/RTC_PR = (32.768 KHz)/(32767+1) */

	/* Wait until last write operation on RTC registers has finished */
	RTC_WaitForLastTask();
}
/**
  * @brief  Configures the RTC.
  * @param  None
  * @retval None
  */
void rtcConfigUseLSI(void)
{
  /* Enable PWR and BKP clocks */
  RCC_APB1PeriphClockCmd(RCC_APB1Periph_PWR | RCC_APB1Periph_BKP, ENABLE);

  /* Allow access to BKP Domain */
  PWR_BackupAccessCmd(ENABLE);

  /* Reset Backup Domain */
  BKP_DeInit();

  /* Enable the LSI OSC */
  RCC_LSICmd(ENABLE);
  /* Wait till LSI is ready */
  while (RCC_GetFlagStatus(RCC_FLAG_LSIRDY) == RESET)
  {}
  /* Select the RTC Clock Source */
  RCC_RTCCLKConfig(RCC_RTCCLKSource_LSI);

  /* Enable RTC Clock */
  RCC_RTCCLKCmd(ENABLE);

  /* Wait for RTC registers synchronization */
  RTC_WaitForSynchro();

  /* Wait until last write operation on RTC registers has finished */
  RTC_WaitForLastTask();

  /* Enable the RTC Second */
  RTC_ITConfig(RTC_IT_SEC, ENABLE);

  /* Wait until last write operation on RTC registers has finished */
  RTC_WaitForLastTask();

  /* Set RTC prescaler: set RTC period to 1sec */
  RTC_SetPrescaler(40000);

  /* Wait until last write operation on RTC registers has finished */
  RTC_WaitForLastTask();
}
/**
  * @brief  This function handles RTC global interrupt request.
  * @param  None
  * @retval None
  */
void RTC_IRQHandler(void)
{
  if (RTC_GetITStatus(RTC_IT_SEC) != RESET)
  {
		rtcTask();		
    /* Clear the RTC Second interrupt */
    RTC_ClearITPendingBit(RTC_IT_SEC);
    /* Wait until last write operation on RTC registers has finished */
    RTC_WaitForLastTask();
    
  }
}
/**
   * @brief  Init RTC 
   * @param  None
   * @retval None
   */
void rtcInit(void)
{
	NVIC_InitTypeDef NVIC_InitStructure;

	/* RTC Configuration */
	if (BKP_ReadBackupRegister(BKP_DR1) != 0xA5A5 || 1)
  {
    /* Backup data register value is not correct or not yet programmed (when
       the first time the program is executed) */

    /* RTC Configuration */
		#ifdef USE_LSE
		rtcConfigUseLSE();
		#else
    rtcConfigUseLSI();
		#endif
    BKP_WriteBackupRegister(BKP_DR1, 0xA5A5);
  }
  else
  {
    /* Wait for RTC registers synchronization */
    RTC_WaitForSynchro();
    /* Enable the RTC Second */
    RTC_ITConfig(RTC_IT_SEC, ENABLE);
    /* Wait until last write operation on RTC registers has finished */
    RTC_WaitForLastTask();
  }	
	
  /* Configure one bit for preemption priority */
  NVIC_PriorityGroupConfig(NVIC_PriorityGroup_1);

  /* Enable the RTC Interrupt */
  NVIC_InitStructure.NVIC_IRQChannel = RTC_IRQn;
  NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0;
  NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0;
  NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
  NVIC_Init(&NVIC_InitStructure);
}
/**
   * @brief  Task RTC 
   * @param  None
   * @retval None
   */
void rtcTask(void)
{
	time_t s_sec = RTC_GetCounter();
	struct  tm  *now = localtime(&s_sec);
	rtcTimeSec++;
//	sysInfo.time.Hour = now -> tm_hour;
//	sysInfo.time.Minutes = now -> tm_min;
//	sysInfo.time.Second = now -> tm_sec;
//	sysInfo.time.Day = now -> tm_mday;
//	sysInfo.time.Month = now -> tm_mon + 1;
//	if(now->tm_year+1900 >= 2000)
//		sysInfo.time.Year	= now->tm_year+1900 - 2000;
//	else
//		sysInfo.time.Year	= 0;
}
/**
  * @brief  Adjusts time.
  * @param  None
  * @retval None
  */
void rtcTimeAdjust(uint32_t Value)
{
	#ifdef USE_LSE
	rtcConfigUseLSE();
	#else
  rtcConfigUseLSI();
	#endif
  /* Wait until last write operation on RTC registers has finished */
  RTC_WaitForLastTask();
  /* Change the current time */
  RTC_SetCounter(Value);
  /* Wait until last write operation on RTC registers has finished */
  RTC_WaitForLastTask();
	/* No need to configure RTC next time */
	BKP_WriteBackupRegister(BKP_DR1, 0xA5A5);
}
/** 
  * @brief	Calculate number of days differece between 2 days
  * @param	st_day, st_month, st_year: start day
			fs_day, fs_month, fs_year: finish day 
  * @retval number of days
  */
uint32_t Sec_Diff( uint32_t st_day, uint32_t st_month, uint32_t st_year,
						uint32_t fs_day, uint32_t fs_month, uint32_t fs_year,
						uint32_t fs_hour, uint32_t fs_min, uint32_t fs_sec)
{
  uint32_t _tmp=0,s_day=0,non_leap_year=0,leap_year = 0;
	uint32_t i;
	_tmp = fs_year-st_year;
	if(_tmp>0){
		_tmp -=2;
	  non_leap_year +=2;
		if(fs_year%4==0)
			leap_year = _tmp/4  ;
		else
			leap_year = _tmp/4 + 1;
	  non_leap_year += _tmp - leap_year ;
	}
	for(i=0;i<non_leap_year;i++)
		 s_day+=365;
	for(i=0;i<leap_year;i++)
		s_day+=366;
	for(i=1;i<fs_month;i++){
			switch(i){
				case 1:case 3:case 5:case 7:case 8:case 10:case 12:s_day+=31;break;
				case 4:case 6:case 9:case 11: s_day+=30;break;
				case 2: if(fs_year%4)s_day+=28;else s_day+=29;break;
				default: break;
			}
	}
	s_day+=fs_day - 1;
	return((s_day*24*3600) + (fs_hour*3600) + (fs_min*60) + fs_sec);
}
/**
  * @brief  Convert RTC Register to Date Time.
  * @param  None
  * @retval Output RTCDateTime struct
  */
void Time_Convert(rtcDATETIME * RTCDateTime)
{
	 time_t s_sec = RTC_GetCounter();
	 struct  tm  *now = localtime(&s_sec);
  /* Compute  hours */
  RTCDateTime->Hour = now->tm_hour;
  /* Compute minutes */
  RTCDateTime->Minutes = now->tm_min;
  /* Compute seconds */
  RTCDateTime->Second = now->tm_sec;
  RTCDateTime->Day= now->tm_mday;
  RTCDateTime->Month= now->tm_mon+1;
	if(now->tm_year+1900>=2000)
		RTCDateTime->Year	= now->tm_year+1900-2000;
	else
		RTCDateTime->Year	= 0;
}
/*****END OF FILE****/

