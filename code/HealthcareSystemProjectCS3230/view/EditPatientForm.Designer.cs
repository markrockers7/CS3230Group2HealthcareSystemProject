using System.Drawing;
using System.Windows.Forms;

namespace HealthcareSystemProjectCS3230.view
{
    partial class EditPatientForm
    {
        private TextBox firstNameTextBox = null!;
        private TextBox lastNameTextBox = null!;
        private DateTimePicker birthdatePicker = null!;
        private ComboBox genderComboBox = null!;
        private TextBox phoneTextBox = null!;
        private TextBox streetTextBox = null!;
        private TextBox cityTextBox = null!;
        private ComboBox stateComboBox = null!;
        private TextBox zipcodeTextBox = null!;
        private CheckBox isActiveCheckBox = null!;

        // Individual validation error labels
        private Label firstNameErrorLabel = null!;
        private Label lastNameErrorLabel = null!;
        private Label birthdateErrorLabel = null!;
        private Label genderErrorLabel = null!;
        private Label phoneErrorLabel = null!;
        private Label streetErrorLabel = null!;
        private Label cityErrorLabel = null!;
        private Label stateErrorLabel = null!;
        private Label zipcodeErrorLabel = null!;

        private Label errorLabel = null!;
        private Button updateButton = null!;
        private Button cancelButton = null!;
        private Label loggedInLabel = null!;

        private void InitializeComponent()
        {
            firstNameTextBox = new TextBox
            {
                Dock = DockStyle.Fill
            };

            lastNameTextBox = new TextBox
            {
                Dock = DockStyle.Fill
            };

            birthdatePicker = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Dock = DockStyle.Fill
            };

            genderComboBox = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Dock = DockStyle.Fill
            };

            phoneTextBox = new TextBox
            {
                Dock = DockStyle.Fill
            };

            streetTextBox = new TextBox
            {
                Dock = DockStyle.Fill
            };

            cityTextBox = new TextBox
            {
                Dock = DockStyle.Fill
            };

            stateComboBox = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Dock = DockStyle.Fill
            };

            zipcodeTextBox = new TextBox
            {
                Dock = DockStyle.Fill
            };

            isActiveCheckBox = new CheckBox
            {
                Text = "Active",
                AutoSize = true
            };

            // Initialize individual error labels
            firstNameErrorLabel = CreateErrorLabel();
            lastNameErrorLabel = CreateErrorLabel();
            birthdateErrorLabel = CreateErrorLabel();
            genderErrorLabel = CreateErrorLabel();
            phoneErrorLabel = CreateErrorLabel();
            streetErrorLabel = CreateErrorLabel();
            cityErrorLabel = CreateErrorLabel();
            stateErrorLabel = CreateErrorLabel();
            zipcodeErrorLabel = CreateErrorLabel();

            // General error label for controller errors
            errorLabel = new Label
            {
                AutoSize = true,
                ForeColor = Color.Firebrick,
                MaximumSize = new Size(650, 0)
            };

            updateButton = new Button
            {
                Text = "Update",
                AutoSize = true
            };

            cancelButton = new Button
            {
                Text = "Cancel",
                AutoSize = true
            };

            loggedInLabel = new Label
            {
                AutoSize = true,
                Anchor = AnchorStyles.Left
            };

            updateButton.Click += updateButton_Click;
            cancelButton.Click += cancelButton_Click;

            var layout = new TableLayoutPanel
            {
                ColumnCount = 2,
                RowCount = 16,
                Dock = DockStyle.Top,
                Padding = new Padding(12),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            layout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 120));

            layout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100));

            // Row 0: Logged-in user
            layout.Controls.Add(loggedInLabel, 0, 0);
            layout.SetColumnSpan(loggedInLabel, 2);

            layout.RowStyles.Add(
                new RowStyle(SizeType.AutoSize));

            // Row 1: Patient search control
            layout.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 330));

            // Rows 2-3: Spacing
            layout.RowStyles.Add(
                new RowStyle(SizeType.AutoSize));

            layout.RowStyles.Add(
                new RowStyle(SizeType.AutoSize));

            // Patient fields with validation labels
            AddField(
                layout,
                "First name",
                firstNameTextBox,
                firstNameErrorLabel,
                4);

            AddField(
                layout,
                "Last name",
                lastNameTextBox,
                lastNameErrorLabel,
                5);

            AddField(
                layout,
                "Birthdate",
                birthdatePicker,
                birthdateErrorLabel,
                6);

            AddField(
                layout,
                "Gender",
                genderComboBox,
                genderErrorLabel,
                7);

            AddField(
                layout,
                "Phone",
                phoneTextBox,
                phoneErrorLabel,
                8);

            AddField(
                layout,
                "Street",
                streetTextBox,
                streetErrorLabel,
                9);

            AddField(
                layout,
                "City",
                cityTextBox,
                cityErrorLabel,
                10);

            AddField(
                layout,
                "State",
                stateComboBox,
                stateErrorLabel,
                11);

            AddField(
                layout,
                "ZIP code",
                zipcodeTextBox,
                zipcodeErrorLabel,
                12);

            // Row 13: Active checkbox
            layout.RowStyles.Add(
                new RowStyle(SizeType.AutoSize));

            layout.Controls.Add(isActiveCheckBox, 1, 13);

            // Row 14: General error messages
            layout.RowStyles.Add(
                new RowStyle(SizeType.AutoSize));

            layout.Controls.Add(errorLabel, 1, 14);

            // Row 15: Buttons
            var buttons = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.RightToLeft,
                Dock = DockStyle.Fill,
                AutoSize = true
            };

            buttons.Controls.Add(cancelButton);
            buttons.Controls.Add(updateButton);

            layout.RowStyles.Add(
                new RowStyle(SizeType.AutoSize));

            layout.Controls.Add(buttons, 1, 15);

            Controls.Add(layout);

            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(850, 850);
            FormBorderStyle = FormBorderStyle.Sizable;
            MaximizeBox = true;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Patient";
        }

        // Creates a red validation label
        private static Label CreateErrorLabel()
        {
            return new Label
            {
                AutoSize = true,
                ForeColor = Color.Red,
                MaximumSize = new Size(600, 0),
                Text = string.Empty
            };
        }

        // Adds an input field with its error label underneath
        private static void AddField(
            TableLayoutPanel layout,
            string labelText,
            Control control,
            Label validationLabel,
            int row)
        {
            layout.RowStyles.Add(
                new RowStyle(SizeType.AutoSize));

            // Field name
            layout.Controls.Add(
                new Label
                {
                    Text = labelText,
                    AutoSize = true,
                    Anchor = AnchorStyles.Left
                },
                0, row);

            // Container for input and error
            var fieldPanel = new TableLayoutPanel
            {
                ColumnCount = 1,
                RowCount = 2,
                Dock = DockStyle.Fill,
                AutoSize = true
            };

            fieldPanel.RowStyles.Add(
                new RowStyle(SizeType.AutoSize));

            fieldPanel.RowStyles.Add(
                new RowStyle(SizeType.AutoSize));

            // Input field
            fieldPanel.Controls.Add(control, 0, 0);

            // Error message underneath input
            fieldPanel.Controls.Add(validationLabel, 0, 1);

            layout.Controls.Add(fieldPanel, 1, row);
        }
    }
}