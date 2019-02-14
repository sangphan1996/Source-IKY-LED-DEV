#include "stm32f10x.h"
#include "logger.h"
#include "system_config.h"
#include "cc1101_receiver.h"
#include "display_task.h"
#include "cc1101_parser.h"
#include "hw_config.h"
#include "sys_tick.h"
#include "display_task.h"
#include "p10matrix.h"
#include "p10matrix_rgb.h"
#include "framebuffer.h"

#define MAIN_LOG(...)  			NRF_LOG_PRINTF(__VA_ARGS__)
#define BUTTON_TIMEOUT			SYSTICK_TIME_MS(500)

Timeout_Type tButtonTimeout;
uint8_t btn1Cnt = 0;
uint8_t remoteIndex = 0;

void Delay(__IO uint32_t nCount);
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
	
	if (SysTick_Config(SystemCoreClock / 1000))
	{
			__disable_irq();
			NVIC_SystemReset();
	}
	CFG_Load();
	Show_RST_Flag();
	IWDGInit();
	DisplayTask_Init();
	frameInit();
	p10RGB_begin();
//	p10matrix_begin();
	
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
		RfRecive_Task();
		rfParserTask();
		CFG_Task();
		DisplayTask();
		ScrollMsgTask();
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
					if(displayState == DISP_SELFTEST)
					{
						displayState = DISP_HOME;
					}
					if(displayState == DISP_SETUP_ID)
					{
						sysCfg.DevID++;
					}
				}
				else if(btn1Cnt == 2)
				{
					if(displayState == DISP_HOME)
					{
						sysCfg.DevID = 1;
						displayState = DISP_SETUP_ID;
					}
					else if(displayState == DISP_SETUP_ID)
					{
						displayState = DISP_HOME;
						saveConfigFlag = 1;
					}
				}
				else if(btn1Cnt == 5)
				{
//						sprintf((char*)sysCfg.GuestInf,"DO VAN HAI 81B122821");				
//											
//						TotalDuration = 30;
//						TimeStart = SysTick_GetSec(); 
//						
//						displayState = DISP_COUNTDOWN;
//						
//						saveConfigFlag = 1;	
					
//						InitTimeout(&tDispCheckOut,SYSTICK_TIME_SEC(5));
//						displayState = DISP_CHECKOUT;
//						sprintf((char*)sysCfg.CheckOut,"HEN GAP LAI");						
				}
				btn1Cnt = 0;
    }
}


void Show_RST_Flag( void )
{
	if (RCC_GetFlagStatus(RCC_FLAG_PINRST) != RESET) 
	{
		MAIN_LOG("External Reset occurred....\r\n");
	}
  if (RCC_GetFlagStatus(RCC_FLAG_PORRST) != RESET)  
	{
    MAIN_LOG("Power On Reset occurred....\r\n");
  }
  if (RCC_GetFlagStatus(RCC_FLAG_SFTRST) != RESET)  
	{
    MAIN_LOG("Software reset occurred....\r\n");
  }
	if (RCC_GetFlagStatus(RCC_FLAG_IWDGRST) != RESET) 
	{		
		MAIN_LOG("Reset by IWDG...\r\n");
	}
	if (RCC_GetFlagStatus(RCC_FLAG_WWDGRST) != RESET) 
	{
		MAIN_LOG("Reset by WWDG...\r\n");
	}
	if (RCC_GetFlagStatus(RCC_FLAG_LPWRRST) != RESET) 
	{
		MAIN_LOG("Reset by Low-power management...\r\n");
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

void Delay(__IO uint32_t nCount)
{
  while(nCount--)
  {
  }
}
/*****END OF FILE****/
