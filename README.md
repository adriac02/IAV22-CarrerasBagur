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
