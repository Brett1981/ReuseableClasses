using System;
using System.Collections.Generic;
using System.Data;

namespace Re_useable_Classes.SQL
{
    internal class GetDatabases
    {
        private DataTable _aTable;
        private List<string> _list1;

        public List<string> GetSqlDataBases(Connection aConn)
        {
            _aTable = new DataTable();
            _list1 = new List<string>();
            try
            {
                _aTable = aConn.ExcuteReader
                    (
                        aConn,
                        "SELECT  [name] as DATABASE_NAME FROM [master].[sys].[databases]  order by name");
                foreach (DataRow row in _aTable.Rows)
                {
                    _list1.Add(row["DATABASE_NAME"].ToString());
                }
                return _list1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"General Exception error with the GetSqlDataBases function, error is:  " + ex);
            }
            return _list1;
        }
    }
}
