#ifndef __RF_PACKET_H
#define __RF_PACKET_H
/* Includes ------------------------------------------------------------------*/
#include "stm8l15x.h"
#include "encrypt.h"
/* Private define ------------------------------------------------------------*/
#define RF_ADDRESS                      0x02
#define RF_PATABLE                      0xC0
//
//Packet Infor
#define PACKET_TX_LENGTH_POSITION	(0)
#define PACKET_TX_ADDR_POSITION		(PACKET_TX_LENGTH_POSITION + 1)
#define PACKET_TX_DATA_POSITION		(PACKET_TX_ADDR_POSITION + 1)

#define RF_ID_DEFAULT                   0xA5A6A7A8
#define RF_VALUE_DUMMY                  0xAA
#define RF_VALUE_BUTTON_SHORT_PRESS	0x01
#define RF_VALUE_BUTTON_LONG_PRESS	0x02
#define RF_VALUE_EXCEPTION              0xA5
#define RF_VALUE_BTN_1_PRESS            0xB1
#define RF_VALUE_BTN_2_PRESS            0xB2
#define RF_VALUE_BTN_3_PRESS            0xB3

typedef struct {
  uint8_t start;
  uint16_t length;
  uint8_t opcode;
  uint8_t *dataPt;
  uint8_t crc;	
} Rf_MSG_Typedef;

extern Rf_MSG_Typedef Rf_MSG;

void RfPacket_Init(void);
void RfPacket_Prepare(Rf_MSG_Typedef *packet,uint8_t opcode,uint8_t *data,uint16_t length);
void RfPacket_Send(void);
void rfSend_Task(void);
#endif /* __RF_PACKET_H */

/*****END OF FILE****/