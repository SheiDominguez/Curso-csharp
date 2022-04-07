using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ParalilismTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Tienes 15 segundos para contestar. ¿Estás listo? (y/n)");
            var opcion = Console.ReadLine();

            if (String.IsNullOrEmpty(opcion)) {
                Console.WriteLine("Debes seleccionar una opción");
                return;
            }

            if (opcion.Equals("n") || opcion.Equals("N"))
                return;

            var seconds = 1;
            var task = Parallel.EjecutaTest();

            long time = 0;
            int limitTime = 10;
            while (seconds <= limitTime)
            {
                await Task.Delay(1000);

                if (task.IsCompleted)
                {
                    time = task.GetAwaiter().GetResult();
                    Console.WriteLine($"\nFelicidades completaste el test en {time / 1000m} segundos.");
                    break;
                }

                if(seconds == limitTime)
                    Console.WriteLine("\n\nSe acabó el tiempo, intenta otra vez.");

                seconds++;
            }
        }
    }

    class Parallel
    {
        public static async Task<long> EjecutaTest()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            await Evaluacion();
            stopWatch.Stop();

            return stopWatch.ElapsedMilliseconds;
        }

        public static async Task Evaluacion()
        {
            await Task.Run(() =>
            {
                int countCorrectAnswers = 0;

                Console.WriteLine("\n¿Cuántos metros tiene un kilometro?");
                Console.WriteLine("a) 10");
                Console.WriteLine("b) 1000");
                Console.WriteLine("c) 100");
                Console.Write("\nEscribe tu respuesta: ");
                var answer = Console.ReadLine();

                if (answer.Equals("b") || answer.Equals("B"))
                    countCorrectAnswers++;

                Console.WriteLine("\n¿Cuántos lados tiene un cubo?");
                Console.WriteLine("a) 6");
                Console.WriteLine("b) 8");
                Console.WriteLine("c) 9");
                Console.Write("\nEscribe tu respuesta: ");
                answer = Console.ReadLine();

                if (answer.Equals("a") || answer.Equals("A"))
                    countCorrectAnswers++;

                Console.WriteLine("\n¿Que pesa más 1kg de algodón o 1kg de metal?");
                Console.WriteLine("a) Algodón");
                Console.WriteLine("b) Metal");
                Console.WriteLine("c) Pesan lo mismo");
                Console.Write("\nEscribe tu respuesta: ");
                answer = Console.ReadLine();

                if (answer.Equals("c") || answer.Equals("C"))
                    countCorrectAnswers++;

                double puntuacion = (countCorrectAnswers * 100) / 3;
                Console.WriteLine($"\nObtuviste {puntuacion} puntos.");
            });
        }
    }
}
