using System.Collections.Generic;
using System.Data;
using System.Data.Sql;

namespace Re_useable_Classes.SQL
{
    public class GetSqlServers
    {
        private List<string> _list1;

        public List<string> aGetSqlServers()
        {
            return _GetSqlServers(true);
        }

        private List<string> _GetSqlServers(bool shouldSortList)
        {
            if (_list1 == null)
            {
                _list1 = new List<string>();
                SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
                DataTable table = instance.GetDataSources();

                foreach (DataRow row in table.Rows)
                {
                    string item = null;
                    foreach (DataColumn col in table.Columns)
                    {
                        //Console.WriteLine("{0} = {1}", col.ColumnName, row[col]);
                        if (col.ColumnName.Equals("ServerName"))
                        {
                            item = item + string.Format
                                              (
                                                  @"{0}",
                                                  row[col]);
                        }
                        if (col.ColumnName.Equals("InstanceName"))
                        {
                            item = item + string.Format
                                              (
                                                  @"\{0}",
                                                  row[col]);
                        }
                    }
                    _list1.Add(item);
                    //Console.WriteLine("============================");
                }

                if (shouldSortList)
                {
                    _list1.Sort();
                }
                // AppMain.Cache.Insert("GetSqlServers", list1, null, Cache.NoAbsoluteExpiration, TimeSpan.FromSeconds(60));

                return _list1;
            }
            return _list1;
        }
    }
}