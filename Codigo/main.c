#include <main.h>
#fuses XT, NOWDT,NOPROTECT,NOLVP
#include <HDM64GS12.c> //Manejo del display gr�fico
#include <graphics.c> //Funciones para dibujar y escribir en el display

#byte trisb=0x86

///Defines

#define escala -0.6 //Escala negativa para que crezca hacia arriba.
#define limpiarGrafico limpiarPorcion(0,20,128,44) //Limpia el area del grafico
#define offset 52 //es el offset para la altura de la grafica

///Fin Defines

///Variables Globales

int x=0; //Posicion inicial de x para graficar la temperatura
float y=0; //Posicion inicial de y (Vamos a tener que cambiarla a la primer temperatura leida) para graficar la temperatura
int1 habilitarLectura=0; //Variable para habilitar o deshabilitar la captura de datos del sensor
char received = '\0';

///Fin Variables Globales

///Funciones

void limpiarPorcion(int x1, int y1, int x2, int y2){ //(x1, y1) = posici�n del primer pixel. (x2, y2) = cantididad de pixeles hacia la derecha y hacia abajo
   for(int i=x1;i<x1+x2;i++){
      for(int j=y1;j<y1+y2;j++){
         glcd_pixel(i, j, OFF); //Apagamos el pixel.
      }
   }
}

void nuevaLinea(float temp){ //Funcion para graficar las nuevas lineas de temperatura
   int x1=x+1;
   if(x1>128){ //Revisamos si sobrepasamos el tama�o de la pantalla
      limpiarGrafico; //Limpiamos el area del grafico
      x=0;
      x1=1;
   }
   glcd_line(x, (y*escala)+offset, x1, (temp*escala)+offset, ON); //multiplicamos por la escala para que la grafica entre en el area del grafico. El offset esta explicado arriba
   y=temp;
   x=x1;
}

///Fin Funciones

///Interrupciones

#INT_RB
void RB_isr(){ //Prueba de interrupciones
   if(input(pin_b6)){ //Habilita o deshabilita la captura de datos
      habilitarLectura=~habilitarLectura;
      if(habilitarLectura)
         glcd_text57(128/2-30, 0, (char*)"Capturando", 1, ON);
      else {
         glcd_text57(128/2-30, 0, (char*)"Capturando", 1, OFF);
         limpiarGrafico;
         x=0;
      }
   }
}

#int_rda
void serial_interrupt() {
   disable_interrupts(int_rda);
   received = getc();
   if(received == 'a') {
      glcd_text57(110,0,(char*)"BT",1,ON); //Mostramos BT
   } else if(received == 'b') {
      glcd_text57(110,0,(char*)"BT",1,OFF); //Mostramos BT
   }
}

///Fin Interrupciones

void main()
{
   int16 iAn;
   float t;
   char str[6];
   
   setup_adc_ports(AN0); //seteamos el pin A0 como analogico
   setup_adc(ADC_CLOCK_INTERNAL); //Establecemos el reloj interno
   glcd_init(on); //Inicializamos el lcd
   enable_interrupts(INT_RB); //Habilitamos las interrupciones del RB4-7
   enable_interrupts(GLOBAL); //Habilitamos las interrupciones globales

   glcd_text57(0,10,(char*)"Temperatura:",1,ON); //Escribimos el texto "Tempreatura:" en la posicion 0,10
   glcd_line(0, 8, 128, 8, ON); //Pintamos una linea por debajo del barra de notificaciones
   glcd_line(0, 19, 128, 19, ON); //Pintamos una linea por debajo de la temperatura
   
   while(TRUE){
      trisb|=0b01000000;
      //turn_on_bt();
      enable_interrupts(int_rda);
      if(habilitarLectura){
         set_adc_channel(0); //Seteamos el canal que vamos a leer
         delay_us(10); //Esperamos 10 us
         iAn=read_adc(); //Levantamos el dato
         t=(5.0*iAn*100.0)/1024.0; //Lo convertemos a temperatura
           
         if(t!=y){ //Si t es != al dato anterior refrescamos la temperatura y la enviamos al bluetooth
            str[0] = '\0';
            sprintf(str, "%4.2f�C", t); //Convertimos la temperatura float en un char*
            limpiarPorcion(12*6, 10, 9*6, 7); //Limpiamos la porcion de pantalla que tiene el valor de la temperatura. 12 es la cantiad de caracteres de "temperatura:"
            glcd_text57(12*6, 10, str, 1, ON); //Escribimos la temperatura.
         }
         if(t<=50){ //Si t es menor o igual a 50 la agregamos al grafico
            nuevaLinea(t); //Dibujamos la nueva linea en el grafico.
            glcd_text57(3, 0, (char*)"T>50", 1, OFF); //ocultamos la notificacion de t>50
         }
         else{
            glcd_text57(3, 0, (char*)"T>50", 1, ON); //Esto significa que no graficamos temperaturas superiores a 50
            y=t; //igualamos el dato anterior al valor de temperatura para no refrescar otra vez el valor de la temperatura
         }
         sprintf(str, "%4.2f", t); //Convertimos la temperatura float en un char*
         puts(str); //Enviamos la temperatura por bluetooth
         delay_ms(250);
      }
   }
}

