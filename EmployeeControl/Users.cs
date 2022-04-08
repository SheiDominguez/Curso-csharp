using System;
using System.Collections.Generic;

namespace EmployeeControl
{
    public class Users : Persons
    {
        
        public DateTime StartDate { get; set; }
        public int Rol { get; set; } // --> Para definir si es Empleado o Supervisor
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public bool ValidatedHours { get; set; }

        public static List<WeeklyRegister> hoursPerWeek = new List<WeeklyRegister>()
        {
            new WeeklyRegister() { Id = 4, HoursMonday = 8, HoursThursday = 8, HoursWednesday = 8, HoursTuesday = 8, Hoursfriday = 8 },
            new WeeklyRegister() { Id = 5, HoursMonday = 8, HoursThursday = 8, HoursWednesday = 8, HoursTuesday = 8, Hoursfriday = 8 },
            new WeeklyRegister() { Id = 3, HoursMonday = 8, HoursThursday = 8, HoursWednesday = 8, HoursTuesday = 8, Hoursfriday = 8 }
        };

        public Users()
        {
        }

        public Users(string name, string middleName, int rol)
        {
            Rol = rol;
        }

        public static void RegisterHours(int userId)
        {
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

            hoursPerWeek.Add(new WeeklyRegister() { Id = userId, HoursMonday = lunes, HoursThursday = martes, HoursWednesday = miercoles, HoursTuesday = jueves, Hoursfriday = viernes });
            Console.WriteLine("Se ha registrado la información, prontó será validado.");
        }
    }
}
