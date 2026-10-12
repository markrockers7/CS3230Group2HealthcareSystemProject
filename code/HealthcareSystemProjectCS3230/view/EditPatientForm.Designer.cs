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

            patientComboBox.SelectedIndexChanged += patientComboBox_SelectedIndexChanged;
            updateButton.Click += updateButton_Click;
            cancelButton.Click += cancelButton_Click;

            var layout = new TableLayoutPanel
            {
                ColumnCount = 2,
                RowCount = 11,
                Dock = DockStyle.Fill,
                Padding = new Padding(12),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            AddField(layout, "Patient", patientComboBox, 0);
            AddField(layout, "First name", firstNameTextBox, 1);
            AddField(layout, "Last name", lastNameTextBox, 2);
            AddField(layout, "Birthdate", birthdatePicker, 3);
            AddField(layout, "Phone", phoneTextBox, 4);
            AddField(layout, "Street", streetTextBox, 5);
            AddField(layout, "City", cityTextBox, 6);
            AddField(layout, "State", stateComboBox, 7);
            AddField(layout, "ZIP code", zipcodeTextBox, 8);
            layout.Controls.Add(isActiveCheckBox, 1, 9);

            var buttons = new FlowLayoutPanel { FlowDirection = FlowDirection.RightToLeft, Dock = DockStyle.Fill, AutoSize = true };
            buttons.Controls.Add(cancelButton);
            buttons.Controls.Add(updateButton);
            layout.Controls.Add(buttons, 1, 10);

            Controls.Add(layout);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 440);
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
