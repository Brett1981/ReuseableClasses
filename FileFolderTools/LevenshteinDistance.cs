/*
 * This is the classic Levenshtein Distance algorithm. It compares
 * two strings and returns the difference in an integer, where the
 * higher the integer is, the greater the distance.
 *
 * The code is in a static class, and thus can be called like this:
 * LevenshteinDistance.ComputeDistance(x, y);
 * 
 * */

using System;

namespace Re_useable_Classes.FileFolderTools
{
    /// <summary>
    ///     Contains the Levenshtein Distance algorithm for computing the
    ///     distance between two strings.
    /// </summary>
    public static class LevenshteinDistance
    {
        /// <summary>
        ///     Compute the distance between two strings (the parameters).
        /// </summary>
        /// <param name="s">The first of the two strings you want to compare.</param>
        /// <param name="t">The second of the two strings you want to compare.</param>
        /// <returns>The Levenshtein Distance (higher is a bigger difference).</returns>
        public static int ComputeDistance
            (
            string s,
            string t)
        {
            int n = s.Length;
            int m = t.Length;
            var d = new int[n + 1, m + 1]; // matrix

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0;
                 i <= n;
                 d[i,
                     0] = i++)
            {
            }

            for (int j = 0;
                 j <= m;
                 d[0,
                     j] = j++)
            {
            }

            // Step 3
            for (int i = 1;
                 i <= n;
                 i++)
            {
                //Step 4
                for (int j = 1;
                     j <= m;
                     j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1])
                                   ? 0
                                   : 1;

                    // Step 6
                    d[i,
                        j] = Math.Min
                            (
                                Math.Min
                                    (
                                        d[i - 1,
                                            j] + 1,
                                        d[i,
                                            j - 1] + 1),
                                d[i - 1,
                                    j - 1] + cost);
                }
            }
            // Step 7
            return d[n,
                m];
        }
    }
}
