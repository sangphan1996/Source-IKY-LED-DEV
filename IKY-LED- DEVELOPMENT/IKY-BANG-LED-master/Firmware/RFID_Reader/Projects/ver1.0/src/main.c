
#include "main.h"
#include <stdio.h>
#include "io_control.h"
#include "h_string.h"
#include "rfid_decode.h"
#include "uart1.h"
#include "rfid_report.h"

#define CCR1_Val                ((u16)8)
#define CCR3_Val                ((uint16_t)62)

uint32_t lowPowerModeTimeout = 0;
//uint32_t rfidEnableTimeout = 0;
uint32_t TagProcess_Tick = 0;
uint8_t SysFault_Flag = 0;
uint8_t rfidEnable = 0;

void main(void)
{
        CLK_SYSCLKConfig(DEFAULT_SYSTEM_CLK_PRESCALER);
        CLK_FastHaltWakeUpCmd(ENABLE);
        rfid_decode_packet_init();
        USART1_Init();
        IO_ToggleInit();
        HW_IO_Init();
        TIMER_Configuration();
        IWDG_Config();
        AWU_Config();        
        Check_Reset();
        RFID_Enable();
        rptTaskInit();
        while(1)
        {
                IO_ProcessTask();
                TagProcess_Task();
//                PowerManage();
                IWDG_ReloadCounter();
        }
}

void PowerManage(void)
{        
        if(ACC_IS_ON)
        {                
                lowPowerModeTimeout = systems_tick;
                RFID_Enable();                
        }
        else
        {
                RFID_Disable();
                IWDG_ReloadCounter();
                halt();
                IWDG_ReloadCounter();
        }
}

void TIMER_Configuration(void)
{
        /* Interval 1ms  as system tick */
        TIM4_TimeBaseInit(DEFAULT_TIM4_PRESCALER, 249);// 500Hz
        TIM4_ITConfig(TIM4_IT_UPDATE, ENABLE);
        TIM4_Cmd(ENABLE);
        
        /* PWM 125KHZ as out RFID */        
        TIM1_TimeBaseInit(DEFAULT_TIM1_PRESCALER - 1, TIM1_COUNTERMODE_UP, 127, 0);        
        TIM1_OC3Init(TIM1_OCMODE_PWM2, TIM1_OUTPUTSTATE_ENABLE, TIM1_OUTPUTNSTATE_ENABLE,
               CCR3_Val, TIM1_OCPOLARITY_LOW, TIM1_OCNPOLARITY_HIGH, TIM1_OCIDLESTATE_SET,
               TIM1_OCNIDLESTATE_RESET);              
        TIM1_Cmd(ENABLE);
        TIM1_CtrlPWMOutputs(ENABLE);
                      
        /* Counter for signal in RFID */
        TIM2_TimeBaseInit(DEFAULT_TIM2_PRESCALER, 0xFFFF);
        TIM2_Cmd(ENABLE);
  
        enableInterrupts();
}

/**
  * @brief  Configures the IWDG to generate a Reset if it is not refreshed at the
  *         correct time. 
  * @param  None
  * @retval None
  */
void IWDG_Config(void)
{
        IWDG_Enable();
        IWDG_WriteAccessCmd(IWDG_WriteAccess_Enable);
        IWDG_SetPrescaler(IWDG_Prescaler_256);
        IWDG_SetReload((uint8_t)0xFF);
        IWDG_ReloadCounter();
}
/**
  * @brief  Check reset reason
*/
void Check_Reset(void)
{
        SysFault_Flag = 0;
        if(RST->SR & RST_FLAG_EMCF)
	{
		SysFault_Flag = 1;
                RST->SR = RST_FLAG_EMCF;
	}
        if(RST->SR & RST_FLAG_ILLOPF)
	{
		SysFault_Flag = 1;
                RST->SR = RST_FLAG_ILLOPF;
	}
        if(RST->SR & RST_FLAG_IWDGF)
	{
		SysFault_Flag = 1;
                RST->SR = RST_FLAG_IWDGF;
	}
        if(RST->SR & RST_FLAG_SWIMF)
	{
		SysFault_Flag = 1;
                RST->SR = RST_FLAG_SWIMF;
	}
        if(RST->SR & RST_FLAG_WWDGF)
	{
		SysFault_Flag = 1;
                RST->SR = RST_FLAG_WWDGF;
	}
}

void HW_IO_Init(void)
{
  GPIO_DeInit(GPIOA);
  GPIO_DeInit(GPIOB);
  GPIO_DeInit(GPIOC);
  GPIO_DeInit(GPIOD);
  
  GPIO_Init(BELL_PORT, BELL_PIN, GPIO_MODE_OUT_PP_LOW_FAST);   
  GPIO_Init(RFID_IN_PORT, RFID_IN_PIN, GPIO_MODE_IN_PU_IT);
  
  disableInterrupts();
  EXTI_DeInit();
  EXTI_SetExtIntSensitivity(EXTI_PORT_GPIOC, EXTI_SENSITIVITY_RISE_FALL);  
  enableInterrupts();   
}

void TagProcess_Task(void)
{
//        char str[20];
        if(!rfid_decode_wait_process) return;
        // Send MSG report here
        rptCallback(rfid_decode_data);
//        sprintf(str,"$CID,%02X%02X%02X%02X%02X,#"
//                ,rfid_decode_data[0]
//                ,rfid_decode_data[1]
//                ,rfid_decode_data[2]
//                ,rfid_decode_data[3]
//                ,rfid_decode_data[4]);
        //Bip
        if(io_bell.enable != IO_TOGGLE_ENABLE)IO_ToggleSetStatus(&io_bell,50,100,IO_TOGGLE_ENABLE,1);
        // Clear flag
        rfid_decode_wait_process = 0;
}

/**
  * @brief  Configure the AWU time base to 12s
  * @param  None
  * @retval None
  */
void AWU_Config(void)
{
        /* Initialization of AWU */
        /* LSI calibration for accurate auto wake up time base*/
//    AWU_LSICalibrationConfig(128000);
        AWU->APR = 30;
    
        /* The delay corresponds to the time we will stay in Halt mode */
        AWU_Init(AWU_TIMEBASE_128MS);
}

/**
  * @brief  Enable RFID reader module
*/
void RFID_Enable(void)
{
        if(!rfidEnable)
        {
                GPIO_Init(RFID_IN_PORT, RFID_IN_PIN, GPIO_MODE_IN_PU_IT);
                TIM1_CtrlPWMOutputs(ENABLE);
                rfidEnable = 1;
        }
}
/**
  * @brief  Disable RFID reader module
*/
void RFID_Disable(void)
{
        if(rfidEnable)
        {
                GPIO_Init(RFID_IN_PORT, RFID_IN_PIN, GPIO_MODE_IN_PU_NO_IT);
                TIM1_CtrlPWMOutputs(DISABLE);
                rfidEnable = 0;
        }
}
/******************* (C) COPYRIGHT 2011 STMicroelectronics *****END OF FILE****/
