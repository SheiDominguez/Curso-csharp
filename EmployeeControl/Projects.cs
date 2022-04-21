using System;
using System.Collections.Generic;

namespace EmployeeControl
{
    public class Projects
    {
        public int IdProyecto { get; set; }
        public string Nombre { get; set; }
        private int _idProyectoSeed = 1;
        public static List<Projects> ProjectsList = new List<Projects>();

        public Projects(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
                throw new ApplicationException("El nombre no puede ser vacio.");

            IdProyecto = _idProyectoSeed;
            Nombre = nombre;
            _idProyectoSeed++;
        }


    }
}
