using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Re_useable_Classes.SQL
{
    public class BuilderDeleteClass
    {
        private static string _aTableName;

        public static string BuildDeleteQuery
            (
            ICollection<SqlParameter> sqlParamColl,
            string tableName)
        {
            _aTableName = tableName;
            {
                int[] i =
                {
                    1
                };

                string aSqlQuery = "DELETE FROM " + _aTableName + " WHERE ";

                foreach (SqlParameter sqlParameter in sqlParamColl.Where(sqlParameter => i[0] < sqlParamColl.Count))
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

                    if (stringPrimary == aCheckString)
                    {
                        aSqlQuery = aSqlQuery + sqlParameter.ParameterName + " = @" + sqlParameter.ParameterName;
                    }
                    i[0]++;
                }
                return aSqlQuery;
            }
        }
    }
}
