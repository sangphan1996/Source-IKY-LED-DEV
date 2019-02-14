/* Define to prevent recursive inclusion -------------------------------------*/
#ifndef __RTC_H
#define __RTC_H
#include "stm32f10x.h"

typedef __packed struct {
	uint8_t Day;
	uint8_t Month;
	uint16_t Year;
	uint8_t Hour;
	uint8_t	Minutes;
	uint8_t Second ;
}rtcDATETIME;

extern uint32_t rtcTimeSec;

void rtcCfg(void);
void rtcInit(void);
void rtcTask(void);
void rtcTimeAdjust(uint32_t Value);
uint32_t Sec_Diff( uint32_t st_day, uint32_t st_month, uint32_t st_year,
						uint32_t fs_day, uint32_t fs_month, uint32_t fs_year,
						uint32_t fs_hour, uint32_t fs_min, uint32_t fs_sec);
void Time_Convert(rtcDATETIME * RTCDateTime);
#endif //__RTC_H

