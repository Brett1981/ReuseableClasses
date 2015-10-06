using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace Re_useable_Classes.Printing
{
    public class PrintDgv
    {
        private static StringFormat _strFormat; // Holds content of a TextBox Cell to write by DrawString
        private static StringFormat _strFormatComboBox; // Holds content of a Boolean Cell to write by DrawImage
        private static Button _cellButton; // Holds the Contents of Button Cell
        private static CheckBox _cellCheckBox; // Holds the Contents of CheckBox Cell 
        private static ComboBox _cellComboBox; // Holds the Contents of ComboBox Cell

        private static int _totalWidth; // Summation of Columns widths
        private static int _rowPos; // Position of currently printing row 
        private static bool _newPage; // Indicates if a new page reached
        private static int _pageNo; // Number of pages to print
        private static readonly ArrayList ColumnLefts = new ArrayList(); // Left Coordinate of Columns
        private static readonly ArrayList ColumnWidths = new ArrayList(); // Width of Columns
        private static readonly ArrayList ColumnTypes = new ArrayList(); // DataType of Columns
        private static int _cellHeight; // Height of DataGrid Cell
        private static int _rowsPerPage; // Number of Rows per Page

        private static readonly PrintDocument printDoc =
            new PrintDocument(); // PrintDocumnet Object used for printing

        private static string _printTitle = ""; // Header of pages
        private static DataGridView _dgv; // Holds DataGridView Object to print its contents
        private static List<string> _selectedColumns = new List<string>(); // The Columns Selected by user to print.

        private static readonly List<string> _availableColumns = new List<string>();
                                             // All Columns avaiable in DataGrid 

        private static bool _printAllRows = true; // True = print all rows,  False = print selected rows    

        private static bool _fitToPageWidth = true;
        // True = Fits selected columns to page width ,  False = Print columns as showed    

        private static int _headerHeight;

        public static void Print_DataGridView(DataGridView dgv1)
        {
            try
            {
                // Getting DataGridView object to print
                _dgv = dgv1;

                // Getting all Coulmns Names in the DataGridView
                _availableColumns.Clear();
                foreach (DataGridViewColumn c in _dgv.Columns.Cast<DataGridViewColumn>()
                                                     .Where(c => c.Visible))
                {
                    _availableColumns.Add(c.HeaderText);
                }

                // Showing the PrintOption Form
                var dlg = new PrintOptions(_availableColumns);
                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                _printTitle = dlg.PrintTitle;
                _printAllRows = dlg.PrintAllRows;
                _fitToPageWidth = dlg.FitToPageWidth;
                _selectedColumns = dlg.GetSelectedColumns();

                _rowsPerPage = 0;

                var ppvw = new PrintPreviewDialog
                           {
                               Document = printDoc
                           };

                // Showing the Print Preview Page
                printDoc.BeginPrint += PrintDoc_BeginPrint;
                printDoc.PrintPage += PrintDoc_PrintPage;
                printDoc.DefaultPageSettings.Landscape = true;
                ppvw.TopMost = true;

                if (ppvw.ShowDialog() != DialogResult.OK)
                {
                    printDoc.BeginPrint -= PrintDoc_BeginPrint;
                    printDoc.PrintPage -= PrintDoc_PrintPage;
                    return;
                }

                // Printing the Documnet
                printDoc.Print();
                printDoc.BeginPrint -= PrintDoc_BeginPrint;
                printDoc.PrintPage -= PrintDoc_PrintPage;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (
                        ex.Message,
                        @"Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private static void PrintDoc_BeginPrint
            (
            object sender,
            PrintEventArgs e)
        {
            try
            {
                // Formatting the Content of Text Cell to print
                _strFormat = new StringFormat
                             {
                                 Alignment = StringAlignment.Near,
                                 LineAlignment = StringAlignment.Center,
                                 Trimming = StringTrimming.EllipsisCharacter
                             };

                // Formatting the Content of Combo Cells to print
                _strFormatComboBox = new StringFormat
                                     {
                                         LineAlignment = StringAlignment.Center,
                                         FormatFlags = StringFormatFlags.NoWrap,
                                         Trimming = StringTrimming.EllipsisCharacter
                                     };

                ColumnLefts.Clear();
                ColumnWidths.Clear();
                ColumnTypes.Clear();
                _cellHeight = 0;
                _rowsPerPage = 0;

                // For various column types
                _cellButton = new Button();
                _cellCheckBox = new CheckBox();
                _cellComboBox = new ComboBox();

                // Calculating Total Widths
                _totalWidth = 0;
                foreach (DataGridViewColumn gridCol in from DataGridViewColumn gridCol in _dgv.Columns
                                                       where gridCol.Visible
                                                       where _selectedColumns.Contains(gridCol.HeaderText)
                                                       select gridCol)
                {
                    _totalWidth += gridCol.Width;
                }
                _pageNo = 1;
                _newPage = true;
                _rowPos = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (
                        ex.Message,
                        @"Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private static void PrintDoc_PrintPage
            (
            object sender,
            PrintPageEventArgs e)
        {
            int tmpTop = e.MarginBounds.Top;
            int tmpLeft = e.MarginBounds.Left;

            try
            {
                // Before starting first page, it saves Width & Height of Headers and CoulmnType
                if (_pageNo == 1)
                {
                    foreach (DataGridViewColumn gridCol in from DataGridViewColumn gridCol in _dgv.Columns
                                                           where gridCol.Visible
                                                           where _selectedColumns.Contains(gridCol.HeaderText)
                                                           select gridCol)
                    {
                        // Detemining whether the columns are fitted to page or not.
                        int tmpWidth;
                        if (_fitToPageWidth)
                        {
                            tmpWidth = (int) (Math.Floor
                                                 (
                                                     gridCol.Width/
                                                     (double) _totalWidth*_totalWidth*
                                                     (e.MarginBounds.Width/(double) _totalWidth)));
                        }
                        else
                        {
                            tmpWidth = gridCol.Width;
                        }

                        _headerHeight = (int) (e.Graphics.MeasureString
                                                  (
                                                      gridCol.HeaderText,
                                                      gridCol.InheritedStyle.Font,
                                                      tmpWidth)
                                                .Height) + 11;

                        // Save width & height of headres and ColumnType
                        ColumnLefts.Add(tmpLeft);
                        ColumnWidths.Add(tmpWidth);
                        ColumnTypes.Add(gridCol.GetType());
                        tmpLeft += tmpWidth;
                    }
                }

                // Printing Current Page, Row by Row
                while (_rowPos <= _dgv.Rows.Count - 1)
                {
                    DataGridViewRow gridRow = _dgv.Rows[_rowPos];
                    if (gridRow.IsNewRow || (!_printAllRows && !gridRow.Selected))
                    {
                        _rowPos++;
                        continue;
                    }

                    _cellHeight = gridRow.Height;

                    if (tmpTop + _cellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        DrawFooter
                            (
                                e,
                                _rowsPerPage);
                        _newPage = true;
                        _pageNo++;
                        e.HasMorePages = true;
                        return;
                    }
                    int i;
                    if (_newPage)
                    {
                        // Draw Header
                        e.Graphics.DrawString
                            (
                                _printTitle,
                                new Font
                                    (
                                    _dgv.Font,
                                    FontStyle.Bold),
                                Brushes.Black,
                                e.MarginBounds.Left,
                                e.MarginBounds.Top -
                                e.Graphics.MeasureString
                                    (
                                        _printTitle,
                                        new Font
                                    (
                                    _dgv.Font,
                                    FontStyle.Bold),
                                        e.MarginBounds.Width)
                                 .Height - 13);

                        string s = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();

                        e.Graphics.DrawString
                            (
                                s,
                                new Font
                                    (
                                    _dgv.Font,
                                    FontStyle.Bold),
                                Brushes.Black,
                                e.MarginBounds.Left + (e.MarginBounds.Width -
                                                       e.Graphics.MeasureString
                                                           (
                                                               s,
                                                               new Font
                                                           (
                                                           _dgv.Font,
                                                           FontStyle.Bold),
                                                               e.MarginBounds.Width)
                                                        .Width),
                                e.MarginBounds.Top -
                                e.Graphics.MeasureString
                                    (
                                        _printTitle,
                                        new Font
                                    (
                                    new Font
                                    (
                                    _dgv.Font,
                                    FontStyle.Bold),
                                    FontStyle.Bold),
                                        e.MarginBounds.Width)
                                 .Height - 13);

                        // Draw Columns
                        tmpTop = e.MarginBounds.Top;
                        i = 0;
                        foreach (DataGridViewColumn gridCol in from DataGridViewColumn gridCol in _dgv.Columns
                                                               where gridCol.Visible
                                                               where _selectedColumns.Contains(gridCol.HeaderText)
                                                               select gridCol)
                        {
                            e.Graphics.FillRectangle
                                (
                                    new SolidBrush(Color.LightGray),
                                    new Rectangle
                                        (
                                        (int) ColumnLefts[i],
                                        tmpTop,
                                        (int) ColumnWidths[i],
                                        _headerHeight));

                            e.Graphics.DrawRectangle
                                (
                                    Pens.Black,
                                    new Rectangle
                                        (
                                        (int) ColumnLefts[i],
                                        tmpTop,
                                        (int) ColumnWidths[i],
                                        _headerHeight));

                            e.Graphics.DrawString
                                (
                                    gridCol.HeaderText,
                                    gridCol.InheritedStyle.Font,
                                    new SolidBrush(gridCol.InheritedStyle.ForeColor),
                                    new RectangleF
                                        (
                                        (int) ColumnLefts[i],
                                        tmpTop,
                                        (int) ColumnWidths[i],
                                        _headerHeight),
                                    _strFormat);
                            i++;
                        }
                        _newPage = false;
                        tmpTop += _headerHeight;
                    }

                    // Draw Columns Contents
                    i = 0;
                    foreach (DataGridViewCell cel in from DataGridViewCell cel in gridRow.Cells
                                                     where cel.OwningColumn.Visible
                                                     where _selectedColumns.Contains(cel.OwningColumn.HeaderText)
                                                     select cel)
                    {
                        // For the TextBox Column
                        switch (((Type) ColumnTypes[i]).Name)
                        {
                            case "DataGridViewLinkColumn":
                            case "DataGridViewTextBoxColumn":
                                e.Graphics.DrawString
                                    (
                                        cel.Value.ToString(),
                                        cel.InheritedStyle.Font,
                                        new SolidBrush(cel.InheritedStyle.ForeColor),
                                        new RectangleF
                                            (
                                            (int) ColumnLefts[i],
                                            tmpTop,
                                            (int) ColumnWidths[i],
                                            _cellHeight),
                                        _strFormat);
                                break;
                            case "DataGridViewButtonColumn":
                            {
                                _cellButton.Text = cel.Value.ToString();
                                _cellButton.Size = new Size
                                    (
                                    (int) ColumnWidths[i],
                                    _cellHeight);
                                var bmp = new Bitmap
                                    (
                                    _cellButton.Width,
                                    _cellButton.Height);
                                _cellButton.DrawToBitmap
                                    (
                                        bmp,
                                        new Rectangle
                                            (
                                            0,
                                            0,
                                            bmp.Width,
                                            bmp.Height));
                                e.Graphics.DrawImage
                                    (
                                        bmp,
                                        new Point
                                            (
                                            (int) ColumnLefts[i],
                                            tmpTop));
                            }
                                break;
                            case "DataGridViewCheckBoxColumn":
                            {
                                _cellCheckBox.Size = new Size
                                    (
                                    14,
                                    14);
                                _cellCheckBox.Checked = (bool) cel.Value;
                                var bmp = new Bitmap
                                    (
                                    (int) ColumnWidths[i],
                                    _cellHeight);
                                Graphics tmpGraphics = Graphics.FromImage(bmp);
                                tmpGraphics.FillRectangle
                                    (
                                        Brushes.White,
                                        new Rectangle
                                            (
                                            0,
                                            0,
                                            bmp.Width,
                                            bmp.Height));
                                _cellCheckBox.DrawToBitmap
                                    (
                                        bmp,
                                        new Rectangle
                                            (
                                            (bmp.Width - _cellCheckBox.Width)/2,
                                            (bmp.Height - _cellCheckBox.Height)/2,
                                            _cellCheckBox.Width,
                                            _cellCheckBox.Height));
                                e.Graphics.DrawImage
                                    (
                                        bmp,
                                        new Point
                                            (
                                            (int) ColumnLefts[i],
                                            tmpTop));
                            }
                                break;
                            case "DataGridViewComboBoxColumn":
                            {
                                _cellComboBox.Size = new Size
                                    (
                                    (int) ColumnWidths[i],
                                    _cellHeight);
                                var bmp = new Bitmap
                                    (
                                    _cellComboBox.Width,
                                    _cellComboBox.Height);
                                _cellComboBox.DrawToBitmap
                                    (
                                        bmp,
                                        new Rectangle
                                            (
                                            0,
                                            0,
                                            bmp.Width,
                                            bmp.Height));
                                e.Graphics.DrawImage
                                    (
                                        bmp,
                                        new Point
                                            (
                                            (int) ColumnLefts[i],
                                            tmpTop));
                                e.Graphics.DrawString
                                    (
                                        cel.Value.ToString(),
                                        cel.InheritedStyle.Font,
                                        new SolidBrush(cel.InheritedStyle.ForeColor),
                                        new RectangleF
                                            (
                                            (int) ColumnLefts[i] + 1,
                                            tmpTop,
                                            (int) ColumnWidths[i]
                                            - 16,
                                            _cellHeight),
                                        _strFormatComboBox);
                            }
                                break;
                            case "DataGridViewImageColumn":
                            {
                                var celSize = new Rectangle
                                    (
                                    (int) ColumnLefts[i],
                                    tmpTop,
                                    (int) ColumnWidths[i],
                                    _cellHeight);
                                Size imgSize = ((Image) (cel.FormattedValue)).Size;
                                e.Graphics.DrawImage
                                    (
                                        (Image) cel.FormattedValue,
                                        new Rectangle
                                            (
                                            (int) ColumnLefts[i] + (celSize.Width - imgSize.Width)/2,
                                            tmpTop + (celSize.Height - imgSize.Height)/2,
                                            ((Image) (cel.FormattedValue)).Width,
                                            ((Image) (cel.FormattedValue)).Height));
                            }
                                break;
                        }

                        // Drawing Cells Borders 
                        e.Graphics.DrawRectangle
                            (
                                Pens.Black,
                                new Rectangle
                                    (
                                    (int) ColumnLefts[i],
                                    tmpTop,
                                    (int) ColumnWidths[i],
                                    _cellHeight));

                        i++;
                    }
                    tmpTop += _cellHeight;

                    _rowPos++;
                    // For the first page it calculates Rows per Page
                    if (_pageNo == 1)
                    {
                        _rowsPerPage++;
                    }
                }

                if (_rowsPerPage == 0)
                {
                    return;
                }

                // Write Footer (Page Number)
                DrawFooter
                    (
                        e,
                        _rowsPerPage);

                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (
                        ex.Message,
                        @"Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private static void DrawFooter
            (
            PrintPageEventArgs e,
            int rowsPerPage)
        {
            double cnt;

            // Detemining rows number to print
            if (_printAllRows)
            {
                if (_dgv.Rows[_dgv.Rows.Count - 1].IsNewRow)
                {
                    cnt = _dgv.Rows.Count - 2; // When the DataGridView doesn't allow adding rows
                }
                else
                {
                    cnt = _dgv.Rows.Count - 1; // When the DataGridView allows adding rows
                }
            }
            else
            {
                cnt = _dgv.SelectedRows.Count;
            }

            // Writing the Page Number on the Bottom of Page
            string pageNum = _pageNo + " of " +
                             Math.Ceiling(cnt/rowsPerPage);

            e.Graphics.DrawString
                (
                    pageNum,
                    _dgv.Font,
                    Brushes.Black,
                    e.MarginBounds.Left + (e.MarginBounds.Width -
                                           e.Graphics.MeasureString
                                               (
                                                   pageNum,
                                                   _dgv.Font,
                                                   e.MarginBounds.Width)
                                            .Width)/2,
                    e.MarginBounds.Top +
                    e.MarginBounds.Height + 31);
        }
    }
}
