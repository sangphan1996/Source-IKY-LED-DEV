/**
* \file
*         CC2500 communication
* \author
*         IKY Company
*/
#include "cc2500_comm.h"
/**
* @brief  Initializes the CC2500 communication.
* @param  None
* @retval None
*/
void CC2500_Comm_Init(void)
{
	CC2500_LowLevel_Init();
}
/**
* @brief  DeInitializes the CC2500 communication.
* @param  None
* @retval None
*/
void CC2500_Comm_DeInit(void)
{
	CC2500_LowLevel_DeInit();
}
/**
* @brief  Write a byte on the SPI interface.
* @param  Data: byte to send.
* @retval None
*/
#ifdef 0
uint8_t halSpiWriteByte(uint8_t Data)
{
	uint32_t TimeOut = 10000;
	/*!< Wait until the transmit buffer is empty */
	TimeOut = 10000;
	while ((SPI_GetFlagStatus(CC2500_SPI, SPI_FLAG_TXE) == RESET) && TimeOut)
	{
		TimeOut--;
	}
	/*!< Send the byte */
	SPI_SendData(CC2500_SPI,Data);

	/*!< Wait to receive a byte*/
	TimeOut = 10000;
	while ((SPI_GetFlagStatus(CC2500_SPI,SPI_FLAG_RXNE) == RESET) && TimeOut)
	{
		TimeOut--;
	}

	/*!< Return the byte read from the SPI bus */
	return SPI_ReceiveData(CC2500_SPI);
}
#endif
#ifdef 0
uint8_t halSpiWriteByte(uint8_t Data)
{
	uint8_t i;
	uint8_t temp = 0;
	uint8_t Delay_x = 1;
	Delay_x++;
	GPIO_ResetBits(CC2500_SPI_SCK_GPIO_PORT, CC2500_SPI_SCK_PIN);
	for (i = 0; i < 8; i++)
	{
		Delay_x ++;
		if (Data & 0x80)
		{
			GPIO_SetBits(CC2500_SPI_MOSI_GPIO_PORT, CC2500_SPI_MOSI_PIN);
		}
		else GPIO_ResetBits(CC2500_SPI_MOSI_GPIO_PORT, CC2500_SPI_MOSI_PIN);
		Delay_x++;
		Data <<= 1;

		GPIO_SetBits(CC2500_SPI_SCK_GPIO_PORT, CC2500_SPI_SCK_PIN);
		Delay_x++;
		temp <<= 1;
		if (HAL_SPI_SOMI_VAL)temp++;
		Delay_x++;
		GPIO_ResetBits(CC2500_SPI_SCK_GPIO_PORT, CC2500_SPI_SCK_PIN);
		Delay_x++;
	}
	return temp;
}
#endif
/*----------------------------------------------------------------------------
 * end of file
 *---------------------------------------------------------------------------*/




