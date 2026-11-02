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
            patientSearchControl = new PatientSearchControl();
            patientNameLabel = new Label();
            patientNameTextBox = new TextBox();
            patientDobLabel = new Label();
            patientDobTextBox = new TextBox();
            inactivePatientLabel = new Label();
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
            titleLabel.Location = new Point(20, 40);
            titleLabel.Name = "titleLabel";
            titleLabel.Text = "Create Appointment";
            //
            // patientSearchControl
            //
            patientSearchControl.Location = new Point(20, 75);
            patientSearchControl.Name = "patientSearchControl";
            patientSearchControl.Size = new Size(760, 300);
            patientSearchControl.TabIndex = 0;
            patientSearchControl.PatientSelected += patientSearchControl_PatientSelected;
            //
            // patientNameLabel
            //
            patientNameLabel.AutoSize = true;
            patientNameLabel.Location = new Point(20, 393);
            patientNameLabel.Name = "patientNameLabel";
            patientNameLabel.Text = "Patient:";
            //
            // patientNameTextBox
            //
            patientNameTextBox.Location = new Point(130, 390);
            patientNameTextBox.Name = "patientNameTextBox";
            patientNameTextBox.ReadOnly = true;
            patientNameTextBox.Size = new Size(300, 23);
            patientNameTextBox.TabStop = false;
            //
            // patientDobLabel
            //
            patientDobLabel.AutoSize = true;
            patientDobLabel.Location = new Point(20, 428);
            patientDobLabel.Name = "patientDobLabel";
            patientDobLabel.Text = "Date of birth:";
            //
            // patientDobTextBox
            //
            patientDobTextBox.Location = new Point(130, 425);
            patientDobTextBox.Name = "patientDobTextBox";
            patientDobTextBox.ReadOnly = true;
            patientDobTextBox.Size = new Size(300, 23);
            patientDobTextBox.TabStop = false;
            //
            // inactivePatientLabel
            //
            inactivePatientLabel.AutoSize = true;
            inactivePatientLabel.ForeColor = Color.Firebrick;
            inactivePatientLabel.Location = new Point(130, 453);
            inactivePatientLabel.Name = "inactivePatientLabel";
            inactivePatientLabel.Size = new Size(0, 15);
            //
            // doctorLabel
            //
            doctorLabel.AutoSize = true;
            doctorLabel.Location = new Point(20, 483);
            doctorLabel.Name = "doctorLabel";
            doctorLabel.Text = "Doctor:";
            //
            // doctorComboBox
            //
            doctorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            doctorComboBox.Location = new Point(130, 480);
            doctorComboBox.Name = "doctorComboBox";
            doctorComboBox.Size = new Size(300, 23);
            doctorComboBox.TabIndex = 1;
            doctorComboBox.SelectedIndexChanged += doctorComboBox_SelectedIndexChanged;
            //
            // dateLabel
            //
            dateLabel.AutoSize = true;
            dateLabel.Location = new Point(20, 523);
            dateLabel.Name = "dateLabel";
            dateLabel.Text = "Date:";
            //
            // appointmentDatePicker
            //
            appointmentDatePicker.Format = DateTimePickerFormat.Short;
            appointmentDatePicker.Location = new Point(130, 520);
            appointmentDatePicker.Name = "appointmentDatePicker";
            appointmentDatePicker.Size = new Size(300, 23);
            appointmentDatePicker.TabIndex = 2;
            appointmentDatePicker.ValueChanged += appointmentDatePicker_ValueChanged;
            //
            // timeSlotLabel
            //
            timeSlotLabel.AutoSize = true;
            timeSlotLabel.Location = new Point(20, 563);
            timeSlotLabel.Name = "timeSlotLabel";
            timeSlotLabel.Text = "Time slot:";
            //
            // appointmentTimeComboBox
            //
            appointmentTimeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            appointmentTimeComboBox.FormattingEnabled = true;
            appointmentTimeComboBox.Location = new Point(130, 560);
            appointmentTimeComboBox.Name = "appointmentTimeComboBox";
            appointmentTimeComboBox.Size = new Size(300, 23);
            appointmentTimeComboBox.TabIndex = 3;
            //
            // availabilityStatusLabel
            //
            availabilityStatusLabel.AutoSize = true;
            availabilityStatusLabel.ForeColor = Color.Firebrick;
            availabilityStatusLabel.Location = new Point(130, 586);
            availabilityStatusLabel.Name = "availabilityStatusLabel";
            availabilityStatusLabel.Size = new Size(0, 15);
            //
            // reasonLabel
            //
            reasonLabel.AutoSize = true;
            reasonLabel.Location = new Point(20, 618);
            reasonLabel.Name = "reasonLabel";
            reasonLabel.Text = "Reason:";
            //
            // reasonTextBox
            //
            reasonTextBox.Location = new Point(130, 615);
            reasonTextBox.MaxLength = 255;
            reasonTextBox.Multiline = true;
            reasonTextBox.Name = "reasonTextBox";
            reasonTextBox.ScrollBars = ScrollBars.Vertical;
            reasonTextBox.Size = new Size(300, 80);
            reasonTextBox.TabIndex = 4;
            //
            // bookButton
            //
            bookButton.Location = new Point(250, 710);
            bookButton.Name = "bookButton";
            bookButton.Size = new Size(85, 30);
            bookButton.TabIndex = 5;
            bookButton.Text = "Book";
            bookButton.UseVisualStyleBackColor = true;
            bookButton.Click += bookButton_Click;
            //
            // cancelButton
            //
            cancelButton.Location = new Point(345, 710);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(85, 30);
            cancelButton.TabIndex = 6;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            //
            // AppointmentForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(800, 760);
            Controls.Add(loggedInLabel);
            Controls.Add(titleLabel);
            Controls.Add(patientSearchControl);
            Controls.Add(patientNameLabel);
            Controls.Add(patientNameTextBox);
            Controls.Add(patientDobLabel);
            Controls.Add(patientDobTextBox);
            Controls.Add(inactivePatientLabel);
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
            Name = "AppointmentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create Appointment";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label loggedInLabel;
        private Label titleLabel;
        private PatientSearchControl patientSearchControl;
        private Label patientNameLabel;
        private TextBox patientNameTextBox;
        private Label patientDobLabel;
        private TextBox patientDobTextBox;
        private Label inactivePatientLabel;
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