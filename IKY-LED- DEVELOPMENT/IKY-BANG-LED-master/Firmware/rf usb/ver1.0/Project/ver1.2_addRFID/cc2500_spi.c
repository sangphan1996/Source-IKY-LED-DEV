
/**
* \file
*         CC2500 SPI driver
* \author
*         IKY Company
*/
#include "cc2500_spi.h"

/**
* @brief  DeInitializes the SPI communication.
* @param  None
* @retval None
*/
void CC2500_LowLevel_DeInit(void)
{
#ifdef USE_SPI_HW
	SPI_Cmd(CC2500_SPI,DISABLE);
	CLK_PeripheralClockConfig(CC2500_SPI_CLK, DISABLE);
#endif
	GPIO_Init(CC2500_SPI_SCK_GPIO_PORT, CC2500_SPI_SCK_PIN, GPIO_Mode_In_FL_No_IT);
	GPIO_Init(CC2500_SPI_MISO_GPIO_PORT, CC2500_SPI_MISO_PIN, GPIO_Mode_In_FL_No_IT);
	GPIO_Init(CC2500_SPI_MOSI_GPIO_PORT, CC2500_SPI_MOSI_PIN, GPIO_Mode_In_FL_No_IT);
	GPIO_Init(CC2500_CS_GPIO_PORT, CC2500_CS_PIN, GPIO_Mode_In_FL_No_IT);
}
/**
* @brief  Initializes the CC2500 SPI and CS pins.
* @param  None
* @retval None
*/
#ifdef USE_SPI_HW
void CC2500_LowLevel_Init(void)
{
	/* Enable SPI clock */
	CLK_PeripheralClockConfig(CC2500_SPI_CLK, ENABLE);

	/* Set the MOSI,MISO and SCK at high level */
	GPIO_ExternalPullUpConfig(CC2500_SPI_SCK_GPIO_PORT, (GPIO_Pin_TypeDef)(CC2500_SPI_MISO_PIN | CC2500_SPI_MOSI_PIN | \
		CC2500_SPI_SCK_PIN), ENABLE);

	/* SD_SPI Configuration */
	SPI_Init(CC2500_SPI, SPI_FirstBit_MSB, SPI_BaudRatePrescaler_4, SPI_Mode_Master,
		SPI_CPOL_High, SPI_CPHA_2Edge, SPI_Direction_2Lines_FullDuplex,
		SPI_NSS_Soft, 0x07);


	/* SD_SPI enable */
	SPI_Cmd(CC2500_SPI,ENABLE);

	/* Set ChipSelect pin in Output push-pull high level */
	GPIO_Init(CC2500_CS_GPIO_PORT, CC2500_CS_PIN, GPIO_Mode_Out_PP_High_Fast);
}
#else
void CC2500_LowLevel_Init(void)
{
	GPIO_Init(CC2500_SPI_MOSI_GPIO_PORT, CC2500_SPI_MOSI_PIN, GPIO_Mode_Out_PP_Low_Fast);
	GPIO_Init(CC2500_SPI_SCK_GPIO_PORT, CC2500_SPI_SCK_PIN, GPIO_Mode_Out_PP_Low_Fast);
	GPIO_Init(CC2500_CS_GPIO_PORT, CC2500_CS_PIN, GPIO_Mode_Out_PP_High_Fast);
	GPIO_Init(CC2500_SPI_MISO_GPIO_PORT, CC2500_SPI_MISO_PIN, GPIO_Mode_In_PU_No_IT);
}
#endif
/*----------------------------------------------------------------------------
 * end of file
 *---------------------------------------------------------------------------*/




