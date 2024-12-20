# Práctica 2. Servicio de descubrimiento con microservicios

## Descripción:

En este laboratorio implementarás un microservicio escalado horizontalmente con el servicio de descubrimiento Eureka.

## Objetivos de la práctica:

Al finalizar la práctica, serás capaz de:

- Comprender la estructura de un microservicio.
- Implementar el servicio de descubrimiento Eureka.
- Registrar microservicio.
- Escalado horizontal del microservicio.

## Duración aproximada
- 45 minutos.
  
---
<div style="width: 400px;">
        <table width="50%">
            <tr>
                <td style="text-align: center;">
                    <a href="../Capitulo1/"><img src="../images/anterior.png" width="40px"></a>
                    <br>Anterior
                </td>
                <td style="text-align: center;">
                   <a href="../README.md">Lista de laboratorios</a>
                </td>
<td style="text-align: center;">
                    <a href="../Capitulo3/"><img src="../images/siguiente.png" width="40px"></a>
                    <br>Siguiente
                </td>
            </tr>
        </table>
</div>

---

## Objetivo visual: 

![Implementacion](../images/2/inicial.png)

<br>

## Instrucciones:

### Tarea 1: Configuración de micro-item

1. Descargar el proyecto de Spring Boot de la carpeta [Capitulo2](../Capitulo2/) llamado **MicroserviceItem**.

2. Abrir el proyecto en Spring Tool Suite **File** > **Import** > **Existing Maven projects**.

3. Analizar la estructura del proyecto.

![estructura proyecto](../images/2/1.png)

4. Iniciar el proyecto: <br>

**Clic derecho al Proyecto** > **Run As** > **Spring Boot App**.

5. Iniciar un cliente para API's **Postman** o **Insomnia**.

6. Probar los siguientes endpoints: <br>
    - ## **GET** (*obtiene todos los productos*): http://localhost:8081/item

    <img src="../images/2/2.png" width="500px"><br>

    - ## **POST** (*inserta un nuevo producto*): http://localhost:8081/item <br>

    **Body format**

    ```json
    {
	"name":"jamon",
	"brand":"fud",
	"amount":500,
	"description":"jamón de pavo"
    }
    ```
    <img src="../images/2/3.png" width="500px"><br>

    - ## **DELETE** (*eliminar un producto por ID*): http://localhost:8081/item?id=2

    <img src="../images/2/4.png" width="500px"><br>

    - ## **PUT** (*actualiza un producto*): http://localhost:8081/item

    **Body format**

    ```json
    {
	"id":3,
	"name":"jamon",
	"brand":"fud",
	"amount":8000,
	"description":"jamón de pavo"
    }
    ```

    <img src="../images/2/5.png" width="500px">

### Tarea 2. Creación de Microservice Eureka

> Este microservicio nos permitirá llevar el registro de nuestros microservicios.

 1. Abrir Spring Tool Suite.
 
 2. Crear un proyecto nuevo **File** > **New** > **Spring Starter Project**.

 3. Configuración inicial:

    - **Name**: MicroserviceEureka <br>
    - **Type**: Maven<br>
    - **Packaging**: Jar<br>
    - **Language**: Java<br>
    - **Java Versión**: 17<br>
    - **Group**: com.bancolombia<br>
    - **Version**: 1.0.0<br>
    - **Description**: my discovery server<br>
    - **Package**: com.bancolombia.app<br>

5. Dependencies:<br>
    - **Spring Boot DevTools**<br>
    - **Eureka Server**<br>
    - **Spring Web**

6. Esperar unos minutos en lo que termina de construir el proyecto (*aproximadamanete 1 minuto*).

7. Configuración archivo de properties: **MicroserviceEureka** > **src/main/resources** > **application.properties**.

```properties
spring.application.name=micro-eureka
server.port=9999

#disable eureka replication
eureka.client.register-with-eureka=false
eureka.client.fetch-registry=false
eureka.server.max-threads-for-peer-replication=0
```

8. Activar Eureka Server en la clase principal: **MicroserviceEureka** > **src/main/java** > **com.bancolombia.app** > **MicroserviceEurekaApplicacion.java**.

```java
package com.bancolombia.app;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.netflix.eureka.server.EnableEurekaServer;

@EnableEurekaServer //aquí se activa
@SpringBootApplication
public class MicroserviceEurekaApplication {

	public static void main(String[] args) {
		SpringApplication.run(MicroserviceEurekaApplication.class, args);
	}

}

```

9. Iniciar la aplicación: **Clic derecho en el proyecto** > **Run As** > **Spring Boot App**.

10. Abrir un explorador web y escribir la siguiente ruta: **http://localhost:9999** *(debería abrir el dashboard de Eureka)*.

<img src="../images/2/6.png" width="700px">

### Tarea 3. Configuración MicroserviceItem con Eureka

1. Abrir el archivo **pom.xml** y añadir la siguiente dependencia:

> **IMPORTANTE**: *Si descargaste el proyecto **MicroserviceItem** del repositorio del curso, no es necesario añadir la dependencia, sólo valida que exista en el pom.xml*.

```xml
<dependency>
	<groupId>org.springframework.cloud</groupId>
	<artifactId>spring-cloud-starter-netflix-eureka-client</artifactId>
</dependency>
```

2. Abrir el archivo: **application.properties** **MicroserviceItem** > **src/main/resources** > **application.properties** y modificar la configuración con la siguiente: 

```properties
spring.application.name=micro-item
server.port=8081

#Eureka configuration
eureka.client.service-url.defaultZone=http://localhost:9999/eureka
```

3. Guardar todo e iniciar el microservicio de nuevo: **Clic derecho al proyecto** > **Run as** > **Spring Boot App**.


### Tarea 4. Validar el registro de MicroserviceItem en Eureka

1. Abrir un explorador web y abre el siguiente URL: **http://localhost:9999**.

> **IMPORTANTE**: Validar que el microservicio esté registrado como en la imagen siguiente:

<img src="../images/2/7.png" width="800px">

### Tarea 5. Levantar segunda instancia de MicroserviceItem

1. **Clic derecho al proyecto MicroserviceItem** > **Run As** > **Run Configurations** y realizar lo siguiente:

![pasos](../images/2/8.png)

- ## Explicación: <br>
    1. Seleccionar el microservicio Item. <br>
    2. Seleccionar **Arguments**.<br>
    3. Escribir el siguiente argumento: **-Dserver.port=8082** (*este argumento levantará una nueva instancia del microservicio item en el puerto 8082*).<br>
    4. **Run**: Inicia la instancia.<br>

> **NOTA**: Si el puerto está usado por otra aplicación, modifica el argumento.

### Tarea 5 (opcional). Probar los endpoints de la segunda instancia

> **NOTA**: Para este paso, usa POSTMAN o INSOMNIA.

## Resultado esperado:

![resultado](../images/2/9.png)
