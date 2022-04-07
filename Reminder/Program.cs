using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Reminder
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Regex dateValidator = new Regex(@"^(?:0?[1-9]|1[1-2])([/])(3[01]|[12][0-9]|0?[1-9])\1\d{4}$");

            Console.WriteLine("What's the event name?:");
            var eventName = Console.ReadLine();

            if (String.IsNullOrEmpty(eventName)) {
                Console.WriteLine("Event name can't be empty");
                return;
            }

            Console.WriteLine("When will it start?: (Please indicate the date with the format mm/dd/yyyy)");
            var startDate = Console.ReadLine();
            var isDate = DateTime.TryParse(startDate, out DateTime eventStartDate);

            if (!isDate)
            {
                Console.WriteLine("Invalid date");
                return;
            }

            if (dateValidator.IsMatch(eventStartDate.ToString("MM/dd/yyyy")) == false)
            {
                Console.WriteLine("Invalid date format.");
                return;
            }

            Console.WriteLine("How many days before you want me to start remiding you?");
            var isNumber = Int32.TryParse(Console.ReadLine(), out int daysForReminding);

            if (!isNumber)
            {
                Console.WriteLine("Invalid number");
                return;
            }

            Console.WriteLine("Indicate the current date: (Please indicate the date with the format mm/dd/yyyy)");
            isDate = DateTime.TryParse(Console.ReadLine(), out DateTime currentDate);

            if (!isDate)
            {
                Console.WriteLine("Invalid date");
                return;
            }

            if (!dateValidator.IsMatch(currentDate.ToString("MM/dd/yyyy")))
            {
                Console.WriteLine("Invalid date format.");
                return;
            }

            if (eventStartDate.Ticks < currentDate.Ticks)
            {
                Console.WriteLine("The date of the event can't be lower than the current date");
                return;
            }

            for (var now = currentDate; now <= eventStartDate; now = now.AddDays(1))
            {
                await Task.Delay(1000);
                Console.Clear();
                await Asynchronous.Remind(eventName, eventStartDate, daysForReminding, now);
            }
            
        }
    }

    class Asynchronous
    {
        public static async Task Remind(string eventName, DateTime eventStartDate, int daysForReminding, DateTime currentDate)
        {
            var countDays = eventStartDate.Subtract(currentDate).TotalDays;

            if (countDays > daysForReminding)
                Console.WriteLine(currentDate.ToString("MM/dd/yyyy"));

            if (countDays <= daysForReminding && countDays != 0)
                Console.WriteLine($"{countDays} days for the event.");

            if (eventStartDate == currentDate)
                Console.WriteLine($"Today is the event: {eventName}");
        }
    }
}
