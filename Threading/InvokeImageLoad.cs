using System.Drawing;
using System.Windows.Forms;
using Infragistics.Win.UltraWinEditors;

namespace Re_useable_Classes.Threading
{
    public class InvokeImageLoad
    {
        public static UltraPictureBox SetPicture
            (
            Image img,
            UltraPictureBox aUltraPictureBox)
        {
            if (aUltraPictureBox.InvokeRequired)
            {
                aUltraPictureBox.Invoke
                    (
                        new MethodInvoker
                            (
                            delegate { aUltraPictureBox.Image = img; }));
            }
            else
            {
                aUltraPictureBox.Image = img;
            }
            return aUltraPictureBox;
        }
    }
}
