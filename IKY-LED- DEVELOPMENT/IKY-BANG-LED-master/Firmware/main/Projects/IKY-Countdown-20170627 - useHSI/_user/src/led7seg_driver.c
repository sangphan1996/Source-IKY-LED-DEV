#include "led7seg_driver.h"
#include "sys_tick.h"
/*******************************************************************************
	Constant variables
 ******************************************************************************/
const uint8_t Led7SegCodeDis[]={
    0x00,// SPACE 0
0xFF,// ! 1
0xFF,// ' 2
0xEB,// # 3
0xDB,// $ 4
0xD8,// % 5
0xC9,// & 6
0xFF,// ' 7
0xFF,// ( 8
0xFF,// ) 9
0xD5,// * 10
0xF7,// + 11
    0xfe,// , 12
    0x80,// - 13
0xFF,// x 14
0xFF,// / 15
/*---------------------*/
    0x5F,  /*0*/
    0x09,  /*1*/
    0x9E,  /*2*/
    0x9B,  /*3*/
    0xC9,  /*4*/
    0xD3,  /*5*/
    0xD7,  /*6*/
    0x19,  /*7*/
    0xDF,  /*8*/
    0xDB,  /*9*/
/*---------------------*/
0xFF,// : 26
0xFF,// ; 27
0xF7,// < 28
0xEB,// = 29
0xFF,// > 30
0xFD,// ? 31
0xCD,// @ 32
/*---------------------*/
    0x35,// A 33
0xBE,// B 34
    0x35,// C 35
0xBE,// D 36
		0x79,// E 37
    0x17,// F 38
0xC1,// G 39
    0x76,// H 40
0x90,// I 41
    0xe9,// J 42
0x80,// K 43
    0x38,// L 44
0x80,// M 45
0x35,// N 46
		0x3F,// O 47
    0x07,// P 48
0xC1,// Q 49
0x80,// R 50
    0x19,// S 51 
0xFE,// T 52
    0x61,// U 53
0xE0,// V 54
0xC0,// W 55
0x9C,// X 56
0xFC,// Y 57
0x9E,// Z 58
0xFF,// [ 59
0xFD,// \ 60
0xFF,// ] 61
0xFB,// ^ 92
0x40,// _ 63
0xFF,// ' 64
0xDF,// a 65
    0x51,// b   66
    0xd5,// c   67
    0x8F,// d   68
0xC7,// e 69
0xF7,// f   70
0xF7,// g 71
0x53,// h 72
0x01,// i 73
0xDF,// j 74
0xFF,// k 75
0xFF,// l 76
0x83,// m 77
0xd3,// n 78
    0xd1,// o 79
0x83,// p 80
0xF7,// q 81
    0xd7,// r 82
0xB7,// s 83
0x55,// t 84
0xC3,// u 85
0xE3,// v 86
0xC3,// w 87
0xBB,// x 88
0xF3,// y 89
0xBB,// z 90
0xFB,// ^ 62
0xE3,// -> 93
0xF7,// <- 94
0xEF,//     95
};

#define LED7SEG_DOT_SEG			0x20
#define TIMER_PERIOD				1	//ms
#define TMR2_PRIORITY				4


LED7Seg_Typedef LED7Seg;

void TIMER2_Init(uint32_t pclk);
void L7S_Delay(uint32_t nTime);
	
void L7S_Delay(uint32_t nTime)
{ 
	while(nTime--);
}

void Led7Seg_Init(void)
{
	GPIO_InitTypeDef GPIO_InitStructure;
	//
	GPIO_InitStructure.GPIO_Pin = LED_7SEG_1_PIN;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_10MHz;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP; 
	GPIO_Init(LED_7SEG_1_PORT, &GPIO_InitStructure );
	//
	GPIO_InitStructure.GPIO_Pin = LED_7SEG_2_PIN; 
	GPIO_Init(LED_7SEG_2_PORT, &GPIO_InitStructure );
	//
	GPIO_InitStructure.GPIO_Pin = LED_7SEG_3_PIN; 
	GPIO_Init(LED_7SEG_3_PORT, &GPIO_InitStructure );
	//
	GPIO_InitStructure.GPIO_Pin = LED_7SEG_4_PIN; 
	GPIO_Init(LED_7SEG_4_PORT, &GPIO_InitStructure );
	//
	GPIO_InitStructure.GPIO_Pin = LED_7SEG_CLK_PIN; 
	GPIO_Init(LED_7SEG_CLK_PORT, &GPIO_InitStructure );
	//
	GPIO_InitStructure.GPIO_Pin = LED_7SEG_DAT_PIN; 
	GPIO_Init(LED_7SEG_DAT_PORT, &GPIO_InitStructure );
	//
	GPIO_InitStructure.GPIO_Pin = LED_7SEG_LATCH_PIN; 
	GPIO_Init(LED_7SEG_LATCH_PORT, &GPIO_InitStructure );
	//
	Led7Seg_Select(0);
	TIMER2_Init(SystemCoreClock);
}

void Led7Seg_WriteData(uint8_t Data)
{	
	uint8_t i;
	for(i=0;i<8;i++) 
	{	
		if ((Data >> i) & 0x01)
				GPIO_SetBits(LED_7SEG_DAT_PORT,LED_7SEG_DAT_PIN);				
		else 
				GPIO_ResetBits(LED_7SEG_DAT_PORT,LED_7SEG_DAT_PIN);
		//
		GPIO_SetBits(LED_7SEG_CLK_PORT,LED_7SEG_CLK_PIN);
		GPIO_ResetBits(LED_7SEG_CLK_PORT,LED_7SEG_CLK_PIN);
	}
	GPIO_SetBits(LED_7SEG_LATCH_PORT,LED_7SEG_LATCH_PIN);	
	L7S_Delay(1);
	GPIO_ResetBits(LED_7SEG_LATCH_PORT,LED_7SEG_LATCH_PIN);	
}

void Led7Seg_WriteChar(uint8_t Data,uint8_t Dot)
{
	if(Dot)
		Led7Seg_WriteData(Led7SegCodeDis[Data - ' '] | LED7SEG_DOT_SEG);
	else
		Led7Seg_WriteData(Led7SegCodeDis[Data - ' ']);
}

void Led7Seg_Select(uint8_t Led)
{
	switch(Led)
	{
		case 0:
			GPIO_ResetBits(LED_7SEG_1_PORT,LED_7SEG_1_PIN);
			GPIO_ResetBits(LED_7SEG_2_PORT,LED_7SEG_2_PIN);
			GPIO_ResetBits(LED_7SEG_3_PORT,LED_7SEG_3_PIN);
			GPIO_ResetBits(LED_7SEG_4_PORT,LED_7SEG_4_PIN);
			break;
		
		case 1:
			GPIO_SetBits(LED_7SEG_1_PORT,LED_7SEG_1_PIN);
			break;
		case 2:
			GPIO_SetBits(LED_7SEG_2_PORT,LED_7SEG_2_PIN);
			break;
		case 3:
			GPIO_SetBits(LED_7SEG_3_PORT,LED_7SEG_3_PIN);
			break;
		case 4:
			GPIO_SetBits(LED_7SEG_4_PORT,LED_7SEG_4_PIN);
			break;
		
		case 0xFF:
			GPIO_SetBits(LED_7SEG_1_PORT,LED_7SEG_1_PIN);
			GPIO_SetBits(LED_7SEG_2_PORT,LED_7SEG_2_PIN);
			GPIO_SetBits(LED_7SEG_3_PORT,LED_7SEG_3_PIN);
			GPIO_SetBits(LED_7SEG_4_PORT,LED_7SEG_4_PIN);
			break;
		
		default:
			break;
	}
}

void Led7Seg_Scan(void)
{	
	if(LED7Seg.enable == 0) return;
	Led7Seg_Select(0);//turn off all led
	Led7Seg_WriteChar(LED7Seg.buffer_1[LED7Seg.scan_index - 1],(LED7Seg.dot_effect>>(LED7Seg.scan_index - 1))&0x01);//outout data
	Led7Seg_Select(LED7Seg.scan_index);//select led
	LED7Seg.scan_index++;//next led
	if(LED7Seg.scan_index > LED7SEG_NUM)LED7Seg.scan_index = 1;
}

void TIM2_IRQHandler(void)
{
	if(TIM2->SR & 1)
	{
		TIM2->SR = (uint16_t)~0x0001;
		Led7Seg_Scan();
	}
}

void TIMER2_Init(uint32_t pclk)
{		
		RCC->APB1ENR |= RCC_APB1ENR_TIM2EN;                     // enable clock for TIM2
    TIM2->PSC = (uint16_t)(pclk/1000000) - 1;            		// set prescaler
    TIM2->ARR = (uint16_t)(1000000*TIMER_PERIOD/1000 - 1);  //1ms          // set auto-reload
    TIM2->CR1 = 0;                                          // reset command register 1
    TIM2->CR2 = 0;                                          // reset command register 2
		TIM2->DIER = 1;                             
		NVIC_SetPriority (TIM2_IRQn,((0x01<<3) | TMR2_PRIORITY));
		NVIC_EnableIRQ(TIM2_IRQn);															// enable interrupt
    TIM2->CR1 |= 1;                              						// enable timer
}
/*******************************************************************************
	*END FILE
********************************************************************************/
