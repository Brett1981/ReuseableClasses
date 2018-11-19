using System;
using System.Globalization;

namespace Re_useable_Classes.Functions
{
    public static class TimeDateChecker
    {
        public static string GetTimeBetweenDates
            (
            DateTime aDateTime,
            DateTime aEndDateTime)
        {
            string aString;
            DateTime startTime = aDateTime;

            DateTime endTime = aEndDateTime;

            TimeSpan span = endTime.Subtract(startTime);

            aString = span.TotalHours.ToString(CultureInfo.InvariantCulture);

            return aString;
        }

        public static bool IsTimeToday(DateTime aDateTime)
        {
            return aDateTime.Date == DateTime.Now.Date;
        }

        public static bool isTimeWithinLast_Days
            (
            DateTime aDateTime,
            int aCountofDays)
        {
            DateTime dt;
            return DateTime.TryParse
                       (
                           aDateTime.ToString(CultureInfo.InvariantCulture),
                           out dt) &&
                   dt.Date > DateTime.Today.AddDays(-aCountofDays) &&
                   dt < DateTime.Now;
        }
    }
}