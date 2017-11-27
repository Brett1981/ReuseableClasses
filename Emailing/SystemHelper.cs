using System;
using System.IO;
using System.Windows.Forms;

namespace Re_useable_Classes.Emailing
{
    public class SystemHelper
    {
        public static string CreateGetProgramDataPath()
        {
            //Program data directory
            string strProgramDataPath =
                Path.Combine
                    (
                        Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                        Path.Combine
                            (
                                "Access Applications",
                                GetAppName()));

            //Check if folder exists
            if (Directory.Exists(strProgramDataPath) == false)
            {
                Directory.CreateDirectory(strProgramDataPath);
            }
            return strProgramDataPath;
        }

        public static string GetAppName()
        {
            return Application.ProductName;
        }
    }
}
