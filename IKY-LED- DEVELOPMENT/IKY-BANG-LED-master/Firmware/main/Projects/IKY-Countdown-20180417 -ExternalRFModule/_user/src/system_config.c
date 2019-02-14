#include "system_config.h"
#include "logger.h"


AppInfoCfg_TypeDef sysCfg;
uint8_t saveConfigFlag = 0;

void CFG_ReLoad(void)
{
	memcpy(&sysCfg, (void*)CONFIG_AREA_START, sizeof(AppInfoCfg_TypeDef));
}
void CFG_Load(void)
{
	uint32_t saveFlag = 0,u32Temp = 0;
	int16_t i;
	uint8_t *u8Pt;
	memcpy(&sysCfg, (void*)CONFIG_AREA_START, sizeof(AppInfoCfg_TypeDef));
	u8Pt = (uint8_t *)&sysCfg;
	u32Temp = 0;
	for(i = 0;i < sizeof(AppInfoCfg_TypeDef)-sizeof(sysCfg.crc);i++)
	{
		u32Temp += u8Pt[i];
	}
	if(u32Temp != sysCfg.crc)
	{
		saveFlag = 1;
	}
	
	if(sysCfg.size != sizeof(AppInfoCfg_TypeDef))
	{		
		sysCfg.size = sizeof(AppInfoCfg_TypeDef);		
		saveFlag = 1;
	}
	
	if(sysCfg.DevID == 0xFF)
	{
		sysCfg.DevID = DEFAULT_DEVID;
		saveFlag = 1;
	}
	
	if(sysCfg.Greeting[0] == 0xFF)
	{
		memset(sysCfg.Greeting,0,sizeof(sysCfg.Greeting));
		strcpy((char*)sysCfg.Greeting,DEFAULT_GREETING);
		saveFlag = 1;
	}
	
	if(sysCfg.GuestInf[0] == 0xFF)
	{
		memset(sysCfg.GuestInf,0,sizeof(sysCfg.GuestInf));
		strcpy((char*)sysCfg.GuestInf,DEFAULT_GUEST_INF);
		saveFlag = 1;
	}
	
	if(saveFlag)
	{
		CFG_Save();
	}
}


uint8_t CFG_CheckSum(AppInfoCfg_TypeDef *sysCfg)
{
	uint32_t u32Temp = 0;
	int16_t i;
	uint8_t *u8Pt;
	u8Pt = (uint8_t *)sysCfg;
	u32Temp = 0;
	for(i = 0;i < sizeof(AppInfoCfg_TypeDef)-sizeof(sysCfg->crc);i++)
	{
		u32Temp += u8Pt[i];
	}
	if(u32Temp != sysCfg->crc)
	{
		return 0;
	}
	return 1;
}
void CFG_Save(void)
{
	int16_t i;
	uint32_t u32Temp;
	uint8_t *u8Pt;
	uint32_t *cfgdest;
	uint16_t  FlashStatus;
	
	if(memcmp((void *)CONFIG_AREA_START,&sysCfg,sizeof(AppInfoCfg_TypeDef)) == NULL)
		return;
	__disable_irq();	
	
	u8Pt = (uint8_t *)&sysCfg;
	u32Temp = 0;
	for(i = 0;i < sizeof(AppInfoCfg_TypeDef)-sizeof(sysCfg.crc);i++)
	{
		u32Temp += u8Pt[i];
	}
	sysCfg.crc = u32Temp;
	
	FLASH_Unlock();
	for(i=0; i <= sizeof(AppInfoCfg_TypeDef)/ PAGE_SIZE; i++) 
	{
		FlashStatus = FLASH_ErasePage((uint32_t)(CONFIG_AREA_START + i*PAGE_SIZE));
		if(FLASH_COMPLETE != FlashStatus) 
		{
			FLASH_Lock();
			__enable_irq();
			return;
		}
	}
	cfgdest = (uint32_t*)&sysCfg;
	for(i=0; i < sizeof(AppInfoCfg_TypeDef); i+=4) 
	{
		FlashStatus = FLASH_ProgramWord(CONFIG_AREA_START + i, *(uint32_t*)(cfgdest + i/4));
		if(*(uint32_t*)(cfgdest + i/4) != *(uint32_t*)(CONFIG_AREA_START + i)) //check wrote data
		{
			FLASH_Lock();
		__enable_irq();
			return;
		}
	}
	FLASH_Lock();

	__enable_irq();
}


void CFG_Task(void)
{
	if(saveConfigFlag)
	{
		saveConfigFlag = 0;
		CFG_Save();
	}
}

