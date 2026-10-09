namespace HealthcareSystemProjectCS3230.view
{
    partial class AppointmentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            loggedInLabel = new Label();
            titleLabel = new Label();
            patientIdLabel = new Label();
            patientIdTextBox = new TextBox();
            doctorLabel = new Label();
            doctorComboBox = new ComboBox();
            dateTimeLabel = new Label();
            appointmentDateTimePicker = new DateTimePicker();
            reasonLabel = new Label();
            reasonTextBox = new TextBox();
            bookButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            //
            // loggedInLabel
            //
            loggedInLabel.AutoSize = true;
            loggedInLabel.ForeColor = SystemColors.GrayText;
            loggedInLabel.Location = new Point(20, 15);
            loggedInLabel.Name = "loggedInLabel";
            loggedInLabel.Text = "Logged in as:";
            //
            // titleLabel
            //
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            titleLabel.Location = new Point(20, 45);
            titleLabel.Name = "titleLabel";
            titleLabel.Text = "Create Appointment";
            //
            // patientIdLabel (TEMP)
            //
            patientIdLabel.AutoSize = true;
            patientIdLabel.Location = new Point(20, 95);
            patientIdLabel.Name = "patientIdLabel";
            patientIdLabel.Text = "Patient ID:";
            //
            // patientIdTextBox (TEMP)
            //
            patientIdTextBox.Location = new Point(130, 92);
            patientIdTextBox.Name = "patientIdTextBox";
            patientIdTextBox.PlaceholderText = "Temporary: enter a patient ID";
            patientIdTextBox.Size = new Size(300, 23);
            patientIdTextBox.TabIndex = 0;
            //
            // doctorLabel
            //
            doctorLabel.AutoSize = true;
            doctorLabel.Location = new Point(20, 135);
            doctorLabel.Name = "doctorLabel";
            doctorLabel.Text = "Doctor:";
            //
            // doctorComboBox
            //
            doctorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            doctorComboBox.Location = new Point(130, 132);
            doctorComboBox.Name = "doctorComboBox";
            doctorComboBox.Size = new Size(300, 23);
            doctorComboBox.TabIndex = 1;
            //
            // dateTimeLabel
            //
            dateTimeLabel.AutoSize = true;
            dateTimeLabel.Location = new Point(20, 175);
            dateTimeLabel.Name = "dateTimeLabel";
            dateTimeLabel.Text = "Date and time:";
            //
            // appointmentDateTimePicker
            //
            appointmentDateTimePicker.CustomFormat = "MM/dd/yyyy   hh:mm tt";
            appointmentDateTimePicker.Format = DateTimePickerFormat.Custom;
            appointmentDateTimePicker.Location = new Point(130, 172);
            appointmentDateTimePicker.Name = "appointmentDateTimePicker";
            appointmentDateTimePicker.Size = new Size(300, 23);
            appointmentDateTimePicker.TabIndex = 2;
            //
            // reasonLabel
            //
            reasonLabel.AutoSize = true;
            reasonLabel.Location = new Point(20, 215);
            reasonLabel.Name = "reasonLabel";
            reasonLabel.Text = "Reason:";
            //
            // reasonTextBox
            //
            reasonTextBox.Location = new Point(130, 212);
            reasonTextBox.MaxLength = 255;
            reasonTextBox.Multiline = true;
            reasonTextBox.Name = "reasonTextBox";
            reasonTextBox.ScrollBars = ScrollBars.Vertical;
            reasonTextBox.Size = new Size(300, 80);
            reasonTextBox.TabIndex = 3;
            //
            // bookButton
            //
            bookButton.Location = new Point(250, 315);
            bookButton.Name = "bookButton";
            bookButton.Size = new Size(85, 30);
            bookButton.TabIndex = 4;
            bookButton.Text = "Book";
            bookButton.UseVisualStyleBackColor = true;
            bookButton.Click += bookButton_Click;
            //
            // cancelButton
            //
            cancelButton.Location = new Point(345, 315);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(85, 30);
            cancelButton.TabIndex = 5;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            //
            // CreateAppointmentForm
            //
            AcceptButton = bookButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(460, 365);
            Controls.Add(loggedInLabel);
            Controls.Add(titleLabel);
            Controls.Add(patientIdLabel);
            Controls.Add(patientIdTextBox);
            Controls.Add(doctorLabel);
            Controls.Add(doctorComboBox);
            Controls.Add(dateTimeLabel);
            Controls.Add(appointmentDateTimePicker);
            Controls.Add(reasonLabel);
            Controls.Add(reasonTextBox);
            Controls.Add(bookButton);
            Controls.Add(cancelButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreateAppointmentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create Appointment";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label loggedInLabel;
        private Label titleLabel;
        private Label patientIdLabel;
        private TextBox patientIdTextBox;
        private Label doctorLabel;
        private ComboBox doctorComboBox;
        private Label dateTimeLabel;
        private DateTimePicker appointmentDateTimePicker;
        private Label reasonLabel;
        private TextBox reasonTextBox;
        private Button bookButton;
        private Button cancelButton;
    }


}