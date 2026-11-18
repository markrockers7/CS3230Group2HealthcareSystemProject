using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HealthcareSystemProjectCS3230.controler;

namespace HealthcareSystemProjectCS3230.view
{
    public partial class AdminStatsForm : Form
    {
        private readonly StatisticsController statisticsController = new StatisticsController();
        /// <summary>
        /// Form constructor for AdminStatsForm. Initializes the form and its components.
        /// </summary>
        public AdminStatsForm()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            var statistics = statisticsController.GetStatistics(dateTimePicker1.Value, dateTimePicker2.Value);
            statsGridView.AutoGenerateColumns = true;
            statsGridView.DataSource = null;
            statsGridView.DataSource = statistics;

            statsGridView.Columns["TestCode"].HeaderText = "Test Code";
            statsGridView.Columns["TestName"].HeaderText = "Test Name";
            statsGridView.Columns["TestCount"].HeaderText = "Times Performed";
            statsGridView.Columns["TotalTests"].HeaderText = "Total Tests Performed";
            statsGridView.Columns["Percentage"].HeaderText = "Percentage of Total Tests";
            statsGridView.Columns["NormalResults"].HeaderText = "Normal Results";
            statsGridView.Columns["AbnormalResults"].HeaderText = "Abnormal Results";
        }
    }
}
