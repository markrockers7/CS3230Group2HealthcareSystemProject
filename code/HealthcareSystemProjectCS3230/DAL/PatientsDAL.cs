using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HealthcareSystemProjectCS3230.model;

namespace HealthcareSystemProjectCS3230.DAL
{
    public static class PatientsDAL
    {
        public static List<Patient> GetAllPatients()
        {
            var results = new List<Patient>();
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query =
                "SELECT p.id AS patient_id, p.person_id, per.first_name, per.last_name " +
                "FROM Patient p JOIN Person per ON p.person_id = per.person_id";
            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                results.Add(new Patient
                {
                    Id = reader.GetInt32("patient_id"),
                    PersonId = reader.GetInt32("person_id"),
                    FirstName = reader.GetString("first_name"),
                    LastName = reader.GetString("last_name")
                });
            }

            return results;
        }

        public static List<Patient> GetPatientsByName(string? firstName, string? lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Both first and last name are required to search by name.");

            }

            return FindPatients(firstName, lastName, null);
        }

        public static List<Patient> GetPatientsByDateOfBirth(DateTime dateOfBirth)
        {
            return FindPatients(null, null, dateOfBirth);
        }

        public static List<Patient> GetPatientsByNameAndDateOfBirth(
            string? firstName,
            string? lastName,
            DateTime dateOfBirth)
        {
            if (string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Both first and last name are required to search by name.");

            }

            return FindPatients(firstName, lastName, dateOfBirth);
        }

        private static List<Patient> FindPatients(string? firstName, string? lastName, DateTime? dateOfBirth)
        {
            var results = new List<Patient>();
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();

            var query =
                "SELECT p.id AS patient_id, p.isActive, p.person_id, per.first_name, per.last_name, per.gender, " +
                "per.birthdate, per.phone_number, per.address_id, a.street, a.city, a.zipcode, a.state " +
                "FROM Patient p " +
                "JOIN Person per ON p.person_id = per.person_id " +
                "JOIN Address a ON per.address_id = a.address_id " +
                "WHERE 1 = 1";

            using var command = new MySqlCommand();
            command.Connection = connection;

            if (!string.IsNullOrWhiteSpace(firstName))
            {
                query += " AND per.first_name = @firstName";
                command.Parameters.Add("@firstName", MySqlDbType.VarChar).Value = firstName.Trim();
            }

            if (!string.IsNullOrWhiteSpace(lastName))
            {
                query += " AND per.last_name = @lastName";
                command.Parameters.Add("@lastName", MySqlDbType.VarChar).Value = lastName.Trim();
            }

            if (dateOfBirth.HasValue)
            {
                query += " AND per.birthdate = @dateOfBirth";
                command.Parameters.Add("@dateOfBirth", MySqlDbType.Date).Value = dateOfBirth.Value.Date;
            }

            command.CommandText = query;
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                results.Add(new Patient
                {
                    Id = reader.GetInt32("patient_id"),
                    IsActive = reader.GetBoolean("isActive"),
                    PersonId = reader.GetInt32("person_id"),
                    FirstName = reader.GetString("first_name"),
                    LastName = reader.GetString("last_name"),
                    Birthdate = reader.GetDateTime("birthdate"),
                    PhoneNumber = reader.GetString("phone_number"),
                    Gender = reader.GetChar("gender"),
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

            return results;
        }

        public static Patient? GetPatientByPatientId(int patientId)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query =
                "SELECT p.id AS patient_id, p.isActive, p.person_id, per.first_name, per.last_name, per.birthdate, per.phone_number, per.address_id, per.gender, " +
                "a.street, a.city, a.zipcode, a.state " +
                "FROM Patient p " +
                "JOIN Person per ON p.person_id = per.person_id " +
                "JOIN Address a ON per.address_id = a.address_id " +
                "WHERE p.id = @patientId";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@patientId", MySqlDbType.Int32).Value = patientId;
            using var reader = command.ExecuteReader();
            if (!reader.Read()) return null;

            return new Patient
            {
                Id = reader.GetInt32("patient_id"),
                IsActive = reader.GetBoolean("isActive"),
                PersonId = reader.GetInt32("person_id"),
                FirstName = reader.GetString("first_name"),
                LastName = reader.GetString("last_name"),
                Birthdate = reader.GetDateTime("birthdate"),
                PhoneNumber = reader.GetString("phone_number"),
                Gender = reader.GetChar("gender"),
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

        public static bool AddPatient(Patient p)
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
                cmdAddr.Parameters.Add("@street", MySqlDbType.VarChar).Value = p.Address.Street;
                cmdAddr.Parameters.Add("@city", MySqlDbType.VarChar).Value = p.Address.City;
                cmdAddr.Parameters.Add("@zipcode", MySqlDbType.String).Value = p.Address.Zipcode;
                cmdAddr.Parameters.Add("@state", MySqlDbType.String).Value = p.Address.State;
                cmdAddr.ExecuteNonQuery();

                // get last address id
                using var cmdLast = new MySqlCommand("SELECT LAST_INSERT_ID()", connection, transaction);
                var addressId = Convert.ToInt32(cmdLast.ExecuteScalar());

                // Insert Person
                const string insertPerson =
                    "INSERT INTO Person (first_name, last_name, birthdate, phone_number, address_id, gender) " +
                    "VALUES (@first, @last, @birthdate, @phone, @addressId, @gender)";
                using var cmdPer = new MySqlCommand(insertPerson, connection, transaction);
                cmdPer.Parameters.Add("@first", MySqlDbType.VarChar).Value = p.FirstName;
                cmdPer.Parameters.Add("@last", MySqlDbType.VarChar).Value = p.LastName;
                cmdPer.Parameters.Add("@birthdate", MySqlDbType.Date).Value = p.Birthdate;
                cmdPer.Parameters.Add("@phone", MySqlDbType.String).Value = p.PhoneNumber;
                cmdPer.Parameters.Add("@addressId", MySqlDbType.Int32).Value = addressId;
                cmdPer.Parameters.Add("@gender", MySqlDbType.String).Value = p.Gender;
                cmdPer.ExecuteNonQuery();

                using var cmdLastPer = new MySqlCommand("SELECT LAST_INSERT_ID()", connection, transaction);
                var personId = Convert.ToInt32(cmdLastPer.ExecuteScalar());

                // Insert Patient
                const string insertPatient =
                    "INSERT INTO Patient (isActive, person_id) VALUES (@isActive, @personId)";
                using var cmdPat = new MySqlCommand(insertPatient, connection, transaction);
                cmdPat.Parameters.Add("@isActive", MySqlDbType.Bit).Value = p.IsActive ? 1 : 0;
                cmdPat.Parameters.Add("@personId", MySqlDbType.Int32).Value = personId;
                cmdPat.ExecuteNonQuery();

                transaction.Commit();
                return true;
            }
            catch
            {
                try { transaction.Rollback(); } catch { }
                return false;
            }
        }

        public static bool UpdatePatient(Patient p)
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
                cmdAddr.Parameters.Add("@street", MySqlDbType.VarChar).Value = p.Address.Street;
                cmdAddr.Parameters.Add("@city", MySqlDbType.VarChar).Value = p.Address.City;
                cmdAddr.Parameters.Add("@zipcode", MySqlDbType.String).Value = p.Address.Zipcode;
                cmdAddr.Parameters.Add("@state", MySqlDbType.String).Value = p.Address.State;
                cmdAddr.Parameters.Add("@addressId", MySqlDbType.Int32).Value = p.Address.AddressId;
                cmdAddr.ExecuteNonQuery();

                // Update Person
                const string updatePerson =
                    "UPDATE Person SET first_name = @first, last_name = @last, birthdate = @birthdate, phone_number = @phone, gender = @gender WHERE person_id = @personId";
                using var cmdPer = new MySqlCommand(updatePerson, connection, transaction);
                cmdPer.Parameters.Add("@first", MySqlDbType.VarChar).Value = p.FirstName;
                cmdPer.Parameters.Add("@last", MySqlDbType.VarChar).Value = p.LastName;
                cmdPer.Parameters.Add("@birthdate", MySqlDbType.Date).Value = p.Birthdate;
                cmdPer.Parameters.Add("@phone", MySqlDbType.String).Value = p.PhoneNumber;
                cmdPer.Parameters.Add("@gender", MySqlDbType.String).Value = p.Gender;
                cmdPer.Parameters.Add("@personId", MySqlDbType.Int32).Value = p.PersonId;
                cmdPer.ExecuteNonQuery();

                // Update Patient isActive if needed
                const string updatePatient = "UPDATE Patient SET isActive = @isActive WHERE id = @patientId";
                using var cmdPat = new MySqlCommand(updatePatient, connection, transaction);
                cmdPat.Parameters.Add("@isActive", MySqlDbType.Bit).Value = p.IsActive ? 1 : 0;
                cmdPat.Parameters.Add("@patientId", MySqlDbType.Int32).Value = p.Id;
                cmdPat.ExecuteNonQuery();

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
