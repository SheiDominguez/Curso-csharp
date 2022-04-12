using System;
using System.Linq;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            // Recibe y regresa valores
            Func<int, int> square = x => x * x;
            // Solo recibe valores
            Action<string> action = x => Console.WriteLine(x);

            Console.WriteLine(square(5));
            action("Hola Mundo!");

            int[] numbers = new int[] {1,3,6,8 };
            var squaredNumbers = numbers.Select(square);
            Console.WriteLine(String.Join(",", squaredNumbers));
            // Los action pueden declararse sin variables de entrada
            Action line = () => Console.WriteLine("Hola");

            Func<int, int, string> isTooLong = (x, y) => x > y ? "es mayor" : "es menor";

            // A partir de C# 7
            var tuplas = MisTuplas();
            //tuplas.Item1; -> Primera propiedad
            //tuplas.Item2; -> Segunda propiedad
            Console.WriteLine(tuplas.esCorrecto + " Mensaje: " + tuplas.Mensaje);

            Func<int, int, (bool, string)> miFunc = (x, y) => (x > y, "Mi mensaje");

            // Se pueden usar Delegados con Parametros descartados _ (C#9)
            Func<int, int, int> constant = (_, _) => 42;
            Action<int, int> constant2 = (_, _) => Console.WriteLine(43);
            // Action con serie de declaraciones
            Action<int> miAccionAsincrona = miParametro =>
            {
                Task.Delay(2000);
                Console.WriteLine("Me esperé 2000 milisegundos");
            };

            Console.WriteLine(isTooLong(20, 15));
            Console.WriteLine(isTooLong2(20, 15));

            // Action asíncrono
            Action<int> miOtraAccionAsíncrona = async parametro => await DelayConImpresion(parametro);
            
        }

        static async Task DelayConImpresion(int x)
        {
            await Task.Delay(2000);
            Console.WriteLine("Me esperé 2000 e imprimí: " + x);
        }

        static (bool esCorrecto, string Mensaje) MisTuplas()
        {
            return (true, "Mensaje de prueba");
        }

        // Método con cuerpo de expresion
        static string isTooLong2(int x, int y) => x > y ? "es mayor" : "es menor"; 
    }
}
