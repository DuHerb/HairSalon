using System;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{

    public partial class DB
    {
        public static MySqlConnection Connection()
        {
            MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
            return conn;
        }

        public static void CloseDB(MySqlConnection conn)
        {
            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }
        }
    }
    public static class DBConfiguration
    {
      public static string ConnectionString = "server=localhost;user id=root;password=root;port=8899;database=dustin_herboldshimer;";
    }
}