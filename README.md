# UnityVR

## Cuestiones importantes para el uso

- Solo para el sistema Android.

- Descarga el juego -> VR_INTERFAZ -> VR_Game.apk(download).

Con la introducción de dispositivos Google Cardboard, están surgiendo experiencias inmersivas de realidad virtual para su uso generalizado.Estas experiencias se caracterizan por el sentido de presencia que crean, colocando a los usuraios en un entornos imaginarios, históricos, representativos e imposibles.

Las experiencias basadas en VR de este juego se centra en una interacción continue entre el jugador y el entorno en el que se situa.El juego utiliza el SDK CardBoard, que esta diseñado para poder jugar con el movil de Android.

- Dispositivo Android con Android 5.0 "Lollipop" (API nivel 21) o superior.
- Android Studio versión 3.4.1 o superior
- Android SDK 9 "Pie" (nivel de API 28) o superior
- Última versión del marco Android NDK

## Gameplay 

La escena consite en un mini pueblo donde el jugador debe conseguir ciertos objetivos poder esbloquear el camino hacia el torre(objetivo del jugaor).
El jugador debe apuntar mediante el "GvrReticlePointer" que es un puntero de retícula basado en la mirada a la superficie donde se situa multiples plataforma o objetos que llamamos teletransportador para poder moverse dentro de la escena.Cuando el jugador encuentra un enemigo en la escena puede usar el puntero de retícula apuntando a la posicion donde se situa el enemigo para iniciar un disparo y destruir el objeto(enemigo) que se te va acercando.

En la escena del juegp se incluye diferentes tipos de objetos:

- Enemigo(Momia) : Existen dos tipos de enemigos, el primer tipo se acerca al jugador si ha entrado en el campo de vision del objeto y el segundo tipo va persiguiendo al jugador cuando entra contacto con la portal mágica que hemos puesto en el camino y va reapareciendo si es destruido, es deicr, es immortal.

- Monedas: el jugador debe coleccionar monedas en la escena para poder desbloquer el camino a la Torre.

- Teletransportador : superficie en el cual el jugador puede moverse en él.

Si el jugador entra contacto con el enemigo va perdiendo vida y si la vida del jugador es inferior o igual a cero pierde la partida y deberia empezar de nuevo aventura para llegar al Torre.

## Hitos de programación logrados relacionándolos con los contenidos que se han impartido
- Hemos logrado la utilizacion y aprendizaje del SDK CardBoard para poder realizar la practica de VR en Unity.
- Comprender diferentes tipos de collisiones(Trigger o Collision).
- Realizacón de la interfaz en Unity conociendo diferentes tipos de objetos y como incluir diferentes tipos de objetos en la escena
- Conocer la parte física del Unity(rigidbody) y sus usos.
- Diferentes tipos de movimientos(Traslaciones, rotaciones...).
- Comprender diferentes tipos de envento y como agregar a los objetos de la escena.
- Utilización de Raycast.
- Cambios de escenas y incorporación de elementos audiovisual.
- Entorno de UI y sus principlaes usos.
- Uso de la cámara y como añadir una extension.

## Aspectos que destacarías en la aplicación.
- Incorporsción de inteligencia artificial.
- Movimientos del personaje.
- Detección de diferentes tipos de trigger.
- Inicia una rutina.

## Gif animado de ejecución

- Menu : 

![sponza](https://github.com/samjxxxx/UnityVR/blob/master/Gif/gifMenu.gif)


- Inicio/Gameplay: 

![sponza](https://github.com/samjxxxx/UnityVR/blob/master/gifInicio/.gif)


- Final : 

![sponza](https://github.com/samjxxxx/UnityVR/blob/master//gifFinal.gif)


## Acta de los acuerdos del grupo respecto al trabajo en equipo
Daniel Labena : Sistema de movimiento del personaje y disparo del personaje.

Daniel Gonzalez Marrero : Realizar IA del juego.

Jiaqi Jin: Extension para la cámara y diferentes tipos de sensores del jugador.

Trabajo Grupal: Entorno del juego y planteaminto de la jugabilidad DEL JUEGO.

 
