#ifndef __CC2500_SPI_H__
#define __CC2500_SPI_H__
#include "stm8l15x.h"

#define USE_SPI_HW
/**
* @brief  CC2500 SPI Interface pins
*/
#define CC2500_SPI							SPI1
#define CC2500_SPI_CLK						CLK_Peripheral_SPI1
#define CC2500_SPI_SCK_PIN					GPIO_Pin_5                 
#define CC2500_SPI_SCK_GPIO_PORT            GPIOB                 
#define CC2500_SPI_MISO_PIN                 GPIO_Pin_7                  
#define CC2500_SPI_MISO_GPIO_PORT           GPIOB                      
#define CC2500_SPI_MOSI_PIN                 GPIO_Pin_6               
#define CC2500_SPI_MOSI_GPIO_PORT           GPIOB                    
#define CC2500_CS_PIN                       GPIO_Pin_4        
#define CC2500_CS_GPIO_PORT                 GPIOB                   

// CC1100 - CC2500
#define CCxxxx_SELECT						GPIO_ResetBits(CC2500_CS_GPIO_PORT,CC2500_CS_PIN)
#define CCxxxx_DESELECT						GPIO_SetBits(CC2500_CS_GPIO_PORT,CC2500_CS_PIN)
#define HAL_SPI_SOMI_VAL					GPIO_ReadInputDataBit(CC2500_SPI_MISO_GPIO_PORT,CC2500_SPI_MISO_PIN)
#define HAL_SPI_MISO_IS_HIGH()				GPIO_ReadInputDataBit(CC2500_SPI_MISO_GPIO_PORT,CC2500_SPI_MISO_PIN)

void CC2500_LowLevel_DeInit(void);
void CC2500_LowLevel_Init(void);
#endif //__CC2500_SPI_H__

