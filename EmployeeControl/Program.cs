using System;

namespace EmployeeControl
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingresa tu nombre de usuario:");
            var userName = Console.ReadLine();
            Console.WriteLine("Ingresa tu contraseña:");
            var password = Console.ReadLine();

            var user = Persons.LogIn(userName, password);
            if (user.Id == 0)
            {
                Console.WriteLine("No se encontro el usuario");
                return;
            }
            Console.Clear();
            Console.WriteLine($"Bienvenido(a) {user.Name} {user.MiddleName}");

            if (user.StartDate.AddYears(1) == DateTime.Now.Date)
                Console.WriteLine("¡Felicidades, has trabajado con nosotros por 1 año!. Sigue así.");

            if (user.Rol == 1)
            {
                var supervisor = new Supervisor(user.Name, user.MiddleName, user.Rol);

                Console.WriteLine("¿Que operación deseas ejecutar?");
                Console.WriteLine("1 - Validar horas de empleados");
                Console.WriteLine("2 - Editar información del empleado");
                Console.WriteLine("3 - Eliminar un empleado");
                Console.WriteLine("4 - Registrar horas laboradas");

                var isNumber = Int32.TryParse(Console.ReadLine(), out int opcion);
                if (!isNumber) {
                    Console.WriteLine("Opción no válida");
                    return;
                }

                switch (opcion)
                {
                    case 1:
                        var employeesList = Supervisor.EmployeeListToValidate();
                        employeesList.ForEach(employee =>
                        {
                            Console.WriteLine($"Id: {employee.Id}, Name: {employee.Name} {employee.MiddleName}, Start Date: {employee.StartDate.ToString("dd/MM/yyyy")}");
                        });
                        Console.WriteLine("Selecciona el empleado por su ID.");
                        isNumber = Int32.TryParse(Console.ReadLine(), out int employeeId);

                        Console.Clear();

                        Console.WriteLine("Validación de horas del empleado");
                        Supervisor.ValidateEmployeeHours(employeeId);
                        break;
                    case 2:
                        employeesList = Supervisor.EmployeeList();
                        employeesList.ForEach(employee =>
                        {
                            Console.WriteLine($"Id: {employee.Id}, Name: {employee.Name} {employee.MiddleName}, Start Date: {employee.StartDate.ToString("dd/MM/yyyy")}");
                        });
                        Console.WriteLine("Selecciona el empleado por su ID.");
                        isNumber = Int32.TryParse(Console.ReadLine(), out employeeId);

                        Console.Clear();
                        Console.WriteLine("Edición de la información del empleado");
                        Supervisor.UpdateEmployeeInformation(employeeId);
                        break;
                    case 3:
                        employeesList = Supervisor.EmployeeList();
                        employeesList.ForEach(employee =>
                        {
                            Console.WriteLine($"Id: {employee.Id}, Name: {employee.Name} {employee.MiddleName}, Start Date: {employee.StartDate.ToString("dd/MM/yyyy")}");
                        });
                        Console.WriteLine("Selecciona el empleado por su ID.");
                        isNumber = Int32.TryParse(Console.ReadLine(), out employeeId);

                        Console.Clear();
                        Console.WriteLine("Eliminación de empleados");
                        Supervisor.DeleteEmployee(employeeId);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Registro de horas");
                        Users.RegisterHours(supervisor.Id);
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
            }
            else
            {
                var employee = new Employee(user.Name, user.MiddleName, user.Rol);
                Console.WriteLine("¿Desea registrar sus horas laboradas de la semana? (s/n)");
                var isChar = Char.TryParse(Console.ReadLine(), out char opcion);
                if (!isChar)
                {
                    Console.WriteLine("Opción no válida");
                }

                if (opcion.Equals('n') || opcion.Equals('N'))
                    return;

                Users.RegisterHours(employee.Id);
            }
        }
    }
}
