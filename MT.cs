using System;
using System.Collections.Generic;
using System.Linq;

namespace MaquinaDeTuring
{
    internal class MT
    {
        public void DibujarSimbolosTuring(string texto)
        {
            // Definir el alfabeto de entrada, símbolos especiales y estados
            char[] alfabeto = { 'a', 'b' };
            char[] simbolosEspeciales = { '*', '#' };
            string[] estados = { "q0", "q1", "q2", "q3", "q4" };
            string[] direcciones = { "I", "D" }; // Izquierda (I), Derecha (D)

            // Dibuja los símbolos del alfabeto
            Console.WriteLine("Alfabeto de la máquina de Turing:");
            foreach (char simbolo in alfabeto)
            {
                Console.Write($"| {simbolo} ");
            }
            Console.WriteLine("|");

            if (texto.Any(c => simbolosEspeciales.Contains(c)))
            {
                Console.WriteLine("\nSímbolos especiales encontrados:");

                // Recorrer los caracteres y mostrar solo los símbolos especiales
                foreach (char simboloEspecial in simbolosEspeciales)
                {
                    if (texto.Contains(simboloEspecial))
                    {
                        Console.Write($"| {simboloEspecial} ");
                    }
                }

                Console.WriteLine("|"); // Cerrar la línea
            }
            else
            {
                Console.WriteLine("No se encontraron símbolos especiales en el texto.");
            }

            // Dibuja los estados
            Console.WriteLine("\nEstados de la máquina de Turing:");
            foreach (string estado in estados)
            {
                Console.Write($"| {estado} ");
            }
            Console.WriteLine("|");

            // Dibuja las direcciones de movimiento
            Console.WriteLine("\nDirecciones de movimiento:");

            // Condición para cadenas que solo se mueven a la derecha
            bool soloDerecha =
                (texto.StartsWith("aba") && (texto.EndsWith("*") || texto.EndsWith("*#"))) &&
                texto.Substring(3).TrimEnd('#', '*').All(c => c == 'a');

            // Si la cadena cumple con las condiciones, solo muestra "Derecha"
            if (soloDerecha)
            {
                Console.WriteLine("| Derecha (D) |");
            }
            else
            {
                foreach (string direccion in direcciones)
                {
                    if (direccion == "I")
                    {
                        Console.Write("| Izquierda (I) ");
                    }
                    else
                    {
                        Console.Write("| Derecha (D) ");
                    }
                }
                Console.WriteLine("|");
            }

        }
    }
}

