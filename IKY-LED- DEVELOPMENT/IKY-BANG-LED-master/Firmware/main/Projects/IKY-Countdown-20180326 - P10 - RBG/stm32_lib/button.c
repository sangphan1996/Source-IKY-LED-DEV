#include "button.h"
#include "hw_config.h"
#include <stdio.h>

/* Button states */
#define BUTTON_STATE_START        0
#define BUTTON_STATE_PRESSED      1
#define BUTTON_STATE_WAITRELEASE  2

TM_BUTTON_t TM_Button_1;

/* Internal functions */
void TM_BUTTON_INT_CheckButton(TM_BUTTON_t* ButtonStruct);

void TM_BUTTON_Init(TM_BUTTON_t* ButtonStruct,GPIO_TypeDef* GPIOx, uint16_t GPIO_Pin, uint8_t ButtonState, void (*ButtonHandler)(TM_BUTTON_PressType_t), void (*ButtonReleasedHandler)(TM_BUTTON_PressType_t)) {
	
	GPIOMode_TypeDef P;
	GPIO_InitTypeDef GPIO_InitStructure;
	/* Save settings */
	ButtonStruct->GPIOx = GPIOx;
	ButtonStruct->GPIO_Pin = GPIO_Pin;
	ButtonStruct->GPIO_State = ButtonState ? 1 : 0;
	ButtonStruct->ButtonHandler = ButtonHandler;
	ButtonStruct->ButtonReleasedHandler = ButtonReleasedHandler;
	ButtonStruct->State = BUTTON_STATE_START;
	
	/* Init pin with pull resistor */
	if (ButtonStruct->GPIO_State) {
		/* Pulldown */
		P = GPIO_Mode_IPD;
	} else {
		/* Pullup */
		P = GPIO_Mode_IPU;
	}
	
	/* Set default values */
	ButtonStruct->PressNormalTime = BUTTON_NORMAL_PRESS_TIME;
	ButtonStruct->PressLongTime = BUTTON_LONG_PRESS_TIME;
	/* Init GPIO pin as input with proper pull resistor */	
	
	GPIO_InitStructure.GPIO_Pin   = GPIO_Pin;
	GPIO_InitStructure.GPIO_Mode  = P;
	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_10MHz;
	GPIO_Init(GPIOx, &GPIO_InitStructure);
}

TM_BUTTON_t* TM_BUTTON_SetPressTime(TM_BUTTON_t* ButtonStruct, uint16_t Normal, uint16_t Long) {
	/* Set values */
	ButtonStruct->PressNormalTime = Normal;
	ButtonStruct->PressLongTime = Long;
	
	/* Return pointer */
	return ButtonStruct;
}

void TM_BUTTON_Update(TM_BUTTON_t* ButtonStruct) {
        TM_BUTTON_INT_CheckButton(ButtonStruct);	
}

/* Internal functions */
void TM_BUTTON_INT_CheckButton(TM_BUTTON_t* ButtonStruct) {
	uint8_t status = GPIO_ReadInputDataBit(ButtonStruct->GPIOx,ButtonStruct->GPIO_Pin);
	uint32_t now = SysTick_Get();
	
	/* First stage */
	if (ButtonStruct->State == BUTTON_STATE_START) {
		/* Check if pressed */
		if (status == ButtonStruct->GPIO_State) {
			/* Button pressed, go to stage BUTTON_STATE_START */
			ButtonStruct->State = BUTTON_STATE_PRESSED;
			
			/* Save pressed time */
			ButtonStruct->StartTime = now;
			
			/* Button pressed OK, call function */
			if (ButtonStruct->ButtonHandler) {
				/* Call function callback */
				ButtonStruct->ButtonHandler(TM_BUTTON_PressType_OnPressed);
			}
		}               
    else{
			/* Button released, call function */
			if (ButtonStruct->ButtonReleasedHandler) {
				/* Call function callback */
				ButtonStruct->ButtonReleasedHandler(TM_BUTTON_PressType_OnPressed);
			}
		}
	}
	
	if (ButtonStruct->State == BUTTON_STATE_PRESSED) {
		/* Button still pressed */
		/* Check for long press */
		if (status == ButtonStruct->GPIO_State) {
			if (now > (ButtonStruct->StartTime + ButtonStruct->PressLongTime)) {
				/* Button pressed OK, call function */
				if (ButtonStruct->ButtonHandler) {
					/* Call function callback */
					ButtonStruct->ButtonHandler(TM_BUTTON_PressType_Long);
				}
				
				/* Go to stage BUTTON_STATE_WAITRELEASE */
				ButtonStruct->State = BUTTON_STATE_WAITRELEASE;
			}
		} else if (status != ButtonStruct->GPIO_State) {
			/* Not pressed */
			if (now > (ButtonStruct->StartTime + ButtonStruct->PressNormalTime)) {
				/* Button pressed OK, call function */
				if (ButtonStruct->ButtonHandler) {
					/* Call function callback */
					ButtonStruct->ButtonHandler(TM_BUTTON_PressType_Normal);
				}
				
				/* Go to stage BUTTON_STATE_WAITRELEASE */
				ButtonStruct->State = BUTTON_STATE_WAITRELEASE;
			} else {
				/* Go to state BUTTON_STATE_START */
				ButtonStruct->State = BUTTON_STATE_START;
			}
		} else {
			/* Go to state BUTTON_STATE_START */
			ButtonStruct->State = BUTTON_STATE_START;
		}
	}
	
	if (ButtonStruct->State == BUTTON_STATE_WAITRELEASE) {
		/* Wait till button released */
		if (status != ButtonStruct->GPIO_State) {
			/* Go to stage 0 again */
			ButtonStruct->State = BUTTON_STATE_START;
		}
	}
	
	/* Save current status */
	ButtonStruct->LastStatus = status;
}
