using HealthcareSystemProjectCS3230.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HealthcareSystemProjectCS3230.DAL
{
    public class StatisticsDAL
    {
        /// <summary>
        /// Returns a list of statistics for the most performed tests during the specified date range.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>A list of statistics for the most performed tests during the specified date range.</returns>
        public List<Statistic> GetStatistics(DateTime startDate, DateTime endDate)
        {
            var statistics = new List<Statistic>();
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();

            using var command = new MySqlCommand("get_most_performed_tests_duringdates", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@p_startdate", MySqlDbType.Date).Value = startDate.Date;
            command.Parameters.Add("@p_enddate", MySqlDbType.Date).Value = endDate.Date;

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var testCount = reader.GetInt32("test_count");
                var totalTests = reader.GetInt32("total_all_tests");
                statistics.Add(new Statistic
                {
                    TestCode = reader.GetString("test_code"),
                    TestName = reader.GetString("test_name"),
                    TestCount = testCount,
                    TotalTests = totalTests,
                    Percentage = totalTests > 0 ? (testCount / (double)totalTests * 100) : 0,
                    AbnormalResults = reader.GetInt32("abnormal_count"),
                    NormalResults = reader.GetInt32("normal_count"),

                });
            }
            return statistics;
        }
    }
}
