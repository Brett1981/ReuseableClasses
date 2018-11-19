using Re_useable_Classes.Message_Helpers.Forms;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Re_useable_Classes.SQL
{
    public class Connection
    {
        public static Boolean SeqApi = true;
        private static SqlErrorCapture _aSqlErrorCapture;
        public String ADatabaseName;
        public String APassword;
        public String AServerAddress;
        public String AType;
        public String AUserName;
        public SqlConnection Conn;
        public String ConnStr;
        public string SqlErrorText { get; set; }

        //        return true;
        //    }
        //    Console.WriteLine(@"Connection Failed!");
        //    return false;
        //}
        public static string DoQuotes(string sql)
        {
            if (sql == null)
            {
                return "";
            }

            sql = sql.Replace
                (
                    Regex.Matches
                        (
                            sql,
                            @"[a-zA-Z]") + "'" + Regex.Matches
                                                     (
                                                         sql,
                                                         @"[a-zA-Z]"),
                    Regex.Matches
                        (
                            sql,
                            @"[a-zA-Z]") + "''" + Regex.Matches
                                                      (
                                                          sql,
                                                          @"[a-zA-Z]"));
            return "EXEC ('" + sql + "')";
        }

        public static void ExcuteNonQuery
            (
            Connection aConn,
            string asqlStmt)
        {
            if (aConn == null)
            {
                return;
            }
            if (aConn.Conn.State == ConnectionState.Closed)
            {
                aConn.Conn.Open();
            }
            SqlCommand command = aConn.Conn.CreateCommand();

            if (asqlStmt != null)
            {
                command.CommandText = asqlStmt;
            }
            if (asqlStmt != null && asqlStmt.Contains("'S'"))
            {
                asqlStmt = asqlStmt.Replace
                    (
                        "'S'",
                        "''''S'");
            }
            command.CommandType = CommandType.Text;

            IAsyncResult result = command.BeginExecuteNonQuery();
            while (!result.IsCompleted)
            {
                Thread.Sleep(100);
            }
            if (!result.IsCompleted)
            {
                return;
            }
            command.EndExecuteNonQuery(result);
        }

        public static void ExcuteNonQueryPreparedStatement(SqlCommand command)
        {
            if (command == null)
            {
                return;
            }
            //Check for "'" in singular form causing a problem with the SQL Statment
            foreach (object sqlParameter in from object sqlParameter in ((command.Parameters))
                                            from item in
                                                ((IEnumerable)((SqlParameter)(sqlParameter)).Value).Cast<object>()
                                                                                                     .Where
                                                (
                                                    item => item.ToString()
                                                                .Contains("'"))
                                            select sqlParameter)
            {
            }
            command.StatementCompleted += (SMECustContactCon_StatementCompleted);
            try
            {
                IAsyncResult result = command.BeginExecuteNonQuery();

                while (!result.IsCompleted)
                {
                    Thread.Sleep(100);
                }
                if (command.Connection != null && command.Connection.State == ConnectionState.Closed)
                {
                    return;
                }
                command.EndExecuteNonQuery(result);
            }
            catch (Exception ex)
            {
                MessageDialog.Show
                    (
                        "Error retrieved updating \r\n" + ex.InnerException,
                        "Error",
                        MessageDialog.MessageBoxButtons.Ok,
                        MessageDialog.MessageBoxIcon.Error,
                        "Please Check You Credentials Are Valid" + "\r\n" + ex.StackTrace);
            }
        }

        public void CloseConnection()
        {
            if (Conn == null || !Conn.State.ToString()
                                     .Equals("Open"))
            {
                return;
            }
            Conn.Close();
        }

        public Boolean CreateConnection
            (
            string userName,
            string password,
            string serverAddress,
            string databaseName,
            string type)
        {
            string aConnection = GetConnectionString
                (
                    userName,
                    password,
                    serverAddress,
                    databaseName,
                    type);
            try
            {
                if (aConnection != null)
                {
                    var builder = new SqlConnectionStringBuilder(aConnection)
                                  {
                                      MultipleActiveResultSets = true
                                  };
                    if (builder.ConnectionString != null)
                    {
                        switch (builder.ConnectionString)
                        {
                            case null:
                                break;

                            default:
                                Conn = new SqlConnection(builder.ConnectionString);

                                break;
                        }
                    }
                }

                Conn.Open();
                if (Conn.State.ToString()
                        .Equals("Open"))
                {
                    //conn.Close();
                    Console.WriteLine(@"Connection worked!");
                    AUserName = userName;
                    APassword = password;
                    AServerAddress = serverAddress;
                    ADatabaseName = databaseName;
                    AType = type;
                    return true;
                }
                Console.WriteLine(@"Connection Failed!");
            }
            catch (Exception ex)
            {
                MessageDialog.Show
                    (
                        "Connection Unsuccessful \r\n" + ex.InnerException,
                        "Error",
                        MessageDialog.MessageBoxButtons.Ok,
                        MessageDialog.MessageBoxIcon.Error,
                        "Please Check You Credentials Are Valid" + "\r\n" + ex.StackTrace);
            }

            return false;
        }

        public DataTable ExcuteReader
            (
            Connection aConn,
            String asqlStmt)
        {
            if (asqlStmt.Contains("'S'"))
            {
                asqlStmt = asqlStmt.Replace
                    (
                        "'S'",
                        "''''S'");
            }
            using (var aDataTable = new DataTable())
            {
                SqlCommand command;
                if (aConn != null && aConn.Conn != null)
                {
                    if (aConn.Conn.State == ConnectionState.Closed)
                    {
                        aConn.Conn.Open();
                    }
                }
                if (aConn != null)
                {
                    _aSqlErrorCapture = new SqlErrorCapture
                        (
                        aConn,
                        asqlStmt);
                }
                if (aConn != null && aConn.Conn != null)
                {
                    using (command = aConn.Conn.CreateCommand())
                    {
                        command.CommandText = asqlStmt;
                        command.CommandType = CommandType.Text;

                        try
                        {
                            if (!IsConnectionOpen())
                            {
                                aConn.CreateConnection
                                    (
                                        aConn.AUserName,
                                        aConn.APassword,
                                        aConn.AServerAddress,
                                        aConn.ADatabaseName,
                                        aConn.AType);
                                if (aConn.Conn != null)
                                {
                                    command = aConn.Conn.CreateCommand();
                                }
                                command.CommandText = asqlStmt;
                                command.CommandType = CommandType.Text;
                                if (command.Connection.State != ConnectionState.Closed)
                                {
                                    SqlDataReader reader = command.ExecuteReader();
                                    aDataTable.Load(reader);
                                }
                                Console.Out.WriteLine("Issue with SQL connection: " + aConn);
                            }
                            else
                            {
                                if (aConn.Conn != null)
                                {
                                    command = aConn.Conn.CreateCommand();
                                }
                                command.CommandText = asqlStmt;
                                command.CommandType = CommandType.Text;
                                try
                                {
                                    command.Connection.FireInfoMessageEventOnUserErrors = true;
                                    SqlDataReader reader = command.ExecuteReader();
                                    aDataTable.Load(reader);
                                }
                                catch (Exception ex)
                                {
                                    MessageDialog.Show
                                        (
                                            "Issue with SQL connection \r\n" + ex.InnerException,
                                            "Error",
                                            MessageDialog.MessageBoxButtons.Ok,
                                            MessageDialog.MessageBoxIcon.Error,
                                            "Please Check You Credentials Are Valid" + "\r\n" + ex.StackTrace);
                                }
                            }
                        }
                        catch (SqlException e)
                        {
                            if (!IsConnectionOpen())
                            {
                                //connection closed, open it again.
                                aConn.CreateConnection
                                    (
                                        aConn.AUserName,
                                        aConn.APassword,
                                        aConn.AServerAddress,
                                        aConn.ADatabaseName,
                                        aConn.AType);
                                if (aConn.Conn != null)
                                {
                                    command = aConn.Conn.CreateCommand();
                                }
                                command.CommandText = asqlStmt;
                                command.CommandType = CommandType.Text;
                                SqlDataReader reader = command.ExecuteReader();
                                aDataTable.Load(reader);
                                MessageDialog.Show
                                    (
                                        "Issue with SQL connection \r\n" + e.InnerException,
                                        "Error",
                                        MessageDialog.MessageBoxButtons.Ok,
                                        MessageDialog.MessageBoxIcon.Error,
                                        "Please Check You Credentials Are Valid" + "\r\n" + e.StackTrace);
                            }
                            else
                            {
                                // else try closing it and going again.

                                aConn.CloseConnection();
                                aConn.CreateConnection
                                    (
                                        aConn.AUserName,
                                        aConn.APassword,
                                        aConn.AServerAddress,
                                        aConn.ADatabaseName,
                                        aConn.AType);
                                if (aConn.Conn != null)
                                {
                                    command = aConn.Conn.CreateCommand();
                                }
                                command.CommandText = asqlStmt;
                                command.CommandType = CommandType.Text;
                                try
                                {
                                    SqlDataReader reader = command.ExecuteReader();
                                    aDataTable.Load(reader);
                                }
                                catch (Exception ex)
                                {
                                    MessageDialog.Show
                                        (
                                            "Issue with SQL connection \r\n" + ex.InnerException,
                                            "Error",
                                            MessageDialog.MessageBoxButtons.Ok,
                                            MessageDialog.MessageBoxIcon.Error,
                                            "Please Check You Credentials Are Valid" + "\r\n" + ex.StackTrace);
                                }
                            }
                        }
                    }
                }

                return aDataTable;
            }
        }

        public DataTable ExcuteReader
            (
            Connection aConn,
            String asqlStmt,
            Object aDataObject)
        {
            if (asqlStmt.Contains("'S'"))
            {
                asqlStmt = asqlStmt.Replace
                    (
                        "'S'",
                        "''''S'");
            }
            using (var aDataTable = new DataTable())
            {
                SqlCommand command;
                if (aConn != null)
                {
                    _aSqlErrorCapture = new SqlErrorCapture
                        (
                        aConn,
                        asqlStmt);
                }
                if (aConn != null && aConn.Conn != null)
                {
                    using (command = aConn.Conn.CreateCommand())
                    {
                        command.CommandText = asqlStmt;
                        //String.Format("select * from [dbo].[USER_CONTROL_LAYOUT] where [USER_ID] = '{0}'", aUser_Id);

                        command.CommandType = CommandType.Text;

                        try
                        {
                            SqlDataReader reader = command.ExecuteReader();
                            aDataTable.Load(reader);
                            if (aDataObject != null)
                            {
                                SqlErrorText = "Status: ok";
                            }
                        }
                        catch (SqlException e)
                        {
                            if (!IsConnectionOpen())
                            {
                                //connection closed, open it again.
                                if (aDataObject != null)
                                {
                                    SqlErrorText =
                                        "Status: Error with this SQL request. Trying to reconnect and redo query, Error message is: "
                                        +
                                        e.Message;
                                }
                                try
                                {
                                    aConn.CreateConnection
                                        (
                                            aConn.AUserName,
                                            aConn.APassword,
                                            aConn.AServerAddress,
                                            aConn.ADatabaseName,
                                            aConn.AType);
                                    if (aConn.Conn != null)
                                    {
                                        command = aConn.Conn.CreateCommand();
                                    }
                                    command.CommandText = asqlStmt;
                                    //String.Format("select * from [dbo].[USER_CONTROL_LAYOUT] where [USER_ID] = '{0}'", aUser_Id);

                                    command.CommandType = CommandType.Text;
                                    SqlDataReader reader = command.ExecuteReader();
                                    aDataTable.Load(reader);
                                    Console.Out.WriteLine("Issue with SQL connection: " + e);
                                }
                                catch (Exception ex)
                                {
                                    MessageDialog.Show
                                        (
                                            "Issue with SQL connection \r\n" + ex.InnerException,
                                            "Error",
                                            MessageDialog.MessageBoxButtons.Ok,
                                            MessageDialog.MessageBoxIcon.Error,
                                            "Please Check You Credentials Are Valid" + "\r\n" + ex.StackTrace);
                                }
                            }
                            //removed here to try and stop crashing.
                            else
                            {
                                // else try closing it and going again.
                                if (aDataObject != null)
                                {
                                    SqlErrorText =
                                        "Status: Error with this SQL request. Trying force close connection, open a new connection and redo query, Error message is: "
                                        +
                                        e.Message;
                                }
                                //  MessageBox.Show("Error with this SQL request. Trying force close connection, open a new connection and redo query, Error message is: " + e.Message);
                                try
                                {
                                    aConn.CloseConnection();
                                    aConn.CreateConnection
                                        (
                                            aConn.AUserName,
                                            aConn.APassword,
                                            aConn.AServerAddress,
                                            aConn.ADatabaseName,
                                            aConn.AType);
                                    if (aConn.Conn != null)
                                    {
                                        command = aConn.Conn.CreateCommand();
                                    }
                                    command.CommandText = asqlStmt;
                                    //String.Format("select * from [dbo].[USER_CONTROL_LAYOUT] where [USER_ID] = '{0}'", aUser_Id);

                                    command.CommandType = CommandType.Text;
                                    SqlDataReader reader = command.ExecuteReader();
                                    if (!reader.IsClosed)
                                    {
                                        aDataTable.Load(reader);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageDialog.Show
                                        (
                                            "Issue with SQL connection \r\n" + ex.InnerException,
                                            "Error",
                                            MessageDialog.MessageBoxButtons.Ok,
                                            MessageDialog.MessageBoxIcon.Error,
                                            "Please Check You Credentials Are Valid" + "\r\n" + ex.StackTrace);
                                }
                            }
                        }
                    }
                }

                // aSmeCallCon.SQLErrorText = "Error with this SQL request. Trying force close connection, open a new connection and redo query, Error message is: ";
                return aDataTable;
            }
        }

        public Boolean IsConnectionOpen()
        {
            return Conn != null && Conn.State.ToString()
                                       .Equals("Open");
        }

        private static void SMECustContactCon_StatementCompleted
            (
            object sender,
            StatementCompletedEventArgs e)
        {
            if (e.RecordCount <= 0)
            {
                Console.WriteLine("error " + e);
            }
        }

        private string GetConnectionString
            (
            string userName,
            string password,
            string serverAddress,
            string databaseName,
            string type)
        {
            ConnStr = null;
            if (userName != null && !userName.Equals(""))
            {
                if (!serverAddress.Equals(""))
                {
                    if (!type.Equals("WIN"))
                    {
                        if (databaseName != String.Empty)
                        {
                            return ConnStr = "Server=" + serverAddress + ";user id=" +
                                             userName + ";password=" + password + ";Asynchronous Processing=true" +
                                             ";initial catalog=" + databaseName + ";";
                        }
                        return ConnStr = "Server=" + serverAddress + ";user id=" +
                                         userName + ";password=" + password + ";Asynchronous Processing=true" +
                                         ";initial catalog=" + databaseName + ";";
                    }
                    return ConnStr = databaseName == String.Empty
                                         ? "Server=" + serverAddress + ";user id=" +
                                           userName + ";Asynchronous Processing=true;Integrated Security=true;"
                                         : "Server=" + serverAddress + ";user id=" +
                                           userName + ";Asynchronous Processing=true;Integrated Security=true" +
                                           ";initial catalog=" + databaseName + ";";
                }
                /* using windows security */
                throw new ArgumentException
                    (
                    String.Format
                        (
                            "No Sql Server specified {0}",
                            "ARG0"));
            }
            return MessageBox.Show
                (
                    "No UserName Specified",
                    "Error!")
                             .ToString();
        }
    }
}