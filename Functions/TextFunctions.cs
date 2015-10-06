using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Re_useable_Classes.Functions
{
    internal static class TextFunctions
    {
        /// <summary>
        ///     Verifies that the index is within the range of the string source.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="index"></param>
        /// <returns>bool</returns>
        public static bool ExceedsLength
            (
            this string source,
            int index)
        {
            return Math.Abs(index) > source.Length;
        }

        public static string InsertEditIntoRequiredText
            (
            string aString,
            bool display)
        {
            string day;
            string month;
            string minute;
            string hour;
            if (DateTime.Now.Day.ToString(CultureInfo.InvariantCulture)
                        .Length == 1)
            {
                day = "0" + DateTime.Now.Day.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                day = DateTime.Now.Day.ToString(CultureInfo.InvariantCulture);
            }

            if (DateTime.Now.Month.ToString(CultureInfo.InvariantCulture)
                        .Length == 1)
            {
                month = "0" + DateTime.Now.Month.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                month = DateTime.Now.Month.ToString(CultureInfo.InvariantCulture);
            }

            if (DateTime.Now.Minute.ToString(CultureInfo.InvariantCulture)
                        .Length == 1)
            {
                minute = "0" + DateTime.Now.Minute.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                minute = DateTime.Now.Minute.ToString(CultureInfo.InvariantCulture);
            }

            if (DateTime.Now.Hour.ToString(CultureInfo.InvariantCulture)
                        .Length == 1)
            {
                hour = "0" + DateTime.Now.Hour.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                hour = DateTime.Now.Hour.ToString(CultureInfo.InvariantCulture);
            }
            if (display)
            {
                string addition = null;
                if (aString.Length > 0)
                {
                    addition = "\n";
                }
                addition += day + month + (DateTime.Now.Year - 2000) + hour + minute;
                if (addition.Length == 13)
                {
                    addition = addition + " ";
                }
                aString += addition;
            }
            else
            {
                string addition = day + month + (DateTime.Now.Year - 2000) + hour + minute;
                if (addition.Length == 13)
                {
                    addition = addition + " ";
                }
                aString += addition;
            }

            return aString;
        }

        public static string PrepareProblemHistoryTextForDisplay(string aString)
        {
            string historyText = aString;
            if (historyText != null)
            {
                for (int x = 1;
                     ((x*14) < aString.Length);
                     x++)
                {
                    historyText = historyText.Insert
                        (
                            (x*15) - 1,
                            "\n");
                }
            }

            return historyText;
        }

        public static string PrepareSearchText(string aString)
        {
            const string beginSelect = "";

            string s = aString;

            s = s.Trim();
            s = s.Replace
                (
                    "\'",
                    "\'\'");
            string outputSelect = beginSelect;

            const RegexOptions options = RegexOptions.None;
            var regex = new Regex
                (
                @"((""((?<token>.*?)(?<!\\)"")|(?<token>[\w]+))(\s)*)",
                options); //seems to work
            // Regex regex = new Regex(@"(?<token>\w+)|\""(?<token>[\w\s]*)""", options);// also works...
            string input = s;
            List<string> result = (from Match m in regex.Matches(input)
                                   where m.Groups["token"].Success
                                   select m.Groups["token"].Value).ToList();

            for (int i = 0;
                 i < result.Count();
                 i++)
            {
                //if (i < result.Count() - 1)
                {
                    outputSelect += "%" + result[i] + "%"; // +AndSelect;
                }

                Console.WriteLine
                    (
                        (@"Token[{0}]: '{1}'"),
                        i,
                        result[i]);
            }

            Console.WriteLine(outputSelect);
            return outputSelect;
        }

        /// <summary>
        ///     Reverses character order in a string.
        /// </summary>
        /// <param name="source"></param>
        /// <returns>string</returns>
        public static string Reverse(this string source)
        {
            char[] charArray = source.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        /// <summary>
        ///     Returns characters slices from string between two indexes.
        ///     If start or end are negative, their indexes will be calculated counting
        ///     back from the end of the source string.
        ///     If the end param is less than the start param, the Slice will return a
        ///     substring in reverse order.
        ///     example
        ///     var s = "This is an extension method";
        ///     If you want to slice off end characters, just supply a negative startIndex value
        ///     but no endIndex value (or an endIndex value >= to the source string length).
        ///     Console.WriteLine(s.Slice(-5));
        ///     Returns "ethod".
        ///     Console.WriteLine(s.Slice(-5, 10));
        ///     Results in a startIndex of 22 (counting 5 back from the end).
        ///     Since that is greater than the endIndex of 10, the result is reversed.
        ///     Returns "m noisnetxe"
        ///     Console.WriteLine(s.Slice(2, 15));
        ///     Returns "is is an exte"
        ///     <param name="source">String the extension method will operate upon.</param>
        ///     <param name="startIndex">Starting index, may be negative.</param>
        ///     <param name="endIndex">Ending index, may be negative).</param>
        /// </summary>
        public static string Slice
            (
            this string source,
            int startIndex,
            int endIndex)
        {
            // If startIndex or endIndex exceeds the length of the string they will be set
            // to zero if negative, or source.Length if positive.
            if (source.ExceedsLength(startIndex))
            {
                startIndex = startIndex < 0
                                 ? 0
                                 : source.Length;
            }
            if (source.ExceedsLength(endIndex))
            {
                endIndex = endIndex < 0
                               ? 0
                               : source.Length;
            }

            // Negative values count back from the end of the source string.
            if (startIndex < 0)
            {
                startIndex = source.Length + startIndex;
            }
            if (endIndex < 0)
            {
                endIndex = source.Length + endIndex;
            }

            // Calculate length of characters to slice from string.
            int length = Math.Abs(endIndex - startIndex);
            // If the endIndex is less than the startIndex, return a reversed substring.
            //if (endIndex < startIndex) return source.Substring(endIndex, length).Reverse();
            if (endIndex < startIndex)
            {
                return source.Substring
                    (
                        endIndex,
                        length);
            }
            return source.Substring
                (
                    startIndex,
                    length);
        }
    }
}
