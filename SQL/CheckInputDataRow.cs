using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Re_useable_Classes.SQL
{
    public class CheckInputDataRow
    {
        public bool DoesRecordExist(SqlConnection ConnectionString, string SelectStatement)
        {
            SqlConnection cnConn = ConnectionString;
            SqlDataAdapter daExist =
                new SqlDataAdapter(SelectStatement, cnConn);
            DataTable dtExists = new DataTable();
            bool recordExists = false;

            daExist.Fill(dtExists);

            if (dtExists.Rows.Count > 0)
            {
                recordExists = true;
            }

            return recordExists; 
        }
    }
}
