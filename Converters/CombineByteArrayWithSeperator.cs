using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Re_useable_Classes.Converters
{
    public static class CombineByteArrayWithSeperator
    {
        public static byte[] ArrayJoin
            (
            string separator,
            List<byte[]> arrays)
        {
            using (var result = new MemoryStream())
            {
                byte[] first = arrays.First();
                result.Write
                    (
                        first,
                        0,
                        first.Length);

                foreach (var array in arrays.Skip(1))
                {
                    // Write the second string to the stream, byte by byte.
                    foreach (char ch in separator)
                    {
                        byte res = 0;
                        try
                        {
                            res = Convert.ToByte(ch);
                        }
                        catch (OverflowException)
                        {
                        }
                        result.WriteByte(res);
                    }


                    result.Write
                        (
                            array,
                            0,
                            array.Length);
                }

                return result.ToArray();
            }
        }
    }
}
