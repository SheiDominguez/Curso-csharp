using System;
using System.Text.RegularExpressions;

namespace RegularExpressions
{
    class Program
    {
        static void Main(string[] args)
        {


            //DomainValidation();
            //PhoneNumber();
            PasswordValidator();


            static void DomainValidation()
            {
                var domain = "https://www.something.com";
                // @"^https?://(www.)?([\w]+)((\.[A-Za-z]{2,3})+)$"
                Regex regex = new Regex(@"https?//:(www.)?([\w]+)((\.[A-Za-z]{2,3})+)$");
                Console.WriteLine(regex.IsMatch(domain));
            }

            static void PhoneNumber()
            {
                var phoneNumber = "+52 (686) 405 4720";
                Regex regex = new Regex(@"\+[\d]{2}\s+\(+[\d]{3}\)\s[\d]{3}\s[\d]{4}");
                Console.WriteLine(regex.IsMatch(phoneNumber));
            }

            static void PasswordValidator()
            {
                // Mínimo 8 characteres
                // Al menos una mayuscula
                // Al menos una minúscula
                // Al menos un character especial (*,#,?,!)
                // Al menos un número

                var password = "S#Ei2022";
                Regex regex = new Regex(@"^(?=.*\d)(?=.*[\*\#\?\!])(?=.*[A-Z])(?=.*[a-z])\S{8,16}$");
                Console.WriteLine(regex.IsMatch(password));
            }
        }
    }
}
