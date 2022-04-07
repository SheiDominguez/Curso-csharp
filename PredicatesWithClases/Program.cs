using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicatesWithClases
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Search (in case of date follow the next yyyy/mm/dd)");
            var input = Console.ReadLine();
            //Searcher(input);
            SearchByBirthday(input);
            //var result = Searcher(input);
            //if (result)
            //    Console.WriteLine("User exists");
            //else
            //    Console.WriteLine("User doesn't exist");
            

            static void Searcher(string usuario) {
                User.Input = usuario;  
                Predicate<Person> predicateByName = new Predicate<Person>(Person.Exists);
                Predicate<Person> predicateByAge = new Predicate<Person>(Person.GetByAge);

                List<Person> People = new List<Person>()
                {
                    new Person() { Name = "Sheila", Age= 29  },
                    new Person() { Name = "Guadalupe", Age= 30  },
                    new Person() { Name = "Angel", Age= 29  }
                };

                if (People.Exists(predicateByName)) {
                    Console.WriteLine("User exist");
                }
                else
                {
                    var result = People.FindAll(predicateByAge);
                    if (result.Any())
                    {
                        Console.WriteLine("We found these names");
                        foreach (var item in result)
                        {
                            Console.WriteLine(item.Name);
                        }
                    }
                    else
                    {
                        Console.WriteLine("We didn't find any name.");
                    }
                }
            }

            static void SearchByBirthday(string date)
            {
                User.Input = date;
                Predicate<Person> predicateByBirthday = new Predicate<Person>(Person.GetByBirthday);

                List<Person> People = new List<Person>()
                {
                    new Person() { Name = "Sheila", Age= 29, Birthday = new DateTime(1992, 11, 30) },
                    new Person() { Name = "Guadalupe", Age= 30, Birthday = new DateTime (1992, 1, 12) },
                    new Person() { Name = "Angel", Age= 29, Birthday = new DateTime(1993, 3, 11) }
                };

                var result = People.FindAll(predicateByBirthday);
                if (result.Any())
                {
                    Console.WriteLine("We found these names");
                    foreach (var person in result)
                    {
                        Console.WriteLine(person.Name);
                    }
                }
                else
                {
                    Console.WriteLine("We didn't find any names.");
                }
                
            }
        }
    }

    public class Person {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }

        public static bool Exists(Person persona) {
            return persona.Name.Equals(User.Input);
        }

        public static bool GetByAge(Person person) {
            var isNumber = Int32.TryParse(User.Input, out int age);
            if (isNumber)
                return person.Age.Equals(age);
            else
                return false;
            
        }

        public static bool GetByBirthday(Person person) {
            var userInput = User.Input.Split('/');
            var year = Int32.Parse(userInput[0]);
            var month = Int32.Parse(userInput[1]);
            var day = Int32.Parse(userInput[2]);
            return person.Birthday.Equals(new DateTime(year, month, day));
        }
    }

    public class User {
        public static string Input { get; set; }
    }

    class LambdaExpressions
    {
        private static List<int> list = new List<int>() { 1,2,3,4,5,6,7,8,9};

        public static List<int> GetPairs()
        {
            return list.FindAll(x => x % 2 == 0);
        }
    }
}

