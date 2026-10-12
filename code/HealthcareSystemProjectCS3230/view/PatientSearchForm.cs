using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using HealthcareSystemProjectCS3230.controler;
using HealthcareSystemProjectCS3230.model;

namespace HealthcareSystemProjectCS3230.view
{
    public class PatientSearchForm : Form
    {
        private readonly TextBox firstNameTextBox;
        private readonly TextBox lastNameTextBox;
        private readonly DateTimePicker birthdatePicker;
        private readonly Button searchButton;
        private readonly PatientController patientController;

        public DataGridView PatientResultsGrid { get; }

        public string FirstNameFilter => firstNameTextBox.Text.Trim();
        public string LastNameFilter => lastNameTextBox.Text.Trim();
        public DateTime? BirthdateFilter => birthdatePicker.Checked ? birthdatePicker.Value.Date : null;

        public event EventHandler? SearchRequested;

        public PatientSearchForm()
        {
            patientController = new PatientController();
            SearchRequested += PatientSearchForm_SearchRequested;

            Text = "Patient Search";
            StartPosition = FormStartPosition.CenterParent;
            MinimumSize = new Size(800, 500);
            Size = new Size(1000, 600);

            firstNameTextBox = new TextBox { Dock = DockStyle.Fill };
            lastNameTextBox = new TextBox { Dock = DockStyle.Fill };
            birthdatePicker = new DateTimePicker
            {
                Dock = DockStyle.Fill,
                Format = DateTimePickerFormat.Short,
                ShowCheckBox = true,
                Checked = false
            };
            searchButton = new Button { Text = "Search", AutoSize = true };
            searchButton.Click += (_, _) => SearchRequested?.Invoke(this, EventArgs.Empty);

            PatientResultsGrid = new DataGridView
            {
                Name = "patientResultsGrid",
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoGenerateColumns = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false
            };
            PatientResultsGrid.Columns.Add(CreateTextColumn(nameof(Patient.FirstName), "First Name"));
            PatientResultsGrid.Columns.Add(CreateTextColumn(nameof(Patient.LastName), "Last Name"));
            PatientResultsGrid.Columns.Add(CreateTextColumn(nameof(Patient.Birthdate), "Birthdate", "d"));
            PatientResultsGrid.Columns.Add(CreateTextColumn(nameof(Patient.PhoneNumber), "Phone Number"));
            PatientResultsGrid.Columns.Add(CreateTextColumn(nameof(Patient.Address), "Address"));
            PatientResultsGrid.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = nameof(Patient.IsActive),
                DataPropertyName = nameof(Patient.IsActive),
                HeaderText = "Active",
                FillWeight = 55,
                ReadOnly = true
            });
            PatientResultsGrid.CellFormatting += PatientResultsGrid_CellFormatting;

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(12),
                ColumnCount = 4,
                RowCount = 3
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 85));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 85));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            layout.Controls.Add(new Label { Text = "First name", AutoSize = true, Anchor = AnchorStyles.Left }, 0, 0);
            layout.Controls.Add(firstNameTextBox, 1, 0);
            layout.Controls.Add(new Label { Text = "Last name", AutoSize = true, Anchor = AnchorStyles.Left }, 2, 0);
            layout.Controls.Add(lastNameTextBox, 3, 0);
            layout.Controls.Add(new Label { Text = "Birthdate", AutoSize = true, Anchor = AnchorStyles.Left }, 0, 1);
            layout.Controls.Add(birthdatePicker, 1, 1);
            layout.Controls.Add(searchButton, 3, 1);
            layout.Controls.Add(PatientResultsGrid, 0, 2);
            layout.SetColumnSpan(PatientResultsGrid, 4);

            Controls.Add(layout);
        }

        private void PatientSearchForm_SearchRequested(object? sender, EventArgs e)
        {
            try
            {
                var patients = patientController.FindPatients(FirstNameFilter, LastNameFilter, BirthdateFilter);
                SetPatients(patients);
                if (patients.Count == 0)
                {
                    MessageBox.Show(
                        "No patients matched your search.",
                        "No Results",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    $"Patients could not be searched. {exception.Message}",
                    "Search Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public void SetPatients(IEnumerable<Patient> patients)
        {
            PatientResultsGrid.DataSource = new BindingList<Patient>(patients.ToList());
        }

        private static DataGridViewTextBoxColumn CreateTextColumn(string propertyName, string headerText, string? format = null)
        {
            return new DataGridViewTextBoxColumn
            {
                Name = propertyName,
                DataPropertyName = propertyName,
                HeaderText = headerText,
                DefaultCellStyle = { Format = format ?? string.Empty }
            };
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // PatientSearchForm
            // 
            ClientSize = new Size(284, 261);
            Name = "PatientSearchForm";
            ResumeLayout(false);

        }

        private void PatientResultsGrid_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (PatientResultsGrid.Columns[e.ColumnIndex].DataPropertyName == nameof(Patient.Address) && e.Value is Address address)
            {
                e.Value = $"{address.Street}, {address.City}, {address.State} {address.Zipcode}";
                e.FormattingApplied = true;
            }
        }
    }
}
