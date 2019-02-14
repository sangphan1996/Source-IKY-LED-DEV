
#ifndef FRAMEBUFFER_H_
#define FRAMEBUFFER_H_

#include <stdint.h>
#include <string.h>
#include <stdio.h>
#include "config.h"


#define FRAMEBUFFER_TYPE			uint8_t
#define MSG_MAX_LENGTH				64
#define	STRING_LINE_EMPTY			"        "

typedef struct{
	uint8_t topScroll;
	char top_msg[MSG_MAX_LENGTH];
	char bot_msg[MSG_MAX_LENGTH];
	uint16_t preTopPixelLen;
	uint16_t curTopPixelLen;
	uint16_t bot_pixel_len;
}SCREEN_TYPE;

extern SCREEN_TYPE screen;
extern uint8_t framebuffer_displaybuffer[64];


void frameInit(void);
void frameClear(void);
void frameFill(void);

void ScrollMsgTask(void);
#endif /* FRAMEBUFFER_H_ */
