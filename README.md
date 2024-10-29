Programa principal (Program.cs)
El archivo Program.cs es el punto de entrada del programa y coordina las operaciones principales de la máquina de Turing. Aquí se instancian las clases necesarias, y se proporciona la ruta del archivo que contiene las cadenas de entrada. Las tareas clave en este archivo incluyen:

Carga de datos: A través de la clase ScannerAFD, el programa carga las cadenas a procesar desde un archivo de texto.
Procesamiento de cadenas: Se lee cada cadena y se envía a las demás clases (MT, ScannerAFD, DosCintas, y Tablas) para su procesamiento.
Variables importantes:

filePath: Contiene la ruta del archivo con las cadenas de entrada.
scannerAFD: Instancia de ScannerAFD que se encarga de gestionar la lectura y el procesamiento de cada cadena en el autómata.
Máquina de Turing (MT.cs)
La clase MT representa la máquina de Turing, que se encarga de manejar la simbología (caracteres de entrada, caracteres especiales, y dirección de movimiento). Aquí se configura el conjunto de caracteres y la lógica de movimiento en cada estado.

Variables y métodos importantes en MT.cs:
List<char> caracteres: Lista de caracteres válidos para el autómata, que se pueden procesar como entradas.
List<char> caracteresEspeciales: Caracteres especiales utilizados para la máquina de Turing (por ejemplo, caracteres que indican el inicio o el fin de una cadena).
Dictionary<(int, char), string> direcciones: Este diccionario asocia un par de valores (estado y símbolo) con una dirección de movimiento ("Izquierda" o "Derecha"). Por ejemplo, { (0, 'a'), "Derecha" } indica que en el estado 0 con símbolo 'a', el movimiento es hacia la derecha.
Métodos principales:

ConfigurarSimbolos(): Método que establece los caracteres y caracteres especiales que la máquina utilizará para sus transiciones.
ObtenerDireccion(int estado, char simbolo): Dado un estado y un símbolo, obtiene la dirección de movimiento desde direcciones.
Escáner de Autómata Finito Determinista (ScannerAFD.cs)
La clase ScannerAFD realiza la conversión de la entrada en un árbol de derivación basado en el grafo de un Autómata Finito No Determinista (AFND). El proceso aquí registra las transiciones de estado y las direcciones en las que se mueven los caracteres.

Variables y métodos importantes en ScannerAFD.cs:
Dictionary<(int, char), int> transiciones: Un diccionario que define las transiciones del autómata, donde cada par (estadoActual, simbolo) se asocia con el estadoSiguiente. Por ejemplo, (0, 'a') podría llevar al estado 1.
List<(int, char, string)> arbolDerivacion: Esta lista almacena cada transición en el árbol de derivación, incluyendo el estado actual, el símbolo y la dirección.
Métodos principales:

ProcesarCadena(string cadena): Recorre cada símbolo en la cadena y actualiza el arbolDerivacion de acuerdo con las transiciones y direcciones definidas. Por cada transición, registra el estado actual, el símbolo y la dirección de movimiento (usando ObtenerDireccion de MT).
MostrarArbolDerivacion(): Dibuja el árbol de derivación de la cadena procesada, mostrando la secuencia de transiciones y las direcciones de movimiento para cada símbolo.
Procesador de Cintas Duales (DosCintas.cs)
La clase DosCintas es responsable de manejar dos cintas paralelas, una para los índices pares y otra para los impares, procesando las cadenas a partir de la posición 0. Cada símbolo de la cadena se asigna a una de las dos cintas según su posición.

Variables y métodos importantes en DosCintas.cs:
List<char> cintaPar: Almacena los caracteres en las posiciones pares de la cadena.
List<char> cintaImpar: Almacena los caracteres en las posiciones impares de la cadena.
Métodos principales:

ProcesarCinta(string cadena): Recorre cada símbolo en cadena y lo asigna a cintaPar o cintaImpar según su índice.
MostrarCintas(): Imprime el contenido de ambas cintas, mostrando cintaPar de izquierda a derecha y cintaImpar de derecha a izquierda. 

La clase de Tabls no contiene nada porque no fue usada para el proyecto.
