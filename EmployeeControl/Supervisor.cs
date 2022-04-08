using System;
using System.Collections.Generic;
using System.Globalization;

namespace EmployeeControl
{
    public class Supervisor : Users
    {
        public Supervisor(string name, string middleName, int rol) : base(name, middleName, rol)
        {
        }

        public static void ValidateEmployeeHours(int employeeId)
        {
            var registro = WeeklyRegister.hoursPerWeek.Find(x => x.Id == employeeId);
            Console.WriteLine($"Lunes: {registro.HoursMonday}");
            Console.WriteLine($"Martes: {registro.HoursThursday}");
            Console.WriteLine($"Miercoles: {registro.HoursWednesday}");
            Console.WriteLine($"Jueves: {registro.HoursTuesday}");
            Console.WriteLine($"Viernes: {registro.Hoursfriday}");
            Console.WriteLine("\n");

            Console.WriteLine("¿Es correcta le información? (s/n)");
            var isChar = Char.TryParse(Console.ReadLine(), out char opcion);

            if (opcion.Equals('s') || opcion.Equals('S'))
            {
                UsuariosSeed.Find(x => x.Id == employeeId).ValidatedHours = true;
                Console.Clear();
                Console.WriteLine("Horas validadas.\n\nEmpleados pendientes de validación:\n");
                var listPendants = Supervisor.EmployeeListToValidate();
                listPendants.ForEach(emp =>
                {
                    Console.WriteLine($"Id: {emp.Id}, Name: {emp.Name} {emp.MiddleName}");
                });
            }
            else
            {
                return;
            }
        }

        public static void UpdateEmployeeInformation(int employeeId)
        {
            Console.WriteLine("Proporciona el nombre del empleado: (Deja en blanco si no deseas cambiar el nombre)");
            var nombre = Console.ReadLine();
            Console.WriteLine("Proporciona la fecha de inicio en la empresa del empleado: (Utiliza el formato dd/MM/yyyy. Deja en blanco si no deseas cambiar la fecha de ingreso)");
            var date = Console.ReadLine();

            if (!String.IsNullOrEmpty(nombre))
            {
                UsuariosSeed.Find(x => x.Id == employeeId).Name = nombre;
            }

            if (!String.IsNullOrEmpty(date))
            {
                var fecha = new DateTime(Int32.Parse(date.Split('/')[2]), Int32.Parse(date.Split('/')[1]), Int32.Parse(date.Split('/')[0]));
                var isDate = DateTime.TryParse(fecha.ToString(), out DateTime fechaIngreso);
                if (isDate)
                    UsuariosSeed.Find(x => x.Id == employeeId).StartDate = new DateTime(fechaIngreso.Year, fechaIngreso.Month, fechaIngreso.Day);
                else
                    Console.WriteLine("Fecha no válida");
            }

            List<Users> users = Supervisor.EmployeeList();
            users.ForEach(e =>
            {
                Console.WriteLine($"Id: {e.Id}, Name: {e.Name} {e.MiddleName}, Fecha Ingreso: {e.StartDate.ToString("dd/MM/yyyy")}");
            });
        }

        public static void DeleteEmployee(int employeeId)
        {
            Users employee = Persons.UsuariosSeed.Find(x => x.Id == employeeId);
            UsuariosSeed.Remove(employee);

            List<Users> users = Supervisor.EmployeeList();
            users.ForEach(e =>
            {
                Console.WriteLine($"Id: {e.Id}, Name: {e.Name} {e.MiddleName}");
            });
        }

        public static List<Users> EmployeeList()
        {
            Predicate<Users> employees = new Predicate<Users>(GetEmployees);
            return UsuariosSeed.FindAll(employees);
        }

        private static bool GetEmployees(Users user)
        {
            return user.Rol == 2 ? true : false;
        }

        public static List<Users> EmployeeListToValidate()
        {
            Predicate<Users> employees = new Predicate<Users>(GetEmployeesToValidate);
            return UsuariosSeed.FindAll(employees);
        }

        private static bool GetEmployeesToValidate(Users user)
        {
            return user.Rol == 2 && user.ValidatedHours == false ? true : false;
        }

    }
}
