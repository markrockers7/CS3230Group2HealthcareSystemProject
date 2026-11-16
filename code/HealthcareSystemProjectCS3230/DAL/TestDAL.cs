using HealthcareSystemProjectCS3230.model;
using MySql.Data.MySqlClient;
using System.Data;

namespace HealthcareSystemProjectCS3230.DAL;

public class TestDAL
{
    /// <summary>
    /// Gets all of the available tests from the database.
    /// </summary>
    /// <returns>List of Test objects representing the available tests</returns>
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

    /// <summary>
    /// Saves a visit and its associated tests to the database.
    /// </summary>
    /// <param name="appointmentId">The ID of the appointment associated with the visit.</param>
    /// <param name="systolic">The systolic blood pressure.</param>
    /// <param name="diastolic">The diastolic blood pressure.</param>
    /// <param name="pulse">The pulse rate.</param>
    /// <param name="bodyTemperature">The body temperature.</param>
    /// <param name="height">The height.</param>
    /// <param name="weight">The weight.</param>
    /// <param name="symptoms">The symptoms.</param>
    /// <param name="initialDiagnosis">The initial diagnosis.</param>
    /// <param name="selectedTests">The selected tests.</param>
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

    /// <summary>
    /// Gets all of the available Visits from the database for a specific patient.
    /// </summary>
    /// <param name="patientId">The ID of the patient to get visits for.</param>
    /// <returns>A list of Visit objects for the specified patient.</returns>
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

    /// <summary>
    /// Gets all the visits that either have no tests or all of the tests are completed for a specific patient.
    /// </summary>
    /// <param name="patientId">The ID of the patient</param>
    /// <returns>List of Visit objects that meet the criteria</returns>
    public List<Visit> GetVisitsWithCompleteOrNoVisitTests(int patientId)
    {
        var visits = new List<Visit>();
        using var connection = new MySqlConnection(Connection.ConnectionString);
        connection.Open();
        var command = new MySqlCommand("SELECT v.* " +
                                       "FROM visit v JOIN appointment a ON v.appointment_id = a.appointment_id " +
                                       "WHERE a.patient_id = @PatientId AND v.final_diagnosis IS NULL AND NOT EXISTS " +
                                       "(SELECT 1 " +
                                       "FROM visittest t " +
                                       "WHERE t.appointment_id = a.appointment_id AND t.result IS NULL)", connection);
        command.Parameters.AddWithValue("@PatientId", patientId);
        var reader = command.ExecuteReader();
        while (reader.Read())
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
        return visits;
    }

    /// <summary>
    /// Gets a patient's visits with the visit date, doctor's name, and diagnoses.
    /// </summary>
    /// <param name="patientId">The ID of the patient</param>
    /// <param name="onlyWithTests">If true, only returns visits that have at least one ordered test</param>
    /// <returns>List of VisitSummary objects, newest first</returns>

    public List<VisitSummary> GetVisitSummariesForPatient(int patientId, bool onlyWithTests = true)
    {
        var visits = new List<VisitSummary>();
        using var connection = new MySqlConnection(Connection.ConnectionString);
        connection.Open();

        string sql =
            "SELECT v.appointment_id, a.appointment_datetime, " +
            "       CONCAT(p.first_name, ' ', p.last_name) AS doctor_name, " +
            "       v.initial_diagnosis, v.final_diagnosis " +
            "FROM Visit v " +
            "JOIN Appointment a ON a.appointment_id = v.appointment_id " +
            "JOIN Doctor d ON d.id = a.doctor_id " +
            "JOIN Person p ON p.person_id = d.person_id " +
            "WHERE a.patient_id = @patientId ";

        if (onlyWithTests)
        {
            sql += "AND EXISTS (SELECT 1 FROM VisitTest vt WHERE vt.appointment_id = v.appointment_id) ";
        }

        sql += "ORDER BY a.appointment_datetime DESC";

        using var command = new MySqlCommand(sql, connection);
        command.Parameters.Add("@patientId", MySqlDbType.Int32).Value = patientId;

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            visits.Add(new VisitSummary
            {
                AppointmentId = reader.GetInt32("appointment_id"),
                AppointmentDateTime = reader.GetDateTime("appointment_datetime"),
                DoctorName = reader.GetString("doctor_name"),
                InitialDiagnosis = reader.IsDBNull("initial_diagnosis") ? null : reader.GetString("initial_diagnosis"),
                FinalDiagnosis = reader.IsDBNull("final_diagnosis") ? null : reader.GetString("final_diagnosis")
            });
        }

        return visits;
    }

    /// <summary>
    /// Gets the tests ordered for a visit, with each test's name, normal range, and any result entered so far.
    /// </summary>
    /// <param name="appointmentId">The ID of the visit (appointment)</param>
    /// <returns>List of VisitTestResult objects</returns>
    public List<VisitTestResult> GetVisitTestResults(int appointmentId)
    {
        var results = new List<VisitTestResult>();
        using var connection = new MySqlConnection(Connection.ConnectionString);
        connection.Open();

        const string sql =
            "SELECT vt.appointment_id, vt.test_code, t.name, t.low_value, t.high_value, t.unit_of_measurement, " +
            "       vt.date_performed, vt.result, vt.isAbnormal " +
            "FROM VisitTest vt " +
            "JOIN Test t ON t.test_code = vt.test_code " +
            "WHERE vt.appointment_id = @appointmentId " +
            "ORDER BY t.name";

        using var command = new MySqlCommand(sql, connection);
        command.Parameters.Add("@appointmentId", MySqlDbType.Int32).Value = appointmentId;

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            results.Add(new VisitTestResult
            {
                AppointmentId = reader.GetInt32("appointment_id"),
                TestCode = reader.GetString("test_code"),
                TestName = reader.GetString("name"),
                LowValue = reader["low_value"] is DBNull ? null : Convert.ToDecimal(reader["low_value"]),
                HighValue = reader["high_value"] is DBNull ? null : Convert.ToDecimal(reader["high_value"]),
                Unit = reader["unit_of_measurement"] is DBNull ? null : reader.GetString("unit_of_measurement"),
                DatePerformed = reader["date_performed"] is DBNull ? null : reader.GetDateTime("date_performed"),
                Result = reader["result"] is DBNull ? null : reader.GetString("result"),
                IsAbnormal = reader["isAbnormal"] is DBNull ? null : Convert.ToBoolean(reader["isAbnormal"])
            });
        }

        return results;
    }

    /// <summary>
    /// Saves the result of one ordered test.
    /// Only updates the test if its visit has no final diagnosis yet, so finalized visits can't be changed.
    /// </summary>
    /// <param name="appointmentId">The ID of the visit (appointment)</param>
    /// <param name="testCode">The code of the test</param>
    /// <param name="datePerformed">When the test was performed</param>
    /// <param name="result">The test result (a number or a description)</param>
    /// <param name="isAbnormal">Whether the result is abnormal</param>
    /// <returns>true if the result was saved, false if the test wasn't found or the visit is finalized</returns>
    public bool SaveTestResult(int appointmentId, string testCode, DateTime datePerformed, string result, bool isAbnormal)
    {
        using var connection = new MySqlConnection(Connection.ConnectionString);
        connection.Open();

        const string sql =
            "UPDATE VisitTest vt " +
            "JOIN Visit v ON v.appointment_id = vt.appointment_id " +
            "SET vt.date_performed = @datePerformed, vt.result = @result, vt.isAbnormal = @isAbnormal " +
            "WHERE vt.appointment_id = @appointmentId " +
            "  AND vt.test_code = @testCode " +
            "  AND v.final_diagnosis IS NULL";

        using var command = new MySqlCommand(sql, connection);
        command.Parameters.Add("@datePerformed", MySqlDbType.DateTime).Value = datePerformed;
        command.Parameters.Add("@result", MySqlDbType.VarChar).Value = result;
        command.Parameters.Add("@isAbnormal", MySqlDbType.Bit).Value = isAbnormal;
        command.Parameters.Add("@appointmentId", MySqlDbType.Int32).Value = appointmentId;
        command.Parameters.Add("@testCode", MySqlDbType.VarChar).Value = testCode;

        return command.ExecuteNonQuery() > 0;
    }

    /// <summary>
    /// Gets one visit's checkup details and diagnoses.
    /// </summary>
    /// <param name="appointmentId">The ID of the visit (appointment)</param>
    /// <returns>The Visit, or null if it doesn't exist</returns>
    public Visit? GetVisitById(int appointmentId)
    {
        using var connection = new MySqlConnection(Connection.ConnectionString);
        connection.Open();

        const string sql = "SELECT * FROM Visit WHERE appointment_id = @appointmentId";

        using var command = new MySqlCommand(sql, connection);
        command.Parameters.Add("@appointmentId", MySqlDbType.Int32).Value = appointmentId;

        using var reader = command.ExecuteReader();
        if (!reader.Read())
        {
            return null;
        }

        return new Visit
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
        };
    }
}