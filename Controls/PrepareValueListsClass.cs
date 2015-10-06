using System.Collections.Generic;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Re_useable_Classes.Controls
{
    public class PrepareValueListsClass
    {
        /*
         *  
         Example Use
         
         var alistofitems = new List<string>()
            {
                "Material",
                "Additional"
            };
           PrepareValueListsClass.PrepareValueLists(utgBOM, e, alistofitems, "ItemType", ColumnStyle.DropDownList, true, "Material");
         
         
         * 
         * 
         */

        public static void PrepareValueLists
            (
            UltraGrid aGrid,
            InitializeLayoutEventArgs e,
            List<string> alistofitems,
            string itemName,
            ColumnStyle aColumnStyle,
            bool hasdefault = false,
            string adefaultValue = "")
        {
            if (!aGrid.DisplayLayout.ValueLists.Exists(itemName))
            {
                UltraGridColumn checkColumn = e.Layout.Bands[0].Columns.Add
                    (
                        itemName,
                        itemName);
                checkColumn.CellActivation = Activation.AllowEdit;
                checkColumn.Header.VisiblePosition = 0;

                ValueList svl = aGrid.DisplayLayout.ValueLists.Add(itemName);

                foreach (string alistofitem in alistofitems)
                {
                    svl.ValueListItems.Add
                        (
                            alistofitem,
                            alistofitem);
                }

                aGrid.DisplayLayout.Bands[0].Columns[itemName].ValueList = aGrid.DisplayLayout.ValueLists[itemName];
                aGrid.DisplayLayout.Bands[0].Columns[itemName].Style = aColumnStyle;
            }
            if (!hasdefault)
            {
                return;
            }
            foreach (UltraGridRow row in aGrid.Rows)
            {
                row.Cells[itemName].Value = adefaultValue;
            }
        }
    }
}
