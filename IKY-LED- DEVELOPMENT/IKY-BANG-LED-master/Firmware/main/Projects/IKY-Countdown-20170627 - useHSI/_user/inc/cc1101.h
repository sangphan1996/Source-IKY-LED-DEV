#ifndef __CC1101_H
#define __CC1101_H
#include <stdbool.h>
#include <stdio.h>
#include <stdint.h>

#define CC1101_PWR_PIN							GPIO_Pin_12
#define CC1101_PWR_PORT            	GPIOB

#define CC1101_MISO_PIN 						GPIO_Pin_6
#define CC1101_MISO_PORT 						GPIOA

#define CC1101_MOSI_PIN							GPIO_Pin_7
#define CC1101_MOSI_PORT 						GPIOA

#define CC1101_SCK_PIN 							GPIO_Pin_5
#define CC1101_SCK_PORT 						GPIOA

#define CC1101_CS_PIN 							GPIO_Pin_4
#define CC1101_CS_PORT 							GPIOA

#define CC1101_GD0_PIN 							GPIO_Pin_3
#define CC1101_GD0_PORT 						GPIOA
#define	CC1101_GD0_PORTSOURCE				GPIO_PortSourceGPIOA
#define CC1101_GD0_PINSOURCE				GPIO_PinSource3
#define CC1101_GD0_EXTLINE					EXTI_Line3

#define CC1101_SELECT()   					GPIO_ResetBits(CC1101_CS_PORT,CC1101_CS_PIN)
#define CC1101_DESELECT() 					GPIO_SetBits(CC1101_CS_PORT,CC1101_CS_PIN)
#define CC1101_MISO_STATUS()				GPIO_ReadInputDataBit(CC1101_MISO_PORT,CC1101_MISO_PIN)

// Configuration Registers
#define CC1101_IOCFG2           0x00        // GDO2 output pin configuration
#define CC1101_IOCFG1           0x01        // GDO1 output pin configuration
#define CC2500_IOCFG0           0x02        // GDO0 output pin configuration
#define CC2500_FIFOTHR          0x03        // RX FIFO and TX FIFO thresholds
#define CC2500_SYNC1            0x04        // Sync word, high byte
#define CC2500_SYNC0            0x05        // Sync word, low byte
#define CC1101_PKTLEN           0x06        // Packet length
#define CC2500_PKTCTRL1         0x07        // Packet automation control
#define CC2500_PKTCTRL0         0x08        // Packet automation control
#define CC2500_ADDR             0x09        // Device address
#define CC2500_CHANNR           0x0A        // Channel number
#define CC2500_FSCTRL1          0x0B        // Frequency synthesizer control
#define CC2500_FSCTRL0          0x0C        // Frequency synthesizer control
#define CC2500_FREQ2            0x0D        // Frequency control word, high byte
#define CC2500_FREQ1            0x0E        // Frequency control word, middle byte
#define CC2500_FREQ0            0x0F        // Frequency control word, low byte
#define CC2500_MDMCFG4          0x10        // Modem configuration
#define CC2500_MDMCFG3          0x11        // Modem configuration
#define CC2500_MDMCFG2          0x12        // Modem configuration
#define CC2500_MDMCFG1          0x13        // Modem configuration
#define CC2500_MDMCFG0          0x14        // Modem configuration
#define CC2500_DEVIATN          0x15        // Modem deviation setting
#define CC2500_MCSM2            0x16        // Main Radio Cntrl State Machine config
#define CC2500_MCSM1            0x17        // Main Radio Cntrl State Machine config
#define CC2500_MCSM0            0x18        // Main Radio Cntrl State Machine config
#define CC2500_FOCCFG           0x19        // Frequency Offset Compensation config
#define CC2500_BSCFG            0x1A        // Bit Synchronization configuration
#define CC2500_AGCCTRL2         0x1B        // AGC control
#define CC2500_AGCCTRL1         0x1C        // AGC control
#define CC2500_AGCCTRL0         0x1D        // AGC control
#define CC2500_WOREVT1          0x1E        // High byte Event 0 timeout
#define CC2500_WOREVT0          0x1F        // Low byte Event 0 timeout
#define CC2500_WORCTRL          0x20        // Wake On Radio control
#define CC2500_FREND1           0x21        // Front end RX configuration
#define CC2500_FREND0           0x22        // Front end TX configuration
#define CC2500_FSCAL3           0x23        // Frequency synthesizer calibration
#define CC2500_FSCAL2           0x24        // Frequency synthesizer calibration
#define CC2500_FSCAL1           0x25        // Frequency synthesizer calibration
#define CC2500_FSCAL0           0x26        // Frequency synthesizer calibration
#define CC2500_RCCTRL1          0x27        // RC oscillator configuration
#define CC2500_RCCTRL0          0x28        // RC oscillator configuration
#define CC2500_FSTEST           0x29        // Frequency synthesizer cal control
#define CC2500_PTEST            0x2A        // Production test
#define CC2500_AGCTEST          0x2B        // AGC test
#define CC2500_TEST2            0x2C        // Various test settings
#define CC2500_TEST1            0x2D        // Various test settings
#define CC2500_TEST0            0x2E        // Various test settings

// Status registers
#define CC1101_PARTNUM          0x30        // Part number
#define CC1101_VERSION          0x31        // Current version number
#define CC2500_FREQEST          0x32        // Frequency offset estimate
#define CC2500_LQI              0x33        // Demodulator estimate for link quality
#define CC2500_RSSI             0x34        // Received signal strength indication
#define CC2500_MARCSTATE        0x35        // Control state machine state
#define CC2500_WORTIME1         0x36        // High byte of WOR timer
#define CC2500_WORTIME0         0x37        // Low byte of WOR timer
#define CC2500_PKTSTATUS        0x38        // Current GDOx status and packet status
#define CC2500_VCO_VC_DAC       0x39        // Current setting from PLL cal module
#define CC2500_TXBYTES          0x3A        // Underflow and # of bytes in TXFIFO
#define CC1101_RXBYTES          0x3B        // Overflow and # of bytes in RXFIFO

// Definitions for burst/single access to registers
#define CC2500_WRITE_BURST      0x40
#define CC1101_READ_SINGLE      0x80
#define CC1101_READ_BURST       0xC0

// Strobe commands
#define CC1101_SRES             0x30        // Reset chip.
#define CC2500_SFSTXON          0x31        // Enable and calibrate frequency synthesizer (if MCSM0.FS_AUTOCAL=1).
                                            // If in RX/TX: Go to a wait state where only the synthesizer is
                                            // running (for quick RX / TX turnaround).
#define CC2500_SXOFF            0x32        // Turn off crystal oscillator.
#define CC2500_SCAL             0x33        // Calibrate frequency synthesizer and turn it off
                                            // (enables quick start).
#define CC2500_SRX              0x34        // Enable RX. Perform calibration first if coming from IDLE and
                                            // MCSM0.FS_AUTOCAL=1.
#define CC2500_STX              0x35        // In IDLE state: Enable TX. Perform calibration first if
                                            // MCSM0.FS_AUTOCAL=1. If in RX state and CCA is enabled:
                                            // Only go to TX if channel is clear.
#define CC2500_SIDLE            0x36        // Exit RX / TX, turn off frequency synthesizer and exit
                                            // Wake-On-Radio mode if applicable.
#define CC2500_SAFC             0x37        // Perform AFC adjustment of the frequency synthesizer
#define CC2500_SWOR             0x38        // Start automatic RX polling sequence (Wake-on-Radio)
#define CC1101_SPWD             0x39        // Enter power down mode when CSn goes high.
#define CC2500_SFRX             0x3A        // Flush the RX FIFO buffer.
#define CC2500_SFTX             0x3B        // Flush the TX FIFO buffer.
#define CC2500_SWORRST          0x3C        // Reset real time clock.
#define CC2500_SNOP             0x3D        // No operation. May be used to pad strobe commands to two
                                            // bytes for simpler software.
																						
// Multi byte memory locations
#define CC1101_PATABLE          0x3E
#define CC2500_TXFIFO           0x3F
#define CC1101_RXFIFO           0x3F																						

// Other register bit fields
#define CC1101_LQI_CRC_OK_BM		0x80
#define CC1101_LQI_EST_BM				0x7F
#define BYTES_IN_RXFIFO					0x7F
// Function
void CC1101_SPI_Init(void);
void CC1101_Power_Init(void);
uint8_t CC1101_ProcessInit(uint8_t PATABLE);
void  CC1101_BurstConfig(uint8_t PATABLE);

uint8_t CC1101_SPI_WriteByte(uint8_t dat);
uint8_t CC1101_SPI_Write(uint8_t addr, const uint8_t* data, uint16_t length);
uint8_t CC1101_SPI_Read(uint8_t addr, uint8_t* data, uint16_t length);
uint8_t CC1101_WriteReg(uint8_t addr, uint8_t data);
uint8_t CC1101_ReadReg(uint8_t addr);
uint8_t CC1101_Strobe(uint8_t cmd);
uint8_t CC1101_ReadStatusReg(uint8_t addr);
uint8_t CC1101_ReadFifo(uint8_t* data, uint8_t length);
void CC1101_WOR_SetDefault(void);
void CC1101_ForceToRxMode(void);
#endif //__CC1101_H
/*******************************************************************************
	*END FILE
********************************************************************************/
