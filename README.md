# Final Project - Digital Electronics II

##### Table of Contents  
[English](#english)  
[Español](#espanyol)  

<a name="english"/>

## Temperature monitoring system for COVID-19 patients

### Participants
[Campo Francisco](https://gitlab.com/FCampo), [Galmarini Felipe Ignacio](https://github.com/naintoma), [Stanganelli Ezequiel](https://gitlab.com/eastanganelli), Vazquez Constanza.
Digital Electronics II, FICEN, Favaloro University.

### Abstract
In this report we will show the codes and schematics for the reproduction of a temperature monitoring system for COVID-19 patients using the PIC16F877 microcontroller, a bluetooth module and an LCD Grader.

### Introduction:
The PIC16F877 is a microcontroller that has a integrated circuit that can be programmed from many different ways.

The temperature sensor is a device that transforms an analog signal to a signal that can be processed in the microcontroller and then be transformed into a digital signal.

The temperatures handled by the LM35 sensor range from -55ºC (-550mV) to 150ºC (1500 mV) with a accuracy of 1 ° C which equals 10mV, then to be able to convert the analog value that returns the sensor the following should be done calculation: 

$` {Temperature} = {Value} \bullet {5} \bullet \tfrac{100}{1024} `$

Given the need to monitor constant temperature of infected patients with this virus, we devised a system to supply with this demand, using a temperature sensor, a microcontroller, a GLCD display and a bluetooth module to transfer data to a computer and thus be able to manage these depending on the need of who receive.

<a name="espanyol"/>

## Sistema de monitoreo de temperatura para pacientes con COVID-19

### Participantes
Campo Francisco, Galmarini Felipe Ignacio, Stanganelli Ezequiel, Vazquez Constanza.
Electrónica Digital II, FICEN, Universidad Favaloro.

### Resumen
En este informe mostraremos los códigos y esquemáticos para la reproducción de un sistema de monitoreo de temperatura para pacientes con COVID-19 utilizando el microcontrolador PIC16F877, un módulo de bluetooth y un LCD Graficador.



### Introducción:
El PIC16F877 es un microcontrolador que tiene uncircuito integrado que puede ser programado de muchas formas diferentes.

El sensor de temperatura es un dispositivo que transforma una señal analogica a una señal eléctrica que puede ser procesada en el microcontrolador y luego ser transformada en una señal digital.

Las temperaturas que maneja el sensor LM35 van desde -55ºC (-550mV) a 150ºC (1500 mV) con una precisión de 1°C que equivale a 10mV, entonces para poder convertir el valor analógico que
devuelve el sensor se debe hacer el siguiente cálculo:

$` {Temperatura} = {Valor} \bullet {5} \bullet \tfrac{100}{1024} `$

Ante la necesidad de mantener un monitoreo constante de la temperatura de pacientes infectados con este virus, ideamos un sistema para suplir con esta demanda, utilizando un sensor de temperatura, un microcontrolador, una pantalla GLCD y un módulo de bluetooth para transferir los datos a una computadora y así poder realizar un manejo de estos dependiendo de la necesidad de quien los reciba
