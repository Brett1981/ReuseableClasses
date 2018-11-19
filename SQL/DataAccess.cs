using Infragistics.Win.UltraWinEditors;
using Re_useable_Classes.ParentalControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Re_useable_Classes.SQL
{
    public class DataAccess
    {
        public DataAccess
            (
            string dbServer,
            string dbDatabaseName,
            string dbUserId,
            string dbPassword)
        {
            _mDbDatabaseName = dbDatabaseName;
            _mDbServer = dbServer;
            _mDbUserId = dbUserId;
            _mDbUserPassword = dbPassword;
        }

        #region Variables

        private readonly string _mDbDatabaseName;
        private readonly string _mDbServer;
        private readonly string _mDbUserId;
        private readonly string _mDbUserPassword;
        public SqlConnection Connection;

        private SqlTransaction _mTheTransaction;

        #endregion Variables

        #region Connection Methods

        public void PopulateSettingsTypeDropDown
            (
            UltraComboEditor cmbcontrol,
            string tablename,
            string whereField
            ,
            string whereValue,
            string displayMember,
            string valueMember)
        {
            cmbcontrol.DataSource =
                GetDataTable("select * from " + tablename + " WHERE " + whereField + " = '" + whereValue + "'");
            cmbcontrol.DisplayMember = displayMember;
            cmbcontrol.ValueMember = valueMember;
            cmbcontrol.DataBind();
        }

        public int GetNextSequence
            (
            string seqTableName,
            string tableName)
        {
            var sqlAdapter = new SqlDataAdapter();

            string strSql = seqTableName;
            var holdVals = new DataTable();

            if ((_mTheTransaction == null))
            {
                OpenConnection();
            }

            sqlAdapter.SelectCommand = new SqlCommand
                (
                strSql,
                Connection)
                                       {
                                           Transaction = _mTheTransaction,
                                           CommandTimeout = CCmdTimeOut,
                                           CommandType = CommandType.StoredProcedure
                                       };

            //Create the Input parameters
            sqlAdapter.SelectCommand.Parameters.Clear();
            sqlAdapter.SelectCommand.Parameters.Add
                (
                    new SqlParameter
                        (
                        "@ParTable",
                        SqlDbType.NVarChar,
                        500));
            sqlAdapter.SelectCommand.Parameters["@ParTable"].Value = tableName;
            //Set the parameter direction as output
            sqlAdapter.SelectCommand.Parameters.Add
                (
                    new SqlParameter
                        (
                        "@ParSequence",
                        SqlDbType.Int));
            sqlAdapter.SelectCommand.Parameters["@ParSequence"].Direction = ParameterDirection.Output;

            sqlAdapter.Fill(holdVals);

            //Fetch the output parameter after doing the Fill
            object value = sqlAdapter.SelectCommand.Parameters["@ParSequence"].Value;
            if (!string.IsNullOrEmpty(value.ToString()))
            {
                var outputValue = (int)value;
                return outputValue;
            }
            else
            {
                const int outputValue = 1;
                return outputValue;
            }
        }

        public DataSet GetDataSet
            (
            string strSql,
            List<SqlParameter> parameters = null)
        {
            var sqlAdapter = new SqlDataAdapter();
            if ((_mTheTransaction == null))
            {
                OpenConnection();
            }
            sqlAdapter.SelectCommand = new SqlCommand
                (
                strSql,
                Connection)
                                       {
                                           Transaction = _mTheTransaction,
                                           CommandTimeout = CCmdTimeOut
                                       };
            if (parameters != null)
            {
                foreach (SqlParameter sqlParameter in parameters)
                {
                    sqlAdapter.SelectCommand.Parameters.Add(sqlParameter);
                }
            }
            var dataset = new DataSet();
            try
            {
                sqlAdapter.Fill(dataset);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            sqlAdapter.SelectCommand.Parameters.Clear();
            if ((_mTheTransaction == null))
            {
                CloseConnection();
            }

            return dataset;
        }

        public DataTable GetDataTable
            (
            string strSql,
            List<SqlParameter> parameters = null)
        {
            var sqlAdapter = new SqlDataAdapter();
            if ((_mTheTransaction == null))
            {
                OpenConnection();
            }

            sqlAdapter.SelectCommand = new SqlCommand
                (
                strSql,
                Connection)
                                       {
                                           Transaction = _mTheTransaction,
                                           CommandTimeout = CCmdTimeOut
                                       };
            if (parameters != null)
            {
                foreach (SqlParameter sqlParameter in parameters)
                {
                    sqlAdapter.SelectCommand.Parameters.Add(sqlParameter);
                }
            }
            var dtTable = new DataTable();
            sqlAdapter.Fill(dtTable);
            sqlAdapter.SelectCommand.Parameters.Clear();
            if ((_mTheTransaction == null))
            {
                CloseConnection();
            }
            return dtTable;
        }

        public DataTable AddToDataTable
            (
            DataTable data,
            string strSql,
            List<SqlParameter> parameters = null)
        {
            var sqlAdapter = new SqlDataAdapter();
            if ((_mTheTransaction == null))
            {
                OpenConnection();
            }

            sqlAdapter.SelectCommand = new SqlCommand
                (
                strSql,
                Connection)
                                       {
                                           Transaction = _mTheTransaction,
                                           CommandTimeout = CCmdTimeOut
                                       };
            if (parameters != null)
            {
                foreach (SqlParameter sqlParameter in parameters)
                {
                    sqlAdapter.SelectCommand.Parameters.Add(sqlParameter);
                }
            }
            sqlAdapter.Fill(data);
            sqlAdapter.SelectCommand.Parameters.Clear();
            if ((_mTheTransaction == null))
            {
                CloseConnection();
            }
            return data;
        }

        public DataTable GetDataIListTable
            (
            string strSql,
            List<SqlParameter> parameters = null)
        {
            var sqlAdapter = new SqlDataAdapter();
            if ((_mTheTransaction == null))
            {
                OpenConnection();
            }

            sqlAdapter.SelectCommand = new SqlCommand
                (
                strSql,
                Connection)
                                       {
                                           Transaction = _mTheTransaction,
                                           CommandTimeout = CCmdTimeOut
                                       };
            if (parameters != null)
            {
                foreach (SqlParameter sqlParameter in parameters)
                {
                    sqlAdapter.SelectCommand.Parameters.Add(sqlParameter);
                }
            }
            var dtTable = new DataTable();
            sqlAdapter.Fill(dtTable);
            sqlAdapter.SelectCommand.Parameters.Clear();
            if ((_mTheTransaction == null))
            {
                CloseConnection();
            }
            return dtTable;
        }

        public CurrentUserPermissions GetUserPermissions(string userId)
        {
            CurrentUserPermissions cuPermissions = null;
            //ToDo Add details of the table which stores users permissions
            DataTable dtcheckPerm = GetDataTable("select * from AQS_SYSTEM_USERS where SU_SC_USERID = '" + userId + "'");

            if (dtcheckPerm != null && dtcheckPerm.Rows.Count > 0)
            {
                cuPermissions = new CurrentUserPermissions
                                {
                                    View = Convert.ToInt16(dtcheckPerm.Rows[0]["SU_VIEW"]),
                                    Edit = Convert.ToInt16(dtcheckPerm.Rows[0]["SU_EDIT"]),
                                    Delete = Convert.ToInt16(dtcheckPerm.Rows[0]["SU_DELETE"]),
                                    Duplicate = Convert.ToInt16(dtcheckPerm.Rows[0]["SU_DUPLICATE"]),
                                    Approval = Convert.ToInt16(dtcheckPerm.Rows[0]["SU_APPROVAL"])
                                };
            }
            return cuPermissions;
        }

        #endregion Connection Methods

        #region Connection Methods

        public string DbConnectionString
        {
            get
            {
                return string.Format
                    (
                        CConStringNoWin,
                        _mDbServer,
                        _mDbDatabaseName,
                        _mDbUserId,
                        _mDbUserPassword);
            }
        }

        private void OpenConnection()
        {
            // Opens a connection string
            try
            {
                if ((Connection == null))
                {
                    Connection = new SqlConnection();
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
                switch (Connection.State)
                {
                    case ConnectionState.Closed:
                        Connection.ConnectionString = connectionString;
                        Connection.Open();
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

        public bool TestDbConnection()
        {
            try
            {
                if (Connection == null)
                {
                    Connection = new SqlConnection();
                }

                string dbName = string.IsNullOrEmpty(_mDbDatabaseName)
                                    ? ""
                                    : _mDbDatabaseName;

                string connectionString = String.Format
                    (
                        CConStringNoWin,
                        _mDbServer,
                        dbName,
                        _mDbUserId,
                        _mDbUserPassword);

                switch (Connection.State)
                {
                    case ConnectionState.Closed:
                        Connection.ConnectionString = connectionString;
                        Connection.Open();
                        Connection.Close();
                        break;
                }
                return true;
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

        private void CloseConnection()
        {
            //  Closes Connection
            if ((Connection.State != ConnectionState.Closed))
            {
                Connection.Close();
            }
        }

        public void BeginTransaction()
        {
            BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void BeginTransaction(IsolationLevel type)
        {
            OpenConnection();
            _mTheTransaction = Connection.BeginTransaction(type);
        }

        public void CommitTransaction()
        {
            int tranCount = Convert.ToInt32(GetSingleValue(CSqlTranCount));
            if ((_mTheTransaction != null
                 && (tranCount > 0)))
            {
                _mTheTransaction.Commit();
            }
            _mTheTransaction = null;
            CloseConnection();
        }

        public void RollbackTransaction()
        {
            int tranCount = Convert.ToInt32(GetSingleValue(CSqlTranCount));
            if ((_mTheTransaction != null
                 && (tranCount > 0)))
            {
                _mTheTransaction.Rollback();
            }
            _mTheTransaction = null;
            CloseConnection();
        }

        public string CallStoredProcedure
            (
            string aExecSp,
            List<SqlParameter> parameters = null,
            SqlParameter outputParameter = null)
        {
            var sqlAdapter = new SqlDataAdapter();

            string strSql = aExecSp;
            string value = "";

            if ((_mTheTransaction == null))
            {
                OpenConnection();
            }

            sqlAdapter.SelectCommand = new SqlCommand
                (
                strSql,
                Connection)
                                       {
                                           Transaction = _mTheTransaction,
                                           CommandTimeout = CCmdTimeOut,
                                           CommandType = CommandType.StoredProcedure
                                       };

            //Create the Input parameters

            sqlAdapter.SelectCommand.Parameters.Clear();
            if (parameters != null)
            {
                foreach (SqlParameter sqlParameter in parameters)
                {
                    sqlAdapter.SelectCommand.Parameters.Add(sqlParameter);
                }
            }

            //Fetch the output parameter after doing the Fill
            if (outputParameter != null)
            {
                sqlAdapter.SelectCommand.Parameters[outputParameter.ParameterName].Direction = ParameterDirection.Output;
                sqlAdapter.SelectCommand.Parameters[outputParameter.ParameterName].SqlDbType = SqlDbType.VarChar;
                sqlAdapter.SelectCommand.Parameters[outputParameter.ParameterName].Size = 500;
            }

            var dtTable = new DataTable();
            sqlAdapter.Fill(dtTable);
            if (outputParameter != null)
            {
                value = (string)sqlAdapter.SelectCommand.Parameters[outputParameter.ParameterName].Value;
            }
            sqlAdapter.SelectCommand.Parameters.Clear();
            if ((_mTheTransaction == null))
            {
                CloseConnection();
            }
            return value;
        }

        public SqlConnection UpdateDataTable
            (
            string strSql,
            string updateSqlCommand,
            DataRow drRow = null,
            List<SqlParameter> parameters = null)
        {
            TestDbConnection();
            Connection.Open();

            SqlTransaction sqlTransaction = Connection.BeginTransaction();
            var cmd = new SqlCommand
                (
                updateSqlCommand,
                Connection,
                sqlTransaction)
                      {
                          Connection = Connection
                      };

            if (parameters != null)
            {
                foreach (SqlParameter sqlParameter in parameters)
                {
                    cmd.Parameters.Add(sqlParameter);
                }
            }
            try
            {
                cmd.ExecuteNonQuery();
                sqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                if (drRow != null)
                {
                    throw new Exception
                        (
                        "Error occured during updating the row!" + _mDbDatabaseName + Environment.NewLine +
                        Environment.NewLine
                        + "Details :" + ex.Message,
                        ex);
                }
                sqlTransaction.Rollback();
                throw new Exception
                    (
                    "Error occured during updating the row!" + _mDbDatabaseName + Environment.NewLine +
                    Environment.NewLine
                    + "Details :" + ex.Message,
                    ex);
            }

            return Connection;
        }

        public SqlConnection DeleteDataTable
            (
            string strSql,
            string deleteSqlCommand,
            DataRow drRow = null,
            List<SqlParameter> parameters = null)
        {
            TestDbConnection();
            Connection.Open();

            SqlTransaction sqlTransaction = Connection.BeginTransaction();
            var cmd = new SqlCommand
                (
                deleteSqlCommand,
                Connection,
                sqlTransaction)
                      {
                          Connection = Connection
                      };

            if (parameters != null)
            {
                foreach (SqlParameter sqlParameter in parameters)
                {
                    cmd.Parameters.Add(sqlParameter);
                }
            }
            try
            {
                cmd.ExecuteNonQuery();
                sqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                throw new Exception
                    (
                    "Error occured during Deleting the row!" + _mDbDatabaseName + Environment.NewLine +
                    Environment.NewLine
                    + "Details :" + ex.Message,
                    ex);
            }

            return Connection;
        }

        public SqlConnection InsertDataTable
            (
            string strSql,
            string insertSqlCommand,
            DataRow drRow = null,
            List<SqlParameter> parameters = null)
        {
            TestDbConnection();
            Connection.Open();

            SqlTransaction sqlTransaction = Connection.BeginTransaction();
            var cmd = new SqlCommand
                (
                insertSqlCommand,
                Connection,
                sqlTransaction)
                      {
                          Connection = Connection
                      };

            if (parameters != null)
            {
                foreach (SqlParameter sqlParameter in parameters)
                {
                    cmd.Parameters.Add(sqlParameter);
                }
            }
            try
            {
                cmd.ExecuteNonQuery();
                sqlTransaction.Commit();
            }
            catch (SqlException ex)
            {
                sqlTransaction.Rollback();
                throw new Exception
                    (
                    "Error occured during inserting the row!" + _mDbDatabaseName + Environment.NewLine +
                    Environment.NewLine
                    + "Details :" + ex.Message,
                    ex);
            }

            return Connection;
        }

        //Execute SQL statment
        public void ExecuteSql(string strSql)
        {
            if ((_mTheTransaction == null))
            {
                OpenConnection();
            }

            var cmd = new SqlCommand
                (
                strSql,
                Connection,
                _mTheTransaction)
                      {
                          Connection = Connection
                      };
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception
                    (
                    "Error occured during inserting the row!" + _mDbDatabaseName + Environment.NewLine +
                    Environment.NewLine
                    + "Details :" + ex.Message,
                    ex);
            }
        }

        //Get single value
        public object GetSingleValue
            (
            string strSql,
            List<SqlParameter> parameters = null)
        {
            if (_mTheTransaction == null)
            {
                OpenConnection();
            }

            var command = new SqlCommand
                (
                strSql,
                Connection)
                          {
                              Transaction = _mTheTransaction,
                              CommandTimeout = CCmdTimeOut
                          };

            if ((parameters != null))
            {
                foreach (SqlParameter sqlParameter in parameters)
                {
                    command.Parameters.Add(sqlParameter);
                }
            }

            object functionReturnValue = command.ExecuteScalar();
            command.Parameters.Clear();

            if (_mTheTransaction == null)
            {
                CloseConnection();
            }
            return functionReturnValue;
        }

        #endregion Connection Methods

        #region Constants

        private const string CConStringNoWin = "Server={0};Database={1};Uid={2};Pwd={3}";
        private const string CConStringWin = "Server={0};Database={1};Trusted_Connection=Yes";
        private const int CCmdTimeOut = 600;
        private const string CSqlTranCount = "SELECT @@TRANCOUNT";

        #endregion Constants
    }
}