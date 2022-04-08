using System;
namespace EmployeeControl
{
    public class WeeklyRegister : Users
    {
        public int HoursMonday { get; set; }
        public int HoursThursday { get; set; }
        public int HoursWednesday { get; set; }
        public int HoursTuesday{ get; set; }
        public int Hoursfriday { get; set; }

        public WeeklyRegister()
        {
        }
    }
}
