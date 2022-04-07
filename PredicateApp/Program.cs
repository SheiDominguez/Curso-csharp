using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pet> pets = new List<Pet>()
            {
                new Pet() { Id = 1, Name = "Artemis", Owner = "Sheila", PetBirthday = new DateTime(2021, 7, 1), PetFirstVaccine = new DateTime(2021, 10, 10), IsMale = true },
                new Pet() { Id = 2, Name = "Juvia", Owner = "Tere", PetBirthday = new DateTime(2015, 6, 11), PetFirstVaccine = new DateTime(2015, 7, 10), IsMale = false },
                new Pet() { Id = 3, Name = "Momo", Owner = "Sheila", PetBirthday = new DateTime(2016, 9, 15), PetFirstVaccine = new DateTime(2016, 9, 20), IsMale = true },
                new Pet() { Id = 4, Name = "Hani", Owner = "Tere", PetBirthday = new DateTime(2019, 7, 1), PetFirstVaccine = new DateTime(2019, 8, 1), IsMale = false },
                new Pet() { Id = 5, Name = "Totoro", Owner = "Alex", PetBirthday = new DateTime(2018, 4, 16), PetFirstVaccine = new DateTime(2018, 5, 1), IsMale = true },
                new Pet() { Id = 6, Name = "Ichigo", Owner = "David", PetBirthday = new DateTime(2021, 7, 1), PetFirstVaccine = new DateTime(2021, 10, 10), IsMale = false },
                new Pet() { Id = 7, Name = "Manchas", Owner = "Roberto", PetBirthday = new DateTime(2021, 7, 1), PetFirstVaccine = new DateTime(2021, 10, 10), IsMale = true },
                new Pet() { Id = 8, Name = "Marisol", Owner = "Alejandra", PetBirthday = new DateTime(2021, 7, 1), PetFirstVaccine = new DateTime(2021, 10, 10), IsMale = false },
                new Pet() { Id = 9, Name = "Sasy", Owner = "Karla", PetBirthday = new DateTime(2018, 7, 1), PetFirstVaccine = new DateTime(2018, 7, 15), IsMale = false },
                new Pet() { Id = 10, Name = "Dolly", Owner = "Cesar", PetBirthday = new DateTime(2021, 1, 23), PetFirstVaccine = new DateTime(2021, 2, 13), IsMale = false },
                new Pet() { Id = 11, Name = "Lucky", Owner = "Rosa", PetBirthday = new DateTime(2021, 7, 1), PetFirstVaccine = new DateTime(2021, 10, 10), IsMale = true },
                new Pet() { Id = 12, Name = "Dante", Owner = "Rosa", PetBirthday = new DateTime(2021, 7, 1), PetFirstVaccine = new DateTime(2021, 10, 10), IsMale = true },
                new Pet() { Id = 13, Name = "Canela", Owner = "Renee", PetBirthday = new DateTime(2021, 7, 1), PetFirstVaccine = new DateTime(2021, 10, 10), IsMale = false },
                new Pet() { Id = 14, Name = "Ban", Owner = "Valeria", PetBirthday = new DateTime(2017, 7, 1), PetFirstVaccine = new DateTime(2017, 8, 3), IsMale = true },
                new Pet() { Id = 15, Name = "Yeontan", Owner = "Renee", PetBirthday = new DateTime(2018, 7, 1), PetFirstVaccine = new DateTime(2018, 7, 21), IsMale = true },
                new Pet() { Id = 16, Name = "Holly", Owner = "Valeria", PetBirthday = new DateTime(2021, 7, 1), PetFirstVaccine = new DateTime(2021, 10, 10), IsMale = true },
                new Pet() { Id = 17, Name = "Moni", Owner = "Ramon", PetBirthday = new DateTime(2021, 7, 1), PetFirstVaccine = new DateTime(2021, 10, 10), IsMale = true },
                new Pet() { Id = 18, Name = "Odeng", Owner = "Juan", PetBirthday = new DateTime(2017, 7, 1), PetFirstVaccine = new DateTime(2017, 10, 10), IsMale = true },
                new Pet() { Id = 19, Name = "Mickey", Owner = "Karla", PetBirthday = new DateTime(2021, 3, 1), PetFirstVaccine = new DateTime(2021, 3, 10), IsMale = true },
                new Pet() { Id = 20, Name = "Chocolate", Owner = "Jonh", PetBirthday = new DateTime(2021, 7, 1), PetFirstVaccine = new DateTime(2021, 10, 10), IsMale = true }
            };

            Console.WriteLine("Select one of this optios for searching:");
            Console.WriteLine("1 - By Id");
            Console.WriteLine("2 - By Name");
            Console.WriteLine("3 - By Owner");
            Console.WriteLine("4 - By Pet's Birthday");
            Console.WriteLine("5 - By Pet's first vaccination date");
            Console.WriteLine("6 - By Gender");
            var isNumber = Int32.TryParse(Console.ReadLine(), out int option);

            List<Pet> result = new List<Pet>();  

            switch (option)
            {
                case 1:
                    Console.WriteLine("Searching by ID");
                    Console.WriteLine("Please write the ID you want to search for:");
                    User.Input = Console.ReadLine();

                    Predicate<Pet> predicateById = new Predicate<Pet>(Pet.GetById);
                    result = pets.FindAll(predicateById);

                    break;
                case 2:
                    Console.WriteLine("Searching by Name");
                    Console.WriteLine("Please write the Name you want to search for:");
                    User.Input = Console.ReadLine();

                    Predicate<Pet> predicateByName = new Predicate<Pet>(Pet.GetByName);
                    result = pets.FindAll(predicateByName);

                    break;
                case 3:
                    Console.WriteLine("Searching by Owner");
                    Console.WriteLine("Please write the Owner you want to search for:");
                    User.Input = Console.ReadLine();

                    Predicate<Pet> predicateByOwner = new Predicate<Pet>(Pet.GetByOwner);
                    result = pets.FindAll(predicateByOwner);

                    break;
                case 4:
                    Console.WriteLine("Searching by Pet's Birthday");
                    Console.WriteLine("Please write the date you want to search for: (format yyyy/mm/dd)");
                    Console.WriteLine("Select 1 - Exact date, 2 - Range of dates");
                    option = Int32.Parse(Console.ReadLine());
                    result = new List<Pet>();
                    if (option == 1)
                    {
                        User.Input = Console.ReadLine();
                        Predicate<Pet> predicateByBirthday = new Predicate<Pet>(Pet.GetByBirthday);
                        result = pets.FindAll(predicateByBirthday);
                    }
                    else if (option == 2)
                    {
                        Console.WriteLine("Set the start date");
                        User.Input = Console.ReadLine();
                        Console.WriteLine("Set the end date");
                        User.Input2 = Console.ReadLine();

                        Predicate<Pet> predicateByBirthdayRange = new Predicate<Pet>(Pet.GetByBirthdayRange);
                        result = pets.FindAll(predicateByBirthdayRange);
                    }
                    else {
                        Console.WriteLine("Invalid option.");
                    }

                    break;
                case 5:
                    Console.WriteLine("Searching by First Vaccination");
                    Console.WriteLine("Please write the date you want to search for: (format yyyy/mm/dd)");
                    Console.WriteLine("Select 1 - Exact date, 2 - Range of dates");
                    option = Int32.Parse(Console.ReadLine());
                    result = new List<Pet>();

                    if (option == 1)
                    {
                        User.Input = Console.ReadLine();
                        Predicate<Pet> predicateByFirstVaccine = new Predicate<Pet>(Pet.GetByFirstVaccine);
                        result = pets.FindAll(predicateByFirstVaccine);
                    }
                    else if (option == 2)
                    {
                        Console.WriteLine("Set the start date");
                        User.Input = Console.ReadLine();
                        Console.WriteLine("Set the end date");
                        User.Input2 = Console.ReadLine();

                        Predicate<Pet> predicateByFirstVaccineRange = new Predicate<Pet>(Pet.GetByFirstVaccineRange);
                        result = pets.FindAll(predicateByFirstVaccineRange);
                    }
                    else
                    {
                        Console.WriteLine("Invalid option.");
                    }

                    break;
                case 6:
                    Console.WriteLine("Searching by Gender");
                    Console.WriteLine("Please write the gender you want to search for: (true - Male, false - Female)");
                    User.Input = Console.ReadLine();

                    Predicate<Pet> predicateByGender = new Predicate<Pet>(Pet.GetByGender);
                    result = pets.FindAll(predicateByGender);

                    break;
                default:
                    Console.WriteLine("Invalid option");
                    ∫break;
            }

            if (result.Any())
            {
                foreach (var pet in result)
                {
                    Console.Write("ID: " + pet.Id + ", ");
                    Console.Write("NAME: " + pet.Name + ", ");
                    Console.Write("OWNER: " + pet.Owner + ", ");
                    Console.Write("BIRTHDAY: " + pet.PetBirthday.ToString("yyyy/MM/dd") + ", ");
                    Console.Write("FIRST VACCINE: " + pet.PetFirstVaccine.ToString("yyyy/MM/dd") + ", ");
                    if (pet.IsMale)
                        Console.Write("GENDER: Male");
                    else
                        Console.Write("GENDER: Female");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("We couldn't find any pet :(.");
            }
        }

    }

    class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public DateTime PetBirthday { get; set; }
        public DateTime PetFirstVaccine { get; set; }
        public bool IsMale { get; set; }

        public static bool GetById(Pet pet)
        {
            var isNumber = Int32.TryParse(User.Input, out int id);
            if (isNumber)
                return pet.Id.Equals(id);
            else
                return false;
        }

        public static bool GetByName(Pet pet)
        {
            return pet.Name.Equals(User.Input);
        }

        public static bool GetByOwner(Pet pet)
        {
            return pet.Owner.Equals(User.Input);
        }

        public static bool GetByBirthday(Pet pet)
        {
            var date = DateTime.Parse(User.Input);
            return pet.PetBirthday.Equals(date);
        }

        public static bool GetByBirthdayRange(Pet pet)
        {
            var firstDate = DateTime.Parse(User.Input);
            var secondDate = DateTime.Parse(User.Input2);
            return pet.PetBirthday >= firstDate && pet.PetBirthday <= secondDate;
        }

        public static bool GetByFirstVaccine(Pet pet)
        {
            var date = DateTime.Parse(User.Input);
            return pet.PetFirstVaccine.Equals(date);
        }

        public static bool GetByFirstVaccineRange(Pet pet)
        {
            var firstDate = DateTime.Parse(User.Input);
            var secondDate = DateTime.Parse(User.Input2);
            return pet.PetFirstVaccine >= firstDate && pet.PetFirstVaccine <= secondDate;
        }

        public static bool GetByGender(Pet pet)
        {
            var isMale = Boolean.Parse(User.Input);
            return pet.IsMale.Equals(isMale);
        }

    }

    class User
    {
        public static string Input { get; set; }
        public static string Input2 { get; set; }
    }
}
