using System;
using System.Collections.Generic;

namespace EmployeeControl
{
    public class User : Persons
    {
        
        public DateTime StartDate { get; set; }
        public int Rol { get; set; } // --> Para definir si es Empleado o Supervisor
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public bool ValidatedHours { get; set; }

        public static List<User> UsuariosSeed = new List<User>()
        {
            new User() { Id= 1, Name = "María", MiddleName = "Posada",  Rol=1, StartDate = new DateTime(2019, 4, 7), UserName = "mposada", PassWord = "12345", ValidatedHours = false },
            new User() { Id= 2, Name = "Eduardo", MiddleName = "Sanchez",  Rol=2, StartDate = new DateTime(2020, 5, 15), UserName = "esanchez", PassWord = "12345", ValidatedHours = false },
            new User() { Id= 3, Name = "Teresa", MiddleName = "Dominguez",  Rol=2, StartDate = new DateTime(2020, 6, 1), UserName = "tdominguez", PassWord = "12345", ValidatedHours = false },
            new User() { Id= 4, Name = "Alma", MiddleName = "Madrigal",  Rol=2, StartDate = new DateTime(2021, 4, 8), UserName = "amadrigal", PassWord = "12345", ValidatedHours = true },
            new User() { Id= 5, Name = "Miguel", MiddleName = "Lopez",  Rol=2, StartDate = new DateTime(2022, 1, 1), UserName = "mlopez", PassWord = "12345", ValidatedHours = false },
            new User() { Id= 6, Name = "Carmen", MiddleName = "Sánchez",  Rol=1, StartDate = new DateTime(2022, 1, 1), UserName = "csanchez", PassWord = "12345", ValidatedHours = false }
        };

        public static List<WeeklyRegister> hoursPerWeek = new List<WeeklyRegister>()
        {
            new WeeklyRegister() { UserId = 4, HoursMonday = 9, HoursTuesday = 9, HoursWednesday = 9, HoursThursday = 9, Hoursfriday = 9, Description = "Programando ando" },
            new WeeklyRegister() { UserId = 5, HoursMonday = 9, HoursTuesday = 9, HoursWednesday = 9, HoursThursday = 9, Hoursfriday = 9, Description = "Trabajando duro o durando en el trabajo" },
            new WeeklyRegister() { UserId = 3, HoursMonday = 8, HoursTuesday = 8, HoursWednesday = 8, HoursThursday = 8, Hoursfriday = 8, Description = "XD" }
        };

        public User()
        {
        }

        public User(string name, string middleName, int rol)
        {
            Rol = rol;
        }

        public static User LogIn(string userName, string password)
        {
            var user = UsuariosSeed.Find(x => x.UserName.Equals(userName) && x.PassWord.Equals(password));
            if (user != null)
                return user;
            else
                return null;
        }

        private static bool ValidateRegisteredHours(int userId)
        {
            return hoursPerWeek.Find(x => x.UserId == userId) != null ? true : false;
        }

        public static void RegisterHours(int userId)
        {
            if (ValidateRegisteredHours(userId))
            {
                Console.WriteLine("Ya se han registrado horas para este usuario.");
                return;
            }

            Console.WriteLine("Proporciona las horas trabajadas en Lunes:");
            var isNumber = Int32.TryParse(Console.ReadLine(), out int lunes);
            if (!isNumber)
            {
                Console.WriteLine("Número inválido");
                return;
            }

            Console.WriteLine("Proporciona las horas trabajadas en Martes:");
            isNumber = Int32.TryParse(Console.ReadLine(), out int martes);
            if (!isNumber)
            {
                Console.WriteLine("Número inválido");
                return;
            }

            Console.WriteLine("Proporciona las horas trabajadas en Miércoles:");
            isNumber = Int32.TryParse(Console.ReadLine(), out int miercoles);
            if (!isNumber)
            {
                Console.WriteLine("Número inválido");
                return;
            }

            Console.WriteLine("Proporciona las horas trabajadas en Jueves:");
            isNumber = Int32.TryParse(Console.ReadLine(), out int jueves);
            if (!isNumber)
            {
                Console.WriteLine("Número inválido");
                return;
            }

            Console.WriteLine("Proporciona las horas trabajadas en Viernes:");
            isNumber = Int32.TryParse(Console.ReadLine(), out int viernes);
            if (!isNumber)
            {
                Console.WriteLine("Número inválido");
                return;
            }

            Console.WriteLine("Descripción de las actividades realizadas.");
            var description = Console.ReadLine();

            var totalHours = lunes + martes + miercoles + jueves + viernes;

            hoursPerWeek.Add(new WeeklyRegister() { UserId = userId, HoursMonday = lunes, HoursTuesday = martes, HoursWednesday = miercoles, HoursThursday = jueves, Hoursfriday = viernes, Description = description });
            Console.WriteLine($"\nHas registrado {totalHours} horas laboradas esta semana.\n");
            Console.WriteLine("Se ha guardado la información, prontó será validada.");
        }
    }
}
