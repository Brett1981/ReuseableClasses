using Re_useable_Classes.Message_Helpers.Forms;
using Re_useable_Classes.SQL;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Principal;
using System.Windows.Forms;

namespace Re_useable_Classes.Forms
{
    public sealed partial class FrmLoginMySql : Form
    {
        public FrmLoginMySql
            (
            string frmTitle,
            Icon frmIcon)
        {
            InitializeComponent();
            Text = frmTitle;
            Icon = frmIcon;
            AConnectionIsOpen = false;
            SplashScreen.SplashScreen.SetStatus("Initialising Form..");
            //ASqlServers = new GetSQLServers();
            SplashScreen.SplashScreen.SetStatus("Preparing SQL Servers...");
            //ASqlServers.GetSqlServers();
            SplashScreen.SplashScreen.SetStatus("Retrieve Windows User....");
            AWindowsIdentity = WindowsIdentity.GetCurrent();
            SplashScreen.SplashScreen.SetStatus("Preparing Application.....");
            //if (AWindowsIdentity != null) txtUsername.Text = AWindowsIdentity.Name;
        }

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
            Cursor = Cursors.Default;
        }

        private void cmbDataBase_BeforeDropDown
            (
            object sender,
            CancelEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            //"datasource =pcathomegroup.com;port=3306;username=sjbrett_Admin;password=Br3tt1981";

            MySqlConnec.AMySqlConnection
                (
                    cmbServer.Text,
                    txtPort.Text,
                    txtUsername.Text,
                    txtPassword.Text,
                    "");
            if (MySqlConnec.CmdDataBase.Connection.State == ConnectionState.Open)
            {
                cmbDataBase.DataSource = MySqlConnec.GetDatabases(MySqlConnec.CmdDataBase.Connection);
            }
            else
            {
                MessageDialog.Show
                    (
                        "Connection Has Failed, Please Check Your Credentials and try again",
                        "Connection State 'Closed'",
                        MessageDialog.MessageBoxButtons.Ok,
                        MessageDialog.MessageBoxIcon.Error);
            }
            Cursor = Cursors.Default;
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

            MySqlConnec.AMySqlConnectionDb
                (
                    cmbDataBase.Text,
                    cmbServer.Text,
                    txtPort.Text,
                    txtUsername.Text,
                    txtPassword.Text,
                    "");

            if (MySqlConnec.CmdDataBase.Connection.State == ConnectionState.Open)
            {
                AConnectionIsOpen = true;
            }
            else
            {
                AConnectionIsOpen = false;
                MessageDialog.Show
                    (
                        "Connection Has Failed, Please Check Your Credentials and try again",
                        "Connection State 'Closed'",
                        MessageDialog.MessageBoxButtons.Ok,
                        MessageDialog.MessageBoxIcon.Error);
            }
            Cursor = Cursors.Default;
        }
    }
}