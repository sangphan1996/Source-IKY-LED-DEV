

#include "softuart.h"

#define SU_TRUE    1
#define SU_FALSE   0

// startbit and stopbit parsed internally (see ISR)
#define RX_NUM_OF_BITS (8)

// 1 Startbit, 8 Databits, 1 Stopbit = 10 Bits/Frame
#define TX_NUM_OF_BITS (10)


SOFTUART_TYPE softuart1;

void transmitter_section_callback(SOFTUART_TYPE *uart)
{	
	uint8_t tmp;
	if ( uart->flag_tx_busy == SU_TRUE ) {
		tmp = uart->timer_tx_ctr;
		if ( --tmp == 0 ) { // if ( --timer_tx_ctr <= 0 )
			if ( uart->internal_tx_buffer & 0x01 ) {
				GPIO_SetBits(SOFTUART_TX_PORT, SOFTUART_TX_PIN);
			}
			else {
				GPIO_ResetBits(SOFTUART_TX_PORT,SOFTUART_TX_PIN);
			}
			uart->internal_tx_buffer >>= 1;
			tmp = 3; // timer_tx_ctr = 3;
			if ( --uart->bits_left_in_tx == 0 ) {
				uart->flag_tx_busy = SU_FALSE;
			}
		}
		uart->timer_tx_ctr = tmp;
	}
}

void receiver_section_callback(SOFTUART_TYPE *uart)
{
	uint8_t tmp;
	uint8_t start_bit, flag_in;
	
	if ( uart->flag_rx_off == SU_FALSE ) {
		if ( uart->flag_rx_waiting_for_stop_bit ) {
			if ( --uart->timer_rx_ctr == 0 ) {
				uart->flag_rx_waiting_for_stop_bit = SU_FALSE;
				uart->flag_rx_ready = SU_FALSE;
				uart->inbuf[uart->qin] = uart->internal_rx_buffer;
				if ( ++uart->qin >= SOFTUART_IN_BUF_SIZE ) {
					// overflow - reset inbuf-index
					uart->qin = 0;
				}
			}
		}
		else {  // rx_test_busy
			if ( uart->flag_rx_ready == SU_FALSE ) {
				start_bit = GPIO_ReadInputDataBit(SOFTUART_RX_PORT,SOFTUART_RX_PIN);
				// test for start bit
				if ( start_bit == 0 ) {
					uart->flag_rx_ready      = SU_TRUE;
					uart->internal_rx_buffer = 0;
					uart->timer_rx_ctr       = 4;
					uart->bits_left_in_rx    = RX_NUM_OF_BITS;
					uart->rx_mask            = 1;
				}
			}
			else {  // rx_busy
				tmp = uart->timer_rx_ctr;
				if ( --tmp == 0 ) { // if ( --timer_rx_ctr == 0 ) {
					// rcv
					tmp = 3;
					flag_in = GPIO_ReadInputDataBit(SOFTUART_RX_PORT,SOFTUART_RX_PIN);
					if ( flag_in ) {
						uart->internal_rx_buffer |= uart->rx_mask;
					}
					uart->rx_mask <<= 1;
					if ( --uart->bits_left_in_rx == 0 ) {
						uart->flag_rx_waiting_for_stop_bit = SU_TRUE;
					}
				}
				uart->timer_rx_ctr = tmp;
			}
		}
	}
}

void timer_uart_event_handler(void)
{	
  receiver_section_callback(&softuart1);
  transmitter_section_callback(&softuart1);
}

void timer32_init(void)
{
    uint32_t time_us = (1000000 / SOFTUART_BAUD_RATE)/3;
            
    CLK_PeripheralClockConfig(CLK_Peripheral_TIM2, ENABLE);
    TIM2_DeInit();
    TIM2_TimeBaseInit(TIM2_Prescaler_16, TIM2_CounterMode_Up, time_us);
    TIM2_ClearFlag(TIM2_FLAG_Update);
    TIM2_ITConfig(TIM2_IT_Update, ENABLE);
    TIM2_Cmd(ENABLE);
}

void softuart_channel_init(SOFTUART_TYPE *uart)
{
	uart->flag_tx_busy  = SU_FALSE;
	uart->flag_rx_ready = SU_FALSE;
	uart->flag_rx_off   = SU_FALSE;
	uart->flag_rx_waiting_for_stop_bit = SU_FALSE;
	//
	GPIO_Init(SOFTUART_RX_PORT, SOFTUART_RX_PIN, GPIO_Mode_In_FL_No_IT);
        GPIO_Init(SOFTUART_TX_PORT, SOFTUART_TX_PIN, GPIO_Mode_Out_PP_High_Fast);
}

void softuart_init( void )
{
	softuart_channel_init(&softuart1);	
	timer32_init();
}

void softuart_reinit( void )
{

}

void softuart_deinit( void )
{

}

static void idle(void)
{
	// timeout handling goes here 
	// - but there is a "softuart_kbhit" in this code...
	// add watchdog-reset here if needed
}

void softuart_turn_rx_on( SOFTUART_TYPE *uart )
{
	uart->flag_rx_off = SU_FALSE;
}

void softuart_turn_rx_off( SOFTUART_TYPE *uart )
{
	uart->flag_rx_off = SU_TRUE;
}

char softuart_getchar( SOFTUART_TYPE *uart )
{
	char ch;

	while ( uart->qout == uart->qin ) {
		idle();
	}
	ch = uart->inbuf[uart->qout];
	if ( ++uart->qout >= SOFTUART_IN_BUF_SIZE ) {
		uart->qout = 0;
	}
	
	return( ch );
}

unsigned char softuart_kbhit( SOFTUART_TYPE *uart )
{
	return( uart->qin != uart->qout );
}

void softuart_flush_input_buffer( SOFTUART_TYPE *uart )
{
	uart->qin  = 0;
	uart->qout = 0;
}
	
unsigned char softuart_transmit_busy( SOFTUART_TYPE *uart ) 
{
	return ( uart->flag_tx_busy == SU_TRUE ) ? 1 : 0;
}

void softuart_putchar( SOFTUART_TYPE *uart, const char ch )
{
	while ( uart->flag_tx_busy == SU_TRUE ) {
		; // wait for transmitter ready
		  // add watchdog-reset here if needed;
	}

	// invoke_UART_transmit
	uart->timer_tx_ctr       = 3;
	uart->bits_left_in_tx    = TX_NUM_OF_BITS;
	uart->internal_tx_buffer = ( ch << 1 ) | 0x200;
	uart->flag_tx_busy       = SU_TRUE;
}
	
void softuart_puts( SOFTUART_TYPE *uart, const char *s )
{
	while ( *s ) {
		softuart_putchar( uart,*s++ );
	}
}

