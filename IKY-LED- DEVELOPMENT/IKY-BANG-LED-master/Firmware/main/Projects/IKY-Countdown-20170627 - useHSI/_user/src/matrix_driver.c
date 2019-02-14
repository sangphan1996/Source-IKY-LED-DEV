#include "stm32f10x.h"
#include "matrix_driver.h"
#include <string.h>
#include "logger.h"
#include "system_config.h"
#include "sys_tick.h"

#define MT_SCAN_DELAY				20

void MaTrix_Column_Select(uint8_t Col);
void MaTrix_VRam_Update(void);
//
LEDMatrix_Typedef LEDMatrix;
const uint8_t Row_Code[] =
{
0x00,
0x04,0x02,0x08,0x01,0x40,0x10,0x80,0x20
};

const uint8_t MaTrix_Column_Code[][6] =
{
{0x00,0x00,0x00,0x00,0x00,0x00}, //0

{0x00,0x00,0x00,0x00,0x00,0x20}, //48
{0x00,0x00,0x00,0x00,0x00,0x01}, //47
{0x00,0x00,0x00,0x00,0x00,0x02}, //46
{0x00,0x00,0x00,0x00,0x00,0x08}, //45
{0x00,0x00,0x00,0x00,0x00,0x04}, //44
{0x00,0x00,0x00,0x00,0x00,0x10}, //43
{0x00,0x00,0x00,0x00,0x00,0x40}, //42
{0x00,0x00,0x00,0x00,0x00,0x80}, //41

{0x00,0x00,0x00,0x00,0x20,0x00}, //40
{0x00,0x00,0x00,0x00,0x01,0x00}, //39
{0x00,0x00,0x00,0x00,0x02,0x00}, //38
{0x00,0x00,0x00,0x00,0x08,0x00}, //37
{0x00,0x00,0x00,0x00,0x04,0x00}, //36
{0x00,0x00,0x00,0x00,0x10,0x00}, //35
{0x00,0x00,0x00,0x00,0x40,0x00}, //34
{0x00,0x00,0x00,0x00,0x80,0x00}, //33

{0x00,0x00,0x00,0x20,0x00,0x00}, //32
{0x00,0x00,0x00,0x01,0x00,0x00}, //31
{0x00,0x00,0x00,0x02,0x00,0x00}, //30
{0x00,0x00,0x00,0x08,0x00,0x00}, //29
{0x00,0x00,0x00,0x04,0x00,0x00}, //28
{0x00,0x00,0x00,0x10,0x00,0x00}, //27
{0x00,0x00,0x00,0x40,0x00,0x00}, //26
{0x00,0x00,0x00,0x80,0x00,0x00}, //25

{0x00,0x00,0x20,0x00,0x00,0x00}, //24
{0x00,0x00,0x01,0x00,0x00,0x00}, //23
{0x00,0x00,0x02,0x00,0x00,0x00}, //22
{0x00,0x00,0x08,0x00,0x00,0x00}, //21
{0x00,0x00,0x04,0x00,0x00,0x00}, //20
{0x00,0x00,0x10,0x00,0x00,0x00}, //19
{0x00,0x00,0x40,0x00,0x00,0x00}, //18
{0x00,0x00,0x80,0x00,0x00,0x00}, //17

{0x00,0x20,0x00,0x00,0x00,0x00}, //16
{0x00,0x01,0x00,0x00,0x00,0x00}, //15
{0x00,0x02,0x00,0x00,0x00,0x00}, //14
{0x00,0x08,0x00,0x00,0x00,0x00}, //13
{0x00,0x04,0x00,0x00,0x00,0x00}, //12
{0x00,0x10,0x00,0x00,0x00,0x00}, //11
{0x00,0x40,0x00,0x00,0x00,0x00}, //10
{0x00,0x80,0x00,0x00,0x00,0x00}, //9

{0x20,0x00,0x00,0x00,0x00,0x00}, //8
{0x01,0x00,0x00,0x00,0x00,0x00}, //7
{0x02,0x00,0x00,0x00,0x00,0x00}, //6
{0x08,0x00,0x00,0x00,0x00,0x00}, //5
{0x04,0x00,0x00,0x00,0x00,0x00}, //4
{0x10,0x00,0x00,0x00,0x00,0x00}, //3
{0x40,0x00,0x00,0x00,0x00,0x00}, //2
{0x80,0x00,0x00,0x00,0x00,0x00}, //1
};

const uint8_t MaTrix_Code_Table[97][6]={
              0x00,0x00,0x00,0x00,0x00,0x00,//  SPACE 0
              0x00,0x00,0x3D,0x00,0x00,0x00,//  ! 1
              0xFF,0xFF,0xF8,0xF4,0xFF,0xFF,//  ' 2
              0xEB,0x80,0xEB,0x80,0xEB,0xFF,//  # 3
              0xDB,0xD5,0x80,0xD5,0xED,0xFF,//  $ 4
              0x62,0x64,0x08,0x13,0x23,0x00,//  % 5
              0x36,0x49,0x55,0x22,0x05,0x00,//  & 6
              0x00,0x50,0x60,0x00,0x00,0x00,//  ' 7
              0x00,0x1C,0x22,0x41,0x00,0x00,//  ( 8
              0x00,0x41,0x22,0x1C,0x00,0x00,//  ) 9
              0x14,0x08,0x3E,0x08,0x14,0x00,//  * 10
              0x08,0x08,0x3E,0x08,0x08,0x00,//  + 11
              0x00,0x05,0x06,0x00,0x00,0x00,//  , 12
              0x08,0x08,0x08,0x08,0x08,0x00,//  - 13
              0x00,0x03,0x03,0x00,0x00,0x00,//  x 14
              0x02,0x04,0x08,0x10,0x20,0x00,//  / 15
              0x3E,0x45,0x49,0x51,0x3E,0x00,//  0 16
              0x00,0x21,0x7F,0x01,0x00,0x00,//  1 17
              0x21,0x43,0x45,0x49,0x31,0x00,//  2 18
              0x42,0x41,0x51,0x69,0x46,0x00,//  3 19
              0x0C,0x14,0x24,0x7F,0x04,0x00,//  4 20
              0x72,0x51,0x51,0x51,0x4E,0x00,//  5 21
              0x1E,0x29,0x49,0x49,0x06,0x00,//  6 22
              0x40,0x47,0x48,0x50,0x60,0x00,//  7 23
              0x36,0x49,0x49,0x49,0x36,0x00,//  8 24
              0x30,0x49,0x49,0x4A,0x3C,0x00,//  9 25
              0x00,0x36,0x36,0x00,0x00,0x00,//  : 26
              0xFF,0xA4,0xC4,0xFF,0xFF,0xFF,//  // 27
              0xF7,0xEB,0xDD,0xBE,0xFF,0xFF,//  < 28
              0x14,0x14,0x14,0x14,0x14,0x00,//  = 29
              0xFF,0xBE,0xDD,0xEB,0xF7,0xFF,//  > 30
              0x20,0x40,0x45,0x48,0x30,0x00,//  ? 31
              0x46,0x89,0x8F,0x81,0x7E,0x00,//  @ 32
              0x3F,0x44,0x44,0x44,0x3F,0x00,//  A 33
              0x7F,0x49,0x49,0x49,0x36,0x00,//  B 34
              0x3E,0x41,0x41,0x41,0x22,0x00,//  C 35
              0x7F,0x41,0x41,0x22,0x1C,0x00,//  D 36
              0x7F,0x49,0x49,0x49,0x49,0x00,//  E 37
              0x7F,0x48,0x48,0x48,0x00,0x00,//  F 38
              0x3E,0x41,0x49,0x49,0x2F,0x00,//  G 39
              0x7F,0x08,0x08,0x08,0x7F,0x00,//  H 40
              0x41,0x41,0x7F,0x41,0x41,0x00,//  I 41
              0x02,0x01,0x41,0x7E,0x40,0x00,//  J 42
              0x7F,0x08,0x14,0x22,0x41,0x00,//  K 43
              0x7F,0x01,0x01,0x01,0x01,0x00,//  L 44
              0x7F,0x20,0x10,0x20,0x7F,0x00,//  M 45
              0x7F,0x10,0x08,0x04,0x7F,0x00,//  N 46
              0x3E,0x41,0x41,0x41,0x3E,0x00,//  O 47
              0x7F,0x48,0x48,0x48,0x30,0x00,//  P 48
              0x3E,0x41,0x45,0x42,0x3D,0x00,//  Q 49
              0x7F,0x48,0x4C,0x4A,0x31,0x00,//  R 50
              0x31,0x49,0x49,0x49,0x46,0x00,//  S 51
              0x40,0x40,0x7F,0x40,0x40,0x00,//  T 52
              0x7E,0x01,0x01,0x01,0x7E,0x00,//  U 53
              0x7C,0x02,0x01,0x02,0x7C,0x00,//  V 54
              0x7E,0x01,0x0E,0x01,0x7E,0x00,//  W 55
              0x63,0x14,0x08,0x14,0x63,0x00,//  X 56
              0x70,0x08,0x07,0x08,0x70,0x00,//  Y 57
              0x43,0x45,0x49,0x51,0x61,0x00,//  Z 58
              0xFF,0x80,0xBE,0xBE,0xFF,0xFF,//  [ 59
              0xFD,0xFB,0xF7,0xEF,0xDF,0xFF,//  \ 60
              0xFF,0xBE,0xBE,0x80,0xFF,0xFF,//  ] 61
              0x10,0x20,0x40,0x20,0x10,0x00,//  ^ 92
              0x01,0x01,0x01,0x01,0x01,0x00,//  _ 63
              0xFF,0xFF,0xF8,0xF4,0xFF,0xFF,//  ' 64
              0x02,0x15,0x15,0x15,0x0F,0x00,//  a 65
              0x7F,0x05,0x09,0x09,0x06,0x00,//  b 66
							0x0E,0x11,0x11,0x11,0x02,0x00,//  c 67
							0x06,0x09,0x09,0x05,0x7F,0x00,//  d 68
							0x0E,0x15,0x15,0x15,0x0C,0x00,//  e 69
							0x08,0x3F,0x48,0x40,0x20,0x00,//  f 70
							0x18,0x25,0x25,0x25,0x3E,0x00,//  g 71
							0x7F,0x08,0x10,0x10,0x0F,0x00,//  h 72
							0x00,0x00,0x2F,0x00,0x00,0x00,//  i 73
							0x02,0x01,0x01,0x5E,0x00,0x00,//  j 74
							0x7F,0x04,0x0A,0x11,0x00,0x00,//  k 75
							0x00,0x41,0x7F,0x01,0x00,0x00,//  l 76
							0x1F,0x10,0x0C,0x10,0x0F,0x00,//  m 77
							0x1F,0x08,0x10,0x10,0x0F,0x00,//  n 78
							0x0E,0x11,0x11,0x11,0x0E,0x00,//  o 79
							0x1F,0x14,0x14,0x14,0x08,0x00,//  p 80
							0x08,0x14,0x14,0x0C,0x1F,0x00,//  q 81
							0x1F,0x08,0x10,0x10,0x08,0x00,//  r 82
							0x09,0x15,0x15,0x15,0x02,0x00,//  s 83
							0x10,0x7E,0x11,0x01,0x02,0x00,//  t 84
							0x1E,0x01,0x01,0x02,0x1F,0x00,//  u 85
							0x1C,0x02,0x01,0x02,0x1C,0x00,//  v 86
              0x1E,0x01,0x06,0x01,0x1E,0x00,//  w 87
              0x11,0x0A,0x04,0x0A,0x11,0x00,//  x 88
              0x18,0x05,0x05,0x05,0x1E,0x00,//  y 89
              0x11,0x13,0x15,0x19,0x11,0x00,//  z 90
              0xFB,0xE1,0xE0,0xE1,0xFB,0xFF,//  ^ 62
              0xE3,0xE3,0xC1,0xE3,0xF7,0xFF,//  -> 93
              0xF7,0xE3,0xC1,0xE3,0xE3,0xFF,//  <- 94
              0xEF,0xC3,0x83,0xC3,0xEF,0xFF,//         95
              0x00,0x00,0x00,0x00,0x00,0x00,//  BLANK CHAR 96
};



uint8_t MaTrix_Row_Code_Convert(uint8_t Data)
{
	uint8_t i;
	uint8_t rs = 0;
	//
	for(i=0;i<8;i++) {	
		if ((Data >> i) & 0x01)
				rs |= Row_Code[i+1];	
	}
	#if(MATRIX_CELL_ON)
	return (rs);
	#else
	return (~rs);
	#endif
}	

void MT_Delay(uint32_t nTime)
{ 
	while(nTime--);
}

void TIMER3_Init(void)
{
	TIM_TimeBaseInitTypeDef TIM_TimeBaseStructure;
	NVIC_InitTypeDef NVIC_InitStructure;
  TIM_DeInit(TIM3);
  TIM_TimeBaseStructInit(&TIM_TimeBaseStructure);
    /* TIM5 clock enable */
  RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM3, ENABLE);
  /* Time base configuration */
  TIM_TimeBaseStructure.TIM_Prescaler = 1200 - 1; // 48 MHz / 1200 = 40 KHz
  TIM_TimeBaseStructure.TIM_Period = 17 - 1;  // 40 KHz / 20 = 2 KHz;
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

void MaTrix_IOInit(void)
{
	GPIO_InitTypeDef GPIO_InitStructure;
	
	GPIO_InitStructure.GPIO_Pin = LED_MATRIX_COL_LATCH_PIN;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_10MHz;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP; 
	GPIO_Init( LED_MATRIX_COL_LATCH_PORT, &GPIO_InitStructure );
	
	GPIO_InitStructure.GPIO_Pin = LED_MATRIX_COL_DAT_PIN; 
	GPIO_Init( LED_MATRIX_COL_DAT_PORT, &GPIO_InitStructure );
	
	GPIO_InitStructure.GPIO_Pin = LED_MATRIX_COL_CLK_PIN;
	GPIO_Init( LED_MATRIX_COL_CLK_PORT, &GPIO_InitStructure );

	GPIO_InitStructure.GPIO_Pin = LED_MATRIX_COL_RESET_PIN;
	GPIO_Init( LED_MATRIX_COL_RESET_PORT, &GPIO_InitStructure );
	//Row	
	GPIO_InitStructure.GPIO_Pin = LED_MATRIX_ROW_CLK_PIN; 
	GPIO_Init( LED_MATRIX_ROW_CLK_PORT, &GPIO_InitStructure );
	
	GPIO_InitStructure.GPIO_Pin = LED_MATRIX_ROW_LATCH_PIN; 
	GPIO_Init( LED_MATRIX_ROW_LATCH_PORT, &GPIO_InitStructure );
	
	GPIO_InitStructure.GPIO_Pin = LED_MATRIX_ROW_DAT_PIN; 
	GPIO_Init( LED_MATRIX_ROW_DAT_PORT, &GPIO_InitStructure );
	
	GPIO_InitStructure.GPIO_Pin = LED_MATRIX_ROW_RESET_PIN; 
	GPIO_Init( LED_MATRIX_ROW_RESET_PORT, &GPIO_InitStructure );
	//
	GPIO_ResetBits(LED_MATRIX_COL_RESET_PORT,LED_MATRIX_COL_RESET_PIN);
	//
	GPIO_ResetBits(LED_MATRIX_ROW_RESET_PORT,LED_MATRIX_ROW_RESET_PIN);
	//	
	MaTrix_Row_WriteData(0);
	MaTrix_Column_Select(0);
	//
	TIMER3_Init();
}

void MaTrix_StringUpdate(uint8_t * newString,uint8_t len)
{	
	if(len >= sizeof(LEDMatrix.buffer_1)) return;
	memset(sysCfg.GuestInf,0,sizeof(sysCfg.GuestInf));
	memcpy(sysCfg.GuestInf,newString,len);
	strcat((char*)sysCfg.GuestInf,GFX_STRING_SPACING);	
	saveConfigFlag = 1;	
}

void MaTrix_Column_Clear(void)
{
	GPIO_SetBits(LED_MATRIX_COL_RESET_PORT,LED_MATRIX_COL_RESET_PIN);
	GPIO_ResetBits(LED_MATRIX_COL_CLK_PORT,LED_MATRIX_COL_CLK_PIN);
	MT_Delay(MT_SCAN_DELAY);
	GPIO_SetBits(LED_MATRIX_COL_CLK_PORT,LED_MATRIX_COL_CLK_PIN);	
	MT_Delay(MT_SCAN_DELAY);
	GPIO_ResetBits(LED_MATRIX_COL_LATCH_PORT,LED_MATRIX_COL_LATCH_PIN);	
	MT_Delay(MT_SCAN_DELAY);
	GPIO_SetBits(LED_MATRIX_COL_LATCH_PORT,LED_MATRIX_COL_LATCH_PIN);
	GPIO_ResetBits(LED_MATRIX_COL_RESET_PORT,LED_MATRIX_COL_RESET_PIN);	
}

void MaTrix_Row_WriteData(uint8_t Data)
{
	uint8_t i;
	for(i=0;i<8;i++) 
	{
		if ((Data >> i) & 0x01)
				GPIO_ResetBits(LED_MATRIX_ROW_DAT_PORT,LED_MATRIX_ROW_DAT_PIN);				
		else 
				GPIO_SetBits(LED_MATRIX_ROW_DAT_PORT,LED_MATRIX_ROW_DAT_PIN);
		//
		GPIO_ResetBits(LED_MATRIX_ROW_CLK_PORT,LED_MATRIX_ROW_CLK_PIN);
		MT_Delay(MT_SCAN_DELAY);
		GPIO_SetBits(LED_MATRIX_ROW_CLK_PORT,LED_MATRIX_ROW_CLK_PIN);
	}
	GPIO_ResetBits(LED_MATRIX_ROW_LATCH_PORT,LED_MATRIX_ROW_LATCH_PIN);
	MT_Delay(MT_SCAN_DELAY);
	GPIO_SetBits(LED_MATRIX_ROW_LATCH_PORT,LED_MATRIX_ROW_LATCH_PIN);
}	

void MaTrix_Column_WriteData(uint8_t *Data)
{
	uint8_t i=0,j=0;
	for(j=0;j<MATRIX_8x8_NUM;j++)
	{
		for(i=0;i<8;i++)
		{
			if ((Data[j] >> i) & 0x01)
				GPIO_ResetBits(LED_MATRIX_COL_DAT_PORT,LED_MATRIX_COL_DAT_PIN);				
			else
				GPIO_SetBits(LED_MATRIX_COL_DAT_PORT,LED_MATRIX_COL_DAT_PIN);
			//
			GPIO_ResetBits(LED_MATRIX_COL_CLK_PORT,LED_MATRIX_COL_CLK_PIN);
			MT_Delay(MT_SCAN_DELAY);
			GPIO_SetBits(LED_MATRIX_COL_CLK_PORT,LED_MATRIX_COL_CLK_PIN);
		}
	}
	GPIO_ResetBits(LED_MATRIX_COL_LATCH_PORT,LED_MATRIX_COL_LATCH_PIN);	
	MT_Delay(MT_SCAN_DELAY);
	GPIO_SetBits(LED_MATRIX_COL_LATCH_PORT,LED_MATRIX_COL_LATCH_PIN);
}

void MaTrix_Column_Select(uint8_t Col)
{
	MaTrix_Column_WriteData((uint8_t*)&MaTrix_Column_Code[Col][0]);
}

void MaTrix_VRam_Update(void)
{
  uint8_t i;
  uint8_t u8Code;
  uint8_t selFont;
  uint8_t colFont;
  //
  for(i=0; i<(MATRIX_8x8_NUM*8); i++)
  {
    selFont = LEDMatrix.buffer_1[((i+LEDMatrix.column_pos)%LEDMatrix.strlen)/WIDTH_OF_FONT]- ' ';
    colFont = (i+LEDMatrix.column_pos)%WIDTH_OF_FONT;
    u8Code = MaTrix_Code_Table[selFont][colFont];
    //        
    LEDMatrix.dram_2[i] = MaTrix_Row_Code_Convert(u8Code);    
  }
	__disable_irq();
  memcpy(LEDMatrix.dram_1,LEDMatrix.dram_2,sizeof(LEDMatrix.dram_1));
	__enable_irq();
}



void MaTrix_Scan(void)
{
	static uint8_t u8Index1 = 0;
	if(LEDMatrix.enable == 0)
	{
		u8Index1 = 0;
		LEDMatrix.column_shift = 0;
		LEDMatrix.column_pos = 0;		
		return;
	}
	MaTrix_Column_Clear();
	MaTrix_Row_WriteData(LEDMatrix.dram_1[u8Index1]);
	MaTrix_Column_Select(u8Index1+1);
	u8Index1 ++;
	if(u8Index1 >= (MATRIX_8x8_NUM*8))
	{
		u8Index1 = 0;
	}
}

void MaTrix_ColPos_Callback(void)
{
	if(LEDMatrix.effect == 0)
	{
		LEDMatrix.column_shift = 0;
		LEDMatrix.column_pos = 0;
		return;
	}
	LEDMatrix.column_shift++;
	if((LEDMatrix.column_shift % 150) == 0)
	{
		LEDMatrix.column_pos++;
		if(LEDMatrix.column_pos >= LEDMatrix.strlen)
		{
			LEDMatrix.column_pos = 0;
		}		
		MaTrix_VRam_Update();
	}
}

void TIM3_IRQHandler(void)
{
	if (TIM_GetITStatus(TIM3, TIM_IT_Update) != RESET)
	{
		MaTrix_Scan();
		TIM_ClearITPendingBit(TIM3, TIM_IT_Update);
	}
}
/*******************************************************************************
	*END FILE
********************************************************************************/
