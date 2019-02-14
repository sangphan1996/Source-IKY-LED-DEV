
#include "framebuffer.h"
#include "font.h"
#include "ArialB16.h"
#include "SystemFont5x7.h"
#include "sys_tick.h"
#include "system_config.h"
#include "logger.h"
#include "display_task.h"

#define GFX_SCREEN_WIDTH			32
#define GFX_SCREEN_HEIGHT			16
#define GFX_CHAR_SPACING			1

#define P10_VRAM_BUFFER_1			1
#define P10_VRAM_BUFFER_2			2

uint8_t framebuffer_displaybuffer[64];
uint8_t framebuffer_writebuffer[64];

int8_t GFXGetCharWidth(char c);
void framePutPixel(int8_t x,int8_t y);

SCREEN_TYPE screen;
Timeout_Type tScrollMsg;


void frameInit(void)
{
	frameClear();
	memset(&screen,0x00,sizeof(SCREEN_TYPE));
	strcpy((char*)screen.top_msg,STRING_LINE_EMPTY);
	strcpy((char*)screen.bot_msg,STRING_LINE_EMPTY);
	screen.topScroll = 1;
	GFXSetFont(System5x7);
}

void frame_BufferClear(uint8_t buffer)
{
  uint8_t i;
  if(buffer == P10_VRAM_BUFFER_2)
  {
    for(i=0;i<64;i++) 
    {
      framebuffer_writebuffer[i] = 0xff;
    }
  }
  else if (buffer == P10_VRAM_BUFFER_1)
  {
    __disable_irq();
    for(i=0;i<64;i++) 
    {
      framebuffer_displaybuffer[i] = 0xff;
    }
    __enable_irq(); 
  }
}

void frameUpdate(void)
{
    uint8_t i;
    __disable_irq();
    for(i=0;i<64;i++) {framebuffer_displaybuffer[i] = framebuffer_writebuffer[i];}
    __enable_irq();
}

void frameClear(void)
{
	uint8_t i;
	__disable_irq();
	for(i=0;i<64;i++) 
	{
      framebuffer_displaybuffer[i] = 0xff;
      framebuffer_writebuffer[i] = 0xff;
	}
	__enable_irq();   
}
	
void frameFill(uint8_t color)
{
	uint8_t i;
	__disable_irq();
	for(i=0;i<64;i++) 
	{
      framebuffer_displaybuffer[i] = color;
      framebuffer_writebuffer[i] = color;
	}
	__enable_irq();   
}


void framePutPixel(int8_t x,int8_t y)
{
	uint8_t dd;
	uint8_t d;
	uint8_t xx;
	
	if(x<0 || x>=GFX_SCREEN_WIDTH || y<0 || y>=GFX_SCREEN_HEIGHT) 
	{
          return;
	}
	
	x = GFX_SCREEN_WIDTH - x -1;
	xx = x/8;
	
	d = framebuffer_writebuffer[xx*16+y];
	
	dd = x%8;
	
	dd = 7-dd;
	
	d &= ~(1<<dd);
		
	framebuffer_writebuffer[xx*16+y]=d;
	
}

int8_t GFXPutCharXY(int8_t x, int8_t y,char c,uint8_t color)
{
	uint8_t mask;
	int8_t _x,_y,fx,fy,b;
	uint8_t shift_val;
	uint8_t bit;
	uint8_t data;
	uint8_t i;
	uint8_t width = 0;
	uint8_t height = __GFXReadFontData(FONT_OFFSET_HEIGHT);
	uint8_t bytes = (height+7)/8;
	uint16_t address;
	
	uint8_t firstChar = __GFXReadFontData(FONT_OFFSET_FIRSTCHAR);
	uint8_t charCount = __GFXReadFontData(FONT_OFFSET_CHARCOUNT);
	
	uint16_t index = 0;
	
	if(c < firstChar || c >= (firstChar+charCount)) {
		return -1;//Error
	}
	
	c-= firstChar;
	
	// read width data, to get the index
	for(i=0; i<c; i++) {
		index += SYSTEM5x7_WIDTH;//__GFXReadFontData(FONT_OFFSET_WTABLE+i);
	}
	index = index + FONT_OFFSET_WTABLE;;//index*bytes+charCount+FONT_OFFSET_WTABLE;
	width = SYSTEM5x7_WIDTH;//__GFXReadFontData(FONT_OFFSET_WTABLE+c);


	//Draw
	
	_y=y;


	shift_val = (bytes*8) - height;

	bytes--;
	for(b=0;b<bytes;b++)
	{
		uint8_t mask=0x01;
		for(fy=0;fy<8;fy++)
		{

			if((_y+fy) > (GFX_SCREEN_HEIGHT-1))
			{
                          break;
                        }

			address=(index+b*width);

			for(_x=x,fx=0;fx<width;fx++,_x++)
			{
                            if(_x> (GFX_SCREEN_WIDTH-1))
                            {
                                break;
                            }

				data=__GFXReadFontData(address);

				bit = (data & mask);

				if(bit)
                                  framePutPixel(_x,_y+fy);

				address++;
                                
                                

			}
			mask=mask<<1;
		}
		_y+=8;
	}

	//Last Byte May require shifting so draw it separately

	mask = 1;//<<shift_val;        
	for(fy=0;fy<(8-shift_val);fy++)
	{
		if((_y+fy)>(GFX_SCREEN_HEIGHT-1))
		{
                  break;
                }
		
		address=(index+b*width);

		for(_x=x,fx=0;fx<width;fx++,_x++)
		{
			if(_x>(GFX_SCREEN_WIDTH-1))	
                        {
                          break;
                        }

			data=__GFXReadFontData(address);

			bit = (data & mask);

			if(bit)
			{
                          framePutPixel(_x,_y+fy);
			}
			//else
			//GFXRawPutPixel(_x,_y+fy,color_invert);

			address++;

		}
		mask=mask<<1;
	}
	return 1;
}

int8_t GFXWriteStringXY(int8_t x,int8_t y,const char *string,uint8_t color)
{
	int8_t w;
	while(*string!='\0')
	{
		if(GFXPutCharXY(x,y,*string,color) == -1)
                {                  
                  return -1;
                }
		
		w = GFXGetCharWidth(*string);
		if(w==-1)
                  return -1;

		x+= w;
		x+= GFX_CHAR_SPACING; //Blank Line after each char
		string++;
	}
	return 1;
}

int8_t GFXGetCharWidth(char c)
{

	uint8_t firstChar = __GFXReadFontData(FONT_OFFSET_FIRSTCHAR);
	uint8_t charCount = __GFXReadFontData(FONT_OFFSET_CHARCOUNT);
	
	return SYSTEM5x7_WIDTH; //Fixed width; char width table not used !!!!    
}

int16_t GFXGetStringWidth(const char *string)
{
	int16_t w,r;
        
	w=0;
	while(*string!='\0')
	{
		r = GFXGetCharWidth(*string);                
		if(r == -1) 
		{                  
			return -1;
		}
		w+= r;
		w+= GFX_CHAR_SPACING;//Extra Spacing Between Chars
		string++;
	}
	return w;
}
int16_t GFXGetStringWidthN(const char *string,uint8_t n)
{
	int16_t w,r;
	int8_t i=0;

	w=0;
	while(*string!='\0')
	{
		r=GFXGetCharWidth(*string);
		if(r==-1) return -1;

		w+=r;
		w+=GFX_CHAR_SPACING;//Extra Spacing Between Chars

		string++;
		
		if(i==n) break; else i++;
	}

	return w;
}
uint8_t CharIndexOfPixel(const char *s, uint16_t pixel)
{
	uint8_t index=0;
	
	while(1)
	{
		if(pixel<GFXGetStringWidthN(s,index))
			return index;
		else
			index++;
	}	
}

void ScrollMsgTask(void)
{
	static int16_t scroll = 0;
	int16_t pos = 0;
		
	if(CheckTimeout(&tScrollMsg) == SYSTICK_TIMEOUT)
	{		
			if(displayState == DISP_SELFTEST)
			{
				scroll++;
				if(scroll%2)
				{
					frameFill(0x00);
				}
				else
				{
					frameFill(0x0FF);
				}
			}
			else
			{
				screen.curTopPixelLen = GFXGetStringWidth((const char*)screen.top_msg);
			
				if(screen.preTopPixelLen != screen.curTopPixelLen)
				{
							scroll = 0;
							screen.preTopPixelLen = screen.curTopPixelLen;
				}
			
				frame_BufferClear(P10_VRAM_BUFFER_2);
				
				if(screen.topScroll)
				{
					pos = (GFX_SCREEN_WIDTH - 1) - (scroll);
				}
				GFXWriteStringXY(pos,0,screen.top_msg,0);
				
				GFXWriteStringXY(3,9,screen.bot_msg,0);
			
				frameUpdate();
						
				if(++scroll == (screen.curTopPixelLen + GFX_SCREEN_WIDTH))
				{
							scroll = 0;
				}
			}			
		  InitTimeout(&tScrollMsg,120);		 
	}
	
}
