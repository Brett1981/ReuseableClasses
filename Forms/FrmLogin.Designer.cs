namespace Re_useable_Classes.Forms
{
    sealed partial class FrmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.cmbServer = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmbDataBase = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblServer = new Infragistics.Win.Misc.UltraLabel();
            this.lblUsername = new Infragistics.Win.Misc.UltraLabel();
            this.lblPassword = new Infragistics.Win.Misc.UltraLabel();
            this.lblDatabase = new Infragistics.Win.Misc.UltraLabel();
            this.txtUsername = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtPassword = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.chkWinAuth = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.lblWindowsAuth = new Infragistics.Win.Misc.UltraLabel();
            this.btnLogin = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.cmbServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDataBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWinAuth)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbServer
            // 
            this.cmbServer.Location = new System.Drawing.Point(252, 26);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(308, 24);
            this.cmbServer.TabIndex = 0;
            this.cmbServer.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cmbServer_BeforeDropDown);
            // 
            // cmbDataBase
            // 
            this.cmbDataBase.Location = new System.Drawing.Point(252, 113);
            this.cmbDataBase.Name = "cmbDataBase";
            this.cmbDataBase.Size = new System.Drawing.Size(308, 24);
            this.cmbDataBase.TabIndex = 1;
            this.cmbDataBase.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cmbDataBase_BeforeDropDown);
            // 
            // lblServer
            // 
            this.lblServer.Location = new System.Drawing.Point(36, 30);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(100, 23);
            this.lblServer.TabIndex = 2;
            this.lblServer.Text = "Server:";
            // 
            // lblUsername
            // 
            this.lblUsername.Location = new System.Drawing.Point(36, 59);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(100, 23);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "User Name:";
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(36, 88);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(100, 23);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password:";
            // 
            // lblDatabase
            // 
            this.lblDatabase.Location = new System.Drawing.Point(36, 117);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(100, 23);
            this.lblDatabase.TabIndex = 5;
            this.lblDatabase.Text = "Database:";
            // 
            // txtUsername
            // 
            this.txtUsername.Enabled = false;
            this.txtUsername.Location = new System.Drawing.Point(252, 55);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(308, 24);
            this.txtUsername.TabIndex = 6;
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(252, 83);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(308, 24);
            this.txtPassword.TabIndex = 7;
            // 
            // chkWinAuth
            // 
            this.chkWinAuth.BackColor = System.Drawing.Color.Transparent;
            this.chkWinAuth.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkWinAuth.Checked = true;
            this.chkWinAuth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWinAuth.Location = new System.Drawing.Point(252, 160);
            this.chkWinAuth.Name = "chkWinAuth";
            this.chkWinAuth.Size = new System.Drawing.Size(30, 20);
            this.chkWinAuth.TabIndex = 8;
            this.chkWinAuth.CheckStateChanged += new System.EventHandler(this.chkWinAuth_CheckStateChanged);
            // 
            // lblWindowsAuth
            // 
            this.lblWindowsAuth.Location = new System.Drawing.Point(36, 160);
            this.lblWindowsAuth.Name = "lblWindowsAuth";
            this.lblWindowsAuth.Size = new System.Drawing.Size(210, 23);
            this.lblWindowsAuth.TabIndex = 9;
            this.lblWindowsAuth.Text = "Windows Authentication:";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(452, 183);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(108, 31);
            this.btnLogin.TabIndex = 10;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // ultraLabel1
            // 
            appearance1.ForeColor = System.Drawing.Color.Silver;
            this.ultraLabel1.Appearance = appearance1;
            this.ultraLabel1.Enabled = false;
            this.ultraLabel1.Location = new System.Drawing.Point(1, 202);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(327, 23);
            this.ultraLabel1.TabIndex = 11;
            this.ultraLabel1.Text = "Developed By : Stephen Brett  © 2015";
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(583, 226);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblWindowsAuth);
            this.Controls.Add(this.chkWinAuth);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.cmbDataBase);
            this.Controls.Add(this.cmbServer);
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frmlogin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLogin_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.cmbServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDataBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWinAuth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbServer;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbDataBase;
        private Infragistics.Win.Misc.UltraLabel lblServer;
        private Infragistics.Win.Misc.UltraLabel lblUsername;
        private Infragistics.Win.Misc.UltraLabel lblPassword;
        private Infragistics.Win.Misc.UltraLabel lblDatabase;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtUsername;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPassword;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkWinAuth;
        private Infragistics.Win.Misc.UltraLabel lblWindowsAuth;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        public Infragistics.Win.Misc.UltraButton btnLogin;
    }
}