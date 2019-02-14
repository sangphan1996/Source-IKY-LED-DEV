/**
* \file
*         CC2500 communication
* \author
*         IKY Company
*/
#include "rf_setting.h"

extern uint8_t halRfWriteReg(uint8_t addr, uint8_t data);

RF_SETTINGS rfSettings = {
    0x0A,   // FSCTRL1   Frequency synthesizer control.
    0x00,   // FSCTRL0   Frequency synthesizer control.
    0x5D,   // FREQ2     Frequency control word, high byte.
    0x93,   // FREQ1     Frequency control word, middle byte.
    0xB1,   // FREQ0     Frequency control word, low byte.
    0x7A,   // MDMCFG4   Modem configuration.
    0x93,   // MDMCFG3   Modem configuration.
    0x0B,   // MDMCFG2   Modem configuration.
    0x22,   // MDMCFG1   Modem configuration.
    0xF8,   // MDMCFG0   Modem configuration.
    0x00,   // CHANNR    Channel number.
    0x44,   // DEVIATN   Modem deviation setting (when FSK modulation is enabled).
    0xB6,   // FREND1    Front end RX configuration.
    0x10,   // FREND0    Front end TX configuration.
    0x18,   // MCSM0     Main Radio Control State Machine configuration.
    0x16,   // FOCCFG    Frequency Offset Compensation Configuration.
    0x6C,   // BSCFG     Bit synchronization Configuration.
    0x43,   // AGCCTRL2  AGC control.
    0x40,   // AGCCTRL1  AGC control.
    0x91,   // AGCCTRL0  AGC control.
    0xEA,   // FSCAL3    Frequency synthesizer calibration.
    0x0A,   // FSCAL2    Frequency synthesizer calibration.
    0x00,   // FSCAL1    Frequency synthesizer calibration.
    0x11,   // FSCAL0    Frequency synthesizer calibration.
    0x59,   // FSTEST    Frequency synthesizer calibration.
    0x88,   // TEST2     Various test settings.
    0x31,   // TEST1     Various test settings.
    0x0B,   // TEST0     Various test settings.
    0x07,   // FIFOTHR   RXFIFO and TXFIFO thresholds.
    0x29,   // IOCFG2    GDO2 output pin configuration.
    0x06,   // IOCFG0D   GDO0 output pin configuration.
    0x05,   // PKTCTRL1  Packet automation control.
    0x45,   // PKTCTRL0  Packet automation control.
    0x00,   // ADDR      Device address.
    0xFF    // PKTLEN    Packet length.
};

// PATABLE (0 dBm output power)
BYTE paTable = 0xFE;
// Channel
BYTE rfChannel = 0xFE;
// Address
BYTE rfAddress = 0xFE;


//------------------------------------------------------------------------------------
//  void RfWriteRfSettings(RF_SETTINGS *pRfSettings)
//
//  DESCRIPTION:
//      This function is used to configure the CCxxx0 based on a given rf setting
//
//  ARGUMENTS:
//      RF_SETTINGS *pRfSettings
//          Pointer to a struct containing rf register settings
//-------------------------------------------------------------------------------------
void halRfWriteRfSettings(RF_SETTINGS *pRfSettings)
{
	// Write register settings
	halRfWriteReg(CCxxx0_FSCTRL1, pRfSettings->FSCTRL1);
	halRfWriteReg(CCxxx0_FSCTRL0, pRfSettings->FSCTRL0);
	halRfWriteReg(CCxxx0_FREQ2, pRfSettings->FREQ2);
	halRfWriteReg(CCxxx0_FREQ1, pRfSettings->FREQ1);
	halRfWriteReg(CCxxx0_FREQ0, pRfSettings->FREQ0);
	halRfWriteReg(CCxxx0_MDMCFG4, pRfSettings->MDMCFG4);
	halRfWriteReg(CCxxx0_MDMCFG3, pRfSettings->MDMCFG3);
	halRfWriteReg(CCxxx0_MDMCFG2, pRfSettings->MDMCFG2);
	halRfWriteReg(CCxxx0_MDMCFG1, pRfSettings->MDMCFG1);
	halRfWriteReg(CCxxx0_MDMCFG0, pRfSettings->MDMCFG0);
	halRfWriteReg(CCxxx0_CHANNR, pRfSettings->CHANNR);
	halRfWriteReg(CCxxx0_DEVIATN, pRfSettings->DEVIATN);
	halRfWriteReg(CCxxx0_FREND1, pRfSettings->FREND1);
	halRfWriteReg(CCxxx0_FREND0, pRfSettings->FREND0);
	halRfWriteReg(CCxxx0_MCSM0, pRfSettings->MCSM0);
	halRfWriteReg(CCxxx0_FOCCFG, pRfSettings->FOCCFG);
	halRfWriteReg(CCxxx0_BSCFG, pRfSettings->BSCFG);
	halRfWriteReg(CCxxx0_AGCCTRL2, pRfSettings->AGCCTRL2);
	halRfWriteReg(CCxxx0_AGCCTRL1, pRfSettings->AGCCTRL1);
	halRfWriteReg(CCxxx0_AGCCTRL0, pRfSettings->AGCCTRL0);
	halRfWriteReg(CCxxx0_FSCAL3, pRfSettings->FSCAL3);
	halRfWriteReg(CCxxx0_FSCAL2, pRfSettings->FSCAL2);
	halRfWriteReg(CCxxx0_FSCAL1, pRfSettings->FSCAL1);
	halRfWriteReg(CCxxx0_FSCAL0, pRfSettings->FSCAL0);
	halRfWriteReg(CCxxx0_FSTEST, pRfSettings->FSTEST);
	halRfWriteReg(CCxxx0_TEST2, pRfSettings->TEST2);
	halRfWriteReg(CCxxx0_TEST1, pRfSettings->TEST1);
	halRfWriteReg(CCxxx0_TEST0, pRfSettings->TEST0);
	halRfWriteReg(CCxxx0_FIFOTHR, pRfSettings->FIFOTHR);
	halRfWriteReg(CCxxx0_IOCFG2, pRfSettings->IOCFG2);
	halRfWriteReg(CCxxx0_IOCFG0, pRfSettings->IOCFG0);
	halRfWriteReg(CCxxx0_PKTCTRL1, pRfSettings->PKTCTRL1);
	halRfWriteReg(CCxxx0_PKTCTRL0, pRfSettings->PKTCTRL0);
	halRfWriteReg(CCxxx0_ADDR, pRfSettings->ADDR);
	halRfWriteReg(CCxxx0_PKTLEN, pRfSettings->PKTLEN);
}



