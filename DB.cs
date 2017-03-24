using System.Data.SqlClient;

namespace PTT_Crawler
{
    class DB
    {
        SqlConnection myConn;

        public DB(string dbHost, string dbUser, string dbPass, string dbName)
        {
            string connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName + ";charset=utf8;";
            myConn = new SqlConnection(connStr);
        }

        public void open()
        {
            myConn.Open();
        }

        public void insertData(string tableName, string field, string value)
        {
            SqlCommand cmd = myConn.CreateCommand();
            cmd.CommandText = "INSERT INTO " + tableName + "(`" + field + "`) VALUES ('" + value + "')"; ;
            cmd.ExecuteNonQuery();
        }

        public void close()
        {
            myConn.Close();
        }
    }
}