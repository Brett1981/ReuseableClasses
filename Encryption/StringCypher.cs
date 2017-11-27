using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Re_useable_Classes.Encryption
{
    public class StringCipher
    {
        // This constant string is used as a "salt" value for the PasswordDeriveBytes function calls.
        private const string InitVector = "tu89geji340t89u2";
        // This constant is used to determine the keysize of the encryption algorithm.
        private const int Keysize = 256;
        private const char Base64Padding = '=';

        private static readonly HashSet<char> Base64Characters = new HashSet<char>
                                                                 {
                                                                     'A',
                                                                     'B',
                                                                     'C',
                                                                     'D',
                                                                     'E',
                                                                     'F',
                                                                     'G',
                                                                     'H',
                                                                     'I',
                                                                     'J',
                                                                     'K',
                                                                     'L',
                                                                     'M',
                                                                     'N',
                                                                     'O',
                                                                     'P',
                                                                     'Q',
                                                                     'R',
                                                                     'S',
                                                                     'T',
                                                                     'U',
                                                                     'V',
                                                                     'W',
                                                                     'X',
                                                                     'Y',
                                                                     'Z',
                                                                     'a',
                                                                     'b',
                                                                     'c',
                                                                     'd',
                                                                     'e',
                                                                     'f',
                                                                     'g',
                                                                     'h',
                                                                     'i',
                                                                     'j',
                                                                     'k',
                                                                     'l',
                                                                     'm',
                                                                     'n',
                                                                     'o',
                                                                     'p',
                                                                     'q',
                                                                     'r',
                                                                     's',
                                                                     't',
                                                                     'u',
                                                                     'v',
                                                                     'w',
                                                                     'x',
                                                                     'y',
                                                                     'z',
                                                                     '0',
                                                                     '1',
                                                                     '2',
                                                                     '3',
                                                                     '4',
                                                                     '5',
                                                                     '6',
                                                                     '7',
                                                                     '8',
                                                                     '9',
                                                                     '+',
                                                                     '/'
                                                                 };

        public static string Encrypt
            (
            string plainText,
            string passPhrase)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(InitVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            var password = new PasswordDeriveBytes
                (
                passPhrase,
                null);
            byte[] keyBytes = password.GetBytes(Keysize/8);
            var symmetricKey = new RijndaelManaged
                               {
                                   Mode = CipherMode.CBC
                               };
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor
                (
                    keyBytes,
                    initVectorBytes);
            var memoryStream = new MemoryStream();
            var cryptoStream = new CryptoStream
                (
                memoryStream,
                encryptor,
                CryptoStreamMode.Write);
            cryptoStream.Write
                (
                    plainTextBytes,
                    0,
                    plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }

        public static string Decrypt
            (
            string cipherText,
            string passPhrase)
        {
            bool isValid = CheckBase64StringSafe(cipherText);
            string returnString = "";
            if (isValid)
            {
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(InitVector);
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
                var password = new PasswordDeriveBytes
                    (
                    passPhrase,
                    null);
                byte[] keyBytes = password.GetBytes(Keysize/8);
                var symmetricKey = new RijndaelManaged
                                   {
                                       Mode = CipherMode.CBC
                                   };
                ICryptoTransform decryptor = symmetricKey.CreateDecryptor
                    (
                        keyBytes,
                        initVectorBytes);
                var memoryStream = new MemoryStream(cipherTextBytes);
                var cryptoStream = new CryptoStream
                    (
                    memoryStream,
                    decryptor,
                    CryptoStreamMode.Read);
                var plainTextBytes = new byte[cipherTextBytes.Length];
                int decryptedByteCount = cryptoStream.Read
                    (
                        plainTextBytes,
                        0,
                        plainTextBytes.Length);
                memoryStream.Close();
                cryptoStream.Close();
                returnString = Encoding.UTF8.GetString
                    (
                        plainTextBytes,
                        0,
                        decryptedByteCount);
            }
            return returnString;
        }

        public static Boolean CheckBase64StringSafe(string param)
        {
            if (param == null)
            {
                // null string is not Base64 something
                return false;
            }

            // replace optional CR and LF characters
            param = param.Replace
                (
                    "\r",
                    String.Empty)
                         .Replace
                (
                    "\n",
                    String.Empty);

            if (param.Length == 0 ||
                (param.Length%4) != 0 ||
                param.Length < 24)
            {
                // Base64 string should not be empty
                // Base64 string length should be multiple of 4 and a minimum of 24 characters
                return false;
            }

            // replace pad chacters
            int lengthNoPadding = param.Length;

            param = param.TrimEnd(Base64Padding);
            int lengthPadding = param.Length;

            if ((lengthNoPadding - lengthPadding) > 2)
            {
                // there should be no more than 2 pad characters
                return false;
            }

            return param.All(c => Base64Characters.Contains(c));

            // nothing invalid found
        }
    }
}
