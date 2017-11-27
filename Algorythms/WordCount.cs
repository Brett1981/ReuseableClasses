/*
 * WordCount.cs 
 * 
 * This is original code that implements a word-count algorithm that yields very similar
 * results to Microsoft Word.
 * 
 * */

namespace Re_useable_Classes.Algorythms
{
    internal static class WordCount
    {
        /// <summary>
        ///     Count words (using spaces and character analysis).
        /// </summary>
        /// <param name="str">The string to count the words of.</param>
        /// <returns>The number of words in the document.</returns>
        public static int Count(string str)
        {
            int c = 0;
            for (int i = 1;
                 i < str.Length;
                 i++)
            {
                switch (char.IsWhiteSpace(str[i - 1]))
                {
                    case true:
                        if (char.IsLetterOrDigit(str[i]) ||
                            char.IsPunctuation(str[i]))
                        {
                            c++;
                        }
                        break;
                }
            }
            // count last word
            if (str.Length > 2)
            {
                c++;
            }
            return c;
        }
    }
}
