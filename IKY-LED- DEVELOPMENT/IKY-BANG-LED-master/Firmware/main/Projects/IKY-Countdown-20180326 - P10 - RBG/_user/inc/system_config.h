#ifndef __SYSTEM_CONFIG_H__
#define __SYSTEM_CONFIG_H__
#include <string.h>
#include <stdint.h>
#include <stdlib.h>
#include "stm32f10x_flash.h"

#define	CONFIG_SIZE_GREETING		64
#define	CONFIG_SIZE_GUEST_INF		64

#define PAGE_SIZE								(0x400)    /* 2 Kbyte */
#define FLASH_SIZE							(0x10000)  /* 64 KBytes */
#define CONFIG_AREA_SIZE				(0x400)
#define CONFIG_AREA_START 			((uint32_t)(0x8000000 + FLASH_SIZE - PAGE_SIZE*(CONFIG_AREA_SIZE/PAGE_SIZE)))

#define DEFAULT_GREETING				"IKY KINH CHAO QUY KHACH"
#define DEFAULT_GUEST_INF				"NGUYEN VAN A 59B1-85642"
#define DEFAULT_DEVID						1

typedef __packed struct
{
	uint16_t	size;
	uint8_t 	Greeting[CONFIG_SIZE_GREETING];
	uint8_t 	GuestInf[CONFIG_SIZE_GUEST_INF];
	uint8_t 	CheckOut[CONFIG_SIZE_GREETING];
	uint8_t 	DevID;
	uint8_t 	Name[30];
	uint8_t 	BKS[15];
	uint32_t 	Remote[2];
	uint8_t 	RemoteCN[5];
	uint32_t	crc;
} AppInfoCfg_TypeDef;


extern AppInfoCfg_TypeDef sysCfg;
extern uint8_t saveConfigFlag;


void ResetMcuSet(uint8_t resetType);
void ResetMcuTask(void);
void CFG_Save(void);
void CFG_Load(void);
void CFG_ReLoad(void);
void CFG_Write(uint8_t *buff, uint32_t address, int offset, int length);
uint8_t CFG_CheckSum(AppInfoCfg_TypeDef *sysCfg);
uint8_t CFG_Check(AppInfoCfg_TypeDef *sysCfg);
void CFG_Task(void);
#endif


