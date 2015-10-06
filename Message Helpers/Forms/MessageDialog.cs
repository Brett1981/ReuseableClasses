using System;
using System.Drawing;
using System.Windows.Forms;

//Message dialog box form

namespace Re_useable_Classes.Message_Helpers.Forms
{
    public partial class MessageDialog : Form
    {
        #region Variables & Constants

        private static MessageDialog _newMessageBox;
        private static MessageBoxResult _mMessageResult = MessageBoxResult.None;
        private readonly string _mCaption;
        private readonly string _mMessage;
        private readonly MessageBoxButtons _mMessageButtons;
        private readonly MessageBoxIcon _mMessageIcon;
        private readonly string _mMore;
        private readonly Form _mParent;
        private int _mHeight;
        private int _mWidth;

        #endregion

        #region Enumerators

        //Icon enum

        //message box buttons
        public enum MessageBoxButtons
        {
            Ok = 0,
            OkCancel = 1,
            YesNo = 2
        }

        public enum MessageBoxIcon
        {
            Asterisk = 0,
            Error = 1,
            Exclamation = 2,
            Hand = 3,
            Information = 4,
            Question = 5,
            Stop = 6,
            Warning = 7,
            None = 8
        }

        //Message box result
        public enum MessageBoxResult
        {
            No = 0,
            Ok = 1,
            Yes = 2,
            None = 3
        }

        #endregion

        #region Events

        //Int event
        public MessageDialog
            (
            string caption,
            string message,
            MessageBoxIcon messageIcon,
            MessageBoxButtons messageButtons,
            string more = "",
            Form parent = null)
        {
            InitializeComponent();

            //Save details for processing
            _mMessageButtons = messageButtons;
            _mMessageIcon = messageIcon;
            _mCaption = caption;
            _mMessage = message;
            _mMore = more;
            _mParent = parent;
        }

        //Form load
        private void MessageDialog_Load
            (
            object sender,
            EventArgs e)
        {
            //Set more text if specified
            tbMoreDetails.Text = (_mMore != ""
                                      ? _mMore
                                      : "");
            egbDetails.Visible = _mMore != "";
            egbDetails.Expanded = false;

            //Set caption
            _newMessageBox.Text = _mCaption;

            //Set text
            _newMessageBox.lblMessage.Text = _mMessage;

            //Set image
            SetBitmap();

            //Set buttons layout
            SetButtonsLayout();

            //Set poisiton
            if (_mParent != null)
            {
                //Set location from parent
                Location = new Point
                    (
                    ((_mParent.Width/2) - (Width/2)),
                    ((_mParent.Height/2) - (Height/2)));
            }
        }

        //Button 1 clicked
        private void btnOne_Click
            (
            object sender,
            EventArgs e)
        {
            //Check button type for process
            switch (_mMessageButtons)
            {
                case MessageBoxButtons.OkCancel:
                    _mMessageResult = MessageBoxResult.None;
                    _newMessageBox.Dispose();
                    break;
                case MessageBoxButtons.YesNo:
                    _mMessageResult = MessageBoxResult.No;
                    _newMessageBox.Dispose();
                    break;
                default:
                    _mMessageResult = MessageBoxResult.None;
                    _newMessageBox.Dispose();
                    break;
            }
        }

        //Button 2 clicked
        private void btnTwo_Click
            (
            object sender,
            EventArgs e)
        {
            //Check button type for process
            switch (_mMessageButtons)
            {
                case MessageBoxButtons.Ok:
                    _mMessageResult = MessageBoxResult.Ok;
                    _newMessageBox.Dispose();
                    break;
                case MessageBoxButtons.OkCancel:
                    _mMessageResult = MessageBoxResult.Ok;
                    _newMessageBox.Dispose();
                    break;
                case MessageBoxButtons.YesNo:
                    _mMessageResult = MessageBoxResult.Yes;
                    _newMessageBox.Dispose();
                    break;
                default:
                    _mMessageResult = MessageBoxResult.Ok;
                    _newMessageBox.Dispose();
                    break;
            }
        }

        //Details expanded changed
        private void egbDetails_ExpandedStateChanged
            (
            object sender,
            EventArgs e)
        {
            //Set box width and height
            SetBoxWidth();
            SetBoxHeight();
        }

        #endregion

        #region Methods

        //Show message dialog
        public static MessageBoxResult Show
            (
            string message,
            string caption,
            MessageBoxButtons messageButtons = MessageBoxButtons.Ok,
            MessageBoxIcon messageIcon = MessageBoxIcon.None,
            string more = "",
            Form parent = null)
        {
            //Create new message instance
            _newMessageBox = new MessageDialog
                (
                caption,
                message,
                messageIcon,
                messageButtons,
                more,
                parent);

            //Display message
            _newMessageBox.ShowDialog();

            //Return result
            return _mMessageResult;
        }

        //Set message width
        private void SetBoxWidth()
        {
            //Check if already set
            if (_mWidth == 0 || egbDetails.Expanded)
            {
                int intMWidth;
                int intCWidth;

                //Get sizes for message and caption
                using (Graphics g = CreateGraphics())
                {
                    // Get the size given the string and the font
                    intMWidth =
                        (int)
                        Math.Round
                            (
                                g.MeasureString
                            (
                                _mMessage,
                                lblMessage.Font,
                                lblMessage.MaximumSize.Width)
                                 .Width,
                                0);
                }
                using (Graphics g = CreateGraphics())
                {
                    // Get the size given the string and the font
                    intCWidth =
                        (int)
                        Math.Round
                            (
                                g.MeasureString
                            (
                                _mCaption,
                                lblMessage.Font,
                                lblMessage.MaximumSize.Width)
                                 .Width,
                                0);
                }

                //Set form width based on required size
                if (_mMore != "" && egbDetails.Expanded)
                {
                    Width = MaximumSize.Width;
                }
                else if (((Width - lblMessage.Width) + (intMWidth > intCWidth
                                                            ? intMWidth
                                                            : intCWidth)) >
                         MaximumSize.Width)
                {
                    Width = MaximumSize.Width;
                }
                else
                {
                    Width = ((Width - lblMessage.Width) + (intMWidth > intCWidth
                                                               ? intMWidth
                                                               : intCWidth + 8));
                }

                //Set message label width
                lblMessage.Width = (intMWidth > intCWidth
                                        ? intMWidth
                                        : intCWidth);

                //Save width
                _mWidth = (_mWidth == 0
                               ? Width
                               : _mWidth);
            }
            else
            {
                Width = _mWidth;
            }
        }

        //Set message height
        private void SetBoxHeight()
        {
            //Check if set or exaqpnded
            if (_mHeight == 0 || egbDetails.Expanded)
            {
                int intHeight;

                //Get sizes for message and caption
                using (Graphics g = CreateGraphics())
                {
                    // Get the size given the string and the font
                    intHeight =
                        (int) Math.Round
                                  (
                                      g.MeasureString
                                  (
                                      _mMessage,
                                      lblMessage.Font,
                                      lblMessage.Width)
                                       .Height,
                                      0);
                }

                //Set form height based on required size
                if (_mMore != "" && egbDetails.Expanded)
                {
                    Height = MaximumSize.Height;
                }
                else if ((((Height - lblMessage.Height) - egbDetails.MaximumSize.Height) + intHeight) >
                         MaximumSize.Height)
                {
                    Height = MaximumSize.Height;
                }
                else
                {
                    Height = (((Height - lblMessage.Height) - egbDetails.MaximumSize.Height) + intHeight);
                }

                //Set label height
                lblMessage.Height = (_mHeight > lblMessage.MaximumSize.Height
                                         ? lblMessage.MaximumSize.Height
                                         : intHeight + 8);

                // Add space for more option if required
                Height += (_mMore != ""
                               ? 20
                               : 0);
                egbDetails.Height = ((pnlButtons.Top - egbDetails.Top) - 10);

                //Set location of more option
                egbDetails.Top = ((lblMessage.Top + lblMessage.Height) + 5);

                //Save height
                _mHeight = (_mHeight == 0
                                ? Height
                                : _mHeight);
            }
            else
            {
                Height = _mHeight;
            }
        }

        //Set bitmap from mnessagbox icon enum
        private void SetBitmap()
        {
            //Check icon type
            switch (_mMessageIcon)
            {
                case MessageBoxIcon.Asterisk:
                    pbMIcon.Image = SystemIcons.Asterisk.ToBitmap();
                    break;
                case MessageBoxIcon.Error:
                    pbMIcon.Image = SystemIcons.Error.ToBitmap();
                    break;
                case MessageBoxIcon.Exclamation:
                    pbMIcon.Image = SystemIcons.Exclamation.ToBitmap();
                    break;
                case MessageBoxIcon.Hand:
                    pbMIcon.Image = SystemIcons.Hand.ToBitmap();
                    break;
                case MessageBoxIcon.Information:
                    pbMIcon.Image = SystemIcons.Information.ToBitmap();
                    break;
                case MessageBoxIcon.Question:
                    pbMIcon.Image = SystemIcons.Question.ToBitmap();
                    break;
                case MessageBoxIcon.Stop:
                    pbMIcon.Image = SystemIcons.Shield.ToBitmap();
                    break;
                case MessageBoxIcon.Warning:
                    pbMIcon.Image = SystemIcons.Warning.ToBitmap();
                    break;
                default:
                    pbMIcon.Image = SystemIcons.Information.ToBitmap();
                    break;
            }
        }

        //Set messagebix layout
        private void SetButtonsLayout()
        {
            //Set buttons as needed
            switch (_mMessageButtons)
            {
                case MessageBoxButtons.Ok:
                    btnOne.Visible = false;
                    btnTwo.Text = "Ok";
                    btnTwo.Left = btnOne.Left;
                    break;
                case MessageBoxButtons.OkCancel:
                    btnOne.Text = "Cancel";
                    btnTwo.Text = "Ok";
                    break;
                case MessageBoxButtons.YesNo:
                    btnOne.Text = "No";
                    btnTwo.Text = "Yes";
                    break;
                default:
                    btnOne.Visible = false;
                    btnTwo.Text = "Ok";
                    btnTwo.Left = btnOne.Left;
                    break;
            }
        }

        #endregion
    }
}
