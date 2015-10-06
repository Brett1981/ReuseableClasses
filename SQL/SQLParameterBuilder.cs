using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Re_useable_Classes.SQL
{
    public static class SqlParameterBuilder
    {
        public static List<SqlParameter> BuildSqlParamters(DataTable dt)
        {
            var sqlParamColl = new List<SqlParameter>();
            //Check if DataTable is not null 
            if (dt == null)
            {
                return null;
            }
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    var sqlParameter = new SqlParameter();
                    int i = 0;
                    foreach (object item in row.ItemArray)
                    {
                        if (i == 0)
                        {
                            sqlParameter.ParameterName = item.ToString();
                        }
                        else
                        {
                            sqlParameter.SqlValue = item.ToString();
                        }
                        i++;
                    }
                    sqlParamColl.Add(sqlParameter);
                }
            }
            catch (Exception)
            {
                return null;
            }


            return sqlParamColl;
        }
    }
}
