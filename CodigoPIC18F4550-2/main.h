#include <18F4550.h>
#device ADC=10

#FUSES XT,NOWDT            	//No Watch Dog Timer

#use delay(crystal=8MHz)
#use rs232(baud=9600, xmit=PIN_C6,rcv=PIN_C7, bits=8, parity=N)

