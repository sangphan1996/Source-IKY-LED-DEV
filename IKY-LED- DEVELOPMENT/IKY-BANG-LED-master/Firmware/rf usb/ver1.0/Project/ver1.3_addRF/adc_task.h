#ifndef __ADC_TASK_H__
#define __ADC_TASK_H__
#include "stm8l15x.h"

#define LOW_BATTERY_VALUE				2650//ms
#define VREF_MEASURE_INTERVAL			20//sleep

#define VREFINT_Factory_CONV_ADDRESS ((uint8_t*)0x4910)
/* Theorically BandGAP 1.224volt */
#define VREF 		1.224L
/* UNCOMMENT the line below for use the VREFINT_Factory_CONV value*/

// #define VREFINT_FACTORY_CONV 1

/*
ADC Converter
LSBIdeal = VREF/4096 or VDA/4096
*/
#define ADC_CONV 	4096

extern uint8_t lowBatteryFlag;

void Vref_Measure_Task(uint32_t time);
float Vdd_appli(void);
uint16_t ADC_Supply(void);
#endif


