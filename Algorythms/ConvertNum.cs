namespace Re_useable_Classes.Algorythms
{
    /// <summary>
    ///     Convert functions.
    /// </summary>
    internal static class ConvertNum
    {
        /// <summary>
        ///     Convert a number in bytes to a number in megabytes.
        /// </summary>
        /// <param name="bytesIn">The number of bytes.</param>
        /// <returns>The number of megabytes.</returns>
        public static double ConvertBytesToMegabytes(long bytesIn)
        {
            return (bytesIn/1024f)/1024f;
        }

        /// <summary>
        ///     Convert a number in kilobytes to a number in megabytes.
        /// </summary>
        /// <param name="kilobytesIn">The number of kilobytes.</param>
        /// <returns>The number of megabytes.</returns>
        public static double ConvertKilobytesToMegabytes(long kilobytesIn)
        {
            return kilobytesIn/1024f;
        }

        /// <summary>
        ///     Convert a number in degrees Celsius to a number in degrees Fahrenheit.
        /// </summary>
        /// <param name="celsiusIn">The number of degrees Celsius.</param>
        /// <returns>The number of degrees Fahrenheit.</returns>
        public static double ConvertCelsiusToFahrenheit(double celsiusIn)
        {
            return ((9.0/5.0)*celsiusIn) + 32;
        }

        /// <summary>
        ///     Convert a number in degrees Fahrenheit to a number in degrees Celsius.
        /// </summary>
        /// <param name="fahrenheitIn">The number of degrees Fahrenheit.</param>
        /// <returns>The number of degrees Celsius.</returns>
        public static double ConvertFahrenheitToCelsius(double fahrenheitIn)
        {
            return (5.0/9.0)*(fahrenheitIn - 32);
        }

        /// <summary>
        ///     Convert a number in miles to a number in kilometers.
        /// </summary>
        /// <param name="milesIn">The number of miles.</param>
        /// <returns>The number of kilometers.</returns>
        public static double ConvertMilesToKilometers(double milesIn)
        {
            return milesIn*1.609344;
        }

        /// <summary>
        ///     Convert a number in kilometers to a number in miles.
        /// </summary>
        /// <param name="kilometersIn">The number of kilometers.</param>
        /// <returns>The number of miles.</returns>
        public static double ConvertKilometersToMiles(double kilometersIn)
        {
            return kilometersIn*0.621371192;
        }
    }
}
