using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace EmployeeControl
{
    public class Supervisor : User
    {
        public Supervisor(string name, string middleName, int rol) : base(name, middleName, rol)
        {
        }

        public static void AddEmployee()
        {
            Console.WriteLine("Nombre del usuario:");
            var nombre = Console.ReadLine();
            Console.WriteLine("Apellido del usuario:");
            var apellido = Console.ReadLine();

            var userName = nombre.ToLower().Substring(0, 1) + apellido.ToLower();

            UsuariosSeed.Add(new User() { Id = _id++, Name = nombre, MiddleName = apellido, StartDate = DateTime.Now, Rol = 2, UserName = userName, PassWord = "12345", ValidatedHours = false });
            Console.WriteLine($"Nuevo usuario creado: {nombre} {apellido}.");
            Console.WriteLine($"Nombre de usuario: {userName}");
            Console.WriteLine("Contraseña: 12345");
            EmployeeList();
        }

        public static void ValidateEmployeeHours(int employeeId)
        {
            var empleado = UsuariosSeed.Find(x => x.Id == employeeId && x.Rol == 2);
            var registro = hoursPerWeek.Find(x => x.UserId == employeeId);

            if (empleado == null)
            {
                Console.WriteLine($"No se encontró el usuario con ID: {employeeId}");
                return;
            }

            if (registro == null)
            {
                Console.WriteLine($"No se encontró el registro de horas del usuario con ID: {employeeId}");
                return;
            }

            Console.WriteLine($"Lunes: {registro.HoursMonday}");
            Console.WriteLine($"Martes: {registro.HoursThursday}");
            Console.WriteLine($"Miercoles: {registro.HoursWednesday}");
            Console.WriteLine($"Jueves: {registro.HoursTuesday}");
            Console.WriteLine($"Viernes: {registro.Hoursfriday}");
            Console.WriteLine($"Descripción de actividades: {registro.Description}");
            Console.WriteLine("\n");

            Console.WriteLine("¿Es correcta le información? (s/n)");
            var isChar = Char.TryParse(Console.ReadLine(), out char opcion);

            if (opcion.Equals('s') || opcion.Equals('S'))
            {
                UsuariosSeed.Find(x => x.Id == employeeId).ValidatedHours = true;
                Console.Clear();
                Console.WriteLine("Horas validadas.\n\nEmpleados pendientes de validación:\n");
                Supervisor.EmployeeListToValidate();
            }
            else
            {
                return;
            }
        }

        public static void UpdateEmployeeInformation(int employeeId)
        {
            var empleado = UsuariosSeed.Find(x => x.Id == employeeId && x.Rol == 2);
            if (empleado == null)
            {
                Console.WriteLine($"No se encontró el usuario con ID: {employeeId}");
                return;
            }

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

            Supervisor.EmployeeList();
        }

        public static void DeleteEmployee(int employeeId)
        {
            var empleado = UsuariosSeed.Find(x => x.Id == employeeId && x.Rol == 2);
            if (empleado == null)
            {
                Console.WriteLine($"No se encontró el usuario con ID: {employeeId}");
                return;
            }

            UsuariosSeed.Remove(empleado);
            Supervisor.EmployeeList();
        }

        public static void EmployeeList()
        {
            Predicate<User> employees = new Predicate<User>(GetEmployees);
            var users = UsuariosSeed.FindAll(employees);

            if (users.Any())
            {
                users.ForEach(emp =>
                {
                    Console.WriteLine($"Id: {emp.Id}, Name: {emp.Name} {emp.MiddleName}, Start Date: {emp.StartDate.ToString("dd/MM/yyyy")}");
                });
            }
            else
            {
                Console.WriteLine("No se encontraton empleados.");
                return;
            }
        }

        private static bool GetEmployees(User user)
        {
            return user.Rol == 2 ? true : false;
        }

        public static void EmployeeListToValidate()
        {
            Predicate<User> employees = new Predicate<User>(GetEmployeesToValidate);
            var employeesList = UsuariosSeed.FindAll(employees);

            if (employeesList.Any())
            {
                employeesList.ForEach(employee =>
                {
                    Console.WriteLine($"Id: {employee.Id}, Name: {employee.Name} {employee.MiddleName}");
                });
            }
            else
            {
                Console.WriteLine($"No se encontraron empleados con horas pendientes de validar.");
                return;
            }
        }

        private static bool GetEmployeesToValidate(User user)
        {
            return user.Rol == 2 && user.ValidatedHours == false ? true : false;
        }

    }
}
