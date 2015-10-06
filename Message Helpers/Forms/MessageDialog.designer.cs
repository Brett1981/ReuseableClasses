namespace Re_useable_Classes.Message_Helpers.Forms
{
    partial class MessageDialog
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.pbMIcon = new Infragistics.Win.UltraWinEditors.UltraPictureBox();
            this.lblMessage = new Infragistics.Win.Misc.UltraLabel();
            this.pnlButtons = new Infragistics.Win.Misc.UltraPanel();
            this.btnTwo = new System.Windows.Forms.Button();
            this.btnOne = new System.Windows.Forms.Button();
            this.ultraExpandableGroupBoxPanel1 = new Infragistics.Win.Misc.UltraExpandableGroupBoxPanel();
            this.tbMoreDetails = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.egbDetails = new Infragistics.Win.Misc.UltraExpandableGroupBox();
            this.pnlContent = new Infragistics.Win.Misc.UltraPanel();
            this.pnlButtons.ClientArea.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.ultraExpandableGroupBoxPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMoreDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.egbDetails)).BeginInit();
            this.egbDetails.SuspendLayout();
            this.pnlContent.ClientArea.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbMIcon
            // 
            appearance1.BorderColor = System.Drawing.Color.Transparent;
            this.pbMIcon.Appearance = appearance1;
            this.pbMIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbMIcon.BorderShadowColor = System.Drawing.Color.Empty;
            this.pbMIcon.Location = new System.Drawing.Point(12, 12);
            this.pbMIcon.Name = "pbMIcon";
            this.pbMIcon.Size = new System.Drawing.Size(48, 48);
            this.pbMIcon.TabIndex = 0;
            // 
            // lblMessage
            // 
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.lblMessage.Appearance = appearance2;
            this.lblMessage.Location = new System.Drawing.Point(66, 12);
            this.lblMessage.MaximumSize = new System.Drawing.Size(506, 240);
            this.lblMessage.MinimumSize = new System.Drawing.Size(100, 48);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(506, 48);
            this.lblMessage.TabIndex = 1;
            // 
            // pnlButtons
            // 
            appearance3.BackColor = System.Drawing.SystemColors.Control;
            this.pnlButtons.Appearance = appearance3;
            // 
            // pnlButtons.ClientArea
            // 
            this.pnlButtons.ClientArea.Controls.Add(this.btnTwo);
            this.pnlButtons.ClientArea.Controls.Add(this.btnOne);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 513);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(582, 40);
            this.pnlButtons.TabIndex = 3;
            // 
            // btnTwo
            // 
            this.btnTwo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTwo.Location = new System.Drawing.Point(416, 8);
            this.btnTwo.Name = "btnTwo";
            this.btnTwo.Size = new System.Drawing.Size(75, 23);
            this.btnTwo.TabIndex = 1;
            this.btnTwo.Text = "Button 2";
            this.btnTwo.UseVisualStyleBackColor = true;
            this.btnTwo.Click += new System.EventHandler(this.btnTwo_Click);
            // 
            // btnOne
            // 
            this.btnOne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOne.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOne.Location = new System.Drawing.Point(497, 8);
            this.btnOne.Name = "btnOne";
            this.btnOne.Size = new System.Drawing.Size(75, 23);
            this.btnOne.TabIndex = 0;
            this.btnOne.Text = "Button 1";
            this.btnOne.UseVisualStyleBackColor = true;
            this.btnOne.Click += new System.EventHandler(this.btnOne_Click);
            // 
            // ultraExpandableGroupBoxPanel1
            // 
            this.ultraExpandableGroupBoxPanel1.Controls.Add(this.tbMoreDetails);
            this.ultraExpandableGroupBoxPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraExpandableGroupBoxPanel1.Location = new System.Drawing.Point(0, 23);
            this.ultraExpandableGroupBoxPanel1.Name = "ultraExpandableGroupBoxPanel1";
            this.ultraExpandableGroupBoxPanel1.Size = new System.Drawing.Size(562, 418);
            this.ultraExpandableGroupBoxPanel1.TabIndex = 0;
            // 
            // tbMoreDetails
            // 
            this.tbMoreDetails.AlwaysInEditMode = true;
            this.tbMoreDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.BackColorDisabled = System.Drawing.Color.Transparent;
            this.tbMoreDetails.Appearance = appearance4;
            this.tbMoreDetails.BackColor = System.Drawing.Color.Transparent;
            this.tbMoreDetails.Location = new System.Drawing.Point(30, 3);
            this.tbMoreDetails.Multiline = true;
            this.tbMoreDetails.Name = "tbMoreDetails";
            this.tbMoreDetails.ReadOnly = true;
            this.tbMoreDetails.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.tbMoreDetails.Size = new System.Drawing.Size(529, 412);
            this.tbMoreDetails.TabIndex = 0;
            this.tbMoreDetails.UseAppStyling = false;
            this.tbMoreDetails.WordWrap = false;
            // 
            // egbDetails
            // 
            this.egbDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.egbDetails.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            this.egbDetails.Controls.Add(this.ultraExpandableGroupBoxPanel1);
            this.egbDetails.ExpandedSize = new System.Drawing.Size(562, 441);
            appearance5.FontData.BoldAsString = "True";
            this.egbDetails.HeaderAppearance = appearance5;
            this.egbDetails.Location = new System.Drawing.Point(12, 66);
            this.egbDetails.MaximumSize = new System.Drawing.Size(564, 449);
            this.egbDetails.Name = "egbDetails";
            this.egbDetails.Size = new System.Drawing.Size(562, 441);
            this.egbDetails.TabIndex = 4;
            this.egbDetails.Text = "More Details";
            this.egbDetails.UseAppStyling = false;
            this.egbDetails.ExpandedStateChanged += new System.EventHandler(this.egbDetails_ExpandedStateChanged);
            // 
            // pnlContent
            // 
            // 
            // pnlContent.ClientArea
            // 
            this.pnlContent.ClientArea.Controls.Add(this.egbDetails);
            this.pnlContent.ClientArea.Controls.Add(this.pnlButtons);
            this.pnlContent.ClientArea.Controls.Add(this.lblMessage);
            this.pnlContent.ClientArea.Controls.Add(this.pbMIcon);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(582, 553);
            this.pnlContent.TabIndex = 5;
            // 
            // MessageDialog
            // 
            this.AcceptButton = this.btnTwo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnOne;
            this.ClientSize = new System.Drawing.Size(582, 553);
            this.Controls.Add(this.pnlContent);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(194, 152);
            this.Name = "MessageDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Message Dialog Box";
            this.Load += new System.EventHandler(this.MessageDialog_Load);
            this.pnlButtons.ClientArea.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel1.ResumeLayout(false);
            this.ultraExpandableGroupBoxPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMoreDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.egbDetails)).EndInit();
            this.egbDetails.ResumeLayout(false);
            this.pnlContent.ClientArea.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraPictureBox pbMIcon;
        private Infragistics.Win.Misc.UltraLabel lblMessage;
        private Infragistics.Win.Misc.UltraPanel pnlButtons;
        private System.Windows.Forms.Button btnTwo;
        private System.Windows.Forms.Button btnOne;
        private Infragistics.Win.Misc.UltraExpandableGroupBoxPanel ultraExpandableGroupBoxPanel1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor tbMoreDetails;
        private Infragistics.Win.Misc.UltraExpandableGroupBox egbDetails;
        private Infragistics.Win.Misc.UltraPanel pnlContent;
    }
}