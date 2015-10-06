namespace Re_useable_Classes.Forms
{
    sealed partial class FrmLoginMySql
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
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.cmbServer = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmbDataBase = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblServer = new Infragistics.Win.Misc.UltraLabel();
            this.lblUsername = new Infragistics.Win.Misc.UltraLabel();
            this.lblPassword = new Infragistics.Win.Misc.UltraLabel();
            this.lblDatabase = new Infragistics.Win.Misc.UltraLabel();
            this.txtUsername = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtPassword = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblPort = new Infragistics.Win.Misc.UltraLabel();
            this.btnLogin = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.txtPort = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            ((System.ComponentModel.ISupportInitialize)(this.cmbServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDataBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbServer
            // 
            valueListItem1.DataValue = "pcathomegroup.com";
            this.cmbServer.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1});
            this.cmbServer.Location = new System.Drawing.Point(189, 21);
            this.cmbServer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(231, 21);
            this.cmbServer.TabIndex = 0;
            this.cmbServer.Text = "pcathomegroup.com";
            this.cmbServer.BeforeDropDown += new System.ComponentModel.CancelEventHandler(this.cmbServer_BeforeDropDown);
            // 
            // cmbDataBase
            // 
            this.cmbDataBase.Location = new System.Drawing.Point(189, 92);
            this.cmbDataBase.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbDataBase.Name = "cmbDataBase";
            this.cmbDataBase.Size = new System.Drawing.Size(231, 21);
            this.cmbDataBase.TabIndex = 3;
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
            this.txtUsername.Location = new System.Drawing.Point(189, 45);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(231, 21);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Text = "sjbrett_Glen";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(189, 67);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(231, 21);
            this.txtPassword.TabIndex = 2;
            // 
            // lblPort
            // 
            this.lblPort.Location = new System.Drawing.Point(27, 130);
            this.lblPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(158, 19);
            this.lblPort.TabIndex = 9;
            this.lblPort.Text = "Port:";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(339, 149);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(81, 25);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // ultraLabel1
            // 
            appearance1.ForeColor = System.Drawing.Color.Silver;
            this.ultraLabel1.Appearance = appearance1;
            this.ultraLabel1.Enabled = false;
            this.ultraLabel1.Location = new System.Drawing.Point(1, 164);
            this.ultraLabel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(245, 19);
            this.ultraLabel1.TabIndex = 11;
            this.ultraLabel1.Text = "Developed By : Stephen Brett  © 2015";
            // 
            // txtPort
            // 
            appearance2.TextHAlignAsString = "Right";
            this.txtPort.Appearance = appearance2;
            this.txtPort.Location = new System.Drawing.Point(189, 124);
            this.txtPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(82, 21);
            this.txtPort.TabIndex = 4;
            this.txtPort.Text = "3306";
            // 
            // FrmLoginMySql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(437, 184);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.cmbDataBase);
            this.Controls.Add(this.cmbServer);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmLoginMySql";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frmlogin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLogin_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.cmbServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDataBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbServer;
        private Infragistics.Win.Misc.UltraLabel lblServer;
        private Infragistics.Win.Misc.UltraLabel lblUsername;
        private Infragistics.Win.Misc.UltraLabel lblPassword;
        private Infragistics.Win.Misc.UltraLabel lblDatabase;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtUsername;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPassword;
        private Infragistics.Win.Misc.UltraLabel lblPort;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        public Infragistics.Win.Misc.UltraButton btnLogin;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPort;
        public Infragistics.Win.UltraWinEditors.UltraComboEditor cmbDataBase;
    }
}