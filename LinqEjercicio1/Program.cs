using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqEjercicio1
{
    class Program
    {
        static List<Customer> customers = new List<Customer>() {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };

        private static List<Student> students = new List<Student>
        {
            new Student {FirstName="Svetlana", LastName="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
            new Student {FirstName="Claire", LastName="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
            new Student {FirstName="Sven", LastName="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
            new Student {FirstName="Cesar", LastName="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
            new Student {FirstName="Debra", LastName="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
            new Student {FirstName="Fadi", LastName="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
            new Student {FirstName="Hanying", LastName="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
            new Student {FirstName="Hugo", LastName="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
            new Student {FirstName="Lance", LastName="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
            new Student {FirstName="Terry", LastName="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
            new Student {FirstName="Eugene", LastName="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
            new Student {FirstName="Michael", LastName="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}}
        };

        static void Main(string[] args)
        {
            #region Ejercicio 1
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };
            var fruitsWithL = fruits.Where(fruit => fruit.StartsWith('L'));
            //Console.WriteLine(string.Join(", ", fruitsWithL));

            // Which of the following numbers are multiples of 4 or 6
            List<int> mixedNumbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };
            var multiples = mixedNumbers
                .Where(num => num % 4 == 0 || num % 6 == 0);
            //Console.WriteLine(string.Join(", ", multiples));


            // Output how many numbers are in this list
            List<int> numbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };
            //Console.WriteLine($"There are {numbers.Count} numbers in the list");
            #endregion
            #region Ejercicio 2
            // Despliega cuantos millonarios hay por banco
            //Console.WriteLine("MILLONARIOS POR BANCO");
            var grupoBanco = customers
                .GroupBy(customer => customer.Bank)
                .Select(grupo => new { banco = grupo.Key, millonarios = grupo.Where(x => x.Balance >= 1000000).Count() });

            //var example = customers.Where(x => x.Balance >= 1000000)
            //    .GroupBy(customer => customer.Bank)
            //    .Select(grupo => new { banco = grupo.Key, millonarios = grupo.Count() });

            //foreach (var item in grupoBanco)
            //{
            //    Console.WriteLine($"Banco: {item.banco}, Cantidad Millonarios: {item.millonarios}");
            //}

            // Mostrar los clientes que su balance sea mayor a $100,000
            //Console.WriteLine("\nCLIENTES CON BALANCE MAYOR A 100,000\n");
            var clients = customers
                .Where(customer => customer.Balance > 100000)
                .Select(customer => customer.Name);
            //Console.WriteLine(string.Join(", ", clients));


            // Ordenar los clientes por balance
            //Console.WriteLine("\nCLIENTES ORDENADOS POR BALANCE\n");
            clients = customers
                .OrderByDescending(customer => customer.Balance)
                .Select(customer => $"{customer.Name} have ${customer.Balance}");
            //Console.WriteLine(string.Join("\n", clients));

            // Sumatoria por riqueza por cada banco
            //Console.WriteLine("\nSUMATORIA DE RIQUEZA POR CADA BANCO\n");
            var grupoBancoRiqueza = customers
                .GroupBy(customer => customer.Bank)
                .Select(grupo => new { banco = grupo.Key, riqueza = grupo.Sum(x => x.Balance) });

            //foreach (var item in grupoBancoRiqueza)
            //{
            //    Console.WriteLine($"Banco: {item.banco}, Riqueza: {item.riqueza}");
            //}

            // Obtener el nombre de los clientes que su balance sea menor a $100,000 y que su banco tengo solo 3 caracteres
            //Console.WriteLine("\nCLIENTES CON BALANCE MENOR A 100,000 Y QUE EL BANCO SOLO TENGA 3 CARACTERES\n");
            var clientes = customers
                .Where(customer => customer.Balance < 100000 && customer.Bank.Length == 3)
                .Select(customer => $"{customer.Name}, {customer.Bank}");

            //Console.WriteLine(string.Join(", ", clientes));

            #endregion
            #region Ejercicio 3
            string[] cities =
            {
                "ROME","LONDON","NAIROBI","CALIFORNIA","ZURICH","NEW DELHI","AMSTERDAM","ABU DHABI", "PARIS"
            };
            // B.1 Find the string which starts and ends with a specific character : AM
            //Console.WriteLine("Find the string which starts and ends with a specific character : AM");
            var citiesStartsEndsWithAM = cities
                .Where(city => city.StartsWith("AM") && city.EndsWith("AM"))
                .Select(city => city);
            //Console.WriteLine(string.Join(", ", citiesStartsEndsWithAM));

            // B.2 Write a program in C# Sharp to display the list of items in the array according to the length of the string then by name in ascending order.
            //Console.WriteLine("Write a program in C# Sharp to display the list of items in the array according to the length of the string then by name in ascending order.");
            var citiesOrderedByLength = cities
                .OrderBy(city => city.Length)
                .ThenBy(city => city)
                .Select(city => city);
            //Console.WriteLine(string.Join("\n", citiesOrderedByLength));

            // B.3 Write a program in C# Sharp to split a collection of strings into 3 random groups.
            // TAREA
            //Console.WriteLine("Write a program in C# Sharp to split a collection of strings into 3 random groups.");
            var citiesSplitGrupos = cities
                .GroupBy(city => city.Length <= 10)
                .Select(grupo1 => grupo1
                    .GroupBy(cit => cit.Length <= 8)
                        .Select(grupo2 => grupo2.GroupBy(ci => ci.Length <= 5)));

            //Console.WriteLine(string.Join(", ", citiesSplitGrupos));
            #endregion
            #region Ejercicio 4
            int[] arr1 = new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 };
            // C.1 Write a program in C# Sharp to display the number and frequency of number from given array.
            var frecuency = arr1.GroupBy(n => n).Select(num => new { numero = num.Key, frecuencia = num.Count() });
            //foreach (var item in frecuency)
            //    Console.WriteLine($"El número {item.numero} aparece {item.frecuencia} veces");

            // C.2 Write a program in C# Sharp to display a list of unrepeated numbers.
            var uniqueNumbers = arr1.Distinct().OrderBy(n => n);
            //Console.WriteLine(string.Join("\n", uniqueNumbers));

            // C.3 Write a program in C# Sharp to display numbers, multiplication of number with frequency and the frequency of number of giving array.
            var operations = arr1.GroupBy(n => n).Select(num => new { number = num.Key, multiplication = num.Key * num.Count(), frecuency = num.Count() });
            //foreach (var item in operations)
            //    Console.WriteLine($"Número: {item.number}, Multiplicación: {item.multiplication}, Frecuencia: {item.frecuency}");
            #endregion
            #region Ejercicio 5
            // D.1 Get the top student of the list making an average of their scores.
            var topStudent = students
                .OrderByDescending(student => student.Scores.Average())
                .FirstOrDefault();
            Console.WriteLine(topStudent.FirstName);
            // D.2 Get the student with the lowest average score.
            var lowerStudent = students
                .OrderByDescending(student => student.Scores.Average())
                .LastOrDefault();
            Console.WriteLine(lowerStudent.FirstName);
            // D.3 Get the last name of the student that has the ID 117
            var student117 = students.Where(x => x.ID == 117).Select(x => x.LastName).FirstOrDefault();
            Console.WriteLine(student117);
            // D.4 Get the first name of the students that have any score more than 90
            var studentsScoreGrater90 = students
                .Where(x => x.Scores.Average() > 90)
                .Select(student => student.FirstName);
            Console.WriteLine(string.Join("\n", studentsScoreGrater90));
            #endregion
        }
    }

    internal class Customer
    {
        public string Name { get; internal set; }
        public double Balance { get; internal set; }
        public string Bank { get; internal set; }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public List<int> Scores { get; set; }
    }
}
