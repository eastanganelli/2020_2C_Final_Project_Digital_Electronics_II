#include <16F877.h>
#device ADC=10
#use delay(crystal=8000000)
#use rs232(baud=4800, xmit=PIN_C6,rcv=PIN_C7, bits=8, parity=N) // change pins compatible for your controller
