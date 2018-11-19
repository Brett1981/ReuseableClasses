using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Re_useable_Classes.Printing
{
    public partial class PrintOptions : Form
    {
        public PrintOptions()
        {
            InitializeComponent();
        }

        public PrintOptions(IEnumerable<string> availableFields)
        {
            InitializeComponent();

            foreach (string field in availableFields)
            {
                chklst.Items.Add
                    (
                        field,
                        true);
            }
        }

        public string PrintTitle
        {
            get { return txtTitle.Text; }
        }

        public bool PrintAllRows
        {
            get { return rdoAllRows.Checked; }
        }

        public bool FitToPageWidth
        {
            get { return chkFitToPageWidth.Checked; }
        }

        private void PrintOtions_Load
            (
            object sender,
            EventArgs e)
        {
            // Initialize some controls
            rdoAllRows.Checked = true;
            chkFitToPageWidth.Checked = true;
        }

        private void btnOK_Click
            (
            object sender,
            EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click
            (
            object sender,
            EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public List<string> GetSelectedColumns()
        {
            return (from object item in chklst.CheckedItems
                    select item.ToString()).ToList();
        }
    }
}