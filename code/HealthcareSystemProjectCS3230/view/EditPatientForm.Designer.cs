using System.Drawing;
using System.Windows.Forms;

namespace HealthcareSystemProjectCS3230.view
{
    partial class EditPatientForm
    {
        private ComboBox patientComboBox = null!;
        private TextBox firstNameTextBox = null!;
        private TextBox lastNameTextBox = null!;
        private DateTimePicker birthdatePicker = null!;
        private TextBox phoneTextBox = null!;
        private TextBox streetTextBox = null!;
        private TextBox cityTextBox = null!;
        private ComboBox stateComboBox = null!;
        private TextBox zipcodeTextBox = null!;
        private CheckBox isActiveCheckBox = null!;
        private Button updateButton = null!;
        private Button cancelButton = null!;
        private Label loggedInLabel = null!;

        private void InitializeComponent()
        {
            patientComboBox = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Fill };
            firstNameTextBox = new TextBox { Dock = DockStyle.Fill };
            lastNameTextBox = new TextBox { Dock = DockStyle.Fill };
            birthdatePicker = new DateTimePicker { Format = DateTimePickerFormat.Short, Dock = DockStyle.Fill };
            phoneTextBox = new TextBox { Dock = DockStyle.Fill };
            streetTextBox = new TextBox { Dock = DockStyle.Fill };
            cityTextBox = new TextBox { Dock = DockStyle.Fill };
            stateComboBox = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Fill };
            zipcodeTextBox = new TextBox { Dock = DockStyle.Fill };
            isActiveCheckBox = new CheckBox { Text = "Active", AutoSize = true };
            updateButton = new Button { Text = "Update", AutoSize = true };
            cancelButton = new Button { Text = "Cancel", AutoSize = true };
            loggedInLabel = new Label { AutoSize = true, Anchor = AnchorStyles.Left };

            patientComboBox.SelectedIndexChanged += patientComboBox_SelectedIndexChanged;
            updateButton.Click += updateButton_Click;
            cancelButton.Click += cancelButton_Click;

            var layout = new TableLayoutPanel
            {
                ColumnCount = 2,
                RowCount = 12,
                Dock = DockStyle.Fill,
                Padding = new Padding(12),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            layout.Controls.Add(loggedInLabel, 0, 0);
            layout.SetColumnSpan(loggedInLabel, 2);
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            AddField(layout, "Patient", patientComboBox, 1);
            AddField(layout, "First name", firstNameTextBox, 2);
            AddField(layout, "Last name", lastNameTextBox, 3);
            AddField(layout, "Birthdate", birthdatePicker, 4);
            AddField(layout, "Phone", phoneTextBox, 5);
            AddField(layout, "Street", streetTextBox, 6);
            AddField(layout, "City", cityTextBox, 7);
            AddField(layout, "State", stateComboBox, 8);
            AddField(layout, "ZIP code", zipcodeTextBox, 9);
            layout.Controls.Add(isActiveCheckBox, 1, 10);

            var buttons = new FlowLayoutPanel { FlowDirection = FlowDirection.RightToLeft, Dock = DockStyle.Fill, AutoSize = true };
            buttons.Controls.Add(cancelButton);
            buttons.Controls.Add(updateButton);
            layout.Controls.Add(buttons, 1, 11);

            Controls.Add(layout);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 470);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit Patient";
        }

        private static void AddField(TableLayoutPanel layout, string labelText, Control control, int row)
        {
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.Controls.Add(new Label { Text = labelText, AutoSize = true, Anchor = AnchorStyles.Left }, 0, row);
            layout.Controls.Add(control, 1, row);
        }
    }
}
