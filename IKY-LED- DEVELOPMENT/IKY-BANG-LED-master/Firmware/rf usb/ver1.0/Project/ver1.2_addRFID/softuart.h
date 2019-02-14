
#ifndef __SOFTUART_H
#define __SOFTUART_H

#include "stm8l15x.h"

#define SOFTUART_USE_TXD                0

#define SOFTUART_BAUD_RATE      	9600
  
#define SOFTUART_IN_BUF_SIZE     	128

#define SOFTUART_RX_PORT                GPIOB
#define SOFTUART_RX_PIN                 GPIO_Pin_3

typedef struct {
	//tx
	volatile uint8_t flag_tx_busy;
	volatile uint8_t timer_tx_ctr;
	volatile uint16_t internal_tx_buffer;
	volatile uint8_t bits_left_in_tx;
	//rx
	volatile uint8_t flag_rx_off;
	volatile uint8_t flag_rx_ready;
	uint8_t flag_rx_waiting_for_stop_bit;	
	uint8_t timer_rx_ctr;
	uint8_t internal_rx_buffer;
	uint8_t rx_mask;	
	uint8_t bits_left_in_rx;
	uint8_t txd_pin_number;
	uint8_t rxd_pin_number;
	volatile uint8_t qin;
	uint8_t qout;
	volatile uint8_t inbuf[SOFTUART_IN_BUF_SIZE];
}SOFTUART_TYPE;


extern SOFTUART_TYPE softuart1;
extern SOFTUART_TYPE softuart2;

// Init the Software Uart
void softuart_init(void);
void softuart_reinit( void );
void softuart_deinit( void );

void timer_uart_event_handler(void);

// Clears the contents of the input buffer.
void softuart_flush_input_buffer( SOFTUART_TYPE *uart );

// Tests whether an input character has been received.
unsigned char softuart_kbhit( SOFTUART_TYPE *uart );

// Reads a character from the input buffer, waiting if necessary.
char softuart_getchar( SOFTUART_TYPE *uart );

// To check if transmitter is busy
unsigned char softuart_transmit_busy( SOFTUART_TYPE *uart );

// Writes a character to the serial port.
void softuart_putchar( SOFTUART_TYPE *uart, const char ch );

// Turns on the receive function.
void softuart_turn_rx_on( SOFTUART_TYPE *uart );

// Turns off the receive function.
void softuart_turn_rx_off( SOFTUART_TYPE *uart );

// Write a NULL-terminated string from RAM to the serial port
void softuart_puts( SOFTUART_TYPE *uart, const char *s );

#endif //__SOFTUART_H

