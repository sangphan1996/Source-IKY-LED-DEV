/**
* \file
*         ADC task
* \author
*         IKY Company
*/
#include "stm8l15x.h"
#include "adc_task.h"
#include "main.h"
#include "uart1.h"
/* Private typedef -----------------------------------------------------------*/
/* Private define ------------------------------------------------------------*/
uint8_t lowBatteryFlag = 0;
/* Private macro -------------------------------------------------------------*/
/* Private variables ---------------------------------------------------------*/
/**
* @brief Function to measure VDD
* @caller main
* @param None
* @retval Vdd value in mV
*/
void Vref_Measure_Task(uint32_t time)
{
	if (time%VREF_MEASURE_INTERVAL)return;
	uint16_t Vdd_mV;
	Vdd_mV = (uint16_t)Vdd_appli();	
#ifdef DEBUG_MODE
	USART1_PutString("VDD: ");
	convert_into_char(Vdd_mV);
	USART1_PutString(" mV\r\n");
#endif
	if (Vdd_mV < LOW_BATTERY_VALUE){
#ifdef DEBUG_MODE
		USART1_PutString("Low battery\r\n");
#endif
		lowBatteryFlag = 1;
	}
	else{
		lowBatteryFlag = 0;
	}
}

/**
* @brief Function to return the VDD measurement
* @caller All measurements: VDD display or Current
* See STM8L152x4/6 and STM8L151x4/6 Errata sheet
* Limitation: "Bandgap VREFINT_Factory_CONV byte value not programmed"
*
* 2 Methods for VDD measurement:
* The first one offers a better accuracy
*
* 1st case: The VREFINT is stored in memory during factory tests
* We use this value for better accuracy in this case
*   Vdd_appli = ( VREF_Factory/Vref_measured ) * VDD_Factory
*   VDD_Factory = 3V+-10mV
*   Vref_Factory +-5mV
*
* 2nd case: The VREFINT is not stored in memory.
*   In this case:
*   Vdd_appli = (Theorical_Vref/Vref mesure) * ADC_Converter
*   Theorical_Vref = 1.224V
*   ADC_Converter 4096
*   ---> LSBIdeal = VREF/4096 or VDA/4096
* @param None
* @retval VDD measurements
*/
float Vdd_appli(void)
{
	uint16_t MeasurINT, FullVREF_FACTORY;
	uint8_t *P_VREFINT_Factory;
	float f_Vdd_appli;

	P_VREFINT_Factory = VREFINT_Factory_CONV_ADDRESS;

	/*Read the BandGap value on ADC converter*/
	MeasurINT = ADC_Supply();

	/* To check if VREFINT_Factory_CONV has been set
	the value is one byte we must add 0x600 to the factory byte */

	/* For use VREFINT_Factory_CONV, we must to define VREFINT_FACTORY_CONV (file discover_functions.h */

#ifdef VREFINT_FACTORY_CONV
	if ((*P_VREFINT_Factory>VREFINT_Factory_CONV_MIN) && (*P_VREFINT_Factory<VREFINT_Factory_CONV_MAX))
	{
		/* If the value exists:
		Adds the hight byte to FullVREF_FACTORY */
		FullVREF_FACTORY = VREFINT_Factory_CONV_MSB;
		FullVREF_FACTORY += *P_VREFINT_Factory;
		f_Vdd_appli = (float)(FullVREF_FACTORY*VDD_FACTORY);
		f_Vdd_appli /= MeasurINT;
	}
	else {
		/* If the value doesn't exist (or not correct) in factory setting takes the theorical value 1.224 volt */
		f_Vdd_appli = (VREF / MeasurINT) * ADC_CONV;
	}
#else
	/* We use the theorcial value */
	f_Vdd_appli = (VREF / MeasurINT) * ADC_CONV;
#endif

	/* Vdd_appli in mV */
	f_Vdd_appli *= 1000L;

	return f_Vdd_appli;
}

/**
* @brief  Read ADC1
* @caller several functions
* @param None
* @retval ADC value
*/
uint16_t ADC_Supply(void)
{
	uint8_t i;
	uint16_t res;
	uint32_t Timeout;

	/* Enable ADC clock */
	CLK_PeripheralClockConfig(CLK_Peripheral_ADC1, ENABLE);

	/* de-initialize ADC */
	ADC_DeInit(ADC1);

	/*ADC configuration
	ADC configured as follow:
	- Channel VREF
	- Mode = Single ConversionMode(ContinuousConvMode disabled)
	- Resolution = 12Bit
	- Prescaler = /1
	- sampling time 9 */

	ADC_VrefintCmd(ENABLE);
	Delay(30);

	ADC_Cmd(ADC1, ENABLE);
	ADC_Init(ADC1, ADC_ConversionMode_Single,ADC_Resolution_12Bit, ADC_Prescaler_1);

	ADC_SamplingTimeConfig(ADC1, ADC_Group_FastChannels, ADC_SamplingTime_9Cycles);
	ADC_ChannelCmd(ADC1, ADC_Channel_Vrefint, ENABLE);
	Delay(30);

	/* initialize result */
	res = 0;
	for (i = 8; i > 0; i--)
	{
		/* start ADC convertion by software */
		ADC_SoftwareStartConv(ADC1);
		/* wait until end-of-covertion */
		Timeout = 10000;
		while (ADC_GetFlagStatus(ADC1, ADC_FLAG_EOC) == 0 && Timeout)
		{
			Timeout--;
		}
		/* read ADC convertion result */
		res += ADC_GetConversionValue(ADC1);
	}

	/* de-initialize ADC */
	ADC_VrefintCmd(DISABLE);

	ADC_DeInit(ADC1);

	/* disable SchmittTrigger for ADC_Channel_24, to save power */
	ADC_SchmittTriggerConfig(ADC1, ADC_Channel_24, DISABLE);

	CLK_PeripheralClockConfig(CLK_Peripheral_ADC1, DISABLE);
	ADC_ChannelCmd(ADC1, ADC_Channel_Vrefint, DISABLE);

	return (res >> 3);
}

