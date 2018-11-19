using Microsoft.Office.Interop.Excel;
using Re_useable_Classes.Message_Helpers.Forms;
using System;
using DataTable = System.Data.DataTable;

namespace Re_useable_Classes.Converters
{
    public static class DataTableToExcel
    {
        public static class MyDataTableExtensions
        {
            // Export DataTable into an excel file with field names in the header line
            // - Save excel file without ever making it visible if filepath is given
            // - Don't save excel file, just make it visible if no filepath is given
            public static string ExportToExcel
                (
                DataTable tbl,
                string excelFilePath = null)
            {
                if (string.IsNullOrEmpty(excelFilePath))
                {
                    return excelFilePath;
                }
                excelFilePath = excelFilePath + "LogBook_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
                try
                {
                    if (tbl == null || tbl.Columns.Count == 0)
                    {
                        MessageDialog.Show
                            (
                                "ExportToExcel: Null or empty input table!",
                                "Error Log Not found For This Date!"
                            );
                        return null;
                    }

                    // load excel, and create a new workbook
                    var excelApp = new Application();
                    excelApp.Workbooks.Add();

                    // single worksheet
                    _Worksheet workSheet = excelApp.ActiveSheet;

                    // column headings
                    for (int i = 0;
                         i < tbl.Columns.Count;
                         i++)
                    {
                        workSheet.Cells[1,
                            (i + 1)] = tbl.Columns[i].ColumnName;
                    }

                    // rows
                    for (int i = 0;
                         i < tbl.Rows.Count;
                         i++)
                    {
                        // to do: format datetime values before printing
                        for (int j = 1;
                             j < tbl.Columns.Count;
                             j++)
                        {
                            workSheet.Cells[(i + 2),
                                (j + 1)] = tbl.Rows[i][j];
                        }
                    }

                    try
                    {
                        workSheet.SaveAs(excelFilePath);
                        excelApp.Quit();
                        return excelFilePath;
                        // MessageBox.Show("Excel file saved!");
                    }
                    catch (Exception ex)
                    {
                        throw new Exception
                            (
                            "ExportToExcel: Excel file could not be saved! Check filepath.\n"
                            + ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("ExportToExcel: \n" + ex.Message);
                }
            }
        }
    }
}