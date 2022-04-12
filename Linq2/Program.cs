using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq2
{
    class Program
    {
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
            int[] scores = { 94, 76, 95, 67, 45 };
            // Usando Linq to objects en formato query expressions
            IEnumerable<int> scoreQry = from score in scores
                                        where score > 70
                                        select score * score;
            // Usando Linq con métodos de extensión y expresiones lambda
            var scoreQryLambda = scores
                .Where(x => x > 70)
                .Select(score => score * score);
            //foreach (var i in scoreQry)
            //{
            //    Console.WriteLine(i);
            //};



            var studentQuery = from student in students
                               where student.Scores[0] > 90 && student.Scores[3] < 80
                               orderby student.Scores[0] descending
                               select student;

            var studentQueryLamda = students.Where(student => student.Scores[0] > 90 && student.Scores[3] < 80)
                                            .OrderByDescending(student => student.Scores[0]);
            // Comparar cada calificación mayor a 80
            var studentQueryLamda2 = students
                // All regresará solo si la condición se cumple con todos los elementos de la lista
                .Where(student => student.Scores.All(score => score > 80))
                // All regresará si la condición se cumple con al menos uno de los elementos de la lista
                //.Where(student => student.Scores.Any(score => score > 80)) 
                .OrderByDescending(student => student.Scores[0]);

            //foreach (var student in studentQuery)
            //{
            //    Console.WriteLine(student.LastName + " " + student.FirstName + " " + student.Scores[0]);
            //};




            // También se pueden agrupar los elemento usando el group by
            var studentQry = from student in students
                             group student by student.LastName[0]
                             into studentGroup
                             orderby studentGroup.Key
                             select studentGroup;

            var studentQryLambda = students
                .GroupBy(student => student.LastName[0])
                .OrderBy(group => group.Key);

            //foreach(var grupo in studentQry)
            //{
            //    Console.WriteLine(grupo.Key);
            //    foreach (var student in grupo)
            //    {
            //        Console.WriteLine($"Apellido: {student.LastName}, Nombre: {student.FirstName}");
            //    }
            //}

            // Se puede usar linq para reawlizar operaciones dentro de la comparación y ademas regresar el valor desado ya formateado

            IEnumerable<string> studentsQuery3 = from student in students
                                                 let totalScores = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
                                                 where totalScores / 4 < student.Scores[0]
                                                 select $"{student.FirstName} {student.LastName}";
            var studentsQuery3Lambda = students
                .Where(student => student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3] / 4 < student.Scores[0])
                .Select(student => $"{student.FirstName} {student.LastName}");



            IEnumerable<string> studentsQuery4 = from student in students
                                                 let totalScores = student.Scores.Sum()
                                                 where totalScores / 4 < student.Scores[0]
                                                 select $"{student.FirstName} {student.LastName}";

            var studentsQuery4Lambda = students
                    .Where(student => student.Scores.Sum() / 4 < student.Scores[0])
                    .Select(student => $"{student.FirstName} {student.LastName}");



            IEnumerable<string> studentsQuery5 = from student in students
                                                 let totalScores = student.Scores.Average()
                                                 where totalScores < student.Scores[0]
                                                 select $"{student.FirstName} {student.LastName}";
            var studentsQuery5Lambda = students
                   .Where(student => student.Scores.Average() < student.Scores[0])
                   .Select(student => $"{student.FirstName} {student.LastName}");

            // Saca el promedio de la clase
            var promedio = students.Average(student => student.Scores.Average());

            //foreach (var student in studentsQuery3)
            //{
            //    Console.WriteLine(student);
            //}
            // También pueden hacer consultas linq con variables externas a ellas
            var lastName = "Garcia";
            var studentQuery6 = from student in students
                                where student.LastName.Equals(lastName)
                                select student.FirstName;

            var studentQuery6Lambda = students
                .Where(student => student.LastName.Equals(lastName))
                .Select(student => student.FirstName);

            //Console.WriteLine("Todos los Garcia de la clase son: ");
            //Console.WriteLine(string.Join(", ", studentQuery6));

            // Crear nuevos objetos a partir de la consulta
            var studentQry7 = from student in students
                              let totalScore = student.Scores.Sum()
                              where totalScore > promedio
                              select new { Id = student.ID, score = totalScore };

            var studentQry7Lambda = students
                .Where(student => student.Scores.Sum() > promedio)
                .Select(student => new { Id = student.ID, score = student.Scores.Sum() });

            Student primerEstudianteFiltrado = studentQueryLamda2
                //.Where(x => x.ID > 1000)
                .FirstOrDefault(x => x.ID > 1000);
            Console.WriteLine(primerEstudianteFiltrado == null ? "es nulo" : primerEstudianteFiltrado.FirstName);

            var ultimoEstudianteFiltrado = studentQueryLamda2.Last();

            var single = studentQueryLamda2.SingleOrDefault(x => x.ID == 101);

            foreach (var item in studentQry7)
            {
                Console.WriteLine($"Student ID: {item.Id}, Score: {item.score}");
            }

        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public List<int> Scores { get; set; }
    }
}
