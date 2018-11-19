using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Re_useable_Classes.Windows.Mstsc
{
    public class DataProtector
    {
        public enum Store
        {
            UseMachineStore = 1
        };

        private const int CryptprotectLocalMachine = 0x4;
        private const int CryptprotectUiForbidden = 0x1;
        private static readonly IntPtr NullPtr = ((IntPtr)((0)));
        private readonly Store _store;

        public DataProtector(Store tempStore)
        {
            _store = tempStore;
        }

        public byte[] Decrypt
            (
            byte[] cipherText,
            byte[] optionalEntropy,
            string dataDescription)
        {
            var plainTextBlob = new DataBlob();
            var cipherBlob = new DataBlob();
            var prompt = new
                CryptprotectPromptstruct();
            InitPromptstruct(ref prompt);
            try
            {
                try
                {
                    int cipherTextSize = cipherText.Length;
                    cipherBlob.pbData = Marshal.AllocHGlobal(cipherTextSize);
                    if (IntPtr.Zero == cipherBlob.pbData)
                    {
                        throw new Exception("Unable to allocate cipherText buffer.");
                    }
                    cipherBlob.cbData = cipherTextSize;
                    Marshal.Copy
                        (
                            cipherText,
                            0,
                            cipherBlob.pbData,
                            cipherBlob.cbData);
                }
                catch (Exception ex)
                {
                    throw new Exception
                        (
                        "Exception marshalling data. " +
                        ex.Message);
                }
                var entropyBlob = new DataBlob();
                int dwFlags;
                if (Store.UseMachineStore == _store)
                {
                    //Using the machine store, should be providing entropy.
                    dwFlags =
                        CryptprotectLocalMachine | CryptprotectUiForbidden;
                    //Check to see if the entropy is null
                    if (null == optionalEntropy)
                    {
                        //Allocate something
                        optionalEntropy = new byte[0];
                    }
                    try
                    {
                        int bytesSize = optionalEntropy.Length;
                        entropyBlob.pbData = Marshal.AllocHGlobal(bytesSize);
                        if (IntPtr.Zero == entropyBlob.pbData)
                        {
                            throw new Exception("Unable to allocate entropy buffer.");
                        }
                        entropyBlob.cbData = bytesSize;
                        Marshal.Copy
                            (
                                optionalEntropy,
                                0,
                                entropyBlob.pbData,
                                bytesSize);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception
                            (
                            "Exception entropy marshalling data. " +
                            ex.Message);
                    }
                }
                else
                {
                    //Using the user store
                    dwFlags = CryptprotectUiForbidden;
                }
                bool retVal = dataDescription != null && CryptUnprotectData
                                                             (
                                                                 ref cipherBlob,
                                                                 dataDescription,
                                                                 ref
                                                             entropyBlob,
                                                                 IntPtr.Zero,
                                                                 ref prompt,
                                                                 dwFlags,
                                                                 ref plainTextBlob);
                if (false == retVal)
                {
                    throw new Exception
                        (
                        "Decryption failed. " +
                        GetErrorMessage(Marshal.GetLastWin32Error()));
                }
                //Free the blob and entropy.
                if (IntPtr.Zero != cipherBlob.pbData)
                {
                    Marshal.FreeHGlobal(cipherBlob.pbData);
                }
                if (IntPtr.Zero != entropyBlob.pbData)
                {
                    Marshal.FreeHGlobal(entropyBlob.pbData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Exception decrypting. " + ex.Message);
            }
            var plainText = new byte[plainTextBlob.cbData];
            Marshal.Copy
                (
                    plainTextBlob.pbData,
                    plainText,
                    0,
                    plainTextBlob.cbData);
            Marshal.FreeHGlobal(plainTextBlob.pbData);
            return plainText;
        }

        public IEnumerable<byte> Encrypt
            (
            byte[] plainText,
            byte[] optionalEntropy,
            string dataDescription)
        {
            var plainTextBlob = new DataBlob();
            var cipherTextBlob = new DataBlob();
            var entropyBlob = new DataBlob();
            var prompt = new CryptprotectPromptstruct();
            InitPromptstruct(ref prompt);
            try
            {
                try
                {
                    int bytesSize = plainText.Length;
                    plainTextBlob.pbData = Marshal.AllocHGlobal(bytesSize);
                    if (IntPtr.Zero == plainTextBlob.pbData)
                    {
                        throw new Exception("Unable to allocate plaintext buffer.");
                    }
                    plainTextBlob.cbData = bytesSize;
                    Marshal.Copy
                        (
                            plainText,
                            0,
                            plainTextBlob.pbData,
                            bytesSize);
                }
                catch (Exception ex)
                {
                    throw new Exception("Exception marshalling data. " + ex.Message);
                }
                int dwFlags;
                if (Store.UseMachineStore == _store)
                {
                    //Using the machine store, should be providing entropy.
                    dwFlags = CryptprotectLocalMachine | CryptprotectUiForbidden;
                    //Check to see if the entropy is null
                    if (null == optionalEntropy)
                    {
                        //Allocate something
                        optionalEntropy = new byte[0];
                    }
                    try
                    {
                        int bytesSize = optionalEntropy.Length;
                        entropyBlob.pbData = Marshal.AllocHGlobal(optionalEntropy.Length);
                        if (IntPtr.Zero == entropyBlob.pbData)
                        {
                            throw new Exception("Unable to allocate entropy data buffer.");
                        }
                        Marshal.Copy
                            (
                                optionalEntropy,
                                0,
                                entropyBlob.pbData,
                                bytesSize);
                        entropyBlob.cbData = bytesSize;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception
                            (
                            "Exception entropy marshalling data. " +
                            ex.Message);
                    }
                }
                else
                {
                    //Using the user store
                    dwFlags = CryptprotectUiForbidden;
                }
                bool retVal = CryptProtectData
                    (
                        ref plainTextBlob,
                        dataDescription,
                        ref entropyBlob,
                        IntPtr.Zero,
                        ref prompt,
                        dwFlags,
                        ref cipherTextBlob);
                if (false == retVal)
                {
                    throw new Exception
                        (
                        "Encryption failed. " +
                        GetErrorMessage(Marshal.GetLastWin32Error()));
                }
                //Free the blob and entropy.
                if (IntPtr.Zero != plainTextBlob.pbData)
                {
                    Marshal.FreeHGlobal(plainTextBlob.pbData);
                }
                if (IntPtr.Zero != entropyBlob.pbData)
                {
                    Marshal.FreeHGlobal(entropyBlob.pbData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Exception encrypting. " + ex.Message);
            }
            var cipherText = new byte[cipherTextBlob.cbData];
            Marshal.Copy
                (
                    cipherTextBlob.pbData,
                    cipherText,
                    0,
                    cipherTextBlob.cbData);
            Marshal.FreeHGlobal(cipherTextBlob.pbData);
            return cipherText;
        }

        [DllImport("Crypt32.dll", SetLastError = true,
            CharSet = CharSet.Auto)]
        private static extern bool CryptProtectData
            (
            ref DataBlob pDataIn,
            String szDataDescr,
            ref DataBlob pOptionalEntropy,
            IntPtr pvReserved,
            ref CryptprotectPromptstruct
                pPromptStruct,
            int dwFlags,
            ref DataBlob pDataOut);

        [DllImport("Crypt32.dll", SetLastError = true,
            CharSet = CharSet.Auto)]
        private static extern bool CryptUnprotectData
            (
            ref DataBlob pDataIn,
            String szDataDescr,
            ref DataBlob pOptionalEntropy,
            IntPtr pvReserved,
            ref CryptprotectPromptstruct
                pPromptStruct,
            int dwFlags,
            ref DataBlob pDataOut);

        [DllImport("kernel32.dll",
            CharSet = CharSet.Auto)]
        public static extern unsafe int FormatMessage
            (
            int dwFlags,
            ref IntPtr lpSource,
            int dwMessageId,
            int dwLanguageId,
            ref String lpBuffer,
            int nSize,
            IntPtr* arguments);

        private static unsafe String GetErrorMessage(int errorCode)
        {
            const int formatMessageAllocateBuffer = 0x00000100;
            const int formatMessageIgnoreInserts = 0x00000200;
            const int formatMessageFromSystem = 0x00001000;
            const int messageSize = 255;
            string lpMsgBuf = "";
            const int dwFlags = formatMessageAllocateBuffer |
                                formatMessageFromSystem |
                                formatMessageIgnoreInserts;
            var ptrlpSource = new IntPtr();
            var prtArguments = new IntPtr();
            int retVal = FormatMessage
                (
                    dwFlags,
                    ref ptrlpSource,
                    errorCode,
                    0,
                    ref lpMsgBuf,
                    messageSize,
                    &prtArguments);
            if (0 == retVal)
            {
                throw new Exception
                    (
                    "Failed to format message for error code " +
                    errorCode + ". ");
            }
            return lpMsgBuf;
        }

        private static void InitPromptstruct(ref CryptprotectPromptstruct ps)
        {
            ps.cbSize = Marshal.SizeOf(typeof(CryptprotectPromptstruct));
            ps.dwPromptFlags = 0;
            ps.hwndApp = NullPtr;
            ps.szPrompt = null;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct CryptprotectPromptstruct
        {
            public int cbSize;
            public int dwPromptFlags;
            public IntPtr hwndApp;
            public String szPrompt;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct DataBlob
        {
            public int cbData;
            public IntPtr pbData;
        }
    }
}