using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ejercicio_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] archivo = File.ReadAllLines(Environment.CurrentDirectory + "\\numeros.txt");
            int[] arregloNumeros = new int[archivo.Length];

            for (int i = 0; i < archivo.Length; i++)
            {
                bool verificar = int.TryParse(archivo[i], out int numero);
                if (verificar)
                {
                    arregloNumeros[i] = numero;
                    //Console.WriteLine(numero);
                }
            }
            List<telefonos> ListaTelefonos = new List<telefonos>();
            Dictionary<int, int> numerosTelefonos = new Dictionary<int, int>();

            foreach (int i in arregloNumeros)
            {
                if (!numerosTelefonos.ContainsKey(i))
                {
                    numerosTelefonos.Add(i, 0);
                    //Console.WriteLine("arreglo " + numerosTelefonos.Keys);
                }

            }

            foreach (var kvp in numerosTelefonos)
            {
                int contador = 0;
                int sumador = 0;
                for (int i = 0; i < arregloNumeros.Length; i++)
                {
                    if (kvp.Key == arregloNumeros[i])
                    {
                        contador++;
                        sumador += i;
                        //Console.WriteLine(kvp.Key);
                    }
                }

                //Console.WriteLine($"{kvp.Key} {contador} {sumador}");
                telefonos miTelefono = new telefonos();
                miTelefono.numero = kvp.Key;
                miTelefono.frecuencia = contador;
                miTelefono.distancia = sumador;
                ListaTelefonos.Add(miTelefono);

            }

            int maximo = 0;

            foreach (var item in ListaTelefonos)
            {
                if (item.frecuencia >= maximo)
                {
                    maximo = item.frecuencia;
                }

                //Console.WriteLine($"{item.distancia} {item.frecuencia} {item.numero}");
            }

            var listadoMaximos = ListaTelefonos.Where(item => item.frecuencia == maximo);
            List<telefonos> misMaximos = new List<telefonos>();

            foreach (var item in listadoMaximos)
            {
                misMaximos.Add(item);

                //Console.WriteLine($"{item.distancia} {item.frecuencia} {item.numero}");
            }
            int minimo = misMaximos.First().distancia;
            foreach (var item in misMaximos)
            {
                if (minimo > item.distancia)
                {
                    minimo = item.distancia;
                }

            }
            Console.WriteLine(minimo.ToString());
            var listadoMiunimos = misMaximos.Where(item => item.distancia == minimo && item.frecuencia == maximo);
            foreach (var item in listadoMiunimos)
            {
                Console.WriteLine($"{item.frecuencia} {item.numero}");
            }

            Console.ReadKey();
        }

        public class telefonos
        {
            public int numero { get; set; }
            public int frecuencia { get; set; }
            public int distancia { get; set; }

        }
    }
}
