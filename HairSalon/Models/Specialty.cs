using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;
namespace HairSalon.Models
{
    public class Specialty
    {
        public string Name {get;set;}
        public int Id {get;set;}

        public Specialty(string name)
        {
            Name = name;
        }

        public override bool Equals(System.Object otherItem)
        {
            if (!(otherItem is Specialty))
            {
                return false;
            }
            else
            {
                Specialty newSpecialty = (Specialty) otherItem;
                bool nameEquality = (this.Name == newSpecialty.Name);
                bool idEquality = (this.Id == newSpecialty.Id);
                return (nameEquality && idEquality);
            }
        }

        public static void ClearSpecialties()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM specialties;";
            cmd.ExecuteNonQuery();
            DB.Close(conn);
        }

        public static List<Specialty> GetAll()
        {
            List<Specialty> specialties = new List<Specialty>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialties;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                Specialty newSpecialty = new Specialty(rdr.GetString(1));
                specialties.Add(newSpecialty);
            }
            DB.Close(conn);
            return specialties;
        }

        //     public static List<Specialty> GetAllByStylist(int stylistId)
        // {
        //     List<Client> clients = new List<Client>{};
        //     MySqlConnection conn = DB.Connection();
        //     conn.Open();
        //     var cmd = conn.CreateCommand() as MySqlCommand;
        //     cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = @stylistId;";
        //     cmd.Parameters.AddWithValue("@stylistId", stylistId);
        //     MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        //     while(rdr.Read())
        //     {
        //         Client newClient = new Client(rdr.GetInt32(1));
        //         newClient.Id = rdr.GetInt32(0);
        //         newClient.FirstName = rdr.GetString(2);
        //         newClient.LastName = rdr.GetString(3);
        //         clients.Add(newClient);
        //     }
        //     DB.Close(conn);
        //     return clients;
        // }

        public static Specialty GetSpecialty(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialties WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            rdr.Read();
            Specialty foundSpecialty = new Specialty(rdr.GetString(1));
            foundSpecialty.Id = rdr.GetInt32(0);
            DB.Close(conn);
            return foundSpecialty;
        }

        public static int CreateSpecialty(string name)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO specialties (name) VALUES (@name);";
            cmd.Parameters.AddWithValue("@name", name);
            cmd.ExecuteNonQuery();
            DB.Close(conn);
            return (int) cmd.LastInsertedId;
        }

        // public void DeleteClient()
        // {
        //     MySqlConnection conn = DB.Connection();
        //     conn.Open();
        //     MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        //     cmd.CommandText = @"DELETE FROM clients WHERE Id = @clientId;";
        //     cmd.Parameters.AddWithValue("@clientId", Id);
        //     cmd.ExecuteNonQuery();
        //     DB.Close(conn);
        // }

        // public void ResetStylistId()
        // {
        //     MySqlConnection conn = DB.Connection();
        //     conn.Open();
        //     MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        //     cmd.CommandText = @"UPDATE clients SET stylist_id = 0 WHERE id = @clientId;";
        //     cmd.Parameters.AddWithValue("@clientId", this.Id);
        //     cmd.ExecuteNonQuery();
        //     DB.Close(conn);
        // }

        // public static void ResetAllByStylistId(int stylistId)
        // {
        //     MySqlConnection conn = DB.Connection();
        //     conn.Open();
        //     MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        //     cmd.CommandText = @"UPDATE clients SET stylist_id = 0 WHERE stylist_id = @stylistId;";
        //     cmd.Parameters.AddWithValue("@stylistId", stylistId);
        //     cmd.ExecuteNonQuery();
        //     DB.Close(conn);
        // }

        // public void EditClientInfo(string firstName, string lastName, string phoneNumber)
        // {
        //     MySqlConnection conn = DB.Connection();
        //     conn.Open();
        //     MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        //     cmd.CommandText = @"UPDATE clients SET first_name = @firstName, last_name = @lastName, phone = @phoneNumber WHERE id = @clientId;";
        //     cmd.Parameters.AddWithValue("@clientId", Id);
        //     cmd.Parameters.AddWithValue("@firstName", firstName);
        //     cmd.Parameters.AddWithValue("@lastName", lastName);
        //     cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
        //     cmd.ExecuteNonQuery();
        //     DB.Close(conn);
        // }
    }
}