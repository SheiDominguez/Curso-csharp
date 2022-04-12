using System;
using System.Collections.Generic;

namespace EmployeeControl
{
    public class Persons
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public static int _id = 7;

       

        public Persons()
        {
        }

        public Persons(string name, string middleName)
        {
            Name = name;
            MiddleName = middleName;
        }

        
    }
}
