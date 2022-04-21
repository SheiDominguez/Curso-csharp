using System;
using System.Collections.Generic;
using System.Linq;

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
                    Console.WriteLine("6 - Reporte: Horas por proyecto.");
                    Console.WriteLine("7 - Agregar proyecto");

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
                            AgregarHorasAlProyecto(user);
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
                            #region Horas por Proyecto
                            Console.Clear();
                            Console.WriteLine("Registro de horas por proyecto");
                            ReporteHorasPorProyecto();
                            #endregion
                            break;
                        case 7:
                            AgregarProyecto();
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

                    #region Menú de empleado
                    Console.WriteLine("¿Que operación deseas ejecutar?");
                    Console.WriteLine("1 - Registrar horas");
                    Console.WriteLine("2 - Salir");

                    var isNumber = Int32.TryParse(Console.ReadLine(), out int opcion);
                    if (!isNumber)
                    {
                        Console.WriteLine("Por favor proporciona un número válido.");
                        return;
                    }
                    #endregion Menú de empleado

                    switch (opcion)
                    {
                        case 1:
                            AgregarHorasAlProyecto(user);
                            break;
                        case 2:
                        default:
                            return;
                    }
                    
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

        private static void ReporteHorasPorProyecto()
        {
            var list = Supervisor.GetHoursPerProject();
            if (list.Any())
            {
                list.ForEach(h =>
                {
                    Console.WriteLine($"Proyecto: {h.Project}   ID: {h.IdProject}");
                    Console.WriteLine($"    Employee: {h.IdEmployee} - {h.Employee}     Hours: {h.Hours}");
                });
            }
            else
            {
                Console.WriteLine("No hay horas registradas");
            }
        }

        private static void AgregarHorasAlProyecto(User user)
        {
            var listHoras = new List<HoursPerProjectDto>();
            var week = new WeeklyRegister();
            int horasTotal = 0;
            var proyectos = User.GetProjects();
            string[] days = new string[5] { "Lunes","Martes","Miércoles","Jueves","Viernes"};
            Console.Clear();
            if (proyectos.Any())
            {
                int countLunes = 0, countMartes = 0, countMiercoles = 0, countJueves = 0, countViernes = 0;
                for (int j = 0; j < days.Length; j++)
                {
                    Console.WriteLine($"Registro de horas: {days[j]}");
                    bool continuar = true;
                    while (continuar)
                    {
                        Console.WriteLine("Selecciona el proyecto al que deseas agregar horas");
                        for (int i = 0; i < proyectos.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {proyectos.ElementAt(i).Nombre}");
                        }
                        var proyectoPosicion = IntentarObtenerInt(Console.ReadLine()) - 1;
                        var proyecto = proyectos.ElementAt(proyectoPosicion);

                        Console.WriteLine($"¿Cuantas horas quiere registrar al proyecto {proyecto.Nombre}?");
                        var horas = IntentarObtenerInt(Console.ReadLine());

                        switch (days[j])
                        {
                            case "Lunes":
                                countLunes += horas;
                                break;
                            case "Martes":
                                countLunes += horas;
                                break;
                            case "Miércoles":
                                countLunes += horas;
                                break;
                            case "Jueves":
                                countLunes += horas;
                                break;
                            case "Viernes":
                                countLunes += horas;
                                break;
                        }

                        listHoras.Add(new HoursPerProjectDto { IdEmployee = user.Id, Employee = user.Name, IdProject = proyecto.IdProyecto, Project = proyecto.Nombre, Hours = horas });
                        horasTotal += horas;
                        Console.WriteLine($"Ha registrado un total de {horasTotal} horas.");
                        Console.WriteLine("\n\n¿Desea registrar mas horas? s/n");
                        continuar = Console.ReadLine().ToLower().Equals("s") ? true : false;
                    }
                }
                Console.WriteLine("Agrega una breve descripción de tu trabajo");
                var descripcion = Console.ReadLine();

                week.HoursMonday = countLunes;
                week.HoursTuesday = countMartes;
                week.HoursWednesday = countMiercoles;
                week.HoursThursday = countJueves;
                week.Hoursfriday = countViernes;
                week.UserId = user.Id;
                week.Description = descripcion;
                week.HoursValidated = false;

                User.RegisterHours(week);
                User.AddHoursToProject(listHoras);
                Console.WriteLine("Horas registradas correctamente");
            }
            else
            {
                Console.WriteLine("No hay projectos a los cuales asignarles horas.");
            }
            
        }

        private static void AgregarProyecto()
        {
            Console.WriteLine("Agregar Proyecto\n");

            Console.WriteLine("¿Que nombre tendrá el proyecto?");
            var nombre = Console.ReadLine();
            var isValid = string.IsNullOrEmpty(nombre);

            if (isValid)
            {
                Console.WriteLine("El nombre no puede ser vacio");
                return;
            }

            var proyecto = new Projects(nombre);
            Supervisor.AddProject(proyecto);
            Console.WriteLine("Proyecto agregado correctamente.");
        }

        private static int IntentarObtenerInt(string input)
        {
            return Int32.TryParse(input, out int posicion) ? posicion : throw new ApplicationException("No se pudo castear el id correctamente");
        }
    }
}
