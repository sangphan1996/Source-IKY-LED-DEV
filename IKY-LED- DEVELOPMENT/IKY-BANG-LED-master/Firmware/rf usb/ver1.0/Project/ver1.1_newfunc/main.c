
/* Includes ------------------------------------------------------------------*/
#include "stm8l15x.h"
#include "stdio.h"
#include <stdlib.h> 
#include "main.h"
#include "rf_packet.h"
#include "uart_parser.h"
#include "uart1.h"
#include "ringbuf.h"
#include "sys_tick.h"

/* Private define ------------------------------------------------------------*/

#define CC2500_SELECT           GPIO_ResetBits(CS_PORT,CS_PIN)
#define CC2500_DESELECT         GPIO_SetBits(CS_PORT,CS_PIN)

#define BYTES_IN_RXFIFO         0x7F  

extern uint8_t rfDataIncomingFlag;
/* Private macro -------------------------------------------------------------*/

uint8_t turnOffRfFlag = 0;
uint32_t btnTick = 0;
uint8_t rfSendFlag = 0;
uint8_t u8Tmp[8]={1,2,3,4};
/* Private function prototypes -----------------------------------------------*/

#ifdef _RAISONANCE_
#define PUTCHAR_PROTOTYPE int putchar (char c)
#define GETCHAR_PROTOTYPE int getchar (void)
#elif defined (_COSMIC_)
#define PUTCHAR_PROTOTYPE char putchar (char c)
#define GETCHAR_PROTOTYPE char getchar (void)
#else /* _IAR_ */
#define PUTCHAR_PROTOTYPE int putchar (int c)
#define GETCHAR_PROTOTYPE int getchar (void)
#endif /* _RAISONANCE_ */
/* Private functions ---------------------------------------------------------*/
void Delay (uint32_t nCount);
void USART_Config(void);
void TimingDelay_Decrement(void);
void halMcuWaitUs(uint32_t uS);
void PWR_ON_CC2500(void);

uint8_t RF_ProcessInit(void);
void ForceToWORMode(void);
void WOR_SetDefault(void);
void ForceToRxMode(void);
uint8_t halSpiWrite(uint8_t addr, const uint8_t* data, uint16_t length);
uint8_t halSpiRead(uint8_t addr, uint8_t* data, uint16_t length);
uint8_t halSpiStrobe(uint8_t cmd);
void halMcuWaitUs(uint32_t uS);
void halRfResetChip(void);
void  halRfBurstConfig(uint8_t PATABLE);
uint8_t halRfGetChipId(void);
uint8_t halRfGetChipVer(void);
HAL_RF_STATUS halRfStrobe(uint8_t cmd);
uint8_t halRfReadStatusReg(uint8_t addr);
uint8_t halRfReadReg(uint8_t addr);
HAL_RF_STATUS halRfWriteReg(uint8_t addr, uint8_t data);
HAL_RF_STATUS halRfWriteFifo(const uint8_t* data, uint8_t length);
HAL_RF_STATUS halRfReadFifo(uint8_t* data, uint8_t length);
HAL_RF_STATUS halRfGetTxStatus(void);
HAL_RF_STATUS halRfGetRxStatus(void);
uint8_t halSpiWriteByte(uint8_t dat);
void IWDG_Config(void);

/**
  * @brief  Main program.
  * @param  None
  * @retval None
  */
void main(void)
{	
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
    //Software SPI
    GPIO_Init(MOSI_PORT, MOSI_PIN, GPIO_Mode_Out_PP_Low_Fast);
    GPIO_Init(SCK_PORT, SCK_PIN, GPIO_Mode_Out_PP_Low_Fast);
    GPIO_Init(CS_PORT, CS_PIN, GPIO_Mode_Out_PP_High_Fast);
    GPIO_Init(ENCC_PORT, ENCC_PIN, GPIO_Mode_Out_PP_High_Fast);
    GPIO_Init(MISO_PORT, MISO_PIN, GPIO_Mode_In_PU_No_IT);
    //
    RF_ProcessInit();
    ForceToRxMode();
    //
    disableInterrupts();
    GPIO_Init(GD0_PORT, GD0_PIN, GPIO_Mode_In_PU_IT);
    EXTI_SetPinSensitivity(GD0_EXTI, EXTI_Trigger_Falling);
    while(EXTI_GetPinSensitivity(GD0_EXTI) != EXTI_Trigger_Falling){}
    enableInterrupts();
    //
    LED_DeInit();
    RfPacket_Init();
    IWDG_Config();
    //
    SysTick_Init(1);
    USART1_PutString((uint8_t*)"ABC\r\n");
    while(1)
    {
      rfSendFlag = UART_GetInfo();
      rfSend_Task();
      if(rfSendFlag){
        rfSendFlag = 0;
        RfPacket_Send();
      }
      if(rfDataIncomingFlag)
      {
        rfDataIncomingFlag = 0;
        USART1_PutString("rfDataIncomingFlag\r\n");
      }
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
  * @brief  Inserts a delay time.
  * @param  nTime: specifies the delay time length, in milliseconds.
  * @retval None
  */
void Delay(uint32_t nTime)
{
  uint32_t i;
  for(i=0;i<nTime;i++){};
}
void PWR_ON_CC2500(void)
{
		GPIO_SetBits(ENCC_PORT, ENCC_PIN);
		halMcuWaitUs(1000);
		GPIO_ResetBits(ENCC_PORT, ENCC_PIN);
		halMcuWaitUs(1000);
}

uint8_t RF_ProcessInit(void)
{
  uint8_t  id;
  uint8_t  ver;
  //
  PWR_ON_CC2500();
  halRfResetChip();
  id  = halRfGetChipId();
  ver = halRfGetChipVer();
  printf("\r\nid=%d,ver=%d\r\n",(u16)id,(u16)ver);
  //
  halRfBurstConfig(0xC0);
  //
  return 0;
}


void ForceToWORMode(void)
{
	halRfWriteReg(CC2500_WOREVT1,0x87); //High Byte Event0 Timeout of 34666
	halRfWriteReg(CC2500_WOREVT0,0x6B); //Low Byte Event0 Timeout
	 /* WORCTRL.EVENT1 = 7 => T_EVENT1 = ~1.5 msec */
	halRfWriteReg(CC2500_MCSM2,0x00); //RX_TIME_RSSI  = 1 and RX_TIME = 6.
	/* WORCTRL.WOR_RES = 0 (EVENT0 = 34667, RX_TIME = 6)  =>  RX timeout  = 34667 * 0.0563 = ~1.96 msec */
	halRfWriteReg(CC2500_WORCTRL, (7 << 4) | 0);
	halRfStrobe(CC2500_SWOR);
}
void WOR_SetDefault(void)
{
	halRfWriteReg(CC2500_WOREVT1,0x87); //High Byte Event0 Timeout of 34666
	halRfWriteReg(CC2500_WOREVT0,0x6A); //Low Byte Event0 Timeout
	halRfWriteReg(CC2500_MCSM2,0x07); 
	halRfWriteReg(CC2500_WORCTRL,0xf8);
}

void ForceToRxMode(void)
{
	halRfStrobe(CC2500_SIDLE);
	halRfStrobe(CC2500_SFRX);
	halRfStrobe(CC2500_SRX);
}

uint8_t halSpiWrite(uint8_t addr, const uint8_t* data, uint16_t length)
{
    uint16_t i;
    uint8_t rc;
		CC2500_SELECT;
		rc = halSpiWriteByte(addr);
		for (i = 0; i < length; i++)
		{
			halSpiWriteByte(data[i]);
		}
		CC2500_DESELECT;
		return(rc);
}

uint8_t halSpiRead(uint8_t addr, uint8_t* data, uint16_t length)
{
    uint16_t i;
    uint8_t rc;
		CC2500_SELECT;
		rc = halSpiWriteByte(addr);
		for (i = 0; i < length; i++)
		{
			data[i] = halSpiWriteByte(0xff);
		}
		CC2500_DESELECT;
    return(rc);
}


uint8_t halSpiStrobe(uint8_t cmd)
{
    uint8_t rc;
		CC2500_SELECT;
		rc = halSpiWriteByte(cmd);
		CC2500_DESELECT;	
    return(rc);
}



void halMcuWaitUs(uint32_t uS)
{
  //uS *= 3;//=16MhZ/5 ; 5 is for while loop
  while(uS--);
}
//----------------------------------------------------------------------------------
//  void halRfResetChip(void)
//
//  DESCRIPTION:
//    Resets the chip using the procedure described in the datasheet.
//----------------------------------------------------------------------------------
void halRfResetChip(void)
{
  uint32_t Time_Sleep;
    // Toggle chip select signal
    CC2500_DESELECT;
    halMcuWaitUs(30);
    CC2500_SELECT;
    halMcuWaitUs(30);
    CC2500_DESELECT;
    halMcuWaitUs(45);
	//	printf("B1.1\r\n");
    // Send SRES command
    CC2500_SELECT;
		
		Time_Sleep = 60000;
    while(GPIO_ReadInputDataBit(MISO_PORT,MISO_PIN) && Time_Sleep)
		{Time_Sleep--;}
		if(Time_Sleep == 0) PWR_ON_CC2500();
		
    halSpiWriteByte(CC2500_SRES);
    // Wait for chip to finish internal reset
	//	printf("B1.2\r\n");
		
		Time_Sleep = 60000;
    while(GPIO_ReadInputDataBit(MISO_PORT,MISO_PIN) && Time_Sleep)
		{Time_Sleep--;}
		if(Time_Sleep == 0) PWR_ON_CC2500();
    CC2500_DESELECT;
		
	///	printf("B1.3\r\n");
}


//----------------------------------------------------------------------------------
//  void  halRfBurstConfig(const HAL_RF_BURST_CONFIG rfConfig, const uint8_t* rfPaTable, uint8_t rfPaTableLen)
//
//  DESCRIPTION:
//    Used to configure all of the CC1100/CC2500 registers in one burst write.
//
//  ARGUMENTS:
//    rfConfig     - register settings
//    rfPaTable    - array of PA table values (from SmartRF Studio)
//    rfPaTableLen - length of PA table
//
//----------------------------------------------------------------------------------

void  halRfBurstConfig(uint8_t PATABLE)
{
    //433.999969 1.2Kbaud
//    halRfWriteReg(CC2500_FSCTRL1,  0x06);       // Frequency synthesizer control.
//    halRfWriteReg(CC2500_FSCTRL0,  0x00);       // Frequency synthesizer control.
//    halRfWriteReg(CC2500_FREQ2,    0x10);       // Frequency control word, high byte.
//    halRfWriteReg(CC2500_FREQ1,    0xB1);       // Frequency control word, middle byte.
//    halRfWriteReg(CC2500_FREQ0,    0x3B);       // Frequency control word, low byte.
//    halRfWriteReg(CC2500_MDMCFG4,  0xF5);       // Modem configuration.
//    halRfWriteReg(CC2500_MDMCFG3,  0x83);       // Modem configuration.
//    halRfWriteReg(CC2500_MDMCFG2,  0x13);       // Modem configuration.
//    halRfWriteReg(CC2500_MDMCFG1,  0x22);       // Modem configuration.
//    halRfWriteReg(CC2500_MDMCFG0,  0xF8);       // Modem configuration.
//    halRfWriteReg(CC2500_CHANNR,   0x00);       // Channel number.
//    halRfWriteReg(CC2500_DEVIATN,  0x15);       // Modem deviation setting (when FSK modulation is enabled).
//    halRfWriteReg(CC2500_FREND1,   0x56);       // Front end RX configuration.
//    halRfWriteReg(CC2500_FREND0,   0x10);       // Front end RX configuration.
//    halRfWriteReg(CC2500_MCSM0,    0x18);       // Main Radio Control State Machine configuration.
//    halRfWriteReg(CC2500_FOCCFG,   0x16);       // Frequency Offset Compensation Configuration.
//    halRfWriteReg(CC2500_BSCFG,    0x6C);       // Bit synchronization Configuration.
//    halRfWriteReg(CC2500_AGCCTRL2, 0x03);       // AGC control.
//    halRfWriteReg(CC2500_AGCCTRL1, 0x40);       // AGC control.
//    halRfWriteReg(CC2500_AGCCTRL0, 0x91);       // AGC control.
//    halRfWriteReg(CC2500_FSCAL3,   0xE9);       // Frequency synthesizer calibration.
//    halRfWriteReg(CC2500_FSCAL2,   0x2A);       // Frequency synthesizer calibration.
//    halRfWriteReg(CC2500_FSCAL1,   0x00);       // Frequency synthesizer calibration.
//    halRfWriteReg(CC2500_FSCAL0,   0x1F);       // Frequency synthesizer calibration.
//    halRfWriteReg(CC2500_FSTEST,   0x59);       // Frequency synthesizer calibration.
//    halRfWriteReg(CC2500_TEST2,    0x81);       // Various test settings.
//    halRfWriteReg(CC2500_TEST1,    0x35);       // Various test settings.
//    halRfWriteReg(CC2500_TEST0,    0x09);       // Various test settings.
//    halRfWriteReg(CC2500_IOCFG2,   0x29);       // GDO2 output pin configuration.
//    halRfWriteReg(CC2500_IOCFG0,   0x06);       // GDO0 output pin configuration.
//    halRfWriteReg(CC2500_PKTCTRL1, 0x04);       // Packet automation control.
//    halRfWriteReg(CC2500_PKTCTRL0, 0x05);       // Packet automation control.
//    halRfWriteReg(CC2500_ADDR,     0x00);       // Device address.
//    halRfWriteReg(CC2500_MCSM1,    0x30);       // Main Radio Control State Machine configuration.
//    halRfWriteReg(CC2500_PKTLEN,   0xFF);       // Packet length.
//    
//    halRfWriteReg(CC2500_PATABLE,  0xC0);
        
        //
  // Rf settings for CC1101 1K2
  //
  halRfWriteReg(CC2500_IOCFG0,0x06);  //GDO0 Output Pin Configuration
  halRfWriteReg(CC2500_FIFOTHR,0x47); //RX FIFO and TX FIFO Thresholds
  halRfWriteReg(CC2500_PKTCTRL0,0x05);//Packet Automation Control
  halRfWriteReg(CC2500_FSCTRL1,0x06); //Frequency Synthesizer Control
  halRfWriteReg(CC2500_FREQ2,0x10);   //Frequency Control Word, High Byte
  halRfWriteReg(CC2500_FREQ1,0xB1);   //Frequency Control Word, Middle Byte
  halRfWriteReg(CC2500_FREQ0,0x3B);   //Frequency Control Word, Low Byte
  halRfWriteReg(CC2500_MDMCFG4,0xF5); //Modem Configuration
  halRfWriteReg(CC2500_MDMCFG3,0x83); //Modem Configuration
  halRfWriteReg(CC2500_MDMCFG2,0x13); //Modem Configuration
  halRfWriteReg(CC2500_DEVIATN,0x15); //Modem Deviation Setting
  halRfWriteReg(CC2500_MCSM0,0x18);   //Main Radio Control State Machine Configuration
  halRfWriteReg(CC2500_FOCCFG,0x16);  //Frequency Offset Compensation Configuration
  halRfWriteReg(CC2500_WORCTRL,0xFB); //Wake On Radio Control
  halRfWriteReg(CC2500_FSCAL3,0xE9);  //Frequency Synthesizer Calibration
  halRfWriteReg(CC2500_FSCAL2,0x2A);  //Frequency Synthesizer Calibration
  halRfWriteReg(CC2500_FSCAL1,0x00);  //Frequency Synthesizer Calibration
  halRfWriteReg(CC2500_FSCAL0,0x1F);  //Frequency Synthesizer Calibration
  halRfWriteReg(CC2500_TEST2,0x81);   //Various Test Settings
  halRfWriteReg(CC2500_TEST1,0x35);   //Various Test Settings
  halRfWriteReg(CC2500_TEST0,0x09);   //Various Test Settings		
  
  //User
  halRfWriteReg(CC2500_MCSM1, 0x3F); 	//RXOFF_MODE - TXOFF_MODE
  halRfWriteReg(CC2500_ADDR, 0);
  halRfWriteReg(CC2500_CHANNR, 0);
  halRfWriteReg(CC2500_PATABLE, 0xC0);
}

//----------------------------------------------------------------------------------
//  uint8_t halRfGetChipId(void)
//----------------------------------------------------------------------------------
uint8_t halRfGetChipId(void)
{
    return(halRfReadStatusReg(CC2500_PARTNUM));
}

//----------------------------------------------------------------------------------
//  uint8_t halRfGetChipVer(void)
//----------------------------------------------------------------------------------
uint8_t halRfGetChipVer(void)
{
    return(halRfReadStatusReg(CC2500_VERSION));
}

//----------------------------------------------------------------------------------
//  HAL_RF_STATUS halRfStrobe(uint8_t cmd)
//----------------------------------------------------------------------------------
HAL_RF_STATUS halRfStrobe(uint8_t cmd)
{
    return(halSpiStrobe(cmd));
}

//----------------------------------------------------------------------------------
//  uint8_t halRfReadStatusReg(uint8_t addr)
//
//  NOTE:
//      When reading a status register over the SPI interface while the register
//      is updated by the radio hardware, there is a small, but finite, probability
//      that the result is corrupt. The CC1100 and CC2500 errata notes explain the
//      problem and propose several workarounds.
//
//----------------------------------------------------------------------------------
uint8_t halRfReadStatusReg(uint8_t addr)
{
    uint8_t reg;
    halSpiRead(addr | CC2500_READ_BURST, &reg, 1);
    return(reg);
}

//----------------------------------------------------------------------------------
//  uint8_t halRfReadReg(uint8_t addr)
//----------------------------------------------------------------------------------
uint8_t halRfReadReg(uint8_t addr)
{
    uint8_t reg;
    halSpiRead(addr | CC2500_READ_SINGLE, &reg, 1);
    return(reg);
}

//----------------------------------------------------------------------------------
//  HAL_RF_STATUS halRfWriteReg(uint8_t addr, uint8_t data)
//----------------------------------------------------------------------------------
HAL_RF_STATUS halRfWriteReg(uint8_t addr, uint8_t data)
{
    uint8_t rc;
    rc = halSpiWrite(addr, &data, 1);
    return(rc);
}

//----------------------------------------------------------------------------------
//  HAL_RF_STATUS halRfWriteFifo(uint8_t* data, uint8_t length)
//----------------------------------------------------------------------------------
HAL_RF_STATUS halRfWriteFifo(const uint8_t* data, uint8_t length)
{
    return(halSpiWrite(CC2500_TXFIFO | CC2500_WRITE_BURST, data, length));
}

//----------------------------------------------------------------------------------
//  HAL_RF_STATUS halRfReadFifo(uint8_t* data, uint8_t length)
//----------------------------------------------------------------------------------
HAL_RF_STATUS halRfReadFifo(uint8_t* data, uint8_t length)
{
    return(halSpiRead(CC2500_RXFIFO | CC2500_READ_BURST, data, length));
}

//----------------------------------------------------------------------------------
//  uint8_t halRfGetTxStatus(void)
//
//  DESCRIPTION:
//      This function transmits a No Operation Strobe (SNOP) to get the status of
//      the radio and the number of free bytes in the TX FIFO
//
//      Status byte:
//
//      ---------------------------------------------------------------------------
//      |          |            |                                                 |
//      | CHIP_RDY | STATE[2:0] | FIFO_BYTES_AVAILABLE (free bytes in the TX FIFO |
//      |          |            |                                                 |
//      ---------------------------------------------------------------------------
//
//  NOTE:
//      When reading a status register over the SPI interface while the register
//      is updated by the radio hardware, there is a small, but finite, probability
//      that the result is corrupt. This also applies to the chip status byte. The
//      CC1100 and CC2500 errata notes explain the problem and propose several
//      workarounds.
//
//----------------------------------------------------------------------------------
HAL_RF_STATUS halRfGetTxStatus(void)
{
    return(halSpiStrobe(CC2500_SNOP));
}

//----------------------------------------------------------------------------------
//  uint8_t halRfGetRxStatus(void)
//
//  DESCRIPTION:
//      This function transmits a No Operation Strobe (SNOP) with the read bit set
//      to get the status of the radio and the number of available bytes in the RX
//      FIFO.
//
//      Status byte:
//
//      --------------------------------------------------------------------------------
//      |          |            |                                                      |
//      | CHIP_RDY | STATE[2:0] | FIFO_BYTES_AVAILABLE (available bytes in the RX FIFO |
//      |          |            |                                                      |
//      --------------------------------------------------------------------------------
//
//  NOTE:
//      When reading a status register over the SPI interface while the register
//      is updated by the radio hardware, there is a small, but finite, probability
//      that the result is corrupt. This also applies to the chip status byte. The
//      CC1100 and CC2500 errata notes explain the problem and propose several
//      workarounds.
//
//----------------------------------------------------------------------------------
HAL_RF_STATUS halRfGetRxStatus(void)
{
    return(halSpiStrobe(CC2500_SNOP | CC2500_READ_SINGLE));
}

/*
uint8_t halSpiWriteByte(uint8_t dat)
{
  uint8_t Data = 0;

  //!< Wait until the transmit buffer is empty 
  while (SPI_GetFlagStatus(SPI1, SPI_FLAG_TXE) == RESET)
  {}
  //!< Send the byte 
  SPI_SendData(SPI1, dat);

  //!< Wait until a data is received 
  while (SPI_GetFlagStatus(SPI1, SPI_FLAG_RXNE) == RESET)
  {}
  //!< Get the received data 
  Data = SPI_ReceiveData(SPI1);

  //!< Return the shifted data 
  return Data;
}
// */

// /*
uint8_t halSpiWriteByte(uint8_t dat)
{
	uint8_t i,temp, Delay_x = 1;

	temp = 0;	
	halMcuWaitUs(Delay_x);
	GPIO_ResetBits(SCK_PORT,SCK_PIN);
	for(i=0; i<8; i++)
	{
		halMcuWaitUs(Delay_x);
		if(dat & 0x80)
		{
			GPIO_SetBits(MOSI_PORT,MOSI_PIN);
		}
		else GPIO_ResetBits(MOSI_PORT,MOSI_PIN);
		halMcuWaitUs(Delay_x);
		dat <<= 1;

		GPIO_SetBits(SCK_PORT,SCK_PIN);
		halMcuWaitUs(Delay_x);
		temp <<= 1;
		if(GPIO_ReadInputDataBit(MISO_PORT,MISO_PIN))temp++; 
		halMcuWaitUs(Delay_x);
		GPIO_ResetBits(SCK_PORT,SCK_PIN);
		halMcuWaitUs(Delay_x);
	}
	return temp;
}
/**
  * @brief Retargets the C library printf function to the USART.
  * @param[in] c Character to send
  * @retval char Character sent
  * @par Required preconditions:
  * - None
  */
PUTCHAR_PROTOTYPE
{ 
#ifdef DEBUG_MODE
  /* Loop until the end of transmission */
  while (USART_GetFlagStatus(USART1, USART_FLAG_TC) == RESET);
  /* Write a character to the USART */
  USART_SendData8(USART1, c);
#endif
  return (c);
}

/**
  * @brief Retargets the C library scanf function to the USART.
  * @param[in] None
  * @retval char Character to Read
  * @par Required preconditions:
  * - None
  */
GETCHAR_PROTOTYPE
{
  int c = 0;
#ifdef DEBUG_MODE  
  /* Loop until the Read data register flag is SET */
  while (USART_GetFlagStatus(USART1, USART_FLAG_RXNE) == RESET);
  c = USART_ReceiveData8(USART1);
#endif
  return (c);
 }

#ifdef  USE_FULL_ASSERT

/**
  * @brief  Reports the name of the source file and the source line number
  *   where the assert_param error has occurred.
  * @param  file: pointer to the source file name
  * @param  line: assert_param error line source number
  * @retval None
  */
void assert_failed(uint8_t* file, uint32_t line)
{
  /* User can add his own implementation to report the file name and line number,
     ex: printf("Wrong parameters value: file %s on line %d\r\n", file, line) */
  /* Infinite loop */
  while (1)
  {}
}
#endif

/**
  * @}
  */

/**
  * @}
  */

/************************ (C) COPYRIGHT STMicroelectronics *****END OF FILE****/
