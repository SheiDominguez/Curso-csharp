using System;
using System.Collections.Generic;

namespace Predicados
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> predicate1 = new Predicate<int>(obtenerPares);
            Predicate<int> predicate = new Predicate<int>(obtenerPrimos);

            List<int> list = new List<int>();
            list.AddRange(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });

            List<int> result = list.FindAll(predicate);
            List<int> pares = list.FindAll(predicate1);
            Console.WriteLine("Pares");
            foreach (var item in pares) {
                Console.WriteLine(item);
            }
            Console.WriteLine("Primos");  
            foreach (var item in result) {
                Console.WriteLine(item);
            }

            static bool obtenerPrimos(int num)
            {
                if (num % 2 == 1) return true;
                else return false;
            }

            static bool obtenerPares(int num)
            {
                if (num % 2 == 0) return true;
                else return false;
            }

        }

        
    }

}
