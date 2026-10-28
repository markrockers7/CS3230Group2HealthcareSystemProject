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
            dateLabel = new Label();
            appointmentDatePicker = new DateTimePicker();
            timeSlotLabel = new Label();
            appointmentTimeComboBox = new ComboBox();
            availabilityStatusLabel = new Label();
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
            doctorComboBox.SelectedIndexChanged += doctorComboBox_SelectedIndexChanged;
            //
            // dateLabel
            //
            dateLabel.AutoSize = true;
            dateLabel.Location = new Point(20, 175);
            dateLabel.Name = "dateLabel";
            dateLabel.Text = "Date:";
            //
            // appointmentDatePicker
            //
            appointmentDatePicker.Format = DateTimePickerFormat.Short;
            appointmentDatePicker.Location = new Point(130, 172);
            appointmentDatePicker.Name = "appointmentDatePicker";
            appointmentDatePicker.Size = new Size(300, 23);
            appointmentDatePicker.TabIndex = 2;
            appointmentDatePicker.ValueChanged += appointmentDatePicker_ValueChanged;
            //
            // timeSlotLabel
            //
            timeSlotLabel.AutoSize = true;
            timeSlotLabel.Location = new Point(20, 215);
            timeSlotLabel.Name = "timeSlotLabel";
            timeSlotLabel.Text = "Time slot:";
            //
            // appointmentTimeComboBox
            //
            appointmentTimeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            appointmentTimeComboBox.FormattingEnabled = true;
            appointmentTimeComboBox.Location = new Point(130, 212);
            appointmentTimeComboBox.Name = "appointmentTimeComboBox";
            appointmentTimeComboBox.Size = new Size(300, 23);
            appointmentTimeComboBox.TabIndex = 3;
            //
            // availabilityStatusLabel
            //
            availabilityStatusLabel.AutoSize = true;
            availabilityStatusLabel.ForeColor = Color.Firebrick;
            availabilityStatusLabel.Location = new Point(130, 238);
            availabilityStatusLabel.Name = "availabilityStatusLabel";
            availabilityStatusLabel.Size = new Size(0, 15);
            availabilityStatusLabel.TabIndex = 11;
            //
            // reasonLabel
            //
            reasonLabel.AutoSize = true;
            reasonLabel.Location = new Point(20, 270);
            reasonLabel.Name = "reasonLabel";
            reasonLabel.Text = "Reason:";
            //
            // reasonTextBox
            //
            reasonTextBox.Location = new Point(130, 267);
            reasonTextBox.MaxLength = 255;
            reasonTextBox.Multiline = true;
            reasonTextBox.Name = "reasonTextBox";
            reasonTextBox.ScrollBars = ScrollBars.Vertical;
            reasonTextBox.Size = new Size(300, 80);
            reasonTextBox.TabIndex = 4;
            //
            // bookButton
            //
            bookButton.Location = new Point(250, 370);
            bookButton.Name = "bookButton";
            bookButton.Size = new Size(85, 30);
            bookButton.TabIndex = 5;
            bookButton.Text = "Book";
            bookButton.UseVisualStyleBackColor = true;
            bookButton.Click += bookButton_Click;
            //
            // cancelButton
            //
            cancelButton.Location = new Point(345, 370);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(85, 30);
            cancelButton.TabIndex = 6;
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
            ClientSize = new Size(460, 420);
            Controls.Add(loggedInLabel);
            Controls.Add(titleLabel);
            Controls.Add(patientIdLabel);
            Controls.Add(patientIdTextBox);
            Controls.Add(doctorLabel);
            Controls.Add(doctorComboBox);
            Controls.Add(dateLabel);
            Controls.Add(appointmentDatePicker);
            Controls.Add(timeSlotLabel);
            Controls.Add(appointmentTimeComboBox);
            Controls.Add(availabilityStatusLabel);
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
        private Label dateLabel;
        private DateTimePicker appointmentDatePicker;
        private Label timeSlotLabel;
        private ComboBox appointmentTimeComboBox;
        private Label availabilityStatusLabel;
        private Label reasonLabel;
        private TextBox reasonTextBox;
        private Button bookButton;
        private Button cancelButton;
    }


}