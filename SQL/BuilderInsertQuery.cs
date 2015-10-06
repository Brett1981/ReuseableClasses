using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Re_useable_Classes.SQL
{
    public class BuilderInsertQuery
    {
        private static string _aTableName;
        private static Connection _appsettings;

        public static string BuildInsertQuery
            (
            List<SqlParameter> sqlParamColl,
            string seqTableName,
            string tableName,
            Connection appsettings,
            object value = null)
        {
            _appsettings = appsettings;
            _aTableName = tableName;
            {
                int i = 1;

                string aSqlQuery = "INSERT INTO " + tableName + " ( ";
                foreach (SqlParameter sqlParameter in sqlParamColl)
                {
                    aSqlQuery = aSqlQuery + sqlParameter.ParameterName;
                    if (i < sqlParamColl.Count)
                    {
                        aSqlQuery = aSqlQuery + ", ";
                        i++;
                    }
                    else
                    {
                        aSqlQuery = aSqlQuery + " ) VALUES( ";
                    }
                }
                i = 1;
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
                    else
                    {
                        aSqlQuery = aSqlQuery + "@" + sqlParameter.ParameterName;
                        if (i < sqlParamColl.Count)
                        {
                            aSqlQuery = aSqlQuery + ", ";
                            i++;
                        }
                        else
                        {
                            aSqlQuery = aSqlQuery + " ) ";
                        }
                    }
                    if (stringPrimary != aCheckString && sqlParameter.ParameterName.Contains("PRIMARY"))
                    {
                        sqlParameter.SqlValue = value;

                        aSqlQuery = aSqlQuery + "@" + sqlParameter.ParameterName;
                        if (i < sqlParamColl.Count)
                        {
                            aSqlQuery = aSqlQuery + ", ";
                            i++;
                        }
                        else
                        {
                            aSqlQuery = aSqlQuery + " ) ";
                        }
                    }
                    if (stringPrimary != aCheckString || !sqlParameter.ParameterName.Contains("PRIMARY"))
                    {
                        continue;
                    }
                    int aPrimaryValue = GetSequenceNumber
                        (
                            sqlParameter,
                            seqTableName,
                            _aTableName);
                    sqlParameter.SqlValue = aPrimaryValue;

                    aSqlQuery = aSqlQuery + "@" + sqlParameter.ParameterName;
                    if (i < sqlParamColl.Count)
                    {
                        aSqlQuery = aSqlQuery + ", ";
                        i++;
                    }
                    else
                    {
                        aSqlQuery = aSqlQuery + " ) ";
                    }
                }
                return aSqlQuery;
            }
        }

        public static int GetSequenceNumber
            (
            SqlParameter sqlParameter,
            string seqTableName,
            string aTableName)
        {
            var dataAccess = new DataAccess
                (
                _appsettings.AServerAddress,
                _appsettings.ADatabaseName,
                _appsettings.AUserName,
                _appsettings.APassword);
            int nextSequence = dataAccess.GetNextSequence
                (
                    seqTableName,
                    aTableName);

            return nextSequence;
        }
    }
}
