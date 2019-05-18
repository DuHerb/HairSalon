using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;
namespace HairSalon.Models
{
    public class Stylist
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public int Id {get;set;}

        public Stylist(string firstName = "default", string lastName = "default")
        {
            FirstName = firstName;
            LastName = lastName;
        }

       public override bool Equals(System.Object otherItem)
        {
            if (!(otherItem is Stylist))
            {
                return false;
            }
            else
            {
                Stylist newStylist = (Stylist) otherItem;
                bool nameEquality = (this.FirstName == newStylist.FirstName && this.LastName == newStylist.LastName);
                bool idEquality = (this.Id == newStylist.Id);
                return (nameEquality && idEquality);
            }
        }

        public static void ClearAllStylists()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylists;";
            cmd.ExecuteNonQuery();
            DB.Close(conn);
        }

        public static List<Stylist> GetAll()
        {
            List<Stylist> stylists = new List<Stylist>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                Stylist newStylist = new Stylist();
                newStylist.Id = rdr.GetInt32(0);
                newStylist.FirstName = rdr.GetString(1);
                newStylist.LastName = rdr.GetString(2);
                stylists.Add(newStylist);
            }
            DB.Close(conn);
            return stylists;
        }

        public static Stylist GetStylist(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylists WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            rdr.Read();
            Stylist foundStylist = new Stylist();
            foundStylist.Id = rdr.GetInt32(0);
            foundStylist.FirstName = rdr.GetString(1);
            foundStylist.LastName = rdr.GetString(2);

            DB.Close(conn);
            return foundStylist;
        }

        public static int CreateStylist(string firstName, string lastName)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylists (first_name, last_Name) VALUES (@firstName, @lastName);";
            MySqlParameter description = new MySqlParameter();
            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            cmd.ExecuteNonQuery();
            DB.Close(conn);
            return (int) cmd.LastInsertedId;
        }

        public void DeleteStylist()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylists WHERE id = @stylistId;";
            MySqlParameter description = new MySqlParameter();
            cmd.Parameters.AddWithValue("@stylistId", this.Id);
            cmd.ExecuteNonQuery();
            DB.Close(conn);
        }
    }
}