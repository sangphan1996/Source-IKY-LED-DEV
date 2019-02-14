#ifndef __RFID_DECODE_H
#define __RFID_DECODE_H
#include "stm8s.h"

extern uint8_t rfid_decode_wait_process;
extern uint8_t rfid_decode_data[6];

void rfid_decode_packet_init(void);
void rfid_decode_packet_packet_callback(uint16_t cnt);
#endif /* __RFID_DECODE_H */

