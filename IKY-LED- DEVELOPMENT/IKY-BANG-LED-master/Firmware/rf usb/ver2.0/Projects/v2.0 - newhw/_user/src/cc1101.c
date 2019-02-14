#include "stm32f10x.h"
#include "cc1101.h"
#include "logger.h"
#include "sys_tick.h"

//#define USE_SPI_SW

#define RF_APPLOG(...)								NRF_LOG_PRINTF(__VA_ARGS__)

#define SPI_RF                   			SPI1
#define RCC_APBPeriphClockCmd_SPI_SD  RCC_APB2PeriphClockCmd
#define RCC_APBPeriph_SPI_RF     			RCC_APB2Periph_SPI1

void CC1101_SPI_Init(void)
{
	#ifndef USE_SPI_SW
	SPI_InitTypeDef  SPI_InitStructure;
	GPIO_InitTypeDef GPIO_InitStructure;

	/* Enable SPI clock, SPI1: APB2, SPI2: APB1 */
	RCC_APBPeriphClockCmd_SPI_SD(RCC_APBPeriph_SPI_RF, ENABLE);

	/* Configure I/O for RF Chip _SELECT */
	GPIO_InitStructure.GPIO_Pin   = CC1101_CS_PIN;
	GPIO_InitStructure.GPIO_Mode  = GPIO_Mode_Out_PP;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_10MHz;
	GPIO_Init(CC1101_CS_PORT, &GPIO_InitStructure);

	/* De-_SELECT the Card: Chip _SELECT high */
	CC1101_DESELECT();

	/* Configure SPI pins: SCK and MOSI with default alternate function (not re-mapped) push-pull */
	GPIO_InitStructure.GPIO_Pin   = CC1101_SCK_PIN | CC1101_MOSI_PIN;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_10MHz;
	GPIO_InitStructure.GPIO_Mode  = GPIO_Mode_AF_PP;
	GPIO_Init(CC1101_MOSI_PORT, &GPIO_InitStructure);
	/* Configure MISO as Input with internal pull-up */
	GPIO_InitStructure.GPIO_Pin   = CC1101_MISO_PIN;
	GPIO_InitStructure.GPIO_Mode  = GPIO_Mode_IN_FLOATING;
	GPIO_Init(CC1101_MISO_PORT, &GPIO_InitStructure);

	/* SPI configuration */
  SPI_InitStructure.SPI_BaudRatePrescaler = SPI_BaudRatePrescaler_4;
	SPI_InitStructure.SPI_CPHA = SPI_CPHA_2Edge;
	SPI_InitStructure.SPI_CPOL = SPI_CPOL_High;
	SPI_InitStructure.SPI_DataSize = SPI_DataSize_8b;
	SPI_InitStructure.SPI_CRCPolynomial = 7;
	SPI_InitStructure.SPI_Direction = SPI_Direction_2Lines_FullDuplex;
	SPI_InitStructure.SPI_FirstBit = SPI_FirstBit_MSB;
	SPI_InitStructure.SPI_Mode = SPI_Mode_Master;
	SPI_InitStructure.SPI_NSS = SPI_NSS_Soft;
	 
	SPI_Init(SPI_RF, &SPI_InitStructure);
	SPI_CalculateCRC(SPI_RF, DISABLE);
	SPI_Cmd(SPI_RF, ENABLE);

	/* drain SPI */
	while (SPI_I2S_GetFlagStatus(SPI_RF, SPI_I2S_FLAG_TXE) == RESET) { ; }
	SPI_I2S_ReceiveData(SPI_RF);
	#endif
}

/*-----------------------------------------------------------------------*/
/* Transmit/Receive a byte to RF via SPI  (Platform dependent)          */
/*-----------------------------------------------------------------------*/
static uint8_t stm32_spi_rw( uint8_t out )
{
	uint32_t timeout = 1000000;
	/* Loop while DR register in not empty */
	/// not needed: while (SPI_I2S_GetFlagStatus(SPI_RF, SPI_I2S_FLAG_TXE) == RESET) { ; }

	/* Send byte through the SPI peripheral */
	SPI_I2S_SendData(SPI_RF, out);

	/* Wait to receive a byte */
	while (SPI_I2S_GetFlagStatus(SPI_RF, SPI_I2S_FLAG_RXNE) == RESET && timeout>0) { timeout--; }

	/* Return the byte read from the SPI bus */
	return SPI_I2S_ReceiveData(SPI_RF);
}

void CC1101_Power_Init(void)
{
	GPIO_InitTypeDef GPIO_InitStructure;
	NVIC_InitTypeDef NVIC_InitStructure;
	EXTI_InitTypeDef EXTI_InitStructure;
	//
	GPIO_InitStructure.GPIO_Pin = CC1101_PWR_PIN;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP;
	GPIO_Init( CC1101_PWR_PORT, &GPIO_InitStructure );	
	//
	#ifdef USE_SPI_SW
	GPIO_InitStructure.GPIO_Pin = CC1101_MISO_PIN;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN_FLOATING;
	GPIO_Init( CC1101_MISO_PORT, &GPIO_InitStructure );	
	//
	GPIO_InitStructure.GPIO_Pin = CC1101_MOSI_PIN;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP;
	GPIO_Init( CC1101_MOSI_PORT, &GPIO_InitStructure );
	//
	GPIO_InitStructure.GPIO_Pin = CC1101_SCK_PIN;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP;
	GPIO_Init( CC1101_SCK_PORT, &GPIO_InitStructure );
	//
	GPIO_InitStructure.GPIO_Pin = CC1101_CS_PIN;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP;
	GPIO_Init( CC1101_CS_PORT, &GPIO_InitStructure );
	//
	GPIO_ResetBits(CC1101_MOSI_PORT,CC1101_MOSI_PIN);
	GPIO_ResetBits(CC1101_SCK_PORT,CC1101_SCK_PIN);
	GPIO_SetBits(CC1101_CS_PORT,CC1101_CS_PIN);
	#endif
	/* Configure GD0 PIN as input floating */
	GPIO_InitStructure.GPIO_Pin = CC1101_GD0_PIN;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_10MHz;
	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IPU;
	GPIO_Init(CC1101_GD0_PORT, &GPIO_InitStructure); 
	GPIO_EXTILineConfig(CC1101_GD0_PORTSOURCE, CC1101_GD0_PINSOURCE); 
	/* Clear the the EXTI interrupt pending bit */	
	EXTI_ClearITPendingBit(CC1101_GD0_EXTLINE);
	EXTI_InitStructure.EXTI_Mode				= EXTI_Mode_Interrupt;
	EXTI_InitStructure.EXTI_Line				= CC1101_GD0_EXTLINE;
	EXTI_InitStructure.EXTI_Trigger     = EXTI_Trigger_Falling;
	EXTI_InitStructure.EXTI_LineCmd     = ENABLE;
	EXTI_Init(&EXTI_InitStructure);
	/* Enable the EXTI Interrupt */
	NVIC_InitStructure.NVIC_IRQChannel = EXTI3_IRQn;
	NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0;
	NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0xF;
	NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
	NVIC_Init(&NVIC_InitStructure);	
}

void CC1101_PowerOn(void)
{
	GPIO_SetBits(CC1101_PWR_PORT, CC1101_PWR_PIN);
	SysTick_DelayMs(500);
	GPIO_ResetBits(CC1101_PWR_PORT, CC1101_PWR_PIN);
	SysTick_DelayMs(500);
}


void CC1101_ResetChip(void)
{
	uint32_t timeOut;
	// Toggle chip select signal
	CC1101_DESELECT();
	SysTick_DelayMs(1);
	CC1101_SELECT();
	SysTick_DelayMs(1);
	CC1101_DESELECT();
	SysTick_DelayMs(1);
	// Send SRES command
	CC1101_SELECT();
		
	timeOut = 60000;
	while(CC1101_MISO_STATUS() && timeOut){timeOut--;}
	if(timeOut == 0) CC1101_PowerOn();
		
	CC1101_SPI_WriteByte(CC1101_SRES);
	// Wait for chip to finish internal reset
		
	timeOut = 60000;
	while(CC1101_MISO_STATUS() && timeOut){timeOut--;}
	if(timeOut == 0) CC1101_PowerOn();
	CC1101_DESELECT();
}

uint8_t CC1101_GetChipId(void)
{
    return(CC1101_ReadStatusReg(CC1101_PARTNUM));
}

uint8_t CC1101_GetChipVer(void)
{
    return(CC1101_ReadStatusReg(CC1101_VERSION));
}

uint8_t CC1101_ProcessInit(uint8_t PATABLE)
{
	uint8_t  CC1101_ID;
	uint8_t  CC1101_Ver;
	//
	CC1101_PowerOn();
	//
	CC1101_ResetChip();
	//
	CC1101_ID  = CC1101_GetChipId();
	CC1101_Ver = CC1101_GetChipVer();
	RF_APPLOG("\r\nID = %02X - Ver = %02X \r\n",CC1101_ID,CC1101_Ver);
	//
	CC1101_BurstConfig(0xC0);
	return 0;
}

void  CC1101_BurstConfig(uint8_t PATABLE)
{
	//433.999969 1.2Kbaud
	CC1101_WriteReg(CC2500_FSCTRL1,  0x06);    	// Frequency synthesizer control.
	CC1101_WriteReg(CC2500_FSCTRL0,  0x00);   	// Frequency synthesizer control.
	CC1101_WriteReg(CC2500_FREQ2,    0x10);			// Frequency control word, high byte.
	CC1101_WriteReg(CC2500_FREQ1,    0xB1);			// Frequency control word, middle byte.
	CC1101_WriteReg(CC2500_FREQ0,    0x3B);			// Frequency control word, low byte.
	CC1101_WriteReg(CC2500_MDMCFG4,  0xF5);    	// Modem configuration.
	CC1101_WriteReg(CC2500_MDMCFG3,  0x83);    	// Modem configuration.
	CC1101_WriteReg(CC2500_MDMCFG2,  0x13);    	// Modem configuration.
	CC1101_WriteReg(CC2500_MDMCFG1,  0x22);    	// Modem configuration.
	CC1101_WriteReg(CC2500_MDMCFG0,  0xF8);    	// Modem configuration.
	CC1101_WriteReg(CC2500_CHANNR,   0x00);     // Channel number.
	CC1101_WriteReg(CC2500_DEVIATN,  0x15);    	// Modem deviation setting (when FSK modulation is enabled).
	CC1101_WriteReg(CC2500_FREND1,   0x56);     // Front end RX configuration.
	CC1101_WriteReg(CC2500_FREND0,   0x10);     // Front end RX configuration.
	CC1101_WriteReg(CC2500_MCSM0,    0x18);			// Main Radio Control State Machine configuration.
	CC1101_WriteReg(CC2500_FOCCFG,   0x16);     // Frequency Offset Compensation Configuration.
	CC1101_WriteReg(CC2500_BSCFG,    0x6C);			// Bit synchronization Configuration.
	CC1101_WriteReg(CC2500_AGCCTRL2, 0x03);   	// AGC control.
	CC1101_WriteReg(CC2500_AGCCTRL1, 0x40);   	// AGC control.
	CC1101_WriteReg(CC2500_AGCCTRL0, 0x91);   	// AGC control.
	CC1101_WriteReg(CC2500_FSCAL3,   0xE9);     // Frequency synthesizer calibration.
	CC1101_WriteReg(CC2500_FSCAL2,   0x2A);     // Frequency synthesizer calibration.
	CC1101_WriteReg(CC2500_FSCAL1,   0x00);     // Frequency synthesizer calibration.
	CC1101_WriteReg(CC2500_FSCAL0,   0x1F);     // Frequency synthesizer calibration.
	CC1101_WriteReg(CC2500_FSTEST,   0x59);     // Frequency synthesizer calibration.
	CC1101_WriteReg(CC2500_TEST2,    0x81);			// Various test settings.
	CC1101_WriteReg(CC2500_TEST1,    0x35);			// Various test settings.
	CC1101_WriteReg(CC2500_TEST0,    0x09);			// Various test settings.
	CC1101_WriteReg(CC1101_IOCFG2,   0x29);			// GDO2 output pin configuration.
	CC1101_WriteReg(CC2500_IOCFG0,   0x06);     // GDO0 output pin configuration.
	CC1101_WriteReg(CC2500_PKTCTRL1, 0x04);   	// Packet automation control.
	CC1101_WriteReg(CC2500_PKTCTRL0, 0x05);   	// Packet automation control.
	CC1101_WriteReg(CC2500_ADDR,     0x00);			// Device address.
	CC1101_WriteReg(CC2500_MCSM1,    0x30);			// Main Radio Control State Machine configuration.
	CC1101_WriteReg(CC1101_PKTLEN,   0xFF);     // Packet length.
		
	CC1101_WriteReg(CC1101_PATABLE,PATABLE);
}

//Low level function
void CC1101_McuWaitUs(uint32_t us)
{
	while(us--);
}

uint8_t CC1101_SPI_WriteByte(uint8_t dat)
{
	#ifdef USE_SPI_SW
	uint8_t i,temp = 0, Delay_x = 100;
	CC1101_McuWaitUs(Delay_x);
	GPIO_ResetBits(CC1101_SCK_PORT,CC1101_SCK_PIN);
	for(i=0; i<8; i++)
	{
		CC1101_McuWaitUs(Delay_x);
		if(dat & 0x80)
		{
			GPIO_SetBits(CC1101_MOSI_PORT,CC1101_MOSI_PIN);
		}
		else GPIO_ResetBits(CC1101_MOSI_PORT,CC1101_MOSI_PIN);
		CC1101_McuWaitUs(Delay_x);
		dat <<= 1;

		GPIO_SetBits(CC1101_SCK_PORT,CC1101_SCK_PIN);
		CC1101_McuWaitUs(Delay_x);
		temp <<= 1;
		if(CC1101_MISO_STATUS())temp++; 
		CC1101_McuWaitUs(Delay_x);
		GPIO_ResetBits(CC1101_SCK_PORT,CC1101_SCK_PIN);
		CC1101_McuWaitUs(Delay_x);
	}
	return temp;
	#else
	return stm32_spi_rw(dat);
	#endif
	
}

uint8_t CC1101_SPI_Write(uint8_t addr, const uint8_t* data, uint16_t length)
{
    uint16_t i;
    uint8_t rc;
		CC1101_SELECT();
		rc = CC1101_SPI_WriteByte(addr);
		for (i = 0; i < length; i++)
		{
			CC1101_SPI_WriteByte(data[i]);
		}
		CC1101_DESELECT();
		return(rc);
}

uint8_t CC1101_SPI_Strobe(uint8_t cmd)
{
    uint8_t rc;
		CC1101_SELECT();
		rc = CC1101_SPI_WriteByte(cmd);
		CC1101_DESELECT();	
    return(rc);
}

uint8_t CC1101_SPI_Read(uint8_t addr, uint8_t* data, uint16_t length)
{
    uint16_t i;
    uint8_t rc;
		CC1101_SELECT();
		rc = CC1101_SPI_WriteByte(addr);
		for (i = 0; i < length; i++)
		{
			data[i] = CC1101_SPI_WriteByte(0xff);
		}
		CC1101_DESELECT();
    return(rc);
}

uint8_t CC1101_WriteReg(uint8_t addr, uint8_t data)
{
    uint8_t rc;
    rc = CC1101_SPI_Write(addr, &data, 1);
    return(rc);
}

uint8_t CC1101_ReadReg(uint8_t addr)
{
    uint8_t reg;
    CC1101_SPI_Read(addr | CC1101_READ_SINGLE, &reg, 1);
    return(reg);
}

uint8_t CC1101_Strobe(uint8_t cmd)
{
    return(CC1101_SPI_Strobe(cmd));
}

uint8_t CC1101_ReadStatusReg(uint8_t addr)
{
    uint8_t reg;
    CC1101_SPI_Read(addr | CC1101_READ_BURST, &reg, 1);
    return(reg);
}

uint8_t CC1101_ReadFifo(uint8_t* data, uint8_t length)
{
    return(CC1101_SPI_Read(CC1101_RXFIFO | CC1101_READ_BURST, data, length));
}

void CC1101_ForceToRxMode(void)
{
	CC1101_Strobe(CC2500_SIDLE);
	//CC1101_Strobe(CC2500_SFRX);
	CC1101_Strobe(CC2500_SRX);
}

