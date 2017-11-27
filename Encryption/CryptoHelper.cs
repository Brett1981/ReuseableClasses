using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Re_useable_Classes.Encryption
{
    public class CryptoHelper
    {
        // DO NOT CHANGE
        private readonly ICryptoTransform _decryptorTransform;
        private readonly ICryptoTransform _encryptorTransform;

        private readonly byte[] _key =
        {
            232,
            64,
            51,
            61,
            159,
            112,
            0,
            187,
            219,
            147,
            123,
            59,
            199,
            201,
            119,
            124,
            95,
            252,
            237,
            11,
            186,
            182,
            100,
            17,
            209,
            105,
            151,
            85,
            66,
            186,
            75,
            179
        };

        private readonly UTF8Encoding _utfEncoder;

        private readonly byte[] _vector =
        {
            248,
            90,
            253,
            48,
            84,
            147,
            249,
            72,
            221,
            172,
            46,
            38,
            142,
            99,
            236,
            181
        };

        public CryptoHelper()
        {
            // The encryption method
            var rm = new RijndaelManaged();

            // Create encryptor and decryptor using our encryption method, key and vector
            _encryptorTransform = rm.CreateEncryptor
                (
                    _key,
                    _vector);
            _decryptorTransform = rm.CreateDecryptor
                (
                    _key,
                    _vector);

            // Used to translate bytes to text and vice versa
            _utfEncoder = new UTF8Encoding();
        }

        public static byte[] GenerateKey()
        {
            var rm = new RijndaelManaged();
            rm.GenerateKey();

            return rm.Key;
        }

        public static byte[] GenerateVector()
        {
            var rm = new RijndaelManaged();
            rm.GenerateIV();

            return rm.IV;
        }

        /// <summary>
        ///     Encrypt some plaintext and return a string suitable for passing in a URL.
        /// </summary>
        /// <param name="plainText">The plaintext to encrypt.</param>
        /// <returns>An ciphertext version of the plaintext.</returns>
        public string EncryptToString(string plainText)
        {
            return ByteArrayToString(Encrypt(plainText));
        }

        /// <summary>
        ///     Decrypt some ciphertext and return a plaintext string.
        /// </summary>
        /// <param name="cipherText">The ciphertext to decrypt.</param>
        /// <returns>The plaintext version of the ciphertext.</returns>
        public string DecryptString(string cipherText)
        {
            return Decrypt(StringToByteArray(cipherText));
        }

        public byte[] Encrypt(string plainText)
        {
            // Translates our text value into a byte array
            byte[] bytes = _utfEncoder.GetBytes(plainText);

            // Used to stream the data in and out of the CryptoStream
            var memoryStream = new MemoryStream();

            // Write the value to the encryption stream
            var cs = new CryptoStream
                (
                memoryStream,
                _encryptorTransform,
                CryptoStreamMode.Write);
            cs.Write
                (
                    bytes,
                    0,
                    bytes.Length);
            cs.FlushFinalBlock();

            // Read the encrypted value back out
            memoryStream.Position = 0;
            var encrypted = new byte[memoryStream.Length];
            memoryStream.Read
                (
                    encrypted,
                    0,
                    encrypted.Length);

            // Tidy up
            cs.Close();
            memoryStream.Close();

            return encrypted;
        }

        public string Decrypt(byte[] cipherBytes)
        {
            // Write the encrypted value to the decryption stream
            var memoryStream = new MemoryStream();
            var cs = new CryptoStream
                (
                memoryStream,
                _decryptorTransform,
                CryptoStreamMode.Write);
            cs.Write
                (
                    cipherBytes,
                    0,
                    cipherBytes.Length);
            cs.FlushFinalBlock();

            // Read the encrypted value from the stream
            memoryStream.Position = 0;
            var decrypted = new byte[memoryStream.Length];
            memoryStream.Read
                (
                    decrypted,
                    0,
                    decrypted.Length);

            cs.Close();
            memoryStream.Close();

            return _utfEncoder.GetString(decrypted);
        }

        public byte[] StringToByteArray(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException
                    (
                    "Invalid value passed to StringToByteArray.",
                    "input");
            }

            var bytes = new byte[input.Length/3];
            int i = 0;
            int j = 0;

            do
            {
                byte val = byte.Parse
                    (
                        input.Substring
                            (
                                i,
                                3));
                bytes[j++] = val;
                i += 3;
            }
            while (i < input.Length);

            return bytes;
        }

        public string ByteArrayToString(byte[] bytes)
        {
            byte val;
            string temp = string.Empty;
            for (int i = 0;
                 i <= bytes.GetUpperBound(0);
                 i++)
            {
                val = bytes[i];
                if (val < 10)
                {
                    temp += "00" + val;
                }
                else if (val < 100)
                {
                    temp += "0" + val;
                }
                else
                {
                    temp += val.ToString();
                }
            }

            return temp;
        }
    }
}
