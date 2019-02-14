#ifndef __RF_SETTING_H
#define __RF_SETTING_H
/* Includes ------------------------------------------------------------------*/
#include "stm8l15x.h"
#include "rf_register.h"

typedef uint8_t BYTE;

/* Private define ------------------------------------------------------------*/
//-----------------------------------------------------------------------------
// RF_SETTINGS is a data structure which contains all relevant CCxxx0 registers
typedef struct S_RF_SETTINGS{
	BYTE FSCTRL1;   // Frequency synthesizer control.
	BYTE FSCTRL0;   // Frequency synthesizer control.
	BYTE FREQ2;     // Frequency control word, high byte.
	BYTE FREQ1;     // Frequency control word, middle byte.
	BYTE FREQ0;     // Frequency control word, low byte.
	BYTE MDMCFG4;   // Modem configuration.
	BYTE MDMCFG3;   // Modem configuration.
	BYTE MDMCFG2;   // Modem configuration.
	BYTE MDMCFG1;   // Modem configuration.
	BYTE MDMCFG0;   // Modem configuration.
	BYTE CHANNR;    // Channel number.
	BYTE DEVIATN;   // Modem deviation setting (when FSK modulation is enabled).
	BYTE FREND1;    // Front end RX configuration.
	BYTE FREND0;    // Front end RX configuration.
	BYTE MCSM0;     // Main Radio Control State Machine configuration.
	BYTE FOCCFG;    // Frequency Offset Compensation Configuration.
	BYTE BSCFG;     // Bit synchronization Configuration.
	BYTE AGCCTRL2;  // AGC control.
	BYTE AGCCTRL1;  // AGC control.
	BYTE AGCCTRL0;  // AGC control.
	BYTE FSCAL3;    // Frequency synthesizer calibration.
	BYTE FSCAL2;    // Frequency synthesizer calibration.
	BYTE FSCAL1;    // Frequency synthesizer calibration.
	BYTE FSCAL0;    // Frequency synthesizer calibration.
	BYTE FSTEST;    // Frequency synthesizer calibration control
	BYTE TEST2;     // Various test settings.
	BYTE TEST1;     // Various test settings.
	BYTE TEST0;     // Various test settings.
	BYTE FIFOTHR;   // RXFIFO and TXFIFO thresholds.
	BYTE IOCFG2;    // GDO2 output pin configuration
	BYTE IOCFG0;    // GDO0 output pin configuration
	BYTE PKTCTRL1;  // Packet automation control.
	BYTE PKTCTRL0;  // Packet automation control.
	BYTE ADDR;      // Device address.
	BYTE PKTLEN;    // Packet length.
} RF_SETTINGS;


extern RF_SETTINGS rfSettings;
extern BYTE paTable;

void halRfWriteRfSettings(RF_SETTINGS *pRfSettings);
#endif /* __RF_SETTING_H */

/*****END OF FILE****/