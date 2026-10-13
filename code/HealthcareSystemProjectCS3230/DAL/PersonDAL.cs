using HealthcareSystemProjectCS3230.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthcareSystemProjectCS3230.DAL
{
    public class PersonDAL
    {
        public static bool DoesExist(int personID)
        {
            return GetPersonByID(personID) != null;
        }

        public static Person GetPersonByID(int personID)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query =
                "SELECT per.person_id, per.first_name, per.last_name, per.birthdate, per.phone_number, per.address_id, " +
                "a.street, a.city, a.zipcode, a.state " +
                "FROM Person per " +
                "JOIN Address a ON per.address_id = a.address_id " +
                "WHERE per.person_id = @personId;";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@personId", MySqlDbType.Int32).Value = personID;
            using var reader = command.ExecuteReader();
            if (!reader.Read()) return null;

            return new Person
            {
                PersonId = reader.GetInt32("person_id"),
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
    }
}
