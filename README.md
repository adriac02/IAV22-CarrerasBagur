# IAV22-CarrerasBagur

## IDEA DE PROYECTO

Mi idea es crear una IA que utilice el modelo de lenguaje GPT-3, creado por OpenAI para crear un juego con NPCs a los que puedas hablar y respondan de manera
inteligente e independiente.

Pasándole una serie de frases que expliquen al NPC antes de empezar el juego, debería poder tener una historia de Background que refleje en su
personalidad.

Además podría cambiar su comportamiento dentro del juego según lo que le digas.
Ej.: Si le dices al NPC que has escuchado un ruido en una habitación X, el NPC podría evitar esa habitación en el caso de que tenga una personalidad miedosa, 
o ir a ver que sucede si es valiente.

##  Planteamiento del proyecto
Para implementar GPT-3 he encontrado un repositorio en github que facilita la implementación de este en unity: https://github.com/ivomarel/OpenAI_Unity

El proyecto va a tratar del personaje del jugador y el personaje con IA.

El jugador puede interactuar con todo el entorno con un controlador normal que le permita moverse y abrir puertas, examinar objetos, etc. además de un cuadro de
texto que se podrá abrir en cualquier momento en el que esté cerca de la IA para interactuar con esta. La implementación del código de este jugador es más
bien sencilla, con scripts de movimiento y teclas especiales, además de una tecla para abrir el cuadro de texto.

Para que el juego pueda comunicar los dos personajes se va a implementar un GameManager que registre los mensajes de cada uno de ellos para, además de poder
recibir respuestas, la Ia hecha con GPT-3 sea capaz de recordar e interpretar toda la conversación que ha tenido el personaje, con memoria.

La implementación de la IA va a retocarse según necesite la API de OpenAI la cual aún no domino completamente, pero la idea general es la siguiente:

```
clase IA:
  string[] registroMensajes
  GameManager* gM //Para tener referencia al GameManager y poder actuar en consecuencia
  
  void recieveMsg(string) //Aquí recibe e interpreta los mensajes que manda el jugador
  void sendReply(string) //Manda la respuesta al gameManager para que este se la mande al jugador
  void Update() //Teniendo en cuenta el registro de los mensajes y lo que se haya guardado en el gameManager, hacer que por ejemplo evite una zona del mapa
  void insertBG(string[]) //Insertar a la IA una historia de fondo para que el personaje esté realmente metido en el juego y que sepa qué hace ahí y quién es, para crear un rol realista
  ```

  ## Memoria API
  Al empezar con el proyecto me he encontrado con muchísimos problemas que me han retrasado en las demás tareas que tenía planteadas.

  Para empezar he descubierto que la API de OpenAI de GPT3, pese a ser una API abierta, es de pago, he hecho lo que he podido con las herramientas que tenía y lo he conseguido implementar funcionalmente.

  Para conseguir esto empecé a pelearme con NuGet, un administrador de paquetes para .NET que jamás había utilizado, aunque me parece muy poderoso. Instalé un paquete que implementaba NuGet en Unity (https://github.com/GlitchEnzo/NuGetForUnity). Aunque este no dió muy buenos resultados.

  Al principio todo fueron conflictos entre versiones de los diferentes paquetes que tenía que utilizar, además el paquete de NuGet para Unity duplicaba algunos archivos y hacía que estos quedaran inservibles.

  Al final descubrí que podía añadir manualmente las librerías sin necesitar un instalador de paquetes ni nada parecido.

  Seguí más o menos este tutorial (https://unitycoder.com/blog/2022/02/05/using-open-ai-gpt-3-api-in-unity/) realizando los cambios que veía necesarios relativos a librerías y versiones, y al final conseguí una IA que completaba el texto que le insertaba.
  

## Memoria Escena

Empecé una escena vacía y añadí un Trigger que simulaba al personaje con la IA, que te permitía interactuar con él solo cuando estabas dentro de su rango.

Además implementé un jugador simple que se puede mover en todas direcciones con un controlador sencillo.

Lo más interesante del jugador es la capacidad de poder introducir texto dirigido a la IA mediante un TextField en el canvas.

# IMPORTANTE SOBRE MI PROYECTO CON GPT3
## Fine-Tuning
La idea inicial que tuve fue entrenar a la IA pasándole varios strings con los que entendía su background, su personalidad etc.

Me he encontrado con muchos problemas por el camino, pero conseguí crear un nuevo motor basado en Curie (uno de los motores base de GPT3), pero este no es compatible con la SDK que estoy utilizando para Unity, así que voy a hacer un video a parte probando ese modelo en la misma página de OpenAI donde sí funciona.

Es un modelo que creé con la finalidad de realizar diálogos de película western, para ello lo entrené con el guion de la película "Los Odiosos Ocho" de Quentin Tarantino.

![Training](imgs/training.png)

Después de crear el JSONL de todo el guión, utilizé el Command-Line de OpenAI para crear un archivo de entrenamiento para un modelo que pudiera entender GPT-3.

![Training_Preparation](imgs/training_prepared.png)

A partir de aquí seguí usando la Command-Line para finalmente crear el motor curie:ft-personal:tarantain-2022-05-23-01-10-42

![Engine](imgs/engine.png)

A partir de aquí puedo hablar con el bot perfectamente, como un chatbot refinado al extremo con temática Western, aunque realmente ya sabiendo cómo se hace, es cuestión de encontrar una database mayor para refinarlo hacia donde se desee.

![WesternChat](imgs/WesternChat.png)

También puede generar él solo un guión de película Western.

![WesternScript](imgs/WesternScript.png)

El mismo OpenAI nos avisa de que contiene contenido sensible, ya que la película con la que ha sido entrenado el motor tiene diálogos con este estilo de palabras.

