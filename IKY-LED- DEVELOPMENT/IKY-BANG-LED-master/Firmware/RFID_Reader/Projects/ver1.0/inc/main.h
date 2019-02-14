#ifndef __MAIN__H__
#define __MAIN__H__
#include "stm8s.h"

#define BUTTON_1_1_CLICK                0x01
#define BUTTON_2_1_CLICK                0x02
#define BUTTON_1_2_CLICK                0x03
#define BUTTON_2_2_CLICK                0x04

typedef enum{
	ISSUE_IDLE_PHASE = 0,
        ISSUE_NOTIFY_PHASE,
	ISSUE_TAG_MASTER_PHASE,
	ISSUE_TAG_USER1_PHASE,
	ISSUE_TAG_USER2_PHASE,
	ISSUE_REMOTE_USER1_PHASE,
        ISSUE_REMOTE_USER2_PHASE,
	ISSUE_END_PHASE,
} ISSUE_PHASE_TYPE;

typedef enum{
	ISSUE_BY_ADMIN = 0,	
        ISSUE_REMOTE_BY_USER,
        ISSUE_TAG_BY_USER,
        ISSUE_MODE_UNKNOWN,
} ISSUE_MODE_TYPE;


typedef enum{
	ALARM_IDLE_PHASE = 0,
        ALARM_ACTIVE_PHASE,
        ALARM_NOTIFY_PHASE,
	ALARM_STOP_PHASE,
} ALARM_PHASE_TYPE;

typedef enum{
	BIKE_KEY_INIT_PHASE = 0,
	BIKE_KEY_IDLE_PHASE,
        BIKE_KEY_ON_PHASE,
        BIKE_KEY_ON_WAIT_PHASE,
        BIKE_KEY_OFF_PHASE,
        BIKE_KEY_OFF_WAIT_PHASE,
} BIKE_KEY_PHASE_TYPE;


typedef enum{
	SOS_IDLE_PHASE = 0,        
        SOS_ACTIVE_PHASE,
        SOS_WAIT_BIKE_LOCK_PHASE,
        SOS_NOTIFY_PHASE,
        SOS_STOP_PHASE,
} SOS_PHASE_TYPE;

#define SYSTEM_SLEEP_TIMEOUT            604800000
#define LOW_POWER_MODE_TIMEOUT          1000
#define SYSTICK_INTERVAL                2//unit ms
#define TIM1_RELOAD_VALUE               0xFFFF
#define RFID_ENABLE_TIMEOUT             60000
#define UNLOCK_BY_REMOTE_TIMEOUT        60000
#define FIND_BIKE_TIMEOUT               3000
#define ISSUE_TAG_TIMEOUT               1000
#define ISSUE_REMOTE_TIMEOUT            1000
#define ISSUE_TASK_TIMEOUT              30000

#if defined(SYSCLK_FREQ_4MHz)
  #define DEFAULT_SYSTEM_CLK_PRESCALER  CLK_PRESCALER_HSIDIV4
  #define DEFAULT_TIM1_PRESCALER        10
  #define DEFAULT_TIM2_PRESCALER        TIM2_PRESCALER_2
  #define DEFAULT_TIM4_PRESCALER        TIM4_PRESCALER_32

#elif defined(SYSCLK_FREQ_8MHz)
  #define DEFAULT_SYSTEM_CLK_PRESCALER  CLK_PRESCALER_HSIDIV2
  #define DEFAULT_TIM1_PRESCALER        20
  #define DEFAULT_TIM2_PRESCALER        TIM2_PRESCALER_4
  #define DEFAULT_TIM4_PRESCALER        TIM4_PRESCALER_64

#elif defined(SYSCLK_FREQ_16MHz)
  #define DEFAULT_SYSTEM_CLK_PRESCALER  CLK_PRESCALER_HSIDIV1
  #define DEFAULT_TIM1_PRESCALER        1
  #define DEFAULT_TIM2_PRESCALER        TIM2_PRESCALER_64
  #define DEFAULT_TIM4_PRESCALER        TIM4_PRESCALER_128
  
#else 
  #error "System clock is not defined"
#endif

extern __IO uint32_t systems_tick;

void AWU_Config(void);
void Check_Reset(void);
void TIMER_Configuration(void);
void IWDG_Config(void);
void HW_IO_Init(void);
void SignalProcess_Task(void);
void SOSProcess_Task(void);
void IssueProcess_Task(void);
void TagProcess_Task(void);
void KeyProcess_Task(void);
void AlarmProcess_Task(void);
void RemoteProcess_Task(void);
void PowerManage(void);
uint8_t SOSProcess_Stop(void);
uint8_t SOSProcess_Active(void);
uint8_t SOSProcess_IsBusy(void);
void AlarmProcess_Active(void);
uint8_t AlarmProcess_IsBusy(void);
void RFID_Enable(void);
void RFID_Disable(void);
#endif //__MAIN__H__

