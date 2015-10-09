using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Re_useable_Classes.Functions
{
    public class FormatDataString
    {
        /// <summary>
        /// Used to format single quotes found in strings for sql insert
        /// </summary>
        /// <param name="InputString"></param>
        /// <returns>Formatted String</returns>
        public static string FormatSingleQuotes(string InputString)
        {
            string result = null;
            if (InputString.Contains("'"))
            {
                result = InputString.Replace("'", "''");
            }

            return result;
        }
    }
}
