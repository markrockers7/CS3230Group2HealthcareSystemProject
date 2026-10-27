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
            stateComboBox.Items.Clear();
            stateComboBox.Items.AddRange(states);
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
                var firstName = fnameTextBox.Text.Trim();
                var lastName = lnameTextBox.Text.Trim();
                var birthdate = birthDateTimePicker.Value;
                var phone = phoneNumberTextBox.Text.Trim();
                var street = streetTextBox.Text.Trim();
                var city = cityTextBox.Text.Trim();
                var state = stateComboBox.SelectedItem?.ToString();
                var zipcode = zipCodeTextBox.Text.Trim();
                var username = usernameTextBox.Text.Trim();
                var password = passwordTextBox.Text.Trim();
                var nurse = new Nurse(0, 0, username)
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Birthdate = birthdate,
                    PhoneNumber = phone,
                    Address = new Address
                    {
                        Street = street,
                        City = city,
                        State = state,
                        Zipcode = zipcode
                    }
                };

                if (!this.validateInput(nurse, password))
                {
                    return;
                }

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
            if (NurseListView.SelectedItems.Count > 0 && updateCheckBox.Checked)
            {
                var selectedNurse = (Nurse)NurseListView.SelectedItems[0].Tag;
                fnameTextBox.Text = selectedNurse.FirstName;
                lnameTextBox.Text = selectedNurse.LastName;
                birthDateTimePicker.Value = selectedNurse.Birthdate;
                phoneNumberTextBox.Text = selectedNurse.PhoneNumber;
                streetTextBox.Text = selectedNurse.Address.Street;
                cityTextBox.Text = selectedNurse.Address.City;
                stateComboBox.SelectedItem = selectedNurse.Address.State;
                zipCodeTextBox.Text = selectedNurse.Address.Zipcode;
                usernameTextBox.Text = selectedNurse.Username;

            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (NurseListView.SelectedItems.Count > 0)
            {
                var nurse = (Nurse)NurseListView.SelectedItems[0].Tag;

                nurseController.UpdateNurse(nurse);
                this.updateNurseView();
                this.clearForm();
            }
        }

        private void updateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (updateCheckBox.Checked)
            {
                passwordTextBox.Enabled = false;
                addButton.Text = "Update";
                addLabel.Text = "Update Existing Nurse";
                this.clearForm();
            }
            else
            {
                passwordTextBox.Enabled = true;
                addButton.Text = "Add";
                addLabel.Text = "Add New Nurse";
                this.clearForm();
            }
        }

        private void clearForm()
        {
            fnameTextBox.Clear();
            lnameTextBox.Clear();
            birthDateTimePicker.Value = DateTime.Now;
            phoneNumberTextBox.Clear();
            streetTextBox.Clear();
            cityTextBox.Clear();
            stateComboBox.SelectedIndex = -1;
            zipCodeTextBox.Clear();
            usernameTextBox.Clear();
            passwordTextBox.Clear();

            this.clearErrorLabels();
        }

        private void clearErrorLabels()
        {
            fnameErrorLabel.Text = "";
            lnameErrorLabel.Text = "";
            birthdateErrorLabel.Text = "";
            phoneNumberErrorLabel.Text = "";
            streetErrorLabel.Text = "";
            cityErrorLabel.Text = "";
            zipCodeErrorLabel.Text = "";
            usernameErrorLabel.Text = "";
            stateErrorLabel.Text = "";
            passwordErrorLabel.Text = "";
        }

        private bool validateInput(Nurse nurse, string password)
        {
            this.clearErrorLabels();
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(nurse.Username) || nurse.Username.Length > 50)
            {
                usernameErrorLabel.Text = "Username must be 50 or less characters, and cannot be empty.";
                isValid = false;
            }
            if(password.Length > 50 || string.IsNullOrWhiteSpace(password))
            {
                passwordErrorLabel.Text = "Password must be 50 or less characters and cannot be empty.";
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(nurse.FirstName))
            {
                fnameErrorLabel.Text = "First name is required.";
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(nurse.LastName))
            {
                lnameErrorLabel.Text = "Last name is required.";
                isValid = false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(nurse.PhoneNumber, @"^\d{10}$"))
            {
                phoneNumberErrorLabel.Text = "Phone number must be 10 digits (numbers only).";
                isValid = false;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(nurse.Address.Zipcode, @"^\d{5}$"))
            {
                zipCodeErrorLabel.Text = "ZIP code must be 5 digits.";
                isValid = false;
            }
            if (nurse.Birthdate >= DateTime.Now)
            {
                birthdateErrorLabel.Text = "Birthdate must be in the past.";
                isValid = false;
            }
            if (nurse.Address.Street.Length > 100 || string.IsNullOrWhiteSpace(nurse.Address.Street))
            {
                streetErrorLabel.Text = "Street address must be 100 or less characters and cannot be empty.";
                isValid = false;
            }
            if (nurse.Address.City.Length > 50 || string.IsNullOrWhiteSpace(nurse.Address.City))
            {
                cityErrorLabel.Text = "City must be 50 or less characters and cannot be empty.";
                isValid = false;
            }
            if (nurse.Address.State == null || string.IsNullOrWhiteSpace(nurse.Address.State))
            {
                stateErrorLabel.Text = "State must be selected.";
                isValid = false;
            }
            return isValid;
        }

        private void clearFormButton_Click(object sender, EventArgs e)
        {
            this.clearForm();
        }
    }
}
