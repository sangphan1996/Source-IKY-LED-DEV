#include "h_string.h"


void h_memcpy(uint8_t * src, uint8_t *des, uint16_t size)
{
  uint16_t i;
  for(i=0;i<size;i++)
  {
    src[i] = des[i];
  }
}

void h_memset(uint8_t * src, uint8_t var, uint16_t size)
{
  uint16_t i;
  for(i=0;i<size;i++)
  {
    src[i] = var;
  }
}

uint8_t h_memcmp(uint8_t * src1, uint8_t *src2, uint16_t size)
{
  uint16_t i;
  for(i=0;i<size;i++)
  {
    if(src1[i] != src2[i]) return 0;
  }
  return 1;
}