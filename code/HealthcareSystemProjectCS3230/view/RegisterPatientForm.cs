using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HealthcareSystemProjectCS3230.model;
using HealthcareSystemProjectCS3230.controler;

namespace HealthcareSystemProjectCS3230.view
{
    public partial class RegisterPatientForm : Form
    {
        private ComboBox genderComboBox = null!;
        private ComboBox stateComboBox = null!;
        private TextBox firstNameTextBox = null!;
        private TextBox lastNameTextBox = null!;
        private DateTimePicker birthdatePicker = null!;
        private TextBox phoneTextBox = null!;
        private TextBox streetTextBox = null!;
        private TextBox cityTextBox = null!;
        private TextBox zipcodeTextBox = null!;
        private Button saveButton = null!;
        private Button cancelButton = null!;
        private readonly PatientController _controller = new PatientController();

        public RegisterPatientForm()
        {
            InitializeComponent();
            PopulateGender();
            PopulateStates();
        }

        private void PopulateGender()
        {
            genderComboBox.Items.Clear();
            genderComboBox.Items.AddRange(new[] { "Male", "Female" });
            genderComboBox.SelectedIndex = 0;
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
            stateComboBox.SelectedIndex = 0;
        }

        private void cancelButton_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void InitializeComponent()
        {
            genderComboBox = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Fill };
            stateComboBox = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Fill };
            firstNameTextBox = new TextBox { Dock = DockStyle.Fill };
            lastNameTextBox = new TextBox { Dock = DockStyle.Fill };
            birthdatePicker = new DateTimePicker { Format = DateTimePickerFormat.Short, Dock = DockStyle.Fill };
            phoneTextBox = new TextBox { Dock = DockStyle.Fill };
            streetTextBox = new TextBox { Dock = DockStyle.Fill };
            cityTextBox = new TextBox { Dock = DockStyle.Fill };
            zipcodeTextBox = new TextBox { Dock = DockStyle.Fill };
            saveButton = new Button { Text = "Save", AutoSize = true };
            cancelButton = new Button { Text = "Cancel", AutoSize = true };

            saveButton.Click += saveButton_Click;
            cancelButton.Click += cancelButton_Click;

            var layout = new TableLayoutPanel
            {
                ColumnCount = 2,
                RowCount = 10,
                Dock = DockStyle.Fill,
                Padding = new Padding(12),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            AddField(layout, "First name", firstNameTextBox, 0);
            AddField(layout, "Last name", lastNameTextBox, 1);
            AddField(layout, "Birthdate", birthdatePicker, 2);
            AddField(layout, "Phone", phoneTextBox, 3);
            AddField(layout, "Gender", genderComboBox, 4);
            AddField(layout, "Street", streetTextBox, 5);
            AddField(layout, "City", cityTextBox, 6);
            AddField(layout, "State", stateComboBox, 7);
            AddField(layout, "ZIP code", zipcodeTextBox, 8);

            var buttons = new FlowLayoutPanel { FlowDirection = FlowDirection.RightToLeft, Dock = DockStyle.Fill, AutoSize = true };
            buttons.Controls.Add(cancelButton);
            buttons.Controls.Add(saveButton);
            layout.Controls.Add(buttons, 1, 9);

            Controls.Add(layout);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 440);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Register Patient";
        }

        private static void AddField(TableLayoutPanel layout, string labelText, Control control, int row)
        {
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.Controls.Add(new Label { Text = labelText, AutoSize = true, Anchor = AnchorStyles.Left }, 0, row);
            layout.Controls.Add(control, 1, row);
        }

        private void saveButton_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(firstNameTextBox.Text) || string.IsNullOrWhiteSpace(lastNameTextBox.Text))
            {
                MessageBox.Show("First and last name are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(phoneTextBox.Text ?? string.Empty, "^[0-9]{10}$"))
            {
                MessageBox.Show("Phone number must be 10 digits (numbers only).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(zipcodeTextBox.Text ?? string.Empty, "^[0-9]{5}$"))
            {
                MessageBox.Show("ZIP code must be 5 digits.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (birthdatePicker.Value.Date >= DateTime.Now.Date)
            {
                MessageBox.Show("Birthdate must be in the past.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var patient = new Patient
            {
                FirstName = firstNameTextBox.Text.Trim(),
                LastName = lastNameTextBox.Text.Trim(),
                Birthdate = birthdatePicker.Value.Date,
                PhoneNumber = phoneTextBox.Text.Trim(),
                Address = new Address
                {
                    Street = streetTextBox.Text.Trim(),
                    City = cityTextBox.Text.Trim(),
                    State = stateComboBox.SelectedItem?.ToString() ?? string.Empty,
                    Zipcode = zipcodeTextBox.Text.Trim()
                },
                IsActive = true
            };

            try
            {
                _controller.AddPatient(patient);
                MessageBox.Show("Patient successfully registered.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
