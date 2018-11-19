using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Re_useable_Classes.Windows.Mstsc
{
    public class RdpFile
    {
        #region enum

        public enum AudioModes
        {
            BringToThisComputer = 0,
            DoNotPlay = 1,
            LeAveAtRemoteComoputer = 2
        };

        public enum KeyboardHooks
        {
            OnTheLocalComputer = 0,
            OnTheRemoteComputer = 1,
            InFullScreenModeOnly = 2
        };

        public enum SessionBpPs
        {
            Bpp8 = 8,
            Bpp15 = 15,
            Bpp16 = 16,
            Bpp24 = 24
        }

        private readonly string[] _rdpTemplate =
        {
            "screen mode id:i:{0}",
            "desktopwidth:i:{1}",
            "desktopheight:i:{2}",
            "session bpp:i:{3}",
            "winposstr:s:0,{4},{5},{6},{7},{8}",
            "full address:s:{9}",
            "compression:i:{10}",
            "keyboardhook:i:{11}",
            "audiomode:i:{12}",
            "redirectdrives:i:{13}",
            "redirectprinters:i:{14}",
            "redirectcomports:i:{15}",
            "redirectsmartcards:i:{16}",
            "displayconnectionbar:i:{17}",
            "autoreconnection enabled:i:{18}",
            "username:s:{19}",
            "domain:s:{20}",
            "alternate shell:s:{21}",
            "shell working directory:s:{22}",
            //"password:b:{23}",removed this as it appears to stop the RDP file being opened in Win7
            "disable wallpaper:i:{23}",
            "disable full window drag:i:{24}",
            "disable menu anims:i:{25}",
            "disable themes:i:{26}",
            "disable cursor setting:i:{27}",
            "bitmapcachepersistenable:i:{28}"
        };

        private int _disableCursorSettings;
        private string _filename = string.Empty;

        public RdpFile()
        {
            var winPosStr = new WindowsPosition();
            WinPosStr = winPosStr;
            Password = string.Empty;
            ShellWorkingDirectory = string.Empty;
            AlternateShell = string.Empty;
            Domain = string.Empty;
            Username = string.Empty;
            AudioMode = 0;
            KeyboardHook = 0;
            FullAddress = string.Empty;
            SessionBpp = 0;
        }

        public string AlternateShell { private get; set; }

        public AudioModes AudioMode { private get; set; }

        public int AutoReconnectionEnabled { private get; set; }

        public int BitmapCachePersistEnable { private get; set; }

        public int Compression { private get; set; }

        public int DesktopHeight { private get; set; }

        public int DesktopWidth { private get; set; }

        public int DisableCursorSettings
        {
            get { return _disableCursorSettings; }
            set { DisplayConnectionBar = value; }
        }

        public int DisableFullWindowDrag { private get; set; }

        public int DisableMenuAnims { private get; set; }

        public int DisableThemes { private get; set; }

        public int DisableWallpaper { private get; set; }

        public int DisplayConnectionBar { private get; set; }

        public string FullAddress { private get; set; }

        public KeyboardHooks KeyboardHook { private get; set; }

        public int RedirectComPorts { private get; set; }

        public int RedirectDrives { private get; set; }

        public int RedirectPrinters { private get; set; }

        public int RedirectSmartCards { private get; set; }

        public int ScreenMode { private get; set; }

        public SessionBpPs SessionBpp { private get; set; }

        public string ShellWorkingDirectory { private get; set; }

        public string Username { private get; set; }

        private string Domain { get; set; }

        private string Password { get; set; }

        private WindowsPosition WinPosStr { get; set; }

        public void Read(string filepath)
        {
            _filename = filepath;

            string data;

            using (var reader = new StreamReader(filepath))
            {
                data = reader.ReadToEnd();
            }

            string[] settings = data.Split
                (
                    new[]
                    {
                        "\r\n"
                    },
                    StringSplitOptions.RemoveEmptyEntries);

            foreach (string thisSetting in settings)
            {
                const string regex = "(?<type>.*)\\:(?<dtype>\\w)\\:(?<value>.*)";

                const RegexOptions options = ((RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline) |
                                              RegexOptions.IgnoreCase);
                var reg = new Regex
                    (
                    regex,
                    options);

                if (!reg.IsMatch(thisSetting))
                {
                    continue;
                }
                Match m = reg.Match(thisSetting);

                string v = m.Groups["value"].Value;

                switch (m.Groups["type"].Value)
                {
                    case "screen mode id":
                        ScreenMode = int.Parse(v);
                        break;

                    case "desktopwidth":
                        DesktopWidth = int.Parse(v);
                        break;

                    case "desktopheight":
                        DesktopHeight = int.Parse(v);
                        break;

                    case "session bpp":
                        SessionBpp = (SessionBpPs)int.Parse(v);
                        break;

                    case "full address":
                        FullAddress = v;
                        break;

                    case "compression":
                        Compression = int.Parse(v);
                        break;

                    case "keyboardhook":
                        KeyboardHook = (KeyboardHooks)int.Parse(v);
                        break;

                    case "audiomode":
                        AudioMode = (AudioModes)int.Parse(v);
                        break;

                    case "redirectdrives":
                        RedirectDrives = int.Parse(v);
                        break;

                    case "redirectprinters":
                        RedirectPrinters = int.Parse(v);
                        break;

                    case "redirectcomports":
                        RedirectComPorts = int.Parse(v);
                        break;

                    case "redirectsmartcards":
                        RedirectSmartCards = int.Parse(v);
                        break;

                    case "displayconnectionbar":
                        DisplayConnectionBar = int.Parse(v);
                        break;

                    case "autoreconnection enabled":
                        AutoReconnectionEnabled = int.Parse(v);
                        break;

                    case "username":
                        Username = v;
                        break;

                    case "domain":
                        Domain = v;
                        break;

                    case "alternate shell":
                        AlternateShell = v;
                        break;

                    case "shell working directory":
                        ShellWorkingDirectory = v;
                        break;

                    //case "password 51":
                    //    this._password = v;
                    //    break;

                    case "disable wallpaper":
                        DisableWallpaper = int.Parse(v);
                        break;

                    case "disable full window drag":
                        DisableFullWindowDrag = int.Parse(v);
                        break;

                    case "disable menu anims":
                        DisableMenuAnims = int.Parse(v);
                        break;

                    case "disable themes":
                        DisableThemes = int.Parse(v);
                        break;

                    case "disable cursor setting":
                        _disableCursorSettings = int.Parse(v);
                        break;

                    case "bitmapcachepersistenable":
                        BitmapCachePersistEnable = int.Parse(v);
                        break;
                }
            }
        }

        public void Save(string filepath)
        {
            _filename = filepath;

            string template = _rdpTemplate.Aggregate
                (
                    string.Empty,
                    (current,
                     temp) => current + (temp + "\r\n"));

            string data = string.Format
                (
                    template,
                    ScreenMode,
                    DesktopWidth,
                    DesktopHeight,
                    (int)SessionBpp,
                    (int)WinPosStr.WinState,
                    WinPosStr.Rect.Top,
                    WinPosStr.Rect.Left,
                    WinPosStr.Rect.Width,
                    WinPosStr.Rect.Height,
                    FullAddress,
                    Compression,
                    (int)KeyboardHook,
                    (int)AudioMode,
                    RedirectDrives,
                    RedirectPrinters,
                    RedirectComPorts,
                    RedirectSmartCards,
                    DisplayConnectionBar,
                    AutoReconnectionEnabled,
                    Username,
                    Domain,
                    AlternateShell,
                    ShellWorkingDirectory,
                //this._password, removed this as it appears to stop the RDP file being opened in Win7
                    DisableWallpaper,
                    DisableFullWindowDrag,
                    DisableMenuAnims,
                    DisableThemes,
                    _disableCursorSettings,
                    BitmapCachePersistEnable
                );

            using (var writer = new StreamWriter(filepath))
            {
                writer.Write(data);
            }
        }

        public void Update()
        {
            Save(_filename);
        }

        private struct Rect
        {
            public readonly int Height;
            public readonly int Left;
            public readonly int Top;
            public readonly int Width;

            public Rect
                (
                int height,
                int left,
                int top,
                int width)
                : this()
            {
                Height = height;
                Left = left;
                Top = top;
                Width = width;
            }
        }

        private enum WindowState
        {
            Normal = 1,
            Maxmize = 3
        }

        private struct WindowsPosition
        {
            public readonly WindowState WinState;
            public Rect Rect;

            public WindowsPosition
                (
                WindowState winState,
                Rect rect)
                : this()
            {
                WinState = winState;
                Rect = rect;
            }
        }

        #endregion enum
    }
}