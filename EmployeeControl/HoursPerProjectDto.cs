using System;
using System.Collections.Generic;

namespace EmployeeControl
{
    public class HoursPerProjectDto
    {
        public int Hours { get; set; }
        public int IdProject { get; set; }
        public string Project { get; set; }
        public int IdEmployee { get; set; }
        public string Employee { get; set; }

        public static List<HoursPerProjectDto> HorasPorProyectoList = new List<HoursPerProjectDto>();
    }
}
