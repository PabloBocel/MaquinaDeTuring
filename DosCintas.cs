using System;
using System.Text;

namespace MaquinaDeTuring
{
    internal class DosCintas
    {
        public string CadenaPar { get; private set; }
        public string CadenaImpar { get; private set; }
        public void SepararCadena(string texto)
        {
            CadenaPar = "";
            CadenaImpar = "";

            for (int i = 0; i < texto.Length; i++)
            {
                if (i % 2 == 0)
                {
                    CadenaPar += texto[i]; // Índices pares
                }
                else
                {
                    CadenaImpar += texto[i]; // Índices impares
                }
            }
        }
        public void MostrarCadenas()
        {
            Console.WriteLine($"Cadena de caracteres pares: {CadenaPar}");
            Console.WriteLine($"Cadena de caracteres impares: {CadenaImpar}");
        }

        public void DerechaIzquierda()
        {
            // StringBuilder para construir la salida en una sola línea
            StringBuilder resultado = new StringBuilder("Cadena: ");

            // Construir la cadena par de derecha a izquierda
            for (int i = CadenaPar.Length - 1; i >= 0; i--)
            {
                resultado.Append(CadenaPar[i]);
            }

            resultado.Append("  ");

            // Construir la cadena impar de derecha a izquierda
            for (int i = CadenaImpar.Length - 1; i >= 0; i--)
            {
                resultado.Append(CadenaImpar[i]);
            }

            Console.WriteLine(resultado.ToString());
        }
        public void IzquieraDerecha()
        {
            Console.WriteLine($"Cadena: {CadenaPar}  {CadenaImpar}" );
        }
    }
}

