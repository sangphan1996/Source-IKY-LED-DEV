#ifndef __IO_CONTROL__H__
#define __IO_CONTROL__H__

#include "stm8s.h"

typedef struct
{
    uint32_t onTime;
    uint32_t offTime;
    int32_t counter;
    uint8_t status;
    uint8_t enable;
    uint32_t times;
} IO_TOGGLE_TYPE;

typedef struct {
	uint8_t io_filter_cnt;
	uint8_t bitOld;
	uint8_t bitNew;
	uint8_t highCnt;
	uint8_t lowCnt;
	uint8_t newUpdate;
	uint8_t updateCnt;
}IOFilterType;

#define TIMER_PERIOD                    10      //ms

#define SIGNAL_IO_FILTER_CNT            2
#define ACC_IO_FILTER_CNT               20

#define IO_STATUS_ON                    1
#define IO_STATUS_OFF                   0
#define IO_STATUS_NOCONTROL             2

#define IO_STATUS_ON_TIME_DFG           (500 / TIMER_PERIOD) /*1s */
#define IO_STATUS_OFF_TIME_DFG          (500 / TIMER_PERIOD) /*1s */

#define IO_TOGGLE_ENABLE		1
#define IO_TOGGLE_DISABLE		0
#define IO_TOGGLE_NOCONTROL             2

#define IO_MAX_TIMES                    0xffffffff
#define IO_MAX_VALUE                    0xffffffff

#define RFID_OUT_PORT           GPIOC
#define RFID_OUT_PIN            GPIO_PIN_3

#define RFID_IN_PORT            GPIOC
#define RFID_IN_PIN             GPIO_PIN_4
#define RFID_INPUT_STATUS       GPIO_ReadInputPin(RFID_IN_PORT,RFID_IN_PIN)

#define ACC_PORT                GPIOD
#define ACC_PIN                 GPIO_PIN_6
#define ACC_IS_ON               (GPIO_ReadInputPin(ACC_PORT,ACC_PIN) == RESET)

#define BELL_PORT               GPIOD
#define BELL_PIN                GPIO_PIN_6
#define BELL_PIN_SET            BELL_PORT->ODR |= (uint8_t)BELL_PIN
#define BELL_PIN_CLR            BELL_PORT->ODR &= (uint8_t)(~BELL_PIN)

extern IO_TOGGLE_TYPE io_bell;

uint8_t IO_ToggleProcess(IO_TOGGLE_TYPE *ioCtrl, uint32_t preodic);
void IO_ToggleSetStatus(IO_TOGGLE_TYPE *ledCtr,uint32_t onTime,uint32_t offTime,uint32_t enable,uint32_t times);
void IO_ToggleInit(void);
void IO_FilterUpdate(IOFilterType *IOFilter,uint8_t status);
void IO_FilterInit(IOFilterType *IOFilter,uint8_t filter_cnt,uint8_t status);
void IO_ProcessTask(void);
#endif

