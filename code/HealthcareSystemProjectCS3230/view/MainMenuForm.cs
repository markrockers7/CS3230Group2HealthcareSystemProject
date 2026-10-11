using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HealthcareSystemProjectCS3230.view
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void appointmentButton_Click(object sender, EventArgs e)
        {
            Hide();

            var appointmentForm = new AppointmentForm();
            appointmentForm.ShowDialog();


            Show();
        }
    }
}
