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
            PopulateStates();
            PopulateGender();
        }

        private void PopulateGender()
        {
            var genders = new[] { 'U', 'M', 'F' };
            genderComboBox.Items.Clear();
            genderComboBox.Items.AddRange(genders);
        }
        private void PopulateStates()
        {
            var states = new[]
            {
                "AL","AK","AZ","AR","CA","CO","CT","DE","FL","GA",
                "HI","ID","IL","IN","IA","KS","KY","LA","ME","MD",
                "MA","MI","MN","MS","MO","MT","NE","NV","NH","NJ",
                "NM","NY","NC","ND","OH","OK","OR","PA","RI","SC",
                "SD","TN","TX","UT","VT","VA","WA","WV","WI","WY"
            };
            addStateComboBox.Items.Clear();
            addStateComboBox.Items.AddRange(states);
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
                var firstName = addFnameTextBox.Text.Trim();
                var lastName = addLnameTextBox.Text.Trim();
                var birthdate = addBirthDateTimePicker.Value;
                var phone = addPhoneNumberTextBox.Text.Trim();
                var street = addStreetTextBox.Text.Trim();
                var city = addCityTextBox.Text.Trim();
                var state = addStateComboBox.SelectedItem?.ToString();
                var zipcode = addZipCodeTextBox.Text.Trim();
                var username = addUsernameTextBox.Text.Trim();
                var password = addPasswordTextBox.Text.Trim();
                var gender = genderComboBox.SelectedItem?.ToString().ToCharArray()[0] ?? 'U';
                var nurse = new Nurse(0, 0, username)
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Birthdate = birthdate,
                    PhoneNumber = phone,
                    Gender = gender,
                    Address = new Address
                    {
                        Street = street,
                        City = city,
                        State = state,
                        Zipcode = zipcode
                    }
                };
                if (updateCheckBox.Checked)
                {
                    nurse.PersonID = ((Nurse)NurseListView.SelectedItems[0].Tag).PersonID;
                    nurse.Address.AddressId = ((Nurse)NurseListView.SelectedItems[0].Tag).Address.AddressId;
                    nurseController.UpdateNurse(nurse);
                }
                else
                {
                    nurseController.AddNurse(nurse, password);
                }
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
                addFnameTextBox.Text = selectedNurse.FirstName;
                addLnameTextBox.Text = selectedNurse.LastName;
                addBirthDateTimePicker.Value = selectedNurse.Birthdate;
                addPhoneNumberTextBox.Text = selectedNurse.PhoneNumber;
                addStreetTextBox.Text = selectedNurse.Address.Street;
                addCityTextBox.Text = selectedNurse.Address.City;
                addStateComboBox.SelectedItem = selectedNurse.Address.State;
                addZipCodeTextBox.Text = selectedNurse.Address.Zipcode;
                addUsernameTextBox.Text = selectedNurse.Username;

            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (NurseListView.SelectedItems.Count > 0)
            {
                var nurse = (Nurse)NurseListView.SelectedItems[0].Tag;

                nurseController.UpdateNurse(nurse);
                this.updateNurseView();
            }
        }

        private void updateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (updateCheckBox.Checked)
            {
                addPasswordTextBox.Enabled = false;
                addButton.Text = "Update";
                addLabel.Text = "Update Existing Nurse";
            }
            else
            {
                addPasswordTextBox.Enabled = true;
                addButton.Text = "Add";
                addLabel.Text = "Add New Nurse";
            }
        }
    }
}
