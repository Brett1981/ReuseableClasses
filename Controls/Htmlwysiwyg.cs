using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;
using mshtml;
using Re_useable_Classes.Message_Helpers.Forms;

namespace Re_useable_Classes.Controls
{
    public class Htmlwysiwyg : UserControl
    {
        /// <summary>
        ///     Required designer variable.
        /// </summary>
        private readonly IContainer components = null;

        public WebBrowser HtmlRenderer;

        private ToolStripButton _newTs;
        private ToolStripButton _printToolStripButton;
        private ToolStripMenuItem _toolStripMenuItem2;
        private ToolStripMenuItem _toolStripMenuItem3;
        private ToolStripMenuItem _toolStripMenuItem4;
        private ToolStripMenuItem _toolStripMenuItem5;
        private ToolStripMenuItem _toolStripMenuItem6;
        private ToolStripMenuItem _toolStripMenuItem7;
        private ToolStripMenuItem _toolStripMenuItem8;
        private ToolStripSeparator _toolStripSeparator1;
        private ToolStripSeparator _toolStripSeparator2;
        private ToolStripSeparator _toolStripSeparator3;
        private ToolStripSeparator _toolStripSeparator4;
        private ToolStripSeparator _toolStripSeparator5;
        private ToolStripSeparator _toolStripSeparator6;
        private ToolStripSeparator _toolStripSeparator7;
        private ToolStrip _ts;
        private ToolStripButton _tsBackColor;
        private ToolStripButton _tsBold;
        private ToolStripButton _tsBullets;
        private ToolStripButton _tsCenter;
        private ToolStripContainer _tsContainer;
        private ToolStripButton _tsCopy;
        private ToolStripButton _tsCut;
        private ToolStripSplitButton _tsFontFamily;
        private ToolStripSplitButton _tsFontSize;
        private ToolStripButton _tsIndent;
        private ToolStripButton _tsItalics;
        private ToolStripButton _tsJustify;
        private ToolStripButton _tsLeft;
        private ToolStripButton _tsLink;
        private ToolStripButton _tsNumeric;
        private ToolStripButton _tsOutdent;
        private ToolStripButton _tsPaste;
        private ToolStripButton _tsRemoveLink;
        private ToolStripButton _tsRight;
        private ToolStripSeparator _tsSeparator1;
        private ToolStripButton _tsTextColor;
        private ToolStripButton _tsUnderline;

        public Htmlwysiwyg()
        {
            InitializeComponent();
            _changed = false;
            try
            {
                if (HtmlRenderer.Document != null)
                {
                    _doc = (IHTMLDocument2) HtmlRenderer.Document.DomDocument;
                }
            }
            catch (Exception ex)
            {
                MessageDialog.Show
                    (
                        "htmlRenderer Exception  \r\n" + ex.InnerException,
                        "Error",
                        MessageDialog.MessageBoxButtons.Ok,
                        MessageDialog.MessageBoxIcon.Error,
                        "" + "\r\n" + ex.StackTrace);
            }
            if (_doc != null)
            {
                _doc.designMode = "On";
                while (_doc.body == null)
                {
                    Application.DoEvents();
                }
            }

            _custCtxMenu = new ContextMenuStrip();
            _custCtxMenu.Items.Add("&Copy");
            _custCtxMenu.Items.Add("&Cut");
            _custCtxMenu.Items.Add("&Paste");
            _custCtxMenu.ItemClicked += custCtxMenu_ItemClicked;
            try
            {
                if (HtmlRenderer.Document == null)
                {
                    return;
                }
                if (HtmlRenderer.Document.Body != null)
                {
                    HtmlRenderer.Document.Body.KeyDown += Body_KeyDown;
                }
                HtmlRenderer.Document.ContextMenuShowing += Document_ContextMenuShowing;
            }
            catch (Exception ex)
            {
                MessageDialog.Show
                    (
                        "htmlRenderer Exception  \r\n" + ex.InnerException,
                        "Error",
                        MessageDialog.MessageBoxButtons.Ok,
                        MessageDialog.MessageBoxIcon.Error,
                        "" + "\r\n" + ex.StackTrace);
            }
        }

        /// <summary>
        ///     Clean up any resources being used.
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

        private string ToBase64String
            (
            Image bmp,
            ImageFormat imageFormat)
        {
            var memoryStream = new MemoryStream();
            bmp.Save
                (
                    memoryStream,
                    imageFormat);

            memoryStream.Position = 0;
            byte[] byteBuffer = memoryStream.ToArray();

            memoryStream.Close();

            string base64String = Convert.ToBase64String(byteBuffer);
            memoryStream.Dispose();


            return base64String;
        }

        private void htmlwysiwyg_Load
            (
            object sender,
            EventArgs e)
        {
            //doc = (mshtml.IHTMLDocument2)this.htmlRenderer.Document.DomDocument;
            //doc.designMode = "On";
            var aFontList = new List<string>
                            {
                                "Arial",
                                "Arial Black",
                                "BC 39",
                                "BC 39 Short SelectHR",
                                "Calibri",
                                "Comic Sans MS",
                                "Courier New",
                                "Georgia",
                                "Impact",
                                "Lucida Console",
                                "Lucida Sans Unicode",
                                "Microsoft Sans Serif",
                                "MS Mincho",
                                "Palatino Linotype",
                                "Symbol",
                                "Tahoma",
                                "Times New Roman",
                                "Trebuchet MS",
                                "Verdana"
                            };
            {
                foreach (string family in aFontList)
                {
                    try
                    {
                        AddFont(family);
                    }
                    catch (Exception ex)
                    {
                        MessageDialog.Show
                            (
                                "Unable to Add Font  \r\n" + ex.InnerException,
                                "Error",
                                MessageDialog.MessageBoxButtons.Ok,
                                MessageDialog.MessageBoxIcon.Error,
                                "" + "\r\n" + ex.StackTrace);
                    }
                }
            }
        }

        #region Component Designer generated code

        /// <summary>
        ///     Required method for Designer support - do not modify
        ///     the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._tsContainer = new System.Windows.Forms.ToolStripContainer();
            this.HtmlRenderer = new System.Windows.Forms.WebBrowser();
            this._ts = new System.Windows.Forms.ToolStrip();
            this._newTs = new System.Windows.Forms.ToolStripButton();
            this._printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._tsSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._tsCut = new System.Windows.Forms.ToolStripButton();
            this._tsCopy = new System.Windows.Forms.ToolStripButton();
            this._tsPaste = new System.Windows.Forms.ToolStripButton();
            this._toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this._toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this._toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this._toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this._toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this._tsFontSize = new System.Windows.Forms.ToolStripSplitButton();
            this._toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this._tsFontFamily = new System.Windows.Forms.ToolStripSplitButton();
            this._tsBold = new System.Windows.Forms.ToolStripButton();
            this._tsUnderline = new System.Windows.Forms.ToolStripButton();
            this._tsItalics = new System.Windows.Forms.ToolStripButton();
            this._tsLeft = new System.Windows.Forms.ToolStripButton();
            this._tsCenter = new System.Windows.Forms.ToolStripButton();
            this._tsJustify = new System.Windows.Forms.ToolStripButton();
            this._tsRight = new System.Windows.Forms.ToolStripButton();
            this._tsIndent = new System.Windows.Forms.ToolStripButton();
            this._tsOutdent = new System.Windows.Forms.ToolStripButton();
            this._tsBullets = new System.Windows.Forms.ToolStripButton();
            this._tsNumeric = new System.Windows.Forms.ToolStripButton();
            this._tsBackColor = new System.Windows.Forms.ToolStripButton();
            this._tsTextColor = new System.Windows.Forms.ToolStripButton();
            this._tsLink = new System.Windows.Forms.ToolStripButton();
            this._tsRemoveLink = new System.Windows.Forms.ToolStripButton();
            this._tsContainer.ContentPanel.SuspendLayout();
            this._tsContainer.TopToolStripPanel.SuspendLayout();
            this._tsContainer.SuspendLayout();
            this._ts.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tsContainer
            // 
            // 
            // _tsContainer.ContentPanel
            // 
            this._tsContainer.ContentPanel.Controls.Add(this.HtmlRenderer);
            this._tsContainer.ContentPanel.Margin = new System.Windows.Forms.Padding(4);
            this._tsContainer.ContentPanel.Size = new System.Drawing.Size
                (
                1051,
                483);
            this._tsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tsContainer.Location = new System.Drawing.Point
                (
                0,
                0);
            this._tsContainer.Margin = new System.Windows.Forms.Padding
                (
                4,
                4,
                4,
                4);
            this._tsContainer.Name = "_tsContainer";
            this._tsContainer.Size = new System.Drawing.Size
                (
                1051,
                510);
            this._tsContainer.TabIndex = 0;
            this._tsContainer.Text = "toolStripContainer1";
            // 
            // _tsContainer.TopToolStripPanel
            // 
            this._tsContainer.TopToolStripPanel.Controls.Add(this._ts);
            // 
            // HtmlRenderer
            // 
            this.HtmlRenderer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HtmlRenderer.Location = new System.Drawing.Point
                (
                0,
                0);
            this.HtmlRenderer.Margin = new System.Windows.Forms.Padding
                (
                4,
                4,
                4,
                4);
            this.HtmlRenderer.MinimumSize = new System.Drawing.Size
                (
                27,
                25);
            this.HtmlRenderer.Name = "HtmlRenderer";
            this.HtmlRenderer.Size = new System.Drawing.Size
                (
                1051,
                483);
            this.HtmlRenderer.TabIndex = 0;
            this.HtmlRenderer.Url = new System.Uri
                (
                "About:blank",
                System.UriKind.Absolute);
            // 
            // _ts
            // 
            this._ts.Dock = System.Windows.Forms.DockStyle.None;
            this._ts.Items.AddRange
                (
                    new System.Windows.Forms.ToolStripItem[]
                    {
                        this._newTs,
                        this._printToolStripButton,
                        this._tsSeparator1,
                        this._tsCut,
                        this._tsCopy,
                        this._tsPaste,
                        this._toolStripSeparator1,
                        this._tsBold,
                        this._tsUnderline,
                        this._tsItalics,
                        this._toolStripSeparator2,
                        this._tsLeft,
                        this._tsCenter,
                        this._tsJustify,
                        this._tsRight,
                        this._toolStripSeparator3,
                        this._tsIndent,
                        this._tsOutdent,
                        this._toolStripSeparator4,
                        this._tsBullets,
                        this._tsNumeric,
                        this._toolStripSeparator5,
                        this._tsBackColor,
                        this._tsTextColor,
                        this._toolStripSeparator6,
                        this._tsLink,
                        this._tsRemoveLink,
                        this._toolStripSeparator7,
                        this._tsFontSize,
                        this._tsFontFamily
                    });
            this._ts.Location = new System.Drawing.Point
                (
                3,
                0);
            this._ts.Name = "_ts";
            this._ts.Size = new System.Drawing.Size
                (
                706,
                27);
            this._ts.TabIndex = 0;
            // 
            // _newTs
            // 
            this._newTs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._newTs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._newTs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._newTs.Name = "_newTs";
            this._newTs.Size = new System.Drawing.Size
                (
                23,
                24);
            this._newTs.Text = "&New";
            this._newTs.Click += new System.EventHandler(this.newTS_Click);
            // 
            // _printToolStripButton
            // 
            this._printToolStripButton.BackgroundImage = global::Re_useable_Classes.Properties.Resources.print;
            this._printToolStripButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._printToolStripButton.Name = "_printToolStripButton";
            this._printToolStripButton.Size = new System.Drawing.Size
                (
                23,
                24);
            this._printToolStripButton.Text = "&Print";
            this._printToolStripButton.Click += new System.EventHandler(this.printToolStripButton_Click);
            // 
            // _tsSeparator1
            // 
            this._tsSeparator1.Name = "_tsSeparator1";
            this._tsSeparator1.Size = new System.Drawing.Size
                (
                6,
                27);
            // 
            // _tsCut
            // 
            this._tsCut.BackgroundImage = global::Re_useable_Classes.Properties.Resources.cut;
            this._tsCut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._tsCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsCut.Name = "_tsCut";
            this._tsCut.Size = new System.Drawing.Size
                (
                23,
                24);
            this._tsCut.Text = "C&ut";
            this._tsCut.Click += new System.EventHandler(this.cutToolStripButton_Click);
            // 
            // _tsCopy
            // 
            this._tsCopy.BackgroundImage = global::Re_useable_Classes.Properties.Resources.copy;
            this._tsCopy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._tsCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsCopy.Name = "_tsCopy";
            this._tsCopy.Size = new System.Drawing.Size
                (
                23,
                24);
            this._tsCopy.Text = "&Copy";
            this._tsCopy.Click += new System.EventHandler(this.copyToolStripButton_Click);
            // 
            // _tsPaste
            // 
            this._tsPaste.BackgroundImage = global::Re_useable_Classes.Properties.Resources.paste;
            this._tsPaste.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._tsPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsPaste.Name = "_tsPaste";
            this._tsPaste.Size = new System.Drawing.Size
                (
                23,
                24);
            this._tsPaste.Text = "&Paste";
            this._tsPaste.Click += new System.EventHandler(this.pasteToolStripButton_Click);
            // 
            // _toolStripSeparator1
            // 
            this._toolStripSeparator1.Name = "_toolStripSeparator1";
            this._toolStripSeparator1.Size = new System.Drawing.Size
                (
                6,
                27);
            // 
            // _toolStripSeparator2
            // 
            this._toolStripSeparator2.Name = "_toolStripSeparator2";
            this._toolStripSeparator2.Size = new System.Drawing.Size
                (
                6,
                27);
            // 
            // _toolStripSeparator3
            // 
            this._toolStripSeparator3.Name = "_toolStripSeparator3";
            this._toolStripSeparator3.Size = new System.Drawing.Size
                (
                6,
                27);
            // 
            // _toolStripSeparator4
            // 
            this._toolStripSeparator4.Name = "_toolStripSeparator4";
            this._toolStripSeparator4.Size = new System.Drawing.Size
                (
                6,
                27);
            // 
            // _toolStripSeparator5
            // 
            this._toolStripSeparator5.Name = "_toolStripSeparator5";
            this._toolStripSeparator5.Size = new System.Drawing.Size
                (
                6,
                27);
            // 
            // _toolStripSeparator6
            // 
            this._toolStripSeparator6.Name = "_toolStripSeparator6";
            this._toolStripSeparator6.Size = new System.Drawing.Size
                (
                6,
                27);
            // 
            // _toolStripSeparator7
            // 
            this._toolStripSeparator7.Name = "_toolStripSeparator7";
            this._toolStripSeparator7.Size = new System.Drawing.Size
                (
                6,
                27);
            // 
            // _tsFontSize
            // 
            this._tsFontSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._tsFontSize.DropDownItems.AddRange
                (
                    new System.Windows.Forms.ToolStripItem[]
                    {
                        this._toolStripMenuItem2,
                        this._toolStripMenuItem3,
                        this._toolStripMenuItem4,
                        this._toolStripMenuItem5,
                        this._toolStripMenuItem6,
                        this._toolStripMenuItem7,
                        this._toolStripMenuItem8
                    });
            this._tsFontSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsFontSize.Name = "_tsFontSize";
            this._tsFontSize.Size = new System.Drawing.Size
                (
                85,
                24);
            this._tsFontSize.Text = "Font Size";
            this._tsFontSize.ButtonClick += new System.EventHandler(this.tsFontSize_ButtonClick);
            // 
            // _toolStripMenuItem2
            // 
            this._toolStripMenuItem2.Name = "_toolStripMenuItem2";
            this._toolStripMenuItem2.Size = new System.Drawing.Size
                (
                86,
                24);
            this._toolStripMenuItem2.Text = "1";
            this._toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // _toolStripMenuItem3
            // 
            this._toolStripMenuItem3.Name = "_toolStripMenuItem3";
            this._toolStripMenuItem3.Size = new System.Drawing.Size
                (
                86,
                24);
            this._toolStripMenuItem3.Text = "2";
            this._toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // _toolStripMenuItem4
            // 
            this._toolStripMenuItem4.Name = "_toolStripMenuItem4";
            this._toolStripMenuItem4.Size = new System.Drawing.Size
                (
                86,
                24);
            this._toolStripMenuItem4.Text = "3";
            this._toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // _toolStripMenuItem5
            // 
            this._toolStripMenuItem5.Name = "_toolStripMenuItem5";
            this._toolStripMenuItem5.Size = new System.Drawing.Size
                (
                86,
                24);
            this._toolStripMenuItem5.Text = "4";
            this._toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // _toolStripMenuItem6
            // 
            this._toolStripMenuItem6.Name = "_toolStripMenuItem6";
            this._toolStripMenuItem6.Size = new System.Drawing.Size
                (
                86,
                24);
            this._toolStripMenuItem6.Text = "5";
            this._toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // _toolStripMenuItem7
            // 
            this._toolStripMenuItem7.Name = "_toolStripMenuItem7";
            this._toolStripMenuItem7.Size = new System.Drawing.Size
                (
                86,
                24);
            this._toolStripMenuItem7.Text = "6";
            this._toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // _toolStripMenuItem8
            // 
            this._toolStripMenuItem8.Name = "_toolStripMenuItem8";
            this._toolStripMenuItem8.Size = new System.Drawing.Size
                (
                86,
                24);
            this._toolStripMenuItem8.Text = "7";
            this._toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // _tsFontFamily
            // 
            this._tsFontFamily.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._tsFontFamily.Font = new System.Drawing.Font
                (
                "Segoe UI",
                9F);
            this._tsFontFamily.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._tsFontFamily.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsFontFamily.Name = "_tsFontFamily";
            this._tsFontFamily.Size = new System.Drawing.Size
                (
                101,
                24);
            this._tsFontFamily.Text = "Font Family";
            // 
            // _tsBold
            // 
            this._tsBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsBold.Image = global::Re_useable_Classes.Properties.Resources.bold;
            this._tsBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsBold.Name = "_tsBold";
            this._tsBold.Size = new System.Drawing.Size
                (
                23,
                24);
            this._tsBold.Text = "&Bold";
            this._tsBold.Click += new System.EventHandler(this.tsBold_Click);
            // 
            // _tsUnderline
            // 
            this._tsUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsUnderline.Image = global::Re_useable_Classes.Properties.Resources.underline;
            this._tsUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsUnderline.Name = "_tsUnderline";
            this._tsUnderline.Size = new System.Drawing.Size
                (
                23,
                24);
            this._tsUnderline.Text = "&Underline";
            this._tsUnderline.Click += new System.EventHandler(this.tsUnderline_Click);
            // 
            // _tsItalics
            // 
            this._tsItalics.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsItalics.Image = global::Re_useable_Classes.Properties.Resources.italic;
            this._tsItalics.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsItalics.Name = "_tsItalics";
            this._tsItalics.Size = new System.Drawing.Size
                (
                23,
                24);
            this._tsItalics.Text = "&Italic";
            this._tsItalics.Click += new System.EventHandler(this.tsItalics_Click);
            // 
            // _tsLeft
            // 
            this._tsLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsLeft.Image = global::Re_useable_Classes.Properties.Resources.align_left;
            this._tsLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsLeft.Name = "_tsLeft";
            this._tsLeft.Size = new System.Drawing.Size
                (
                23,
                24);
            this._tsLeft.Text = "Align Left";
            this._tsLeft.Click += new System.EventHandler(this.tsLeft_Click);
            // 
            // _tsCenter
            // 
            this._tsCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsCenter.Image = global::Re_useable_Classes.Properties.Resources.align_center;
            this._tsCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsCenter.Name = "_tsCenter";
            this._tsCenter.Size = new System.Drawing.Size
                (
                23,
                24);
            this._tsCenter.Text = "Align Centre";
            this._tsCenter.Click += new System.EventHandler(this.tsCenter_Click);
            // 
            // _tsJustify
            // 
            this._tsJustify.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsJustify.Image = global::Re_useable_Classes.Properties.Resources.align_justify;
            this._tsJustify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsJustify.Name = "_tsJustify";
            this._tsJustify.Size = new System.Drawing.Size
                (
                23,
                24);
            this._tsJustify.Text = "Distribute";
            this._tsJustify.Click += new System.EventHandler(this.tsJustify_Click);
            // 
            // _tsRight
            // 
            this._tsRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsRight.Image = global::Re_useable_Classes.Properties.Resources.align_right;
            this._tsRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsRight.Name = "_tsRight";
            this._tsRight.Size = new System.Drawing.Size
                (
                23,
                24);
            this._tsRight.Text = "Align Right";
            this._tsRight.Click += new System.EventHandler(this.tsRight_Click);
            // 
            // _tsIndent
            // 
            this._tsIndent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsIndent.Image = global::Re_useable_Classes.Properties.Resources.increase_indent;
            this._tsIndent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsIndent.Name = "_tsIndent";
            this._tsIndent.Size = new System.Drawing.Size
                (
                23,
                24);
            this._tsIndent.Text = "Increase Indent";
            this._tsIndent.Click += new System.EventHandler(this.tsIndent_Click);
            // 
            // _tsOutdent
            // 
            this._tsOutdent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsOutdent.Image = global::Re_useable_Classes.Properties.Resources.decrease_indent;
            this._tsOutdent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsOutdent.Name = "_tsOutdent";
            this._tsOutdent.Size = new System.Drawing.Size
                (
                23,
                24);
            this._tsOutdent.Text = "Decrease Indent";
            this._tsOutdent.Click += new System.EventHandler(this.tsOutdent_Click);
            // 
            // _tsBullets
            // 
            this._tsBullets.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsBullets.Image = global::Re_useable_Classes.Properties.Resources.bulleted_list;
            this._tsBullets.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsBullets.Name = "_tsBullets";
            this._tsBullets.Size = new System.Drawing.Size
                (
                23,
                24);
            this._tsBullets.Text = "Bullet Point";
            this._tsBullets.Click += new System.EventHandler(this.tsBullets_Click);
            // 
            // _tsNumeric
            // 
            this._tsNumeric.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsNumeric.Image = global::Re_useable_Classes.Properties.Resources.numbered_list;
            this._tsNumeric.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsNumeric.Name = "_tsNumeric";
            this._tsNumeric.Size = new System.Drawing.Size
                (
                23,
                24);
            this._tsNumeric.Text = "Number Points";
            this._tsNumeric.Click += new System.EventHandler(this.tsNumeric_Click);
            // 
            // _tsBackColor
            // 
            this._tsBackColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsBackColor.Image = global::Re_useable_Classes.Properties.Resources.select_background_color;
            this._tsBackColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsBackColor.Name = "_tsBackColor";
            this._tsBackColor.Size = new System.Drawing.Size
                (
                23,
                24);
            this._tsBackColor.Text = "Highlight ";
            this._tsBackColor.Click += new System.EventHandler(this.tsBackColor_Click);
            // 
            // _tsTextColor
            // 
            this._tsTextColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsTextColor.Image = global::Re_useable_Classes.Properties.Resources.select_color_text;
            this._tsTextColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsTextColor.Name = "_tsTextColor";
            this._tsTextColor.Size = new System.Drawing.Size
                (
                23,
                24);
            this._tsTextColor.Text = "Font Colour";
            this._tsTextColor.Click += new System.EventHandler(this.tsTextColor_Click);
            // 
            // _tsLink
            // 
            this._tsLink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsLink.Image = global::Re_useable_Classes.Properties.Resources.insert_link;
            this._tsLink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsLink.Name = "_tsLink";
            this._tsLink.Size = new System.Drawing.Size
                (
                23,
                24);
            this._tsLink.Text = "Add Hyperlink";
            this._tsLink.Click += new System.EventHandler(this.tsLink_Click);
            // 
            // _tsRemoveLink
            // 
            this._tsRemoveLink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsRemoveLink.Image = global::Re_useable_Classes.Properties.Resources.remove_link;
            this._tsRemoveLink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsRemoveLink.Name = "_tsRemoveLink";
            this._tsRemoveLink.Size = new System.Drawing.Size
                (
                23,
                24);
            this._tsRemoveLink.Text = "Remove Hyperlink";
            this._tsRemoveLink.Click += new System.EventHandler(this.tsRemoveLink_Click);
            // 
            // Htmlwysiwyg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF
                (
                8F,
                16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this._tsContainer);
            this.Margin = new System.Windows.Forms.Padding
                (
                4,
                4,
                4,
                4);
            this.Name = "Htmlwysiwyg";
            this.Size = new System.Drawing.Size
                (
                1051,
                510);
            this.Load += new System.EventHandler(this.htmlwysiwyg_Load);
            this._tsContainer.ContentPanel.ResumeLayout(false);
            this._tsContainer.TopToolStripPanel.ResumeLayout(false);
            this._tsContainer.TopToolStripPanel.PerformLayout();
            this._tsContainer.ResumeLayout(false);
            this._tsContainer.PerformLayout();
            this._ts.ResumeLayout(false);
            this._ts.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion Component Designer generated code

        #region declerations

        private readonly ContextMenuStrip _custCtxMenu;
        private readonly IHTMLDocument2 _doc;

        private bool _changed;
        private bool _edits = true;

        public bool Changed
        {
            //get { return _changed; }
            set
            {
                _changed = value;
                if (BodyChanged != null)
                {
                    BodyChanged
                        (
                            this,
                            new EventArgs());
                }
            }
        }

        public event EventHandler BodyChanged;

        #endregion declerations

        #region MainCallingEvents

        public String GetHtml()
        {
            _changed = false;
            return _doc.body.innerHTML;
        }

        public void SetHtml(String html)
        {
            _changed = false;
            _doc.body.innerHTML = html;
        }

        public String GetPlainText()
        {
            _changed = false;
            return _doc.body.innerText;
        }

        public void AllowEdit(bool edit)
        {
            _edits = edit;
            _doc.designMode = edit
                                  ? "On"
                                  : "Off";
        }

        /// <summary>
        ///     Allows you to add custome fonts to the control
        /// </summary>
        /// <param name="fontName"> Name of the font to add</param>
        private void AddFont(String fontName)
        {
            var tsMi = new ToolStripLabel
                       {
                           Font = new Font
                               (
                               fontName,
                               Font.Size),
                           Name = fontName + "ToolStripLabel",
                           AutoSize = true,
                           Text = fontName
                       };

            //Create a Thread
            var newThreadForEmail = new Thread
                (
                () =>
                {
                    //Create our Context and install it:
                    SynchronizationContext.SetSynchronizationContext
                        (
                            new DispatcherSynchronizationContext
                                (
                                Dispatcher.CurrentDispatcher));
                    var ahtmlwysiwyg = new Htmlwysiwyg();

                    //When the window closes shut down the dispatcher
                    ahtmlwysiwyg.ControlAdded += (s,
                                                  e) =>
                                                 Dispatcher.CurrentDispatcher.BeginInvokeShutdown
                                                     (
                                                         DispatcherPriority.Background);
                    tsMi.Click += addFont_click;
                    tsMi.MouseEnter += addBGFontColour_click;
                    tsMi.MouseLeave += addBGFontColourNom_click;

                    // Set the dispatcher processing
                    Dispatcher.Run();
                });
            //Setup and start thread
            //Setup the apartment state
            newThreadForEmail.SetApartmentState(ApartmentState.STA);
            //make the thread a background thread
            newThreadForEmail.IsBackground = true;
            //Start the thread
            newThreadForEmail.Start();
            _tsFontFamily.DropDownItems.Add(tsMi);
        }

        private void Body_KeyDown
            (
            object sender,
            HtmlElementEventArgs e)
        {
            // Notify class that change has been made
            if (!_changed)
            {
                Changed = true;
            }
        }

        private void Document_ContextMenuShowing
            (
            object sender,
            HtmlElementEventArgs e)
        {
            _custCtxMenu.Show(Cursor.Position);
            e.ReturnValue = false;
        }

        #endregion MainCallingEvents

        #region FieldProperties

        [Description("Show the back color button or not"),
         Category("Toolbar")]
        public bool ShowBackColorButton
        {
            //get { return tsBackColor.Visible; }
            set
            {
                _tsBackColor.Visible = value;
                UpdateToolbarSeperators();
            }
        }

        [Description("Show the new button or not"),
         Category("Toolbar")]
        public bool ShowNewButton
        {
            // get { return newTS.Visible; }
            set
            {
                _newTs.Visible = value;
                UpdateToolbarSeperators();
            }
        }

        [Description("Show the new button or not"),
         Category("Toolbar")]
        public bool ShowPrintButton
        {
            // get { return printToolStripButton.Visible; }
            set
            {
                _printToolStripButton.Visible = value;
                UpdateToolbarSeperators();
            }
        }

        [Description("Show the cut button or not"),
         Category("Toolbar")]
        public bool ShowCutButton
        {
            // get { return tsCut.Visible; }
            set
            {
                _tsCut.Visible = value;
                UpdateToolbarSeperators();
            }
        }

        [Description("Show the copy button or not"),
         Category("Toolbar")]
        public bool ShowCopyButton
        {
            // get { return tsCopy.Visible; }
            set
            {
                _tsCopy.Visible = value;
                UpdateToolbarSeperators();
            }
        }

        [Description("Show the paste button or not"),
         Category("Toolbar")]
        public bool ShowPasteButton
        {
            // get { return tsPaste.Visible; }
            set
            {
                _tsPaste.Visible = value;
                UpdateToolbarSeperators();
            }
        }

        [Description("Show the bold button or not"),
         Category("Toolbar")]
        public bool ShowBolButton
        {
            //get { return tsBold.Visible; }
            set
            {
                _tsBold.Visible = value;
                UpdateToolbarSeperators();
            }
        }

        [Description("Show the underline button or not"),
         Category("Toolbar")]
        public bool ShowUnderlineButton
        {
            //get { return tsUnderline.Visible; }
            set
            {
                _tsUnderline.Visible = value;
                UpdateToolbarSeperators();
            }
        }

        [Description("Show the italics button or not"),
         Category("Toolbar")]
        public bool ShowItalicButton
        {
            //get { return tsItalics.Visible; }
            set
            {
                _tsItalics.Visible = value;
                UpdateToolbarSeperators();
            }
        }

        [Description("Show the Align Left button or not"),
         Category("Toolbar")]
        public bool ShowAlignLeftButton
        {
            //get { return tsLeft.Visible; }
            set
            {
                _tsLeft.Visible = value;
                UpdateToolbarSeperators();
            }
        }

        [Description("Show the Align Center button or not"),
         Category("Toolbar")]
        public bool ShowAlignCenterButton
        {
            //get { return tsCenter.Visible; }
            set
            {
                _tsCenter.Visible = value;
                UpdateToolbarSeperators();
            }
        }

        [Description("Show the Link button"),
         Category("Toolbar")]
        public bool ShowLinkButton
        {
            //get { return tsLink.Visible; }
            set
            {
                _tsLink.Visible = value;
                UpdateToolbarSeperators();
            }
        }

        [Description("Show the Unlink button"),
         Category("Toolbar")]
        public bool ShowUnlinkButton
        {
            //get { return tsRemoveLink.Visible; }
            set
            {
                _tsRemoveLink.Visible = value;
                UpdateToolbarSeperators();
            }
        }

        [Description("Show the Text Background color button"),
         Category("Toolbar")]
        public bool ShowTxtBgButton
        {
            //get { return tsTextColor.Visible; }
            set
            {
                _tsTextColor.Visible = value;
                UpdateToolbarSeperators();
            }
        }

        [Description("Show the Font Size button"),
         Category("Toolbar")]
        public bool ShowFontSizeButton
        {
            //get { return tsFontSize.Visible; }
            set
            {
                _tsFontSize.Visible = value;
                UpdateToolbarSeperators();
            }
        }

        [Description("Show the Justify button or not"),
         Category("Toolbar")]
        public bool ShowJustifyButton
        {
            //get { return tsJustify.Visible; }
            set
            {
                _tsJustify.Visible = value;
                UpdateToolbarSeperators();
            }
        }

        [Description("Show the Align Right button or not"),
         Category("Toolbar")]
        public bool ShowAlignRightButton
        {
            //get { return tsRight.Visible; }
            set
            {
                _tsRight.Visible = value;
                UpdateToolbarSeperators();
            }
        }

        [Description("Show the Indent button or not"),
         Category("Toolbar")]
        public bool ShowIndentButton
        {
            //get { return tsIndent.Visible; }
            set
            {
                _tsIndent.Visible = value;
                UpdateToolbarSeperators();
            }
        }

        [Description("Show the Outdent button or not"),
         Category("Toolbar")]
        public bool ShowOutdentButton
        {
            //get { return tsOutdent.Visible; }
            set
            {
                _tsOutdent.Visible = value;
                UpdateToolbarSeperators();
            }
        }

        [Description("Show the Bullet button or not"),
         Category("Toolbar")]
        public bool ShowBulletButton
        {
            //get { return tsBullets.Visible; }
            set
            {
                _tsBullets.Visible = value;
                UpdateToolbarSeperators();
            }
        }

        [Description("Show the OutdentOrdered List button or not"),
         Category("Toolbar")]
        public bool ShowOrderedListButton
        {
            //get { return tsNumeric.Visible; }
            set
            {
                _tsNumeric.Visible = value;
                UpdateToolbarSeperators();
            }
        }

        [Description("Show the Text color button"),
         Category("Toolbar")]
        public bool ShowTxtColorButton
        {
            //get { return tsTextColor.Visible; }
            set
            {
                _tsTextColor.Visible = value;
                UpdateToolbarSeperators();
            }
        }

        [Description("Show the Font Family button"),
         Category("Toolbar")]
        public bool ShowFontFamilyButton
        {
            //get { return tsFontFamily.Visible; }
            set
            {
                _tsFontFamily.Visible = value;
                UpdateToolbarSeperators();
            }
        }

        public void UpdateToolbarSeperators()
        {
            _tsSeparator1.Visible = _newTs.Visible || _printToolStripButton.Visible;

            _toolStripSeparator1.Visible = _tsCut.Visible || _tsCopy.Visible || _tsPaste.Visible;

            _toolStripSeparator2.Visible = _tsBold.Visible || _tsUnderline.Visible ||
                                           _tsItalics.Visible;
            _toolStripSeparator3.Visible = _tsCenter.Visible || _tsJustify.Visible ||
                                           _tsLeft.Visible || _tsRight.Visible;
            _toolStripSeparator4.Visible = _tsIndent.Visible || _tsOutdent.Visible;
            _toolStripSeparator5.Visible = _tsBullets.Visible || _tsNumeric.Visible;

            _toolStripSeparator6.Visible = _tsBackColor.Visible || _tsTextColor.Visible;

            _toolStripSeparator7.Visible = _tsLink.Visible || _tsRemoveLink.Visible;
        }

        #endregion FieldProperties

        #region ClickEvents

        private void custCtxMenu_ItemClicked
            (
            object sender,
            ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            switch (item.Text)
            {
                case "&Paste":
                    _tsPaste.PerformClick();
                    break;
                case "&Copy":
                    _tsCopy.PerformClick();
                    break;
                case "&Cut":
                    _tsCut.PerformClick();
                    break;
            }
        }

        private void newTS_Click
            (
            object sender,
            EventArgs e)
        {
            if (_edits)
            {
                _doc.body.innerText = "";
            }
        }

        private void printToolStripButton_Click
            (
            object sender,
            EventArgs e)
        {
            if (_edits)
            {
                _doc.execCommand
                    (
                        "Print",
                        true,
                        null);
            }
        }

        private void cutToolStripButton_Click
            (
            object sender,
            EventArgs e)
        {
            if (!_edits)
            {
                return;
            }
            try
            {
                _doc.execCommand
                    (
                        "Cut",
                        false,
                        null);
            }
            catch (Exception ex)
            {
                MessageDialog.Show
                    (
                        "Error Couldn't Cut  \r\n" + ex.InnerException,
                        "Error",
                        MessageDialog.MessageBoxButtons.Ok,
                        MessageDialog.MessageBoxIcon.Error,
                        "" + "\r\n" + ex.StackTrace);
            }
        }

        private void copyToolStripButton_Click
            (
            object sender,
            EventArgs e)
        {
            if (_edits)
            {
                _doc.execCommand
                    (
                        "Copy",
                        false,
                        null);
            }
        }

        private void pasteToolStripButton_Click
            (
            object sender,
            EventArgs e)
        {
            if (!_edits)
            {
                return;
            }
            if (Clipboard.ContainsImage())
            {
                Image bmp = Clipboard.GetImage();

                string base64String = ToBase64String
                    (
                        bmp,
                        ImageFormat.Png);
                string pasteImgHtml = "<img src='data:image/png;base64," + base64String + "' />";

                //this.doc.write(pasteImgHtml);

                var range = (IHTMLTxtRange) _doc.selection.createRange();
                range.pasteHTML(pasteImgHtml);
                range.collapse(false);
                range.@select();
            }
            else
            {
                _doc.execCommand
                    (
                        "Paste",
                        false,
                        null);
            }
        }

        private void tsBold_Click
            (
            object sender,
            EventArgs e)
        {
            if (_edits)
            {
                _doc.execCommand
                    (
                        "Bold",
                        false,
                        null);
            }
        }

        private void tsUnderline_Click
            (
            object sender,
            EventArgs e)
        {
            if (_edits)
            {
                _doc.execCommand
                    (
                        "Underline",
                        false,
                        null);
            }
        }

        private void tsItalics_Click
            (
            object sender,
            EventArgs e)
        {
            if (_edits)
            {
                _doc.execCommand
                    (
                        "Italic",
                        false,
                        null);
            }
        }

        private void tsCenter_Click
            (
            object sender,
            EventArgs e)
        {
            if (_edits)
            {
                _doc.execCommand
                    (
                        "JustifyCenter",
                        false,
                        null);
            }
        }

        private void tsLeft_Click
            (
            object sender,
            EventArgs e)
        {
            if (_edits)
            {
                _doc.execCommand
                    (
                        "JustifyLeft",
                        false,
                        null);
            }
        }

        private void tsJustify_Click
            (
            object sender,
            EventArgs e)
        {
            if (_edits)
            {
                _doc.execCommand
                    (
                        "JustifyFull",
                        false,
                        null);
            }
        }

        private void tsRight_Click
            (
            object sender,
            EventArgs e)
        {
            if (_edits)
            {
                _doc.execCommand
                    (
                        "JustifyRight",
                        false,
                        null);
            }
        }

        private void tsIndent_Click
            (
            object sender,
            EventArgs e)
        {
            if (_edits)
            {
                _doc.execCommand
                    (
                        "Indent",
                        false,
                        null);
            }
        }

        private void tsOutdent_Click
            (
            object sender,
            EventArgs e)
        {
            if (_edits)
            {
                _doc.execCommand
                    (
                        "Outdent",
                        false,
                        null);
            }
        }

        private void tsBullets_Click
            (
            object sender,
            EventArgs e)
        {
            if (_edits)
            {
                _doc.execCommand
                    (
                        "InsertUnorderedList",
                        false,
                        null);
            }
        }

        private void tsNumeric_Click
            (
            object sender,
            EventArgs e)
        {
            if (_edits)
            {
                _doc.execCommand
                    (
                        "InsertOrderedList",
                        false,
                        null);
            }
        }

        private void tsLink_Click
            (
            object sender,
            EventArgs e)
        {
            if (_edits)
            {
                _doc.execCommand
                    (
                        "CreateLink",
                        true,
                        null);
            }
        }

        private void tsRemoveLink_Click
            (
            object sender,
            EventArgs e)
        {
            if (_edits)
            {
                _doc.execCommand
                    (
                        "Unlink",
                        true,
                        null);
            }
        }

        private void toolStripMenuItem2_Click
            (
            object sender,
            EventArgs e)
        {
            if (_edits)
            {
                _doc.execCommand
                    (
                        "FontSize",
                        false,
                        1);
            }
        }

        private void toolStripMenuItem3_Click
            (
            object sender,
            EventArgs e)
        {
            if (_edits)
            {
                _doc.execCommand
                    (
                        "FontSize",
                        false,
                        2);
            }
        }

        private void toolStripMenuItem4_Click
            (
            object sender,
            EventArgs e)
        {
            if (_edits)
            {
                _doc.execCommand
                    (
                        "FontSize",
                        false,
                        3);
            }
        }

        private void toolStripMenuItem5_Click
            (
            object sender,
            EventArgs e)
        {
            if (_edits)
            {
                _doc.execCommand
                    (
                        "FontSize",
                        false,
                        4);
            }
        }

        private void toolStripMenuItem6_Click
            (
            object sender,
            EventArgs e)
        {
            if (_edits)
            {
                _doc.execCommand
                    (
                        "FontSize",
                        false,
                        5);
            }
        }

        private void toolStripMenuItem7_Click
            (
            object sender,
            EventArgs e)
        {
            if (_edits)
            {
                _doc.execCommand
                    (
                        "FontSize",
                        false,
                        6);
            }
        }

        private void toolStripMenuItem8_Click
            (
            object sender,
            EventArgs e)
        {
            if (_edits)
            {
                _doc.execCommand
                    (
                        "FontSize",
                        false,
                        7);
            }
        }

        private void tsFontSize_ButtonClick
            (
            object sender,
            EventArgs e)
        {
        }

        private void addFont_click
            (
            object sender,
            EventArgs e)
        {
            if (_edits)
            {
                _doc.execCommand
                    (
                        "FontName",
                        false,
                        ((ToolStripLabel) sender).Text);
            }
        }

        private void addBGFontColour_click
            (
            object sender,
            EventArgs e)
        {
            if (_edits)
            {
                ((ToolStripLabel) sender).ActiveLinkColor = Color.PaleGoldenrod;
            }
        }

        private void addBGFontColourNom_click
            (
            object sender,
            EventArgs e)
        {
            if (_edits)
            {
                ((ToolStripLabel) sender).ActiveLinkColor = Color.White;
            }
        }

        private void tsTextColor_Click
            (
            object sender,
            EventArgs e)
        {
            if (!_edits)
            {
                return;
            }
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() != DialogResult.Cancel)
            {
                _doc.execCommand
                    (
                        "ForeColor",
                        false,
                        ColorTranslator.ToHtml(colorDialog.Color));
            }
        }

        private void tsBackColor_Click
            (
            object sender,
            EventArgs e)
        {
            if (!_edits)
            {
                return;
            }
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() != DialogResult.Cancel)
            {
                _doc.execCommand
                    (
                        "BackColor",
                        false,
                        ColorTranslator.ToHtml(colorDialog.Color));
            }
        }

        #endregion ClickEvents
    }
}
