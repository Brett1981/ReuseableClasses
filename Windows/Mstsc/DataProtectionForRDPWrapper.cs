using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Re_useable_Classes.Windows.Mstsc
{
    public class DataProtectionForRdpWrapper
    {
        private static readonly DataProtector Dp = new DataProtector(DataProtector.Store.UseMachineStore);

        public static string Decrypt(string encPassword)
        {
            byte[] b = ToByteArray(encPassword);
            if (b != null && Dp != null)
            {
                byte[] d = Dp.Decrypt
                    (
                        b,
                        null,
                        "psw");
                if (d != null)
                {
                    return GetString(d);
                }
            }

            return null;
        }

        public static string Encrypt(string textPassword)
        {
            IEnumerable<byte> e = Dp.Encrypt
                (
                    GetBytes(textPassword),
                    null,
                    "psw");
            return GetHex(e);
        }

        private static byte[] GetBytes(string text)
        {
            return Encoding.Unicode.GetBytes(text);
        }

        private static string GetHex(IEnumerable<byte> bytText)
        {
            return bytText != null
                       ? bytText.Aggregate
                             (
                                 string.Empty,
                                 (current,
                                  t) => current + Convert.ToString
                                                      (
                                                          t,
                                                          16)
                                                         .PadLeft
                                                      (
                                                          2,
                                                          '0')
                                                         .ToUpper())
                       : null;
        }

        private static string GetString(byte[] byt)
        {
            Encoding enc = Encoding.Unicode;
            return byt != null
                       ? enc.GetString(byt)
                       : null;
        }

        private static byte[] ToByteArray(String hexString)
        {
            try
            {
                int numberChars = hexString.Length;
                var bytes = new byte[numberChars/2];
                for (int i = 0;
                     i < numberChars;
                     i += 2)
                {
                    bytes[i/2] = Convert.ToByte
                        (
                            hexString.Substring
                                (
                                    i,
                                    2),
                            16);
                }
                return bytes;
            }
            catch (Exception ex)
            {
                // this occures everytime we decrypt MSTSC generated password.
                // so let's just throw an exception for now
                throw new Exception
                    (
                    "Problem converting Hex to Bytes",
                    ex);
            }
        }
    }
}
