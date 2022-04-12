using System;
namespace EmployeeControl
{
    public class WeeklyRegister
    {
        public int UserId { get; set; }
        public int HoursMonday { get; set; }
        public int HoursTuesday { get; set; }
        public int HoursWednesday { get; set; }
        public int HoursThursday { get; set; }
        public int Hoursfriday { get; set; }
        public string Description { get; set; }
        public bool HoursValidated { get; set; }

        public WeeklyRegister()
        {
        }
    }
}
