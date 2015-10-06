using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Infragistics.Win.AppStyling;

namespace Re_useable_Classes
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Stream s =
                (Assembly.GetExecutingAssembly()).GetManifestResourceStream
                    (
                        "Re_useable_Classes.Resources.RubberBlack.iSalesLedger");
            if (s != null)
            {
                StyleManager.Load(s);
            }
        }
    }
}
