using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Re_useable_Classes.SQL
{
    public class BuilderUpdateClass
    {
        private static string _aTableName;

        public static string BuildUpdateQuery
            (
            ICollection<SqlParameter> sqlParamColl,
            string tableName)
        {
            _aTableName = tableName;
            int[] i =
            {
                1
            };
            string aSqlQuery = "UPDATE " + _aTableName + " SET ";
            try
            {
                foreach (SqlParameter sqlParameter in sqlParamColl)
                {
                    //Check if PRIMARY exists in Column name from the nth Character if true then Primary - otherwise might be a FK
                    const string stringPrimary = "PRIMARY";
                    string aCheckString = "";
                    if (sqlParameter.ParameterName.Contains("PRIMARY"))
                    {
                        aCheckString =
                            sqlParameter.ParameterName.Substring
                                (
                                    sqlParameter.ParameterName.IndexOf
                                        (
                                            ("_"),
                                            StringComparison.Ordinal) +
                                    1,
                                    7);
                    }

                    if (stringPrimary != aCheckString)
                    {
                        aSqlQuery = aSqlQuery + sqlParameter.ParameterName + " = @" + sqlParameter.ParameterName;
                        if (i[0] < sqlParamColl.Count)
                        {
                            aSqlQuery = aSqlQuery + ", ";
                            i[0]++;
                        }
                        else
                        {
                            aSqlQuery = aSqlQuery + " WHERE ";
                        }
                    }
                    else
                    {
                        i[0]++;
                    }
                }
                i[0] = 1;
                foreach (SqlParameter sqlParameter in sqlParamColl.Where(sqlParameter => i[0] < sqlParamColl.Count))
                {
                    if (sqlParameter.ParameterName.Contains("PRIMARY"))
                    {
                        aSqlQuery = aSqlQuery + sqlParameter.ParameterName + " = @" + sqlParameter.ParameterName + " ";
                        return aSqlQuery;
                    }
                    i[0]++;
                }
            }
            catch (Exception)
            {
                //
            }

            return aSqlQuery;
        }
    }
}
