using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle;
using ColumnStyle = Infragistics.Win.UltraWinGrid.ColumnStyle;

namespace Re_useable_Classes.Controls
{
    public class ControlHelper
    {
        public static void SetDataGridDataSource
            (
            UltraGrid grid,
            DataTable data,
            string tableName)
        {
            // Set grid data based on data returned
            if (data != null && data.Rows.Count > 0 || tableName == "AQS_SYSTEM_USERS")
            {
                if (grid == null)
                {
                    grid = new UltraGrid();
                }
                grid.DataSource = data;
                grid.Visible = true;
            }
            else
            {
                if (grid == null)
                {
                    grid = new UltraGrid();
                }
                //Check if Table is a User Editable Table if true then show empty Dataset so Insert can Occur
                if (tableName.Contains("AQS_U_"))
                {
                    grid.DataSource = data;
                    grid.Visible = true;
                }
                else
                {
                    grid.DataSource = null;
                    grid.Visible = false;
                }
            }
        }

        //Hide/enable colum headers  (extended property of datatble column Enabled required)
        public static void HideEnableGridColumns(UltraGrid grid)
        {
            DataTable dtData = null;

            //Check data set
            if (grid.DataSource != null)
            {
                dtData = grid.DataSource as DataTable;
            }
            foreach (UltraGridBand band in grid.DisplayLayout.Bands)
            {
                foreach (UltraGridColumn col in band.Columns)
                {
                    //Check underscore in name
                    if (col.Header.Caption.Contains("__"))
                    {
                        col.Hidden = true;
                    }

                    //Check enable from datatable property
                    if (dtData == null || !dtData.Columns[col.Key].ExtendedProperties.ContainsKey("Enabled") ||
                        Convert.ToBoolean(dtData.Columns[col.Key].ExtendedProperties["Enabled"]) != true)
                    {
                        continue;
                    }
                    col.CellClickAction = CellClickAction.CellSelect;
                    col.CellActivation = Activation.NoEdit;
                }
            }
        }

        // Format numeric grid cells
        public static void FormatNumericDp
            (
            UltraGridCell cell,
            int decimalPlaces)
        {
            //Set mask editor for muti cell precision on numbers
            string strMask = ("nnnnnn" + (decimalPlaces > 0
                                              ? "."
                                              : ""));
            strMask = strMask.PadRight
                (
                    (decimalPlaces + strMask.Length),
                    Convert.ToChar("n"));
            var osSettings = new DefaultEditorOwnerSettings
                             {
                                 MaskInput = strMask
                             };
            var deOwner = new DefaultEditorOwner(osSettings);
            var meEditor = new EditorWithMask(deOwner);
            cell.Editor = meEditor;
        }

        //Get first visibble column
        public static UltraGridColumn GetFirstVisibleGridColumnForBand(UltraGridBand band)
        {
            return band.Columns.Cast<UltraGridColumn>()
                       .FirstOrDefault(col => !col.Header.Caption.Contains("__"));
        }

        public static void ResizeAndHideGridColumns(UltraGrid grid)
        {
            foreach (UltraGridBand band in grid.DisplayLayout.Bands)
            {
                foreach (UltraGridColumn col in band.Columns)
                {
                    //Check underscore in name
                    if (col.Header.Caption.Contains("__"))
                    {
                        col.Hidden = true;
                    }
                    col.PerformAutoResize(PerformAutoSizeType.VisibleRows);
                }
            }
        }

        //Hide combo box headers
        public static void HideComboColumns(UltraCombo combo)
        {
            foreach (
                UltraGridColumn col in
                    combo.DisplayLayout.Bands[0].Columns.Cast<UltraGridColumn>()
                                                .Where(col => col.Header.Caption.Contains("__")))
            {
                col.Hidden = true;
            }
        }

        //Set grid column data types
        public static void SetGridColumnTypes(InitializeLayoutEventArgs e)
        {
            //Loop all bands
            foreach (UltraGridBand band in e.Layout.Bands)
            {
                //Loop all grid columns
                foreach (UltraGridColumn col in band.Columns)
                {
                    //Check datatype
                    switch (col.DataType.FullName)
                    {
                        case "System.String":
                            break;

                        case "System.Int32":
                            col.Style = ColumnStyle.Integer;
                            col.CellAppearance.TextHAlign = HAlign.Right;
                            col.Header.Appearance.TextHAlign = HAlign.Right;
                            break;

                        case "System.Double":
                        case "System.Decimal":
                            col.Style = ColumnStyle.Double;
                            col.CellAppearance.TextHAlign = HAlign.Right;
                            col.Header.Appearance.TextHAlign = HAlign.Right;
                            break;

                        case "System.DateTime":
                        case "System.Date":
                            col.Style = ColumnStyle.DateTime;
                            break;

                        case "System.Boolean":
                            col.Style = ColumnStyle.CheckBox;
                            break;
                    }
                }
            }
        }

        public static void SetGridColumnTypes
            (
            InitializeLayoutEventArgs e,
            bool rightAlignNumericFields,
            string excludeColumn = null)
        {
            foreach (
                UltraGridColumn col in
                    e.Layout.Bands.Cast<UltraGridBand>()
                     .SelectMany
                        (
                            band => band.Columns.Cast<UltraGridColumn>()
                                        .Where(col => col.Key != excludeColumn))
                )
            {
                //Check datatype
                switch (col.DataType.FullName)
                {
                    case "System.String":
                        break;

                    case "System.Int32":
                        col.Style = ColumnStyle.Integer;
                        if (rightAlignNumericFields)
                        {
                            col.CellAppearance.TextHAlign = HAlign.Right;
                            col.Header.Appearance.TextHAlign = HAlign.Right;
                        }
                        break;

                    case "System.Double":
                    case "System.Decimal":
                        col.Style = ColumnStyle.Double;
                        if (rightAlignNumericFields)
                        {
                            col.CellAppearance.TextHAlign = HAlign.Right;
                            col.Header.Appearance.TextHAlign = HAlign.Right;
                        }
                        break;

                    case "System.DateTime":
                    case "System.Date":
                        col.Style = ColumnStyle.DateTime;
                        break;

                    case "System.Boolean":
                        col.Style = ColumnStyle.CheckBox;
                        break;
                }
            }
        }

        //Get datatype from column for SQL format
        public static string SetGridColumnTypesSql
            (
            DataRow row,
            string cName)
        {
            //Check datatype
            switch (row.Table.Columns[cName].DataType.FullName)
            {
                case "System.String":
                    return ("'" + row[cName] + "'");

                case "System.Int32":
                case "System.Double":
                case "System.Decimal":
                    return row[cName].ToString();

                case "System.DateTime":
                case "System.Date":
                    return row[cName].ToString();

                case "System.Boolean":
                    return (Convert.ToBoolean(row[cName])
                                ? 1
                                : 0).ToString();

                default:
                    return ("'" + row[cName] + "'");
            }
        }

        //Set grid add row defaults
        public static void SetGridAddRowDefaults(UltraGridRow row)
        {
            //Loop all cells
            foreach (UltraGridCell cell in row.Cells)
            {
                //Check datatype
                switch (cell.Column.DataType.FullName)
                {
                    case "System.String":
                        cell.Value = "";
                        break;

                    case "System.Int32":
                    case "System.Double":
                    case "System.Decimal":
                        cell.Value = 0;
                        break;

                    case "System.DateTime":
                    case "System.Date":
                        cell.Value = null;
                        break;

                    case "System.Boolean":
                        cell.Value = false;
                        break;
                }
            }
        }

        public static void SetFormAsReadOnly(Form frm)
        {
            foreach (Control ctrl in frm.Controls)
            {
                SetControlAsReadOnly(ctrl);
                switch (ctrl.GetType()
                            .Name)
                {
                    case "UltraTextEditor":
                    case "UltraCalendarCombo":
                    case "UltraComboEditor":
                    case "UltraCheckEditor":
                    case "UltraCombo":
                        ctrl.Enabled = false;
                        break;
                }
            }
        }

        public static void SetControlAsReadOnly(Control control)
        {
            foreach (Control ctrl in control.Controls)
            {
                if (ctrl.HasChildren)
                {
                    SetControlAsReadOnly(ctrl);
                }

                switch (ctrl.GetType()
                            .Name)
                {
                    case "UltraTextEditor":
                    case "UltraCalendarCombo":
                    case "UltraCombo":
                    case "UltraComboEditor":
                    case "UltraCheckEditor":
                        ctrl.Enabled = false;
                        break;
                }
            }
        }

        public static void SetToolBarAsReadOnly
            (
            UltraToolbarsManager tbmControl,
            string excludeToolItems = null)
        {
            foreach (ToolBase tool in tbmControl.Tools)
            {
                tool.SharedProps.Enabled = false;
                if (excludeToolItems == null)
                {
                    continue;
                }
                if (excludeToolItems.Contains(tool.Key))
                {
                    tool.SharedProps.Enabled = true;
                }
            }
        }

        //Create insert from datarow based on column settings
        public static string InsertFromGrid
            (
            DataRow row,
            int newPrimary,
            int parentPrimary)
        {
            string strSql = ("INSERT INTO " + row.Table.TableName);
            string strColumns = "";
            string strValues = "";

            //Loop all columns
            foreach (
                DataColumn col in
                    row.Table.Columns.Cast<DataColumn>()
                       .Where
                        (
                            col => col.ColumnName.Substring
                                       (
                                           0,
                                           2) != "__"))
            {
                //Check primary
                if (col.ColumnName.Substring
                        (
                            col.ColumnName.IndexOf
                        (
                            "_",
                            StringComparison.Ordinal)) == "_PRIMARY")
                {
                    //Buid Insert
                    strColumns += ((strColumns.Length == 0
                                        ? "(["
                                        : ",[") + col.ColumnName + "]");
                    strValues += ((strValues.Length == 0
                                       ? "VALUES("
                                       : ",") + newPrimary);
                }
                else if (
                    col.ColumnName.Substring
                        (
                            col.ColumnName.IndexOf
                                (
                                    "_",
                                    StringComparison.Ordinal) + 1)
                       .Substring
                        (
                            col.ColumnName.IndexOf
                        (
                            "_",
                            StringComparison.Ordinal)) == "_PRIMARY")
                //Parent primary
                {
                    //Build Insert
                    strColumns += ((strColumns.Length == 0
                                        ? "(["
                                        : ",[") + col.ColumnName + "]");
                    strValues += ((strValues.Length == 0
                                       ? "VALUES("
                                       : ",") + parentPrimary);
                }
                else //All other fields
                {
                    //Build Insert
                    strColumns += ((strColumns.Length == 0
                                        ? "(["
                                        : ",[") + col.ColumnName + "]");
                    strValues += ((strValues.Length == 0
                                       ? "VALUES("
                                       : ",") +
                                  SetGridColumnTypesSql
                                      (
                                          row,
                                          col.ColumnName));
                }
            }

            //Return SQL statment for insert
            return (strSql + " " + strColumns + ") " + strValues + ")");
        }

        //Create update from datarow based on column settings
        public static string UpdateFromGrid(DataRow row)
        {
            string strSql = ("UPDATE " + row.Table.TableName);
            string strValues = "";
            string strWhere = "";

            //Loop all columns
            foreach (
                DataColumn col in
                    row.Table.Columns.Cast<DataColumn>()
                       .Where
                        (
                            col => col.ColumnName.Substring
                                       (
                                           0,
                                           2) != "__"))
            {
                //Check primary
                if (col.ColumnName.Substring
                        (
                            col.ColumnName.IndexOf
                        (
                            "_",
                            StringComparison.Ordinal)) == "_PRIMARY")
                {
                    strWhere = ("WHERE [" + col.ColumnName + "] = " + row[col.ColumnName]);
                }
                else if (
                    col.ColumnName.Substring
                        (
                            col.ColumnName.IndexOf
                                (
                                    "_",
                                    StringComparison.Ordinal) + 1)
                       .Substring
                        (
                            col.ColumnName.IndexOf
                        (
                            "_",
                            StringComparison.Ordinal)) != "_PRIMARY")
                {
                    //Build update
                    strValues += ((strValues.Length == 0
                                       ? "SET ["
                                       : ",[") + col.ColumnName + "] = " +
                                  SetGridColumnTypesSql
                                      (
                                          row,
                                          col.ColumnName)) + "]";
                }
            }

            //Return SQL statment for insert
            return (strSql + " " + strValues + " " + strWhere);
        }

        public static void SetDataGridColumnsAsReadOnly
            (
            UltraGrid grid,
            string excludeColumnItems = null)
        {
            if (excludeColumnItems == null)
            {
                return;
            }
            List<string> excludeColumns = excludeColumnItems.Split(',')
                                                            .ToList();

            foreach (UltraGridRow row in grid.Rows)
            {
                foreach (UltraGridCell cell in row.Cells)
                {
                    cell.Activation = excludeColumns.Contains(cell.Column.Key)
                                          ? Activation.AllowEdit
                                          : Activation.NoEdit;
                }
            }
        }

        //Set grid cell text edito for lookup
        public static void SetCellLookupEditor
            (
            UltraGridColumn col,
            EditorButtonEventHandler Event)
        {
            //Set part lookup editor for column
            var txtAssemblyPart = new UltraTextEditor
                                  {
                                      UseAppStyling = false
                                  };
            var btnEditor = new EditorButton
                            {
                                Text = "..",
                                Width = 17,
                                Appearance =
                                {
                                    TextHAlign = HAlign.Center
                                }
                            };
            txtAssemblyPart.EditorButtonClick += Event;
            txtAssemblyPart.ButtonsRight.Add(btnEditor);
            col.ButtonDisplayStyle = ButtonDisplayStyle.Always;
            col.EditorComponent = txtAssemblyPart;
        }
    }
}