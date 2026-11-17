using System;
using System.Collections.Generic;
using System.Text;
using HealthcareSystemProjectCS3230.model;

namespace HealthcareSystemProjectCS3230.controler
{
    public class StatisticsController
    {
        /// <summary>
        ///  Returns a list of statistics for the most performed tests during the specified date range.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>A list of statistics for the most performed tests during the specified date range.</returns>
        public List<Statistic> GetStatistics(DateTime startDate, DateTime endDate)
        {
            var statisticsDAL = new DAL.StatisticsDAL();
            return statisticsDAL.GetStatistics(startDate, endDate);
        }
    }
}
