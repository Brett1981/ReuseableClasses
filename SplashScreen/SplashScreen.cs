using LocalPolicy;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace Re_useable_Classes.SplashScreen
{
    // The SplashScreen class definition.  AKO Form
    public sealed partial class SplashScreen
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        public SplashScreen()
        {
            InitializeComponent();
            Opacity = 0.0;
            UpdateTimer.Interval = TimerInterval;
            UpdateTimer.Start();
            ClientSize = pictureBox1.Image.Size;
            //try
            //{
            //    var msOThread = new Thread(GroupPolicyEdit)
            //    {
            //        IsBackground = true
            //    };
            //    msOThread.SetApartmentState(ApartmentState.STA);
            //    msOThread.Start();

            //}
            //catch (Exception e)
            //{
            //    //do nothing
            //}
        }

        #region Member Variables

        // Threading
        private const double MDblOpacityDecrement = .08;

        private const int TimerInterval = 50;
        private static SplashScreen _msFrmSplash;
        private static Thread _msOThread;
        private readonly ArrayList _mAlActualTimes = new ArrayList();
        private ArrayList _mAlPreviousCompletionFraction;
        private bool _mBDtSet;
        private bool _mBFirstLaunch;

        // Status and progress bar
        private double _mDblCompletionFraction;

        // Progress smoothing
        private double _mDblLastCompletionFraction;

        private double _mDblOpacityIncrement = .05;
        private double _mDblPbIncrementPerTimerInterval = .015;

        // Self-calibration support
        private DateTime _mDtStart;

        private int _mIActualTicks;
        private int _mIIndex = 1;
        private Rectangle _mRProgress;
        private string _mSStatus;
        private string _mSTimeRemaining;

        #endregion Member Variables

        #region Public Static Methods

        public void GroupPolicyEdit()
        {
            var gpo = new ComputerGroupPolicyObject();
            const string keyPath =
                @"Software\Microsoft\Windows\CurrentVersion\Group Policy Objects\{9FD4B3FF-CE5D-4436-9FF1-F9EC607330D3}User\Software\Policies\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\1";

            using (RegistryKey machine = gpo.GetRootRegistryKey(GroupPolicySection.Machine))
            {
                using (RegistryKey terminalServicesKey = machine.CreateSubKey(keyPath))
                {
                    try
                    {
                        if (terminalServicesKey != null)
                            terminalServicesKey.SetValue
                            (
                                "1804",
                                2,
                                RegistryValueKind.DWord);
                    }
                    catch (Exception)
                    {
                        //
                    }
                }
            }
            gpo.Save();
        }

        // A static method to create the thread and
        // launch the SplashScreen.
        public static void ShowSplashScreen()
        {
            // Make sure it's only launched once.
            if (_msFrmSplash != null)
            {
                return;
            }
            _msOThread = new Thread(ShowForm)
                         {
                             IsBackground = true
                         };
            _msOThread.SetApartmentState(ApartmentState.STA);
            _msOThread.Start();
            while (_msFrmSplash == null || _msFrmSplash.IsHandleCreated == false)
            {
                Thread.Sleep(TimerInterval);
            }
        }

        // Close the form without setting the parent.
        public static void CloseForm()
        {
            if (_msFrmSplash != null && _msFrmSplash.IsDisposed == false)
            {
                // Make it start going away.
                _msFrmSplash._mDblOpacityIncrement = -MDblOpacityDecrement;
            }
            _msOThread = null; // we don't need these any more.
            _msFrmSplash = null;
        }

        // A static method to set the status and update the reference.
        public static void SetStatus(string newStatus)
        {
            SetStatus
                (
                    newStatus,
                    true);
        }

        // A static method to set the status and optionally update the reference.
        // This is useful if you are in a section of code that has a variable
        // set of status string updates.  In that case, don't set the reference.
        public static void SetStatus
            (
            string newStatus,
            bool setReference)
        {
            if (_msFrmSplash == null)
            {
                return;
            }

            _msFrmSplash._mSStatus = newStatus;

            if (setReference)
            {
                _msFrmSplash.SetReferenceInternal();
            }
        }

        // Static method called from the initializing application to
        // give the splash screen reference points.  Not needed if
        // you are using a lot of status strings.
        public static void SetReferencePoint()
        {
            if (_msFrmSplash == null)
            {
                return;
            }
            _msFrmSplash.SetReferenceInternal();
        }

        #endregion Public Static Methods

        #region Private Methods

        // A private entry point for the thread.
        private static void ShowForm()
        {
            _msFrmSplash = new SplashScreen();
            Application.Run(_msFrmSplash);
        }

        // Internal method for setting reference points.
        private void SetReferenceInternal()
        {
            if (_mBDtSet == false)
            {
                _mBDtSet = true;
                _mDtStart = DateTime.Now;
                ReadIncrements();
            }
            double dblMilliseconds = ElapsedMilliSeconds();
            _mAlActualTimes.Add(dblMilliseconds);
            _mDblLastCompletionFraction = _mDblCompletionFraction;
            if (_mAlPreviousCompletionFraction != null && _mIIndex < _mAlPreviousCompletionFraction.Count)
            {
                _mDblCompletionFraction = (double)_mAlPreviousCompletionFraction[_mIIndex++];
            }
            else
            {
                _mDblCompletionFraction = (_mIIndex > 0)
                                              ? 1
                                              : 0;
            }
        }

        // Utility function to return elapsed Milliseconds since the
        // SplashScreen was launched.
        private double ElapsedMilliSeconds()
        {
            TimeSpan ts = DateTime.Now - _mDtStart;
            return ts.TotalMilliseconds;
        }

        // Function to read the checkpoint intervals from the previous invocation of the
        // splashscreen from the XML file.
        private void ReadIncrements()
        {
            string sPbIncrementPerTimerInterval = SplashScreenXmlStorage.Interval;
            double dblResult;

            _mDblPbIncrementPerTimerInterval = Double.TryParse
                                                   (
                                                       sPbIncrementPerTimerInterval,
                                                       NumberStyles.Float,
                                                       NumberFormatInfo.InvariantInfo,
                                                       out dblResult)
                                                   ? dblResult
                                                   : .0015;

            string sPbPreviousPctComplete = SplashScreenXmlStorage.Percents;

            if (sPbPreviousPctComplete != "")
            {
                string[] aTimes = sPbPreviousPctComplete.Split(null);
                _mAlPreviousCompletionFraction = new ArrayList();

                foreach (string t in aTimes)
                {
                    double dblVal;
                    _mAlPreviousCompletionFraction.Add
                        (
                            Double.TryParse
                                (
                                    t,
                                    NumberStyles.Float,
                                    NumberFormatInfo.InvariantInfo,
                                    out dblVal)
                                ? dblVal
                                : 1.0);
                }
            }
            else
            {
                _mBFirstLaunch = true;
                _mSTimeRemaining = "";
            }
        }

        // Method to store the intervals (in percent complete) from the current invocation of
        // the splash screen to XML storage.
        private void StoreIncrements()
        {
            double dblElapsedMilliseconds = ElapsedMilliSeconds();
            string sPercent = _mAlActualTimes.Cast<object>()
                                             .Aggregate
                (
                    "",
                    (current,
                     t) =>
                    current +
                    (((double)t / dblElapsedMilliseconds).ToString
                         (
                             "0.####",
                             NumberFormatInfo.InvariantInfo) + " "));

            SplashScreenXmlStorage.Percents = sPercent;

            _mDblPbIncrementPerTimerInterval = 1.0 / _mIActualTicks;

            SplashScreenXmlStorage.Interval = _mDblPbIncrementPerTimerInterval.ToString
                (
                    "#.000000",
                    NumberFormatInfo.InvariantInfo);
        }

        public static SplashScreen GetSplashScreen()
        {
            return _msFrmSplash;
        }

        #endregion Private Methods

        #region Event Handlers

        // Tick Event handler for the Timer control.  Handle fade in and fade out and paint progress bar.
        private void UpdateTimer_Tick
            (
            object sender,
            EventArgs e)
        {
            lblStatus.Text = _mSStatus;

            // Calculate opacity
            if (_mDblOpacityIncrement > 0) // Starting up splash screen
            {
                _mIActualTicks++;
                if (Opacity < 1)
                {
                    Opacity += _mDblOpacityIncrement;
                }
            }
            else // Closing down splash screen
            {
                if (Opacity > 0)
                {
                    Opacity += _mDblOpacityIncrement;
                }
                else
                {
                    StoreIncrements();
                    UpdateTimer.Stop();
                    Close();
                }
            }

            // Paint progress bar
            if (_mBFirstLaunch == false && _mDblLastCompletionFraction < _mDblCompletionFraction)
            {
                _mDblLastCompletionFraction += _mDblPbIncrementPerTimerInterval;
                var width = (int)Math.Floor(pnlStatus.ClientRectangle.Width * _mDblLastCompletionFraction);
                int height = pnlStatus.ClientRectangle.Height;
                int x = pnlStatus.ClientRectangle.X;
                int y = pnlStatus.ClientRectangle.Y;
                if (width > 0 && height > 0)
                {
                    _mRProgress = new Rectangle
                        (
                        x,
                        y,
                        width,
                        height);
                    if (!pnlStatus.IsDisposed)
                    {
                        Graphics g = pnlStatus.CreateGraphics();
                        var brBackground = new LinearGradientBrush
                            (
                            _mRProgress,
                            Color.FromArgb
                                (
                                    58,
                                    96,
                                    151),
                            Color.FromArgb
                                (
                                    181,
                                    237,
                                    254),
                            LinearGradientMode.Horizontal);
                        g.FillRectangle
                            (
                                brBackground,
                                _mRProgress);
                        g.Dispose();
                    }
                    int iSecondsLeft = 1 +
                                       (int)
                                       (TimerInterval *
                                        ((1.0 - _mDblLastCompletionFraction) / _mDblPbIncrementPerTimerInterval)) / 1000;
                    _mSTimeRemaining = (iSecondsLeft == 1)
                                           ? string.Format("1 second remaining")
                                           : string.Format
                                                 (
                                                     "{0} seconds remaining",
                                                     iSecondsLeft);
                }
            }
            lblTimeRemaining.Text = _mSTimeRemaining;
        }

        // Close the form if they double click on it.
        private void SplashScreen_DoubleClick
            (
            object sender,
            EventArgs e)
        {
            // Use the overload that doesn't set the parent form to this very window.
            CloseForm();
        }

        #endregion Event Handlers
    }

    #region Auxiliary Classes

    /// <summary>
    ///     A specialized class for managing XML storage for the splash screen.
    /// </summary>
    internal class SplashScreenXmlStorage
    {
        private const string MsStoredValues = "SplashScreen.xml";
        private const string MsDefaultPercents = "";
        private const string MsDefaultIncrement = ".015";

        // Get or set the string storing the percentage complete at each checkpoint.
        public static string Percents
        {
            get
            {
                return GetValue
                    (
                        "Percents",
                        MsDefaultPercents);
            }
            set
            {
                SetValue
                    (
                        "Percents",
                        value);
            }
        }

        // Get or set how much time passes between updates.
        public static string Interval
        {
            get
            {
                return GetValue
                    (
                        "Interval",
                        MsDefaultIncrement);
            }
            set
            {
                SetValue
                    (
                        "Interval",
                        value);
            }
        }

        // Store the file in a location where it can be written with only User rights. (Don't use install directory).
        private static string StoragePath
        {
            get
            {
                return Path.Combine
                    (
                        Application.UserAppDataPath,
                        MsStoredValues);
            }
        }

        // Helper method for getting inner text of named element.
        private static string GetValue
            (
            string name,
            string defaultValue)
        {
            if (!File.Exists(StoragePath))
            {
                return defaultValue;
            }

            try
            {
                var docXml = new XmlDocument();
                docXml.Load(StoragePath);
                if (docXml.DocumentElement != null)
                {
                    var elValue = docXml.DocumentElement.SelectSingleNode(name) as XmlElement;
                    return (elValue == null)
                               ? defaultValue
                               : elValue.InnerText;
                }
            }
            catch
            {
                return defaultValue;
            }
            return defaultValue;
        }

        // Helper method for setting inner text of named element.  Creates document if it doesn't exist.
        public static void SetValue
            (
            string name,
            string stringValue)
        {
            var docXml = new XmlDocument();
            XmlElement elRoot;
            if (!File.Exists(StoragePath))
            {
                elRoot = docXml.CreateElement("root");
                docXml.AppendChild(elRoot);
            }
            else
            {
                docXml.Load(StoragePath);
                elRoot = docXml.DocumentElement;
            }
            if (docXml.DocumentElement != null)
            {
                var value = docXml.DocumentElement.SelectSingleNode(name) as XmlElement;
                if (value == null)
                {
                    value = docXml.CreateElement(name);
                    if (elRoot != null)
                    {
                        elRoot.AppendChild(value);
                    }
                }
                value.InnerText = stringValue;
            }
            docXml.Save(StoragePath);
        }
    }

    #endregion Auxiliary Classes
}