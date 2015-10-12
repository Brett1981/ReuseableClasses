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
            this.lblDevelopedby = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.cmbServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDataBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWinAuth)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbServer
            // 
            this.cmbServer.Location = new System.Drawing.Point(189, 21);
            this.cmbServer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(231, 21);
            this.cmbServer.TabIndex = 0;
            this.cmbServer.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cmbServer_BeforeDropDown);
            // 
            // cmbDataBase
            // 
            this.cmbDataBase.Location = new System.Drawing.Point(189, 92);
            this.cmbDataBase.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbDataBase.Name = "cmbDataBase";
            this.cmbDataBase.Size = new System.Drawing.Size(231, 21);
            this.cmbDataBase.TabIndex = 1;
            this.cmbDataBase.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cmbDataBase_BeforeDropDown);
            // 
            // lblServer
            // 
            this.lblServer.Location = new System.Drawing.Point(27, 24);
            this.lblServer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(75, 19);
            this.lblServer.TabIndex = 2;
            this.lblServer.Text = "Server:";
            // 
            // lblUsername
            // 
            this.lblUsername.Location = new System.Drawing.Point(27, 48);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(75, 19);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "User Name:";
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(27, 72);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(75, 19);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password:";
            // 
            // lblDatabase
            // 
            this.lblDatabase.Location = new System.Drawing.Point(27, 95);
            this.lblDatabase.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(75, 19);
            this.lblDatabase.TabIndex = 5;
            this.lblDatabase.Text = "Database:";
            // 
            // txtUsername
            // 
            this.txtUsername.Enabled = false;
            this.txtUsername.Location = new System.Drawing.Point(189, 45);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(231, 21);
            this.txtUsername.TabIndex = 6;
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(189, 67);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(231, 21);
            this.txtPassword.TabIndex = 7;
            // 
            // chkWinAuth
            // 
            this.chkWinAuth.BackColor = System.Drawing.Color.Transparent;
            this.chkWinAuth.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkWinAuth.Checked = true;
            this.chkWinAuth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWinAuth.Location = new System.Drawing.Point(189, 130);
            this.chkWinAuth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkWinAuth.Name = "chkWinAuth";
            this.chkWinAuth.Size = new System.Drawing.Size(22, 16);
            this.chkWinAuth.TabIndex = 8;
            this.chkWinAuth.CheckStateChanged += new System.EventHandler(this.chkWinAuth_CheckStateChanged);
            // 
            // lblWindowsAuth
            // 
            this.lblWindowsAuth.Location = new System.Drawing.Point(27, 130);
            this.lblWindowsAuth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lblWindowsAuth.Name = "lblWindowsAuth";
            this.lblWindowsAuth.Size = new System.Drawing.Size(158, 19);
            this.lblWindowsAuth.TabIndex = 9;
            this.lblWindowsAuth.Text = "Windows Authentication:";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(339, 149);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(81, 25);
            this.btnLogin.TabIndex = 10;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblDevelopedby
            // 
            appearance1.ForeColor = System.Drawing.Color.Silver;
            this.lblDevelopedby.Appearance = appearance1;
            this.lblDevelopedby.Enabled = false;
            this.lblDevelopedby.Location = new System.Drawing.Point(1, 164);
            this.lblDevelopedby.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lblDevelopedby.Name = "lblDevelopedby";
            this.lblDevelopedby.Size = new System.Drawing.Size(245, 19);
            this.lblDevelopedby.TabIndex = 11;
            this.lblDevelopedby.Text = "Developed By : Stephen Brett  © 2015";
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(437, 184);
            this.Controls.Add(this.lblDevelopedby);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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

        public Infragistics.Win.Misc.UltraButton btnLogin;
        public Infragistics.Win.UltraWinEditors.UltraComboEditor cmbServer;
        public Infragistics.Win.UltraWinEditors.UltraComboEditor cmbDataBase;
        public Infragistics.Win.Misc.UltraLabel lblServer;
        public Infragistics.Win.Misc.UltraLabel lblUsername;
        public Infragistics.Win.Misc.UltraLabel lblPassword;
        public Infragistics.Win.Misc.UltraLabel lblDatabase;
        public Infragistics.Win.UltraWinEditors.UltraTextEditor txtUsername;
        public Infragistics.Win.UltraWinEditors.UltraTextEditor txtPassword;
        public Infragistics.Win.UltraWinEditors.UltraCheckEditor chkWinAuth;
        public Infragistics.Win.Misc.UltraLabel lblWindowsAuth;
        public Infragistics.Win.Misc.UltraLabel lblDevelopedby;
    }
}