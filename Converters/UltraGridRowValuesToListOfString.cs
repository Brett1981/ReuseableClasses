using Infragistics.Win.UltraWinGrid;
using System.Collections.Generic;
using System.Linq;

namespace Re_useable_Classes.Converters
{
    public class UltraGridRowValuesToListOfString
    {
        private static readonly List<string> ARowList = new List<string>();

        public static List<string> CalculateRowList(UltraGridRow aUltraGridRow)
        {
            foreach (
                string aString in
                    from UltraGridCell cell in aUltraGridRow.Cells
                    select cell.Value.ToString()
                        into aString
                        select aString + "\r\n")
            {
                ARowList.Add(aString);
            }
            return ARowList;
        }
    }
}