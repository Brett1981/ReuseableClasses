/*
 * The Alphanum Algorithm is an improved sorting algorithm for strings
 * containing numbers. Instead of sorting numbers in ASCII order like
 * a standard sort, this algorithm sorts numbers in numeric order.
 *
 * */

using System;
using System.Collections;
using System.Diagnostics;
using System.Text;

namespace Re_useable_Classes.Algorythms
{
    /// <summary>
    ///     Call Array.Sort with the first argument being the array and the second being a "new" instance
    ///     of this class, just called with the default constructor. This will result in the array being
    ///     sorted "naturally," such as in the Windows Explorer or Mac Finder.
    /// </summary>
    public class AlphanumComparator : IComparer
    {
        public int Compare
            (
            object x,
            object y)
        {
            Debug.Assert
                (
                    x is string && y is string,
                    "Only strings allowed");
            var s1 = (string) x;
            var s2 = (string) y;

            int thisMarker = 0;
            int thatMarker = 0;

            while ((thisMarker < s1.Length) && (thatMarker < s2.Length))
            {
                char thisCh = s1[thisMarker];
                char thatCh = s2[thatMarker];

                var thisChunk = new StringBuilder();
                var thatChunk = new StringBuilder();

                while ((thisMarker < s1.Length) && InChunk
                                                       (
                                                           thisCh,
                                                           thisChunk))
                {
                    thisChunk.Append(thisCh);
                    thisMarker++;

                    if (thisMarker < s1.Length)
                    {
                        thisCh = s1[thisMarker];
                    }
                }

                while ((thatMarker < s2.Length) && InChunk
                                                       (
                                                           thatCh,
                                                           thatChunk))
                {
                    thatChunk.Append(thatCh);
                    thatMarker++;

                    if (thatMarker < s2.Length)
                    {
                        thatCh = s2[thatMarker];
                    }
                }

                int thisChunkType = char.IsNumber(thisChunk[0])
                                        ? 1
                                        : 0;
                int thatChunkType = char.IsNumber(thatChunk[0])
                                        ? 1
                                        : 0;

                // If both chunks contain numeric characters, sort them numerically
                int result = 0;

                if ((thisChunkType == 1) && (thatChunkType == 1))
                {
                    // int.parse is faster 
                    int thisNumericChunk = int.Parse(thisChunk.ToString());
                    int thatNumericChunk = int.Parse(thatChunk.ToString());

                    if (thisNumericChunk < thatNumericChunk)
                    {
                        result = -1;
                    }
                    else if (thisNumericChunk > thatNumericChunk)
                    {
                        result = 1;
                    }
                }
                else
                {
                    result = String.Compare
                        (
                            thisChunk.ToString(),
                            thatChunk.ToString(),
                            StringComparison.Ordinal);
                }

                if (result != 0)
                {
                    return result;
                }
            }
            return 0;
        }

        private static bool InChunk
            (
            char ch,
            StringBuilder s)
        {
            if (s.Length == 0)
            {
                return true;
            }

            bool isNumChunk = char.IsNumber(s[0]);

            if (isNumChunk == false && char.IsNumber(ch))
            {
                return false;
            }

            return isNumChunk != true || char.IsNumber(ch);
        }
    }
}
