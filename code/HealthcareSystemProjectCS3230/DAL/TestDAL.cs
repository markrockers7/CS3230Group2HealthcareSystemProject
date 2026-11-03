using HealthcareSystemProjectCS3230.model;
using MySql.Data.MySqlClient;
using System.Data;

namespace HealthcareSystemProjectCS3230.DAL;

public class TestDAL
{
    /*
     * Gets all of the available tests from the database.
     */
    public List<Test> GetTests()
    {
        var tests = new List<Test>();

        using var connection = new MySqlConnection(Connection.ConnectionString);
        connection.Open();

        const string sql = "SELECT * FROM Test";

        using var command = new MySqlCommand(sql, connection);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            tests.Add(new Test
            {
                TestCode = reader.GetString("test_code"),
                Name = reader.GetString("name"),
                LowValue = reader["low_value"] is DBNull ? null : Convert.ToDouble(reader["low_value"]),
                HighValue = reader["high_value"] is DBNull ? null : Convert.ToDouble(reader["high_value"]),
                UnitOfMeasurement = reader["unit_of_measurement"] is DBNull
                    ? null
                    : reader.GetString("unit_of_measurement")
            });
        }

        return tests;
    }

    /*
     * Gets all of the available tests from the database for a specific patient.
     */
    public List<VisitTest> GetVisitTestsByAppointment(int appointmentId)
    {
        var visitTests = new List<VisitTest>();
        using var connection = new MySqlConnection(Connection.ConnectionString);
        connection.Open();
        var command = new MySqlCommand("SELECT * FROM VisitTest WHERE AppointmentId = @AppointmentId", connection);
        command.Parameters.AddWithValue("@AppointmentId", appointmentId);
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            visitTests.Add(new VisitTest
            {
                AppointmentId = reader.GetInt32("appointment_id"),
                TestCode = reader.GetString("test_code"),
                DatePreformed = reader.GetDateTime("date_performed"),
                Result = reader.GetString("result"),
                IsAbnormal = reader.GetBoolean("is_abnormal")
            });
        }
        return visitTests;
    }

    /*
     * Saves a visit and its associated tests to the database.
     */
    public void SaveVisitAndTests(int appointmentId, int systolic, int diastolic, int pulse,
        decimal bodyTemperature, decimal height, decimal weight, string symptoms, string? initialDiagnosis,
        IReadOnlyCollection<Test> selectedTests)
    {
        using var connection = new MySqlConnection(Connection.ConnectionString);
        connection.Open();

        using var transaction = connection.BeginTransaction();

        try
        {
            const string visitSql =
                "INSERT INTO Visit(appointment_id, systolic_bp, diastolic_bp, pulse,body_temperature, height, weight, symptoms, initial_diagnosis)" +
                " VALUES(@appointmentId, @systolic, @diastolic, @pulse, @bodyTemperature, @height, @weight, @symptoms, @initialDiagnosis)";

            using (var visitCommand = new MySqlCommand(visitSql, connection, transaction))
            {
                visitCommand.Parameters.AddWithValue("@appointmentId", appointmentId);
                visitCommand.Parameters.AddWithValue("@systolic", systolic);
                visitCommand.Parameters.AddWithValue("@diastolic", diastolic);
                visitCommand.Parameters.AddWithValue("@pulse", pulse);
                visitCommand.Parameters.AddWithValue("@bodyTemperature", bodyTemperature);
                visitCommand.Parameters.AddWithValue("@height", height);
                visitCommand.Parameters.AddWithValue("@weight", weight);
                visitCommand.Parameters.AddWithValue("@symptoms", symptoms);
                visitCommand.Parameters.AddWithValue(
                    "@initialDiagnosis",
                    string.IsNullOrWhiteSpace(initialDiagnosis) ? DBNull.Value : initialDiagnosis.Trim());
                visitCommand.ExecuteNonQuery();
            }

            const string visitTestSql =
                "INSERT INTO VisitTest(appointment_id, test_code, date_performed, result, isAbnormal)" +
                " VALUES(@appointmentId, @testCode, @datePerformed, NULL, NULL)";

            foreach (var test in selectedTests)
            {
                using var testCommand = new MySqlCommand(visitTestSql, connection, transaction);
                testCommand.Parameters.AddWithValue("@appointmentId", appointmentId);
                testCommand.Parameters.AddWithValue("@testCode", test.TestCode);
                testCommand.Parameters.AddWithValue("@datePerformed", DateTime.Now);
                testCommand.ExecuteNonQuery();
            }

            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    /*
     * Gets all of the available Visits from the database for a specific patient.
     */
    public List<Visit> GetVisitsByPatientId(int patientId)
    {
        var visits = new List<Visit>();
        using var connection = new MySqlConnection(Connection.ConnectionString);
        connection.Open();
        var command = new MySqlCommand("SELECT * FROM Visit v JOIN Appointment a ON v.appointment_id = a.appointment_id WHERE a.patient_id = @PatientId", connection);
        command.Parameters.AddWithValue("@PatientId", patientId);
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            visits.Add(new Visit
            {
                AppointmentId = reader.GetInt32("appointment_id"),
                SystolicBp = reader.GetInt32("systolic_bp"),
                DiastolicBp = reader.GetInt32("diastolic_bp"),
                Pulse = reader.GetInt32("pulse"),
                BodyTemperature = reader.GetDouble("body_temperature"),
                Height = reader.GetDouble("height"),
                Weight = reader.GetDouble("weight"),
                Symptoms = reader.GetString("symptoms"),
                InitialDiagnosis = reader.IsDBNull("initial_diagnosis") ? null : reader.GetString("initial_diagnosis"),
                FinalDiagnosis = reader.IsDBNull("final_diagnosis") ? null : reader.GetString("final_diagnosis")
            });
        }
        return visits;
    }
}