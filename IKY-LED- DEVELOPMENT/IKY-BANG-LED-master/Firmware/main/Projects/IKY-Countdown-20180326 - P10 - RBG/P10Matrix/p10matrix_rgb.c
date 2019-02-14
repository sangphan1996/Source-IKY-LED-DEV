

#include "stm32f10x.h"
#include "p10matrix_rgb.h"
#include "hw_config.h"
#include "sys_tick.h"
#include "framebuffer.h"


#define COLOR_1_PORT		HUB75_R1_PORT
#define COLOR_1_PIN			HUB75_R1_PIN

#define COLOR_2_PORT		HUB75_R2_PORT
#define COLOR_2_PIN			HUB75_R2_PIN

uint8_t p10RGB_ch = 0;
uint32_t toggleTick = 0;
uint32_t toggleStatus = 0;

void p10RGB_timer_init(uint32_t period)
{
	TIM_TimeBaseInitTypeDef TIM_TimeBaseStructure;
	NVIC_InitTypeDef NVIC_InitStructure;
  TIM_DeInit(TIM3);
  TIM_TimeBaseStructInit(&TIM_TimeBaseStructure);
	/* Clock enable */
  RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM3, ENABLE);
  /* Time base configuration */
  TIM_TimeBaseStructure.TIM_Prescaler = 48 - 1; // 48 MHz / 1200 = 40 KHz
  TIM_TimeBaseStructure.TIM_Period = period - 1;  // 40 KHz / 20 = 2 KHz;
  TIM_TimeBaseStructure.TIM_ClockDivision = 0;
  TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up;
  TIM_TimeBaseInit(TIM3, &TIM_TimeBaseStructure);
    
  TIM_Cmd(TIM3, ENABLE);	
	TIM_ClearITPendingBit(TIM3, TIM_IT_Update);  
  TIM_ITConfig(TIM3, TIM_IT_Update, ENABLE);
      
  NVIC_InitStructure.NVIC_IRQChannel = TIM3_IRQn;
  NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 1;
  NVIC_InitStructure.NVIC_IRQChannelSubPriority = 1;
  NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
  NVIC_Init(&NVIC_InitStructure);
}

void p10RGB_PinModeOutput(GPIO_TypeDef* port,uint16_t pin)
{
	GPIO_InitTypeDef GPIO_InitStructure;
	
	GPIO_InitStructure.GPIO_Pin = pin;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_Init(port, &GPIO_InitStructure );
}

void p10RGB_pinout_init(void)
{
	p10RGB_PinModeOutput(HUB75_OE_PORT,HUB75_OE_PIN);
	p10RGB_PinModeOutput(HUB75_LAT_PORT,HUB75_LAT_PIN);
	p10RGB_PinModeOutput(HUB75_CLK_PORT,HUB75_CLK_PIN);
	
	p10RGB_PinModeOutput(HUB75_A_PORT,HUB75_A_PIN);
	p10RGB_PinModeOutput(HUB75_B_PORT,HUB75_B_PIN);
	p10RGB_PinModeOutput(HUB75_C_PORT,HUB75_C_PIN);
	
	p10RGB_PinModeOutput(HUB75_R1_PORT,HUB75_R1_PIN);
	p10RGB_PinModeOutput(HUB75_R2_PORT,HUB75_R2_PIN);
	p10RGB_PinModeOutput(HUB75_G1_PORT,HUB75_G1_PIN);
	p10RGB_PinModeOutput(HUB75_G2_PORT,HUB75_G2_PIN);
	p10RGB_PinModeOutput(HUB75_B1_PORT,HUB75_B1_PIN);
	p10RGB_PinModeOutput(HUB75_B2_PORT,HUB75_B2_PIN);
	
	p10RGB_DispOff();
	
	GPIO_ResetBits(HUB75_R1_PORT,HUB75_R1_PIN);
	GPIO_ResetBits(HUB75_R2_PORT,HUB75_R2_PIN);
	
	GPIO_ResetBits(HUB75_G1_PORT,HUB75_G1_PIN);
	GPIO_ResetBits(HUB75_G2_PORT,HUB75_G2_PIN);
	
	GPIO_ResetBits(HUB75_B1_PORT,HUB75_B1_PIN);
	GPIO_ResetBits(HUB75_B2_PORT,HUB75_B2_PIN);	
}

void p10RGB_begin(void)
{
	p10RGB_pinout_init();	
	p10RGB_timer_init(500);
}

void p10RGB_Scan(void)
{
	uint8_t i;	
	uint32_t 	rowR1;
	uint32_t 	rowR2;
	
		
	p10RGB_DispOff();
		
	rowR2 = (framebuffer_displaybuffer[p10RGB_ch + 48])
						|	(framebuffer_displaybuffer[p10RGB_ch + 32] <<8)
						| (framebuffer_displaybuffer[p10RGB_ch + 16] <<16)
						| (framebuffer_displaybuffer[p10RGB_ch] <<24);
					
	
	rowR1 = (framebuffer_displaybuffer[p10RGB_ch + 56])
						| (framebuffer_displaybuffer[p10RGB_ch + 40] <<8)
						|	(framebuffer_displaybuffer[p10RGB_ch + 24] <<16) 
						|	(framebuffer_displaybuffer[p10RGB_ch + 8] <<24);
	
	
		
	for(i=0;i<32;i++)
	{
			if((rowR1<<i) & 0x80000000)
			{
				GPIO_ResetBits(COLOR_1_PORT,COLOR_1_PIN);	
			}
			else
			{
				GPIO_SetBits(COLOR_1_PORT,COLOR_1_PIN);			
			}
			
			if((rowR2<<i) & 0x80000000)
			{
				GPIO_ResetBits(COLOR_2_PORT,COLOR_2_PIN);	
			}
			else
			{
				GPIO_SetBits(COLOR_2_PORT,COLOR_2_PIN);			
			}
			
			p10RGB_Pulse();  //Pulse the Clock line	
	}
					
	p10RGB_Latch();
   
	p10RGB_SelCh(7-p10RGB_ch);
	
	p10RGB_DispOn();
   
	if(++p10RGB_ch == 8) 
	{
			p10RGB_ch = 0;
	}	 
}

void p10RGB_SelCh(uint8_t ch)
{
	(ch & 0x01) ? GPIO_SetBits(HUB75_A_PORT , HUB75_A_PIN): GPIO_ResetBits(HUB75_A_PORT , HUB75_A_PIN);	
	(ch & 0x02) ? GPIO_SetBits(HUB75_B_PORT , HUB75_B_PIN): GPIO_ResetBits(HUB75_B_PORT , HUB75_B_PIN);	
	(ch & 0x04) ? GPIO_SetBits(HUB75_C_PORT , HUB75_C_PIN): GPIO_ResetBits(HUB75_C_PORT , HUB75_C_PIN);
}

void p10RGB_DispOff(void)
{
		GPIO_SetBits(HUB75_OE_PORT,HUB75_OE_PIN);
}

void p10RGB_DispOn(void)
{
		GPIO_ResetBits(HUB75_OE_PORT,HUB75_OE_PIN);
}


void p10RGB_Pulse(void)
{
    GPIO_SetBits(HUB75_CLK_PORT,HUB75_CLK_PIN);
    GPIO_ResetBits(HUB75_CLK_PORT,HUB75_CLK_PIN);
}

void p10RGB_Latch(void)
{
   GPIO_SetBits(HUB75_LAT_PORT,HUB75_LAT_PIN);
   GPIO_ResetBits(HUB75_LAT_PORT,HUB75_LAT_PIN);
}


