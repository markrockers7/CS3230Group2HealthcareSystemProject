using HealthcareSystemProjectCS3230.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareSystemProjectCS3230.DAL
{
    public class NurseDAL
    {
        /*
         * Retrieves a list of all nurses from the database.
         *
         */
        public List<Nurse> GetAllNurses()
        {
            var nurses = new List<Nurse>();
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query = "SELECT nur.id, nur.username, per.person_id, per.first_name, per.last_name, per.birthdate, per.phone_number, per.address_id, " +
                "a.street, a.city, a.zipcode, a.state " +
                "FROM Person per " +
                "JOIN Address a ON per.address_id = a.address_id " +
                "JOIN Nurse nur ON per.person_id = nur.person_id";
            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                nurses.Add(new Nurse(
                    reader.GetInt32("id"),
                    reader.GetInt32("person_id"),
                    reader.GetString("username"))
                {
                    FirstName = reader.GetString("first_name"),
                    LastName = reader.GetString("last_name"),
                    Birthdate = reader.GetDateTime("birthdate"),
                    PhoneNumber = reader.GetString("phone_number"),
                    Address = new Address
                    {
                        AddressId = reader.GetInt32("address_id"),
                        Street = reader.GetString("street"),
                        City = reader.GetString("city"),
                        Zipcode = reader.GetString("zipcode"),
                        State = reader.GetString("state")
                    }
                });
            }

            return nurses;
        }

        /*
         * Retrieves a nurse from the database by their ID.
         * @param id The ID of the nurse to retrieve.
         */
        public Nurse GetNurseByID(int id)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();

            const string query = @"
            SELECT n.id, n.person_id, n.username,
                   p.first_name, p.last_name, p.birthdate, p.phone_number, p.address_id,
                   a.street, a.city, a.zipcode, a.state
            FROM Nurse n
            JOIN Person p ON n.person_id = p.person_id
            JOIN Address a ON p.address_id = a.address_id
            WHERE n.id = @id";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            using var reader = command.ExecuteReader();
            if (reader.Read())      
            {
                return new Nurse(
                    reader.GetInt32("id"),
                    reader.GetInt32("person_id"),
                    reader.GetString("username"))
                {
                    FirstName = reader.GetString("first_name"),
                    LastName = reader.GetString("last_name"),
                    Birthdate = reader.GetDateTime("birthdate"),
                    PhoneNumber = reader.GetString("phone_number"),
                    Address = new Address
                    {
                        AddressId = reader.GetInt32("address_id"),
                        Street = reader.GetString("street"),
                        City = reader.GetString("city"),
                        Zipcode = reader.GetString("zipcode"),
                        State = reader.GetString("state")
                    }
                };
            }

            return null;
        }
        /*
         * Adds a new nurse to the database.
         * @param nurse The nurse object to add.
         * @param password The password for the nurse's account.
         */
        public bool AddNurse(Nurse nurse, string password)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction();
            try
            {
                // Insert Address
                const string insertAddress =
                    "INSERT INTO Address (street, city, zipcode, state) VALUES (@street, @city, @zipcode, @state)";
                using var cmdAddr = new MySqlCommand(insertAddress, connection, transaction);
                cmdAddr.Parameters.Add("@street", MySqlDbType.VarChar).Value = nurse.Address.Street;
                cmdAddr.Parameters.Add("@city", MySqlDbType.VarChar).Value = nurse.Address.City;
                cmdAddr.Parameters.Add("@zipcode", MySqlDbType.String).Value = nurse.Address.Zipcode;
                cmdAddr.Parameters.Add("@state", MySqlDbType.String).Value = nurse.Address.State;
                cmdAddr.ExecuteNonQuery();

                // get last address id
                using var cmdLast = new MySqlCommand("SELECT LAST_INSERT_ID()", connection, transaction);
                var addressId = Convert.ToInt32(cmdLast.ExecuteScalar());

                // Insert Person
                const string insertPerson =
                    "INSERT INTO Person (first_name, last_name, birthdate, phone_number, address_id) " +
                    "VALUES (@first, @last, @birthdate, @phone, @addressId)";
                using var cmdPer = new MySqlCommand(insertPerson, connection, transaction);
                cmdPer.Parameters.Add("@first", MySqlDbType.VarChar).Value = nurse.FirstName;
                cmdPer.Parameters.Add("@last", MySqlDbType.VarChar).Value = nurse.LastName;
                cmdPer.Parameters.Add("@birthdate", MySqlDbType.Date).Value = nurse.Birthdate;
                cmdPer.Parameters.Add("@phone", MySqlDbType.String).Value = nurse.PhoneNumber;
                cmdPer.Parameters.Add("@addressId", MySqlDbType.Int32).Value = addressId;
                cmdPer.ExecuteNonQuery();

                using var cmdLastPer = new MySqlCommand("SELECT LAST_INSERT_ID()", connection, transaction);
                var personId = Convert.ToInt32(cmdLastPer.ExecuteScalar());

                const string insertLogin =
                    "INSERT INTO Account (username, password, type) VALUES (@username, @password, 'nurse')";
                using var cmdLogin = new MySqlCommand(insertLogin, connection, transaction);
                cmdLogin.Parameters.Add("@username", MySqlDbType.VarChar).Value = nurse.Username;
                cmdLogin.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
                cmdLogin.ExecuteNonQuery();

                // Insert Nurse
                const string insertNurse =
                    "INSERT INTO Nurse (person_id, username) VALUES (@personId, @username)";
                using var cmdNurse = new MySqlCommand(insertNurse, connection, transaction);
                cmdNurse.Parameters.Add("@personId", MySqlDbType.Int32).Value = personId;
                cmdNurse.Parameters.Add("@username", MySqlDbType.VarChar).Value = nurse.Username;
                cmdNurse.ExecuteNonQuery();

                

                transaction.Commit();
                return true;
            }
            catch
            {
                try { transaction.Rollback(); } catch { }
                return false;
            }
        }

        /*
         * Updates an existing nurse in the database.
         * @param nurse The nurse object with updated information.
         */
        public bool UpdateNurse(Nurse nurse)
        {
           using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction();
            try
            {
                // Update Address
                const string updateAddress =
                    "UPDATE Address SET street = @street, city = @city, zipcode = @zipcode, state = @state WHERE address_id = @addressId";
                using var cmdAddr = new MySqlCommand(updateAddress, connection, transaction);
                cmdAddr.Parameters.Add("@street", MySqlDbType.VarChar).Value = nurse.Address.Street;
                cmdAddr.Parameters.Add("@city", MySqlDbType.VarChar).Value = nurse.Address.City;
                cmdAddr.Parameters.Add("@zipcode", MySqlDbType.String).Value = nurse.Address.Zipcode;
                cmdAddr.Parameters.Add("@state", MySqlDbType.String).Value = nurse.Address.State;
                cmdAddr.Parameters.Add("@addressId", MySqlDbType.Int32).Value = nurse.Address.AddressId;
                cmdAddr.ExecuteNonQuery();

                // Update Person
                const string updatePerson =
                    "UPDATE Person SET first_name = @first, last_name = @last, birthdate = @birthdate, phone_number = @phone WHERE person_id = @personId";
                using var cmdPer = new MySqlCommand(updatePerson, connection, transaction);
                cmdPer.Parameters.Add("@first", MySqlDbType.VarChar).Value = nurse.FirstName;
                cmdPer.Parameters.Add("@last", MySqlDbType.VarChar).Value = nurse.LastName;
                cmdPer.Parameters.Add("@birthdate", MySqlDbType.Date).Value = nurse.Birthdate;
                cmdPer.Parameters.Add("@phone", MySqlDbType.String).Value = nurse.PhoneNumber;
                cmdPer.Parameters.Add("@personId", MySqlDbType.Int32).Value = nurse.PersonID;
                cmdPer.ExecuteNonQuery();

                // Update Nurse
                const string updateAccount = "UPDATE Account SET username = @username WHERE username = (SELECT username FROM Nurse WHERE person_id = @personId)";
                using var cmdNurse = new MySqlCommand(updateAccount, connection, transaction);
                cmdNurse.Parameters.Add("@username", MySqlDbType.VarString).Value = nurse.Username;
                cmdNurse.Parameters.Add("@personId", MySqlDbType.Int32).Value = nurse.PersonID;
                cmdNurse.ExecuteNonQuery();

                transaction.Commit();
                return true;
            }
            catch
            {
                try { transaction.Rollback(); } catch { }
                return false;
            }
        }
    }
}