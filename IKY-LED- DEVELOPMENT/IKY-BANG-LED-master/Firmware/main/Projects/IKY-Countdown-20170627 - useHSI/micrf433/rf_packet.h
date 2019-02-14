#ifndef __RF_PACKET_H
#define __RF_PACKET_H
/* Includes ------------------------------------------------------------------*/
#include "stm32f10x.h"
#include "ringbuf.h"
//
#define REMOTE_CN_BTN4_VALUE         0x01000000
#define REMOTE_CN_BTN3_VALUE         0x00010000
#define REMOTE_CN_BTN2_VALUE         0x00000100
#define REMOTE_CN_BTN1_VALUE         0x00000001

#define REMOTE_BTN1_LONG_PRESS_VALUE    0x04
#define REMOTE_BTN2_LONG_PRESS_VALUE    0x05
#define REMOTE_BTN3_LONG_PRESS_VALUE    0x06
//PIR Detect
#define PIR_ACTIVE_VALUE                0x01
#define PIR_INACTIVE_VALUE              0x02
//DOOR Detect
#define DOOR_CLOSE_VALUE                0x01
#define DOOR_OPEN_VALUE                 0x02
//Opcode Table
#define OPCODE_REMOTE_BTN_PRESS         0x01
#define OPCODE_REMOTE_BTN_LONG_PRESS    0x02
//
#define RRP_WAIT_START_PULSE            0x01
#define RRP_RECORD_8_BITS               0x02
//
typedef struct {
  uint8_t start;
  uint16_t length;
  uint8_t opcode;
  uint8_t *dataPt;
  uint8_t crc;	
} Rf_MSG_Typedef;

typedef struct {
  uint8_t addr[5];
  uint32_t data;
	uint8_t flag;
} Radio_433_CN_Typedef;

extern RINGBUF rrp_rx_ringbuff;
extern Radio_433_CN_Typedef rf_cn_packet;
extern uint8_t rf_cn_pulse_buff[50];
extern uint8_t rf_cn_bit_buff[25];;

void config_rf_module(uint32_t mode);
void receive_rf_packet_init(void);
void receive_rf_packet_callback(uint16_t cnt);
void receive_rf_china_packet_callback(uint16_t cnt, uint8_t status);
#endif /* __RF_PACKET_H */

/*****END OF FILE****/

