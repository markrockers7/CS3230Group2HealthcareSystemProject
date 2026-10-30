using System.Drawing;
using System.Windows.Forms;

namespace HealthcareSystemProjectCS3230.view
{
    partial class EditPatientForm
    {
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

            updateButton.Click += updateButton_Click;
            cancelButton.Click += cancelButton_Click;

            var layout = new TableLayoutPanel
            {
                ColumnCount = 2,
                RowCount = 14,
                Dock = DockStyle.Top,
                Padding = new Padding(12),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            // Row 0: logged-in user
            layout.Controls.Add(loggedInLabel, 0, 0);
            layout.SetColumnSpan(loggedInLabel, 2);
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // Row 1: PatientSearchControl (added in EditPatientForm.cs)
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 330));
            // Rows 2-3: spacing
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            AddField(layout, "First name", firstNameTextBox, 4);
            AddField(layout, "Last name", lastNameTextBox, 5);
            AddField(layout, "Birthdate", birthdatePicker, 6);
            AddField(layout, "Phone", phoneTextBox, 7);
            AddField(layout, "Street", streetTextBox, 8);
            AddField(layout, "City", cityTextBox, 9);
            AddField(layout, "State", stateComboBox, 10);
            AddField(layout, "ZIP code", zipcodeTextBox, 11);

            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.Controls.Add(isActiveCheckBox, 1, 12);

            var buttons = new FlowLayoutPanel { FlowDirection = FlowDirection.RightToLeft, Dock = DockStyle.Fill, AutoSize = true };
            buttons.Controls.Add(cancelButton);
            buttons.Controls.Add(updateButton);
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.Controls.Add(buttons, 1, 13);

            Controls.Add(layout);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(850, 850);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;
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