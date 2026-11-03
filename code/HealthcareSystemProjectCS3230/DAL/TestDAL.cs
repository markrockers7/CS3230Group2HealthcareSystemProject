using HealthcareSystemProjectCS3230.model;
using MySql.Data.MySqlClient;

namespace HealthcareSystemProjectCS3230.DAL;

public class TestDAL
{
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
                UnitOfMeasurement = reader["unit_of_measurement"] is DBNull ? null : reader.GetString("unit_of_measurement")
            });
        }

        return tests;
    }

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
}