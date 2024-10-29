using System;
using System.IO;

namespace MaquinaDeTuring
{
    internal class Program
    {
        public static void Main(string[] args) // Pablo Bocel #1109623
        {
            ScannerAFD turingMachine = new ScannerAFD();
            MT maquina = new MT();
            DosCintas cinta = new DosCintas();
            Tablas tablas = new Tablas();

            string filePath = @"D:\Universidad\Cuarto ciclo\Lenguajes formales y autómatas\MaquinaDeTuring\AF.txt";

            // Leer todas las líneas del archivo
            if (File.Exists(filePath))
            {
                string[] lineas = File.ReadAllLines(filePath); // Cada línea es una cadena

                foreach (string texto in lineas)
                {
                    //parte 1
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\nProcesando la cadena: {texto}\n");
                    Console.ForegroundColor= ConsoleColor.White;

                    Console.WriteLine("Simbología:");
                    maquina.DibujarSimbolosTuring(texto);

                    //parte 2
                    Console.WriteLine("\nGrafo dibujado");
                    // Validar si la cadena es aceptada por el AFD
                    bool esAceptada = turingMachine.EsAceptada(texto);

                    if (esAceptada)
                    {
                        Console.WriteLine("La cadena es aceptada.");
                        TreeVisualizer.PrintTree(turingMachine.Root);
                    }
                    else
                    {
                        Console.WriteLine("La cadena no es aceptada.");
                    }

                    //parte 3
                    Console.WriteLine("\nDoble cinta");
                    cinta.SepararCadena(texto);
                    cinta.MostrarCadenas();

                    //parte 4
                    Console.WriteLine("\nCadena de Derecha a Izquierda");
                    cinta.DerechaIzquierda();

                    Console.WriteLine("\nCadena de Izquierda a Derecha");
                    cinta.IzquieraDerecha();

                    //parte 5
                    Console.WriteLine("\nTablas de transición");
                    bool esAceptada1 = turingMachine.EsAceptada(texto);

                    if (esAceptada1)
                    {
                        turingMachine.ImprimirTabla(texto);
                    }
                    else
                    {
                        Console.WriteLine("La tabla de transición no pudo ser creada.");
                    }
                    
                }
            }
            else
            {
                Console.WriteLine($"El archivo en la ruta {filePath} no existe.");
            }

            Console.ReadKey();
        }
    }
}




