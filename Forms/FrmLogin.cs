using Re_useable_Classes.SQL;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Security.Principal;
using System.Windows.Forms;

namespace Re_useable_Classes.Forms
{
    public sealed partial class FrmLogin : Form
    {
        public FrmLogin
            (
            string frmTitle,
            Icon frmIcon, Form afrmtoLoad)
        {
            InitializeComponent();
            Text = frmTitle;
            Icon = frmIcon;
            AformtoConnect = afrmtoLoad;
            AConnectionIsOpen = false;
            SplashScreen.SplashScreen.SetStatus("Initialising Form..");
            ASqlServers = new GetSqlServers();
            SplashScreen.SplashScreen.SetStatus("Preparing SQL Servers...");
            ASqlServers.aGetSqlServers();
            SplashScreen.SplashScreen.SetStatus("Retrieve Windows User....");
            AWindowsIdentity = WindowsIdentity.GetCurrent();
            SplashScreen.SplashScreen.SetStatus("Preparing Application.....");
            if (AWindowsIdentity != null)
            {
                txtUsername.Text = AWindowsIdentity.Name;
            }
        }

        private Form AformtoConnect { get; set; }
        private Connection AConnection { get; set; }
        private GetSqlServers ASqlServers { get; set; }
        private GetDatabases ADatabases { get; set; }
        private WindowsIdentity AWindowsIdentity { get; set; }
        public bool AConnectionIsOpen { get; set; }

        private void cmbServer_BeforeDropDown
            (
            object sender,
            CancelEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            cmbServer.DataSource = ASqlServers.aGetSqlServers();
            Cursor = Cursors.Default;
        }

        private void cmbDataBase_BeforeDropDown
            (
            object sender,
            CancelEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            switch (chkWinAuth.CheckState)
            {
                case CheckState.Checked:
                    AConnection = new Connection();
                    AConnection.CreateConnection
                        (
                            txtUsername.Text,
                            txtPassword.Text,
                            cmbServer.Text,
                            "",
                            "WIN");
                    break;

                default:
                    AConnection = new Connection();
                    AConnection.CreateConnection
                        (
                            txtUsername.Text,
                            txtPassword.Text,
                            cmbServer.Text,
                            "",
                            "SQL");
                    break;
            }
            ADatabases = new GetDatabases();
            cmbDataBase.DataSource = ADatabases.GetSqlDataBases(AConnection);
            Cursor = Cursors.Default;
        }

        private void chkWinAuth_CheckStateChanged
            (
            object sender,
            EventArgs e)
        {
            if (chkWinAuth.CheckState == CheckState.Checked)
            {
                if (AWindowsIdentity.User == null)
                {
                    return;
                }
                txtUsername.Text = AWindowsIdentity.Name;
                txtUsername.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                txtUsername.Enabled = true;
                txtPassword.Enabled = true;
            }
        }

        private void FrmLogin_FormClosed
            (
            object sender,
            FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click
            (
            object sender,
            EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            switch (chkWinAuth.CheckState)
            {
                case CheckState.Checked:
                    AConnection = new Connection();
                    AConnection.CreateConnection
                        (
                            txtUsername.Text,
                            txtPassword.Text,
                            cmbServer.Text,
                            cmbDataBase.Text,
                            "WIN");
                    break;

                default:
                    AConnection = new Connection();
                    AConnection.CreateConnection
                        (
                            txtUsername.Text,
                            txtPassword.Text,
                            cmbServer.Text,
                            cmbDataBase.Text,
                            "SQL");
                    break;
            }
            ADatabases = new GetDatabases();
            cmbDataBase.DataSource = ADatabases.GetSqlDataBases(AConnection);
            AConnectionIsOpen = AConnection.IsConnectionOpen();
            Cursor = Cursors.Default;
            AformtoConnect.Show();
            Hide();
        }
    }
}