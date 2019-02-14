#include "stm32f10x.h"
#include "logger.h"
#include "system_config.h"
#include "cc1101_receiver.h"
#include "led7seg_task.h"
#include "cc1101_parser.h"
#include "hw_config.h"
#include "sys_tick.h"
#include "matrix_task.h"
#include <stdarg.h>

#define MAIN_Info(...)  		//DbgCfgPrintf(__VA_ARGS__)
#define BUTTON_TIMEOUT			SYSTICK_TIME_MS(500)

Timeout_Type tButtonTimeout;
uint8_t btn1Cnt = 0;
uint8_t remoteIndex = 0;

void SystemClockInit(void);
void Show_RST_Flag(void);
void IWDGInit(void);
void BUTTON1_EventHandler(TM_BUTTON_PressType_t type);
void BUTTON1_ReleaseHandler(TM_BUTTON_PressType_t type);
//
int main(void)
{
	SystemClockInit();
	__enable_irq();
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOA
												| RCC_APB2Periph_GPIOB
												| RCC_APB2Periph_GPIOC
												| RCC_APB2Periph_GPIOD
												| RCC_APB2Periph_AFIO, ENABLE);
	GPIO_PinRemapConfig(GPIO_Remap_SWJ_JTAGDisable, ENABLE);
	USART1_Init(SystemCoreClock,__USART1_BAUDRATE);
	CFG_Load();
	if (SysTick_Config(SystemCoreClock / 1000))
	{
		__disable_irq();
    NVIC_SystemReset();
	}
	Show_RST_Flag();
	IWDGInit();		
	Led7SegTask_Init();
	LedMatrix_Disp_Init();	
	//
	rfParserTask_Init();
	CC1101_SPI_Init();
	CC1101_Power_Init();
	CC1101_ProcessInit(0x34);	
	CC1101_ForceToRxMode();
	TM_BUTTON_Init(&TM_Button_1,BUTTON_1_PORT, BUTTON_1_PIN, 0, BUTTON1_EventHandler,BUTTON1_ReleaseHandler);
	InitTimeout(&tButtonTimeout,BUTTON_TIMEOUT);		
	while(1)
	{
		Led7SegTask();
		RfRecive_Task();
		rfParserTask();
		CFG_Task();
		LedMatrix_Disp_Task();
		IWDG_ReloadCounter();
	}
}

void IWDGInit(void)
{
  IWDG_WriteAccessCmd(IWDG_WriteAccess_Enable);
  IWDG_SetPrescaler(IWDG_Prescaler_32);
  IWDG_SetReload(0x0FFF);
  IWDG_ReloadCounter();
  IWDG_Enable();
}

void BUTTON1_EventHandler(TM_BUTTON_PressType_t type) 
{    
	if (type == TM_BUTTON_PressType_Normal) 
	{
        if(CheckTimeout(&tButtonTimeout) == SYSTICK_TIMEOUT)
        {
          btn1Cnt = 1;
        }
        else
        {
          btn1Cnt++;
        }
        InitTimeout(&tButtonTimeout,BUTTON_TIMEOUT);
	}
}

void BUTTON1_ReleaseHandler(TM_BUTTON_PressType_t type) 
{   
    if(CheckTimeout(&tButtonTimeout) == SYSTICK_TIMEOUT)
    {
				if(btn1Cnt == 1)
				{
					if(led7SegStateGet() == LED7SEG_SELFTEST)
					{
						led7SegStateChange(LED7SEG_IDLE);
					}
					if(LedMatrix_State_Get() == LEDMATRIX_DISP_SELFTEST)
					{
						LedMatrix_State_Change(LEDMATRIX_DISP_NORMAL);
					}
					if(LedMatrix_State_Get() == LEDMATRIX_DISP_CFG_ID)
					{
						sysCfg.DevID++;
					}
				}
				else if(btn1Cnt == 2)
				{
					if(LedMatrix_State_Get() == LEDMATRIX_DISP_NORMAL)
					{
						sysCfg.DevID = 1;
						LedMatrix_State_Change(LEDMATRIX_DISP_CFG_ID);
					}
					else if(LedMatrix_State_Get() == LEDMATRIX_DISP_CFG_ID)
					{
						LedMatrix_State_Change(LEDMATRIX_DISP_NORMAL);
						saveConfigFlag = 1;
					}
				}
				else if(btn1Cnt == 3)
				{
					if(LedMatrix_State_Get() == LEDMATRIX_DISP_NORMAL)
					{
						remoteIndex = 0;
						LedMatrix_State_Change(LEDMATRIX_DISP_CFG_REMOTE);
					}
					else if(LedMatrix_State_Get() == LEDMATRIX_DISP_CFG_REMOTE)
					{
						LedMatrix_State_Change(LEDMATRIX_DISP_NORMAL);
						saveConfigFlag = 1;
					}
				}
				else if(btn1Cnt == 5)
				{
					if(led7SegStateGet() == LED7SEG_IDLE)
					{
						led7SegStateChange(LED7SEG_SELFTEST);
					}
					if(LedMatrix_State_Get() == LEDMATRIX_DISP_NORMAL)
					{
						LedMatrix_State_Change(LEDMATRIX_DISP_SELFTEST);
					}
				}
				btn1Cnt = 0;
    }
}


void Show_RST_Flag( void )
{
	if (RCC_GetFlagStatus(RCC_FLAG_PINRST) != RESET) 
	{
		MAIN_Info((uint8_t*)"External Reset occurred....\r\n");
	}
  if (RCC_GetFlagStatus(RCC_FLAG_PORRST) != RESET)  
	{
    MAIN_Info((uint8_t*)"Power On Reset occurred....\r\n");
  }
  if (RCC_GetFlagStatus(RCC_FLAG_SFTRST) != RESET)  
	{
    MAIN_Info((uint8_t*)"Software reset occurred....\r\n");
  }
	if (RCC_GetFlagStatus(RCC_FLAG_IWDGRST) != RESET) 
	{		
		MAIN_Info((uint8_t*)"Reset by IWDG...\r\n");
	}
	if (RCC_GetFlagStatus(RCC_FLAG_WWDGRST) != RESET) 
	{
		MAIN_Info((uint8_t*)"Reset by WWDG...\r\n");
	}
	if (RCC_GetFlagStatus(RCC_FLAG_LPWRRST) != RESET) 
	{
		MAIN_Info((uint8_t*)"Reset by Low-power management...\r\n");
	}
	RCC_ClearFlag();
}

/**@brief Init system clock use HSI
 */
void SystemClockInit(void)
{                                                                           
  /*Configure all clocks to max for best performance.
   * If there are EMI, power, or noise problems, try slowing the clocks*/

  /* First set the flash latency to work with our clock*/
  /*000 Zero wait state, if 0  MHz < SYSCLK <= 24 MHz
    001 One wait state, if  24 MHz < SYSCLK <= 48 MHz
    010 Two wait states, if 48 MHz < SYSCLK <= 72 MHz */
  FLASH_SetLatency(FLASH_Latency_1);

  /* Start with HSI clock (internal 8mhz), divide by 2 and multiply by 9 to
   * get maximum allowed frequency: 36Mhz
   * Enable PLL, wait till it's stable, then select it as system clock*/
  RCC_PLLConfig(RCC_PLLSource_HSI_Div2, RCC_PLLMul_12);
  RCC_PLLCmd(ENABLE);
  while(RCC_GetFlagStatus(RCC_FLAG_PLLRDY) == RESET);
  RCC_SYSCLKConfig(RCC_SYSCLKSource_PLLCLK);

  /* Set HCLK, PCLK1, and PCLK2 to SCLK (these are default */
  RCC_HCLKConfig(RCC_SYSCLK_Div1);
  RCC_PCLK1Config(RCC_HCLK_Div1);
  RCC_PCLK2Config(RCC_HCLK_Div1);
}

/**
   * @brief  print debug msg 
   * @param  None
   * @retval None
   */
uint32_t  DbgCfgPrintf(const uint8_t *format, ...)
{
	#if DEBUG_MODE
	static  uint8_t  buffer[256];
	uint32_t len,i;
	va_list     vArgs;		    
	va_start(vArgs, format);
	len = vsprintf((char *)&buffer[0], (char const *)format, vArgs);
	va_end(vArgs);
	if(len >= 255) len = 255;
	for(i = 0;i < len; i++)
	{
		{
			USART1_PutChar(buffer[i]);
		}
	}
	#endif
	return 0;
}
/*****END OF FILE****/
