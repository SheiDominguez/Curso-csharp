using System;

namespace EmployeeControl
{
    class Program
    {
        static void Main(string[] args)
        {
            bool terminaPrograma = false;
            while (!terminaPrograma)
            {
                #region Login
                Console.WriteLine("Ingresa tu nombre de usuario:");
                var userName = Console.ReadLine();
                Console.WriteLine("Ingresa tu contraseña:");
                var password = Console.ReadLine();

                var user = User.LogIn(userName, password);
                if (user == null)
                {
                    Console.WriteLine("No se encontro el usuario");
                    return;
                }
                #endregion Login
                #region Bienvenida
                Console.Clear();
                Console.WriteLine($"Bienvenido(a) {user.Name} {user.MiddleName}");

                if (user.StartDate.AddYears(1) == DateTime.Now.Date)
                    Console.WriteLine("¡Felicidades, has trabajado con nosotros por 1 año!. Sigue así.");
                #endregion Bienvenida

                if (user.Rol == 1)
                {
                    var supervisor = new Supervisor(user.Name, user.MiddleName, user.Rol);
                    #region Menú de supervisor
                    Console.WriteLine("¿Que operación deseas ejecutar?");
                    Console.WriteLine("1 - Validar horas de empleados");
                    Console.WriteLine("2 - Editar información del empleado");
                    Console.WriteLine("3 - Eliminar un empleado");
                    Console.WriteLine("4 - Registrar horas laboradas");
                    Console.WriteLine("5 - Registrar nuevo empleado");
                    Console.WriteLine("6 - Salir");

                    var isNumber = Int32.TryParse(Console.ReadLine(), out int opcion);
                    if (!isNumber)
                    {
                        Console.WriteLine("Por favor proporciona un número válido.");
                        return;
                    }
                    #endregion Menú de supervisor

                    switch (opcion)
                    {
                        case 1:
                            #region Validación de horas
                            Supervisor.EmployeeListToValidate();

                            Console.WriteLine("Selecciona el empleado por su ID.");
                            isNumber = Int32.TryParse(Console.ReadLine(), out int employeeId);

                            if (!isNumber)
                            {
                                Console.WriteLine("Número inválido");
                                return;
                            }

                            Console.Clear();

                            Console.WriteLine("Validación de horas del empleado");
                            Supervisor.ValidateEmployeeHours(employeeId);
                            #endregion
                            break;
                        case 2:
                            #region Edición de empleado
                            Supervisor.EmployeeList();

                            Console.WriteLine("Selecciona el empleado por su ID.");
                            isNumber = Int32.TryParse(Console.ReadLine(), out employeeId);

                            if (!isNumber)
                            {
                                Console.WriteLine("Número inválido");
                                return;
                            }

                            Console.Clear();

                            Console.WriteLine("Edición de la información del empleado");
                            Supervisor.UpdateEmployeeInformation(employeeId);
                            #endregion
                            break;
                        case 3:
                            #region Eliminación de empleado
                            Supervisor.EmployeeList();

                            Console.WriteLine("Selecciona el empleado por su ID.");
                            isNumber = Int32.TryParse(Console.ReadLine(), out employeeId);

                            if (!isNumber)
                            {
                                Console.WriteLine("Número inválido");
                                return;
                            }

                            Console.Clear();

                            Console.WriteLine("Eliminación de empleados");
                            Supervisor.DeleteEmployee(employeeId);
                            #endregion
                            break;
                        case 4:
                            #region Registro de horas del supervisor
                            Console.Clear();
                            Console.WriteLine("Registro de horas");
                            User.RegisterHours(supervisor.Id);
                            #endregion
                            break;
                        case 5:
                            #region Añadir empleado
                            Console.Clear();
                            Console.WriteLine("Registro de Empleado");
                            Supervisor.AddEmployee();
                            #endregion
                            break;
                        case 6:
                            break;
                        default:
                            Console.WriteLine("Opción no válida");
                            break;
                    }
                }
                else
                {
                    #region Registro de horas del empleado
                    var employee = new Employee(user.Name, user.MiddleName, user.Rol);
                    Console.WriteLine("¿Desea registrar sus horas laboradas de la semana? (s/n)");
                    var isChar = Char.TryParse(Console.ReadLine(), out char opcion);
                    if (!isChar)
                    {
                        Console.WriteLine("Opción no válida");
                        return;
                    }

                    if (opcion.Equals('n') || opcion.Equals('N'))
                        return;

                    User.RegisterHours(user.Id);
                    #endregion
                }

                #region Terminar ejecución del programa
                Console.WriteLine("¿Terminar ejecución? (s/n)");
                var isCharr = Char.TryParse(Console.ReadLine(), out char terminar);

                if (!isCharr)
                {
                    Console.WriteLine("Opcion no válida");
                }

                if (terminar.Equals('s') || terminar.Equals('S'))
                    terminaPrograma = true;
                #endregion Terminar ejecución del programa
            }
        }
    }
}
