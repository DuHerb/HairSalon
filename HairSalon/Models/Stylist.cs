using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;
namespace HairSalon.Models
{
    public class Stylist
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        int _id;
        public int Id {get=> _id; set=> _id = value;}

        public Stylist(int id = 0, string firstName = "default", string lastName = "default")
        {
            FirstName = firstName;
            LastName = lastName;
            _id = id;
        }

        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
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

        public void Save()
        {

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




    }
}