
/* Includes ------------------------------------------------------------------*/
#include "stm8l15x.h"
#include "main.h"
#include "rf_packet.h"
#include "uart_parser.h"
#include "uart1.h"
#include "ringbuf.h"
#include "sys_tick.h"
#include "softuart.h"

void IWDG_Config(void);

/**
  * @brief  Main program.
  * @param  None
  * @retval None
  */
void main(void)
{	
    uint8_t c;
    /* High speed internal clock prescaler: 1 */
    CLK_SYSCLKDivConfig(CLK_SYSCLKDiv_1);	
    /* Select HSI as system clock source */
    CLK_SYSCLKSourceSwitchCmd(ENABLE);
    CLK_SYSCLKSourceConfig(CLK_SYSCLKSource_HSI);		
    while (CLK_GetSYSCLKSource() != CLK_SYSCLKSource_HSI){}
    /* Enable LSI clock */
    CLK_LSICmd(ENABLE);  
    /* Wait for LSI clock to be ready */
    while (CLK_GetFlagStatus(CLK_FLAG_LSIRDY) == RESET){}
    
    Uart1_init();
    RfPacket_Init();
    IWDG_Config();
    //    
    SysTick_Init(1);
    softuart_init();
    USART1_PutString((uint8_t*)"IKY\r\n");
    while(1)
    {
      if ( softuart_kbhit(&softuart1) ) 
      {
              c = softuart_getchar(&softuart1);
              USART1_PutChar(c);
      }
      UART_GetInfo();      
      IWDG_ReloadCounter();
    }
}

/**
  * @brief  Configures the IWDG to generate a Reset if it is not refreshed at the
  *         correct time. 
  * @param  None
  * @retval None
  */
void IWDG_Config(void)
{
  /* Enable IWDG (the LSI oscillator will be enabled by hardware) */
  IWDG_Enable(); 
    
  /* Enable write access to IWDG_PR and IWDG_RLR registers */
  IWDG_WriteAccessCmd(IWDG_WriteAccess_Enable);
  
  /* IWDG configuration: IWDG is clocked by LSI = 38KHz */
  IWDG_SetPrescaler(IWDG_Prescaler_256);
  
  /* IWDG timeout = (RELOAD_VALUE + 1) * Prescaler / LSI 
                  = (254 + 1) * 256 / 38 000 
                  = 1717.6 ms */
  IWDG_SetReload((uint8_t)254);
  
  /* Reload IWDG counter */
  IWDG_ReloadCounter();
}


/**
  * @}
  */
