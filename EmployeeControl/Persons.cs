using System;
using System.Collections.Generic;

namespace EmployeeControl
{
    public class Persons
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }

        public static List<Users> UsuariosSeed = new List<Users>()
        {
            new Users() { Id= 1, Name = "María", MiddleName = "Posada",  Rol=1, StartDate = new DateTime(2019, 4, 7), UserName = "mposada", PassWord = "12345", ValidatedHours = false },
            new Users() { Id= 2, Name = "Eduardo", MiddleName = "Sanchez",  Rol=2, StartDate = new DateTime(2020, 5, 15), UserName = "esanchez", PassWord = "12345", ValidatedHours = false },
            new Users() { Id= 3, Name = "Teresa", MiddleName = "Dominguez",  Rol=2, StartDate = new DateTime(2020, 6, 1), UserName = "tdominguez", PassWord = "12345", ValidatedHours = false },
            new Users() { Id= 4, Name = "Alma", MiddleName = "Madrigal",  Rol=2, StartDate = new DateTime(2021, 4, 7), UserName = "amadrigal", PassWord = "12345", ValidatedHours = true },
            new Users() { Id= 5, Name = "Miguel", MiddleName = "Lopez",  Rol=2, StartDate = new DateTime(2022, 1, 1), UserName = "mlopez", PassWord = "12345", ValidatedHours = false },
            new Users() { Id= 6, Name = "Carmen", MiddleName = "Sánchez",  Rol=1, StartDate = new DateTime(2022, 1, 1), UserName = "csanchez", PassWord = "12345", ValidatedHours = false }
        };

        public Persons()
        {
        }

        public Persons(string name, string middleName)
        {
            Name = name;
            MiddleName = middleName;
        }

        public static Users LogIn(string userName, string password)
        {
            var user = UsuariosSeed.Find(x => x.UserName.Equals(userName) && x.PassWord.Equals(password));
            if (user != null)
                return user;
            else
                return new Users();
        }
    }
}
