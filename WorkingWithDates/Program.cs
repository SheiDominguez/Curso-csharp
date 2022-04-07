using System;

namespace WorkingWithDates
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date = DateTime.Now;
            var x = date.ToString("yyyy-MM-dd");

            Console.WriteLine(x);
        }
    }
}
