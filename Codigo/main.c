#include <main.h>
#include <string.h>
#fuses XT, NOWDT,NOPROTECT,NOLVP
#include <HDM64GS12.c> //Manejo del display gr�fico
#include <graphics.c> //Funciones para dibujar y escribir en el display

#byte trisb=0x86

///Defines

#define escala -0.20 //Escala negativa para que crezca hacia arriba.
#define limpiarGrafico limpiarPorcion(0,20,128,44) //Limpia el area del grafico

///Fin Defines

///Variables Globales

int x=0; //Posicion inicial de x para graficar la temperatura
signed int16 y=0; //Posicion inicial de y (Vamos a tener que cambiarla a la primer temperatura leida) para graficar la temperatura
int offset=52; //es el offset para la altura de la grafica

///Fin Variables Globales

///Funciones

void mostrarBT(int1 estado){ //Mostramos BT si el bluetooth esta prendido
   char bt[]="BT";
   glcd_text57(110,0,bt,1,estado);
}

void limpiarPorcion(int x1, int y1, int x2, int y2){ //(x1, y1) = posici�n del primer pixel. (x2, y2) = cantididad de pixeles hacia la derecha y hacia abajo
   for(int i=x1;i<x1+x2;i++){
      for(int j=y1;j<y1+y2;j++){
         glcd_pixel(i, j, OFF); //Apagamos el pixel.
      }
   }
}

void nuevaLinea(float temp){ //Funcion para graficar las nuevas lineas de temperatura
   int x1=x+2;
   if(x1>128){ //Revisamos si sobrepasamos el tama�o de la pantalla
		limpiarGrafico; //Limpiamos el area del grafico
      x=0;
      x1=2;
   }
   glcd_line(x, (y*escala)+offset, x1, (temp*escala)+offset, ON); //multiplicamos por la escala para que la grafica entre en el area del grafico. El offset esta explicado arriba
   y=temp;
   x=x1;
}

void turn_on_bt() {
   char value;
   value = getc(); //Obtenemos el dato
   if(value == 'a') { //Si el valor es a
      //output_high(LED1);   // LED ON
      mostrarBT(ON); //Mostramos BT
      delay_ms(500); //Delay 500 ms
   } else if(value == 'b') { //Si el valor es b
      //output_low(LED1);    // LED OFF
      mostrarBT(OFF); //No mostramos BT
      delay_ms(500); //Delay 500 ms
   } 
}

///Fin Funciones

///Interrupciones

#INT_RB
void RB_isr(){ //Prueba de interrupciones
	if(input(pin_b6)){
		limpiarGrafico;
		x=0;
	}
}

///Fin Interrupciones

void main()
{
   char str[10];
   char temp[]="Temperatura:";
   float t[]={37, 36.5, 38, -55, 150, 30}; //ESTO HAY QUE FLETARLO CUANDO YA EST� LA CAPTURA REAL
   
   glcd_init(on); //Inicializamos el lcd
	enable_interrupts(INT_RB); //Habilitamos las interrupciones del RB4-7
	enable_interrupts(GLOBAL); //Habilitamos las interrupciones globales

   glcd_text57(0,10,temp,1,ON); //Escribimos el texto "Tempreatura:" en la posicion 0,10
   glcd_line(0, 8, 128, 8, ON); //Pintamos una linea por debajo del barra de notificaciones
   glcd_line(0, 19, 128, 19, ON); //Pintamos una linea por debajo de la temperatura
     
   for(int i=0; i<10; i++){ //ESTO HAY QUE FLETARLO CUANDO YA EST� LA CAPTURA REAL || LO QUE ESTA ACA DESPUES VA AL WHILE(TRUE)
      sprintf(str, "%4.2f�C", t[i]); //Convertimos la temperatura float en un char*
      limpiarPorcion(strlen(temp)*6, 10, 9*6, 7); //Limpiamos la porcion de pantalla que tiene el valor de la temperatura.
      glcd_text57(strlen(temp)*6, 10, str, 1, ON); //Escribimos la temperatura.
      nuevaLinea(t[i]); //Dibujamos la nueva linea en el grafico.
      printf("%f\r", t[i]);
      //puts(str);
      delay_ms(200);
   }
     
   while(TRUE){
      trisb|=0b01000000;
      if(kbhit()) { // if data received 
         turn_on_bt();
      }
   }
}
