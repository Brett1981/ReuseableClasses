using System;

namespace Re_useable_Classes.Converters
{
    public static class DateTimeExtensions
    {
        public static DateTime AddWorkdays
            (
            this DateTime originalDate,
            int workDays)
        {
            DateTime tmpDate = originalDate;
            while (workDays > 0)
            {
                tmpDate = tmpDate.AddDays(1);
                if (tmpDate.DayOfWeek < DayOfWeek.Saturday &&
                    tmpDate.DayOfWeek > DayOfWeek.Sunday)
                {
                    workDays--;
                }
            }
            return tmpDate;
        }
    }
}