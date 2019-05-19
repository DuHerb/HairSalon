using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;
namespace HairSalon.Models
{
    public class Client
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public int Id {get;set;}
        public string Phone {get;set;}

        public int StylistId {get;set;}

        public Client( int stylistId, string firstName = "default", string lastName = "default", string phoneNumber = "none")
        {
            FirstName = firstName;
            LastName = lastName;
            StylistId = stylistId;
            Phone = phoneNumber;
        }


        public override bool Equals(System.Object otherItem)
        {
            if (!(otherItem is Client))
            {
                return false;
            }
            else
            {
                Client newClient = (Client) otherItem;
                bool nameEquality = (this.FirstName == newClient.FirstName && this.LastName == newClient.LastName);
                bool idEquality = (this.Id == newClient.Id && this.StylistId == newClient.StylistId);
                return (nameEquality && idEquality);
            }
        }

        public static void ClearAllClients()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM clients;";
            cmd.ExecuteNonQuery();
            DB.Close(conn);
        }

        public static List<Client> GetAll()
        {
            List<Client> clients = new List<Client>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                Client newClient = new Client(rdr.GetInt32(1));
                newClient.Id = rdr.GetInt32(0);
                newClient.FirstName = rdr.GetString(2);
                newClient.LastName = rdr.GetString(3);
                clients.Add(newClient);
            }
            DB.Close(conn);
            return clients;
        }

            public static List<Client> GetAllByStylist(int stylistId)
        {
            List<Client> clients = new List<Client>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = @stylistId;";
            cmd.Parameters.AddWithValue("@stylistId", stylistId);
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                Client newClient = new Client(rdr.GetInt32(1));
                newClient.Id = rdr.GetInt32(0);
                newClient.FirstName = rdr.GetString(2);
                newClient.LastName = rdr.GetString(3);
                clients.Add(newClient);
            }
            DB.Close(conn);
            return clients;
        }

        public static Client GetClient(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            rdr.Read();
            Client foundClient = new Client(rdr.GetInt32(1));
            foundClient.Id = rdr.GetInt32(0);
            foundClient.FirstName = rdr.GetString(2);
            foundClient.LastName = rdr.GetString(3);
            foundClient.Phone = rdr.GetString(4);
            DB.Close(conn);
            return foundClient;
        }

        public static int CreateClient(int stylistId, string firstName, string lastName)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO clients (stylist_Id, first_name, last_Name) VALUES (@stylistId, @firstName, @lastName);";
            MySqlParameter description = new MySqlParameter();
            cmd.Parameters.AddWithValue("@stylistId", stylistId);
            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            cmd.ExecuteNonQuery();
            DB.Close(conn);
            return (int) cmd.LastInsertedId;
        }

        public void DeleteClient()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM clients WHERE Id = @clientId;";
            cmd.Parameters.AddWithValue("@clientId", Id);
            cmd.ExecuteNonQuery();
            DB.Close(conn);
        }

        public void ResetStylistId()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE clients SET stylist_id = 0 WHERE id = @clientId;";
            cmd.Parameters.AddWithValue("@clientId", this.Id);
            cmd.ExecuteNonQuery();
            DB.Close(conn);
        }

        public static void ResetAllByStylistId(int stylistId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE clients SET stylist_id = 0 WHERE stylist_id = @stylistId;";
            cmd.Parameters.AddWithValue("@stylistId", stylistId);
            cmd.ExecuteNonQuery();
            DB.Close(conn);
        }

        public void EditClientInfo(string firstName, string lastName, string phoneNumber)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE clients SET first_name = @firstName, last_name = @lastName, phone = @phoneNumber WHERE id = @clientId;";
            cmd.Parameters.AddWithValue("@clientId", Id);
            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            cmd.ExecuteNonQuery();
            DB.Close(conn);
        }
    }
}