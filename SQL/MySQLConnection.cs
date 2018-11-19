using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace Re_useable_Classes.SQL
{
    public static class MySqlConnec
    {
        public static MySqlConnection ConDataBase { get; set; }
        public static MySqlCommand CmdDataBase { get; set; }
        public static string ADBase { get; set; }

        public static MySqlConnection AMySqlConnection()
        {
            const string constring = "datasource =pcathomegroup.com;port=3306;username=sjbrett_Admin;password=Br3tt1981";
            const string query = "show databases";

            ConDataBase = new MySqlConnection(constring);
            CmdDataBase = new MySqlCommand
                (
                query,
                ConDataBase);
            try
            {
                ConDataBase.Open();
            }
            catch (Exception)
            {
                return ConDataBase;
            }
            return ConDataBase;
        }

        public static MySqlConnection AMySqlConnectionDb
            (
            string aDb,
            string aDatasource,
            string aPort,
            string aUsername,
            string aPassword,
            string aQuery)
        {
            ADBase = aDb;
            string constring = "datasource = " + aDatasource + ";database = " + ADBase + ";port=" + aPort +
                               ";username= " +
                               aUsername + ";password= " +
                               aPassword + "";
            const string query = "show databases";
            ConDataBase = new MySqlConnection(constring);
            CmdDataBase = new MySqlCommand
                (
                query,
                ConDataBase);
            try
            {
                ConDataBase.Open();
            }
            catch (Exception)
            {
                return ConDataBase;
            }

            return ConDataBase;
        }

        public static List<string> GetDatabases(MySqlConnection aConnection)
        {
            var aList = new List<string>();

            const string query = "show databases";
            CmdDataBase = new MySqlCommand
                (
                query,
                aConnection);
            try
            {
                MySqlDataReader myReader = CmdDataBase.ExecuteReader();

                {
                    while (myReader.Read())
                    {
                        string row = "";
                        for (int i = 0;
                            i < myReader.FieldCount;
                            i++)
                        {
                            row += myReader.GetValue(i)
                                .ToString();
                        }
                        aList.Add(row);
                    }
                    myReader.Close();
                }
            }
            catch (Exception)
            {
                return aList;
            }
            return aList;
        }

        public static DataGridView GetSetUpdateQueryData
            (
            MySqlConnection aConnection,
            string aQuery,
            DataGridView dgv)
        {
            var dataTable = new DataTable();

            try
            {
                if (aConnection.State != ConnectionState.Closed)
                {
                    aConnection.Close();
                }
                aConnection.Open();

                var cmd = new MySqlCommand
                          {
                              Connection = aConnection,
                              CommandText = aQuery
                          };
                cmd.ExecuteNonQuery();

                var da = new MySqlDataAdapter(cmd);
                da.Fill(dataTable);

                var cb = new MySqlCommandBuilder(da);

                dgv.DataSource = dataTable;
                dgv.DataMember = dataTable.TableName;
                dgv.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (aConnection != null)
                {
                    aConnection.Close();
                }
            }
            return dgv;
        }

        public static MySqlConnection AMySqlConnection
            (
            string aDatasource,
            string aPort,
            string aUsername,
            string aPassword,
            string aQuery)
        {
            string constring = "datasource = " + aDatasource + ";port=" + aPort + ";username= " + aUsername +
                               ";password= " +
                               aPassword + "";
            const string query = "show databases";
            ConDataBase = new MySqlConnection(constring);
            CmdDataBase = new MySqlCommand
                (
                query,
                ConDataBase);
            try
            {
                ConDataBase.Open();
            }
            catch (Exception)
            {
                return ConDataBase;
            }

            return ConDataBase;
        }

        public static List<string> GetSetUpdateQueryDataList
            (
            MySqlConnection aConnection,
            string aQuery,
            byte[] anarray = null)
        {
            if (aConnection.State != ConnectionState.Closed)
            {
                aConnection.Close();
            }
            aConnection.Open();
            var aList = new List<string>();
            if (string.IsNullOrEmpty(aQuery))
            {
                return aList;
            }
            string query = aQuery;

            CmdDataBase = new MySqlCommand
                (
                query,
                aConnection);
            if (anarray != null)
            {
                CmdDataBase.Parameters.AddWithValue(
                        "?p1",
                        anarray);
            }

            try
            {
                MySqlDataReader myReader = CmdDataBase.ExecuteReader();

                {
                    //myReader.Read();
                    while (myReader.Read())
                    {
                        string row = "";
                        for (int i = 0;
                            i < myReader.FieldCount;
                            i++)
                        {
                            row += myReader.GetValue(i)
                                .ToString();
                        }
                        aList.Add(row);
                    }
                    myReader.Close();
                }
            }
            catch (Exception)
            {
                using (MySqlDataReader myReader = CmdDataBase.ExecuteReader())
                {
                    //myReader.Read();
                    while (myReader.Read())
                    {
                        string row = "";
                        for (int i = 0;
                            i < myReader.FieldCount;
                            i++)
                        {
                            row += myReader.GetValue(i)
                                .ToString();
                        }
                        aList.Add(row);
                    }
                    myReader.Close();
                }
                aConnection.Close();
                return aList;
            }

            aConnection.Close();
            return aList;
        }
    }
}