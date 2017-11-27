using System;

namespace Re_useable_Classes.Functions
{
    internal class TestDateMethods
    {
        public TestDateMethods()
        {
            DateTime firstDay = DateHelpers.FirstDayOfYear();

            DateTime lastDay = DateHelpers.LastDayOfYear();

            DateTime tomorrow = DateHelpers.GetTomorrow();

            DateTime yesterday = DateHelpers.GetYesterday();
        }
    }


    /// <summary>
    ///     A static class that stores our DateTime helper methods.
    /// </summary>
    internal static class DateHelpers
    {
        /// <summary>
        ///     Example method to display the current day.
        /// </summary>
        public static void ShowToday()
        {
            // This is today.
            DateTime today = DateTime.Today;

            // Print out the result.
            Console.WriteLine(@"Today: " + today.ToShortDateString());
        }

        /// <summary>
        ///     Method to find the previous day (yesterday) to the current day.
        /// </summary>
        /// <returns>The date for yesterday.</returns>
        public static DateTime GetYesterday()
        {
            // This is yesterday.
            DateTime yesterday = DateTime.Today.AddDays(-1);

            Console.WriteLine(@"Yesterday: " + yesterday.ToShortDateString());
            return yesterday;
        }

        /// <summary>
        ///     Finds the next day (tomorrow) from the current day.
        /// </summary>
        /// <returns>The date corresponding to tomorrow.</returns>
        public static DateTime GetTomorrow()
        {
            // This is tomorrow.
            DateTime tomorrow = DateTime.Today.AddDays(1);

            Console.WriteLine(@"Tomorrow: " + tomorrow.ToShortDateString());
            return tomorrow;
        }

        /// <summary>
        ///     Overloaded method to return the first day of the current year
        ///     (from today).
        /// </summary>
        /// <returns>The first day of the current year.</returns>
        public static DateTime FirstDayOfYear()
        {
            return FirstDayOfYear(DateTime.Today);
        }

        /// <summary>
        ///     Finds the first day of year in which the selected day
        ///     falls (as in the first day of that year).
        /// </summary>
        /// <param name="selectedDay">
        ///     The day of the year you want
        ///     the first day of.
        /// </param>
        /// <returns>The first day of the year.</returns>
        public static DateTime FirstDayOfYear(DateTime selectedDay)
        {
            // First day of the current year.
            DateTime firstDay = DateTime.Parse(selectedDay.Year + "-01-01");

            Console.WriteLine(@"First of this year: " + firstDay.ToShortDateString());
            return firstDay;
        }

        /// <summary>
        ///     Finds the last day of the year for the current day (today).
        /// </summary>
        /// <returns>The last day of the current year.</returns>
        public static DateTime LastDayOfYear()
        {
            return LastDayOfYear(DateTime.Today);
        }

        /// <summary>
        ///     Finds the last day of the year for the selected day's year.
        /// </summary>
        /// <param name="selectedDay">The day that falls in the year.</param>
        /// <returns>The last day of the year.</returns>
        public static DateTime LastDayOfYear(DateTime selectedDay)
        {
            // Find last day of the current year.
            // First, get the first day of the next year.
            DateTime firstNextYear = DateTime.Parse((selectedDay.Year + 1) + "-01-01");
            DateTime lastDay = firstNextYear.AddDays(-1);

            Console.WriteLine(@"Last of this year: " + lastDay.ToShortDateString());
            return lastDay;
        }
    }
}
