using System;
using System.Linq;

namespace LinqMethodSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] factoriales = { 2, 2, 3, 5, 5 };
            // Distinct solo traera un elemento unico en el listado aun si se repiten
            int factorialesUnicos = factoriales.Distinct().Count();
            Console.WriteLine($"Hay {factorialesUnicos} factoriales unicos");

            // Suma de elementos
            int[] numbers = { 5,4,1,4,6,34};
            double numSum = numbers.Sum();
            Console.WriteLine($"La suma de elementos es: {numSum}");

            // El valor minimo dentro del un listado
            int[] numbers2 = { 5, 4, 1, 4, 6, 34 };
            int minNum = numbers2.Min();
            Console.WriteLine($"El numero más chico es: {minNum}");

            // El valor máximo dentro de un listado
            int maxNum = numbers2.Max();
            Console.WriteLine($"El numero más chico es: {maxNum}");

            // Proyecciones en min y max
            string[] words = { "cherry", "apple", "banana" };
            int shortedWord = words.Min(w => w.Length);
            Console.WriteLine($"La palabra mas corta tiene: {shortedWord} caracteres");

            int longestWord = words.Max(w => w.Length);
            Console.WriteLine($"La palabra mas larga tiene: {longestWord} caracteres");

            // Promedio de un listado
            double avereageNum = numbers.Average();
            Console.WriteLine($"El promedio es: {avereageNum}");

            double averageLength = words.Average(w => w.Length);
            Console.WriteLine($"El promedio de caracteres es: {averageLength}");

            // Conversion de listas
            double[] dobles = { 1.4, 5.3, 5.2, 6.4 };
            var sorderDoubles = dobles.OrderBy(d => d);
            var doublesArray = sorderDoubles.ToArray();
            var doublesList = sorderDoubles.ToList();
            for(int i = 0; i < doublesArray.Length; i++)
            {
                Console.WriteLine(doublesArray[i]);
            }

            foreach (var d in doublesList)
                Console.WriteLine(d);

            // Conversión a diccionario
            var scoreRecord = new[]
            {
                new { Name = "Alice", Score = 50 },
                new { Name = "Bob", Score = 40 },
                new { Name = "Cathy", Score = 45 }
            };
            // El diccionario es una coleccion de llave y valor
            var scoreRecordDict = scoreRecord.ToDictionary(sr => sr.Name);
            Console.WriteLine("Bob's score {0}", scoreRecordDict["Bob"]);

            // Extraer datos obtenidos
            object[] numbersObjects = { null, 1.0m, "two", 3, "four", 5, "six", 7.0d };
            var doublesObjects = numbersObjects.OfType<double>();
            foreach (var d in doublesObjects)
            {
                Console.WriteLine(d);
            }

            var stringObjects = numbersObjects.OfType<string>();
            foreach (var d in stringObjects)
            {
                Console.WriteLine(d);
            }

            // un elemento del listado
            string[] strings = { "zero", "one", "two" , "three", "four", "five"};
            var theFirstOne = strings.First();
            var theOne = strings.First(c => c == "one");
            
            Console.WriteLine($"El primer elemento de la lista es: {theFirstOne}");
            Console.WriteLine($"El primer elemento que coincide con 'one' es: {theOne}");

            // talvez exista un elemento del listado
            string[] strings2 = { };
            var maybeTheFirstOne = strings2.FirstOrDefault();
            //var maybeTheFirstOne = strings2.DefaultIfEmpty("hola").First();

            // Obtener un objeto de la posicion en un listado
            int[] numbers3 = { 5, 4, 1, 4, 6, 34 };
            var inPosition = numbers3.ElementAt(2);
            Console.WriteLine($"El número en la posicion 2 es: {inPosition}");

            // ordenamiento de listado
            var sortedList = strings.OrderBy(c => c);
            var sortedListDesc = strings.OrderByDescending(c => c);
            var sortedMultipleTimes = strings.OrderBy(c => c[0]).ThenBy(c => c.Length);

            Console.WriteLine("El ordes ascendiente de la lista es:");
            foreach (var s in sortedListDesc)
            {
                Console.WriteLine(s);
            }

            // Toma la lista y las ordena al revés
            var sortedReversed = strings.Reverse();

            // Particiones en una lista
            int[] numbers4 = { 5,4,1,8,6,4,9,0 };
            var first3Numbers = numbers4.Take(3);
            Console.WriteLine("Los primeros 3 numeros");
            Console.WriteLine(string.Join("\n", first3Numbers));

            var takeWhile = numbers4.TakeWhile(c => c > 3);
            Console.WriteLine("Tomará mientras la condición de que el numero sea mayor a 3 se cumpla");
            Console.WriteLine(string.Join("\n", takeWhile));

            var allButFirst4Numbers = numbers4.Skip(4);
            Console.WriteLine("Los elementos después de los primeros 4 son:");
            Console.WriteLine(string.Join("\n", allButFirst4Numbers));

            var skipWhile = numbers4.SkipWhile(c => c > 2);
            Console.WriteLine("Los elementos que fueron brincados cumpliendo la condicion de ser mayores a 2 son:");
            Console.WriteLine(string.Join("\n", skipWhile));

            // Proyecciones
            // Creamos un listado a partir de una clase anónima
            var selectedList = strings.Select(c => new { Length = c.Length, Word = c });
            // Creamos un listado a partir de una clase definida
            var selectedListWithEntity = strings.Select(c => new MyWord{ Length = c.Length, Word = c });
            foreach (var str in selectedListWithEntity)
            {
                Console.WriteLine($"La palabra {str.Word} tiene {str.Length} caracteres.");
            }

            //Contains
            // Regresa un boleano si la condición se cumple
            var existezero = strings.Contains("zero");
            Console.WriteLine(existezero);

            // Equals
            var esIgualAThree = strings.Any(c => c.Equals("Three"));
            Console.WriteLine(esIgualAThree);

            // Concat
            // Une 2 listados
            int[] nums1 = { 1,2,3 };
            int[] nums2 = { 4,5,6 };
            foreach ( var n in nums1.Concat(nums2))
            {
                Console.WriteLine(n);
            }
        }
    }

    class MyWord
    {
        public int Length { get; set;}
        public string Word { get; set; }
    }
}
