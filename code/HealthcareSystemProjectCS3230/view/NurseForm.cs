using HealthcareSystemProjectCS3230.controler;
using HealthcareSystemProjectCS3230.DAL;
using HealthcareSystemProjectCS3230.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HealthcareSystemProjectCS3230.view
{
    public partial class NurseForm : Form
    {
        private readonly NurseController nurseController = new NurseController();
        public NurseForm()
        {
            InitializeComponent();
        }

        private void NurseForm_Load(object sender, EventArgs e)
        {
            this.updateNurseView();
        }

        private void updateNurseView()
        {
            NurseListView.Items.Clear();
            var nurses = nurseController.GetAllNurses();
            foreach (var nurse in nurses)
            {
                var person = PersonDAL.GetPersonByID(nurse.PersonID);
                var fname = person.FirstName;
                var lname = person.LastName;
                var item = new ListViewItem(nurse.ID.ToString());
                item.SubItems.Add(fname);
                item.SubItems.Add(lname);
                item.SubItems.Add(nurse.Username);
                item.Tag = nurse;

                NurseListView.Items.Add(item);
            }

            if (NurseListView.Items.Count > 0)
            {
                NurseListView.Items[0].Selected = true;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                var personID = Int32.Parse(personIDTextBox.Text);
                var username = addUsernameTextBox.Text;
                nurseController.AddNurse(personID, username);
                this.updateNurseView();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Please check your input");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message, "Error");
            }
        }

        private void NurseListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NurseListView.SelectedItems.Count > 0)
            {
                var selectedNurse = (Nurse)NurseListView.SelectedItems[0].Tag;

                selectedNurseID.Text = selectedNurse.ID.ToString();
                updateUsernameTextBox.Text = selectedNurse.Username;
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (NurseListView.SelectedItems.Count > 0)
            {
                var nurse = (Nurse)NurseListView.SelectedItems[0].Tag;

                var currentUsername = nurse.Username;
                var newUsername = updateUsernameTextBox.Text;
                nurseController.UpdateNurse(currentUsername, newUsername);
                this.updateNurseView();
            }
        }
    }
}
