using System;
using System.Data;
using System.Data.SqlClient;

namespace Re_useable_Classes.SQL
{
    public static class FunctionHelper
    {
        private const string CConStringNoWin = "Server={0};Database={1};Uid={2};Pwd={3}";
        private const int CCmdTimeOut = 600;
        private static SqlConnection _connection;
        private static string _mDbServer;
        private static string _mDbDatabaseName;
        private static string _mDbUserId;
        private static string _mDbUserPassword;
        private static Connection AppSettings { get; set; }
        public static SqlTransaction MTheTransaction { get; set; }

        public static object GetValue
            (
            SqlConnection dc,
            string procedureName,
            DataTable aParameterDataTable,
            Connection appSettings)
        {
            _connection = dc;
            AppSettings = appSettings;
            _mDbServer = AppSettings.AServerAddress;
            _mDbDatabaseName = AppSettings.ADatabaseName;
            _mDbUserId = AppSettings.AUserName;
            _mDbUserPassword = AppSettings.APassword;

            var sqlAdapter = new SqlDataAdapter();
            string strSql = procedureName;
            var holdVals = new DataTable();

            object objValue;

            try
            {
                if ((MTheTransaction == null))
                {
                    OpenConnection();
                }

                sqlAdapter.SelectCommand = new SqlCommand
                    (
                    strSql,
                    _connection)
                                           {
                                               Transaction = MTheTransaction,
                                               CommandTimeout = CCmdTimeOut,
                                               CommandType = CommandType.StoredProcedure
                                           };
                foreach (DataRow dataRow in aParameterDataTable.Rows)
                {
                    //Create the parameters
                    //sqlAdapter.SelectCommand.Parameters.Clear();
                    sqlAdapter.SelectCommand.Parameters.Add
                        (
                            new SqlParameter
                                (
                                dataRow[0].ToString(),
                                dataRow[1].GetType()));
                    sqlAdapter.SelectCommand.Parameters[dataRow[0].ToString()].Value = dataRow[1].ToString();
                    //Set the parameter direction as  input (1) or output (0)
                    sqlAdapter.SelectCommand.Parameters[dataRow[0].ToString()].Direction = dataRow[3].ToString() == "1"
                                                                                               ? ParameterDirection
                                                                                                     .Input
                                                                                               : ParameterDirection
                                                                                                     .Output;
                }


                sqlAdapter.Fill(holdVals);
                objValue = sqlAdapter.SelectCommand.ExecuteScalar();
            }
            catch (Exception)
            {
                return false;
            }

            return objValue ?? (new decimal(0.00));
        }

        public static DataRow BuildTableHelper
            (
            string aParamterName,
            string aParameterValue,
            Type atype,
            int aInOut)
        {
            var dt = new DataTable();
            try
            {
                dt.Columns.Add
                    (
                        "aParamterName",
                        typeof (string));
                dt.Columns.Add
                    (
                        "aParameterValue",
                        atype);
                dt.Columns.Add
                    (
                        "atype",
                        atype);
                dt.Columns.Add
                    (
                        "aInOut",
                        typeof (int));

                dt.Rows.Add
                    (
                        aParamterName,
                        aParameterValue,
                        atype,
                        aInOut);
            }
            catch (Exception)
            {
                return null;
            }


            return dt.Rows[0];
        }

        private static void OpenConnection()
        {
            // Opens a connection string
            try
            {
                if ((_connection == null))
                {
                    _connection = new SqlConnection();
                }
                // Set to master if no supplied
                string dbName = (_mDbDatabaseName == "")
                                    ? "master"
                                    : _mDbDatabaseName;
                // Set connection string based on win auth
                string connectionString = string.Format
                    (
                        CConStringNoWin,
                        _mDbServer,
                        dbName,
                        _mDbUserId,
                        _mDbUserPassword);
                switch (_connection.State)
                {
                    case ConnectionState.Closed:
                        _connection.ConnectionString = connectionString;
                        _connection.Open();
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception
                    (
                    "Error occured creating connection to SQL Server : " + _mDbServer + " and/or Database : " +
                    _mDbDatabaseName + Environment.NewLine + Environment.NewLine
                    + ex.Message,
                    ex);
            }
        }
    }
}
