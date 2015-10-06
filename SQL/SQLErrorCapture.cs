using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Re_useable_Classes.SQL
{
    public class SqlErrorCapture
    {
        private static string _aSqlStatement;
        private readonly Connection _aConnection;

        public SqlErrorCapture
            (
            Connection aConn,
            string aSqlStatement)
        {
            _aConnection = aConn;
            if (_aConnection == null)
            {
                return;
            }
            _aSqlStatement = aSqlStatement;

            aConn.Conn.InfoMessage += (Conn_InfoMessage);
        }

        private void Conn_InfoMessage
            (
            object sender,
            SqlInfoMessageEventArgs e)
        {
            if (_aConnection.Conn.State == ConnectionState.Closed)
            {
                return;
            }
            Console.WriteLine(e.Errors[0].Message);
            Console.ReadLine();
            if (e.Errors[0].Message == "Warning: Null value is eliminated by an aggregate or other SET operation.")
            {
            }
            else
            {
                MessageBox.Show
                    (
                        "Error Recieved - Unable to perform query successfully\r\n\r\n" + e.Errors[0].Message
                        + "\r\n\r\n" +
                        _aSqlStatement,
                        "\r\n\r\nSQL Information Returned",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
            _aConnection.CloseConnection();
        }
    }
}
