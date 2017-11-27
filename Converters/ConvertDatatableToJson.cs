using System.Data;
using System.Text;

namespace Re_useable_Classes.Converters
{
    public static class ConvertDatatableToJson
    {
        /*
          How to Use:
          dtJ = new ConvertDatatableToJson();   
          JsonString = dtJ.DataTableToJson((DataTable)ViewState["dt"]); 

         */
        /// <summary>
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTableToJson(DataTable dt)
        {
            var ds = new DataSet();
            ds.Merge(dt);
            var jsonStr = new StringBuilder();
            if (ds.Tables[0].Rows.Count > 0)
            {
                jsonStr.Append("[");
                for (int i = 0;
                     i < ds.Tables[0].Rows.Count;
                     i++)
                {
                    jsonStr.Append("{");
                    for (int j = 0;
                         j < ds.Tables[0].Columns.Count;
                         j++)
                    {
                        if (j < ds.Tables[0].Columns.Count - 1)
                        {
                            jsonStr.Append
                                (
                                    "\"" + ds.Tables[0].Columns[j].ColumnName + "\":" + "\"" + ds.Tables[0].Rows[i][j]
                                    + "\",");
                        }
                        else if (j == ds.Tables[0].Columns.Count - 1)
                        {
                            jsonStr.Append
                                (
                                    "\"" + ds.Tables[0].Columns[j].ColumnName + "\":" + "\"" + ds.Tables[0].Rows[i][j]
                                    + "\"");
                        }
                    }
                    if (i == ds.Tables[0].Rows.Count - 1)
                    {
                        jsonStr.Append("}");
                    }
                    else
                    {
                        jsonStr.Append("},");
                    }
                }
                jsonStr.Append("]");
                return jsonStr.ToString();
            }
            return null;
        }
    }
}
