using System.Collections.Generic;
using System.Data;

namespace Re_useable_Classes.SQL
{
    public static class SqlRunner
    {
        private static DataAccess _objDataAccess;
        private static string _aConCatSelect = "*";

        //Runs the given parameters for the Select Query and returns Bool (true/False_ for results. 
        //Results if exists are stored in GlobalSettings.ASqlResultsTable for use later

        public static bool CheckSqlRecordExists
            (
            string aTableName,
            string aWhereColumn,
            float aValue,
            List<string> aSelectColumn = null)
        {
            //Clear existing Table Results
            GlobalSettings.ASqlResultsTable = null;
            _aConCatSelect = "*";
            _objDataAccess = new DataAccess
                (
                GlobalSettings.AServer,
                GlobalSettings.ADatabase,
                GlobalSettings.AUser,
                GlobalSettings.APassword);
            string aParenttable = aTableName;

            if (aSelectColumn != null)
            {
                _aConCatSelect = "";
                int i = 0;
                int max = aSelectColumn.Count - 1;
                foreach (string aSelect in aSelectColumn)
                {
                    if (i < max)
                    {
                        _aConCatSelect = _aConCatSelect + aSelect + ",";
                        i++;
                    }
                    else
                    {
                        _aConCatSelect = _aConCatSelect + aSelect;
                        i++;
                    }
                }
            }

            DataTable adt =
                _objDataAccess.GetDataTable
                    (
                        "select " + _aConCatSelect + " from " + aParenttable + " where " +
                        aWhereColumn + " = '" + aValue + "'");

            if (adt != null && adt.Rows.Count > 0)
            {
                //Save results information for use later
                GlobalSettings.ASqlResultsTable = adt;
            }
            else
            {
                GlobalSettings.ASqlResultsTable = null;
                return false;
            }
            return true;
        }
    }
}
