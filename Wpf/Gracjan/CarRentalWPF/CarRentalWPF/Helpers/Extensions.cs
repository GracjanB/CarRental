using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalWPF.Helpers
{
    public static class Extensions
    {
        public static string ConvertToZonedDate(DateTime date, DateTime time)
        {
            DateTime fullDate = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
            var zonedDate = fullDate.ToString("s");
            zonedDate += "Z";

            return zonedDate;
        }

        public static string ConvertToReprDate(DateTime date, DateTime time)
        {
            DateTime fullDate = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
            return fullDate.ToString("g");
        }
    }
}
