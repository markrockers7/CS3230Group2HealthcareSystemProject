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
            appointmentTabControl = new TabControl();
            createAppointmentTabPage = new TabPage();
            initialDiagnosisTabPage = new TabPage();
            dataGridView1 = new DataGridView();
            label3 = new Label();
            initialDiagnosisTextBox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            appointmentComboBox = new ComboBox();
            appointmentTabControl.SuspendLayout();
            createAppointmentTabPage.SuspendLayout();
            initialDiagnosisTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // loggedInLabel
            // 
            loggedInLabel.AutoSize = true;
            loggedInLabel.ForeColor = SystemColors.GrayText;
            loggedInLabel.Location = new Point(0, 0);
            loggedInLabel.Name = "loggedInLabel";
            loggedInLabel.Size = new Size(77, 15);
            loggedInLabel.TabIndex = 0;
            loggedInLabel.Text = "Logged in as:";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            titleLabel.Location = new Point(6, 37);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(165, 21);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Create Appointment";
            // 
            // patientIdLabel
            // 
            patientIdLabel.AutoSize = true;
            patientIdLabel.Location = new Point(6, 87);
            patientIdLabel.Name = "patientIdLabel";
            patientIdLabel.Size = new Size(61, 15);
            patientIdLabel.TabIndex = 2;
            patientIdLabel.Text = "Patient ID:";
            // 
            // patientIdTextBox
            // 
            patientIdTextBox.Location = new Point(116, 84);
            patientIdTextBox.Name = "patientIdTextBox";
            patientIdTextBox.PlaceholderText = "Temporary: enter a patient ID";
            patientIdTextBox.Size = new Size(300, 23);
            patientIdTextBox.TabIndex = 0;
            // 
            // doctorLabel
            // 
            doctorLabel.AutoSize = true;
            doctorLabel.Location = new Point(6, 127);
            doctorLabel.Name = "doctorLabel";
            doctorLabel.Size = new Size(46, 15);
            doctorLabel.TabIndex = 3;
            doctorLabel.Text = "Doctor:";
            // 
            // doctorComboBox
            // 
            doctorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            doctorComboBox.Location = new Point(116, 124);
            doctorComboBox.Name = "doctorComboBox";
            doctorComboBox.Size = new Size(300, 23);
            doctorComboBox.TabIndex = 1;
            // 
            // dateTimeLabel
            // 
            dateTimeLabel.AutoSize = true;
            dateTimeLabel.Location = new Point(6, 167);
            dateTimeLabel.Name = "dateTimeLabel";
            dateTimeLabel.Size = new Size(84, 15);
            dateTimeLabel.TabIndex = 4;
            dateTimeLabel.Text = "Date and time:";
            // 
            // appointmentDateTimePicker
            // 
            appointmentDateTimePicker.CustomFormat = "MM/dd/yyyy   hh:mm tt";
            appointmentDateTimePicker.Format = DateTimePickerFormat.Custom;
            appointmentDateTimePicker.Location = new Point(116, 164);
            appointmentDateTimePicker.Name = "appointmentDateTimePicker";
            appointmentDateTimePicker.Size = new Size(300, 23);
            appointmentDateTimePicker.TabIndex = 2;
            // 
            // reasonLabel
            // 
            reasonLabel.AutoSize = true;
            reasonLabel.Location = new Point(6, 207);
            reasonLabel.Name = "reasonLabel";
            reasonLabel.Size = new Size(48, 15);
            reasonLabel.TabIndex = 5;
            reasonLabel.Text = "Reason:";
            // 
            // reasonTextBox
            // 
            reasonTextBox.Location = new Point(116, 204);
            reasonTextBox.MaxLength = 255;
            reasonTextBox.Multiline = true;
            reasonTextBox.Name = "reasonTextBox";
            reasonTextBox.ScrollBars = ScrollBars.Vertical;
            reasonTextBox.Size = new Size(300, 80);
            reasonTextBox.TabIndex = 3;
            // 
            // bookButton
            // 
            bookButton.Location = new Point(236, 307);
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
            // appointmentTabControl
            // 
            appointmentTabControl.Controls.Add(createAppointmentTabPage);
            appointmentTabControl.Controls.Add(initialDiagnosisTabPage);
            appointmentTabControl.Location = new Point(0, 0);
            appointmentTabControl.Name = "appointmentTabControl";
            appointmentTabControl.SelectedIndex = 0;
            appointmentTabControl.Size = new Size(484, 409);
            appointmentTabControl.TabIndex = 6;
            // 
            // createAppointmentTabPage
            // 
            createAppointmentTabPage.Controls.Add(loggedInLabel);
            createAppointmentTabPage.Controls.Add(titleLabel);
            createAppointmentTabPage.Controls.Add(patientIdLabel);
            createAppointmentTabPage.Controls.Add(bookButton);
            createAppointmentTabPage.Controls.Add(patientIdTextBox);
            createAppointmentTabPage.Controls.Add(reasonTextBox);
            createAppointmentTabPage.Controls.Add(doctorLabel);
            createAppointmentTabPage.Controls.Add(reasonLabel);
            createAppointmentTabPage.Controls.Add(doctorComboBox);
            createAppointmentTabPage.Controls.Add(appointmentDateTimePicker);
            createAppointmentTabPage.Controls.Add(dateTimeLabel);
            createAppointmentTabPage.Location = new Point(4, 24);
            createAppointmentTabPage.Name = "createAppointmentTabPage";
            createAppointmentTabPage.Padding = new Padding(3);
            createAppointmentTabPage.Size = new Size(476, 381);
            createAppointmentTabPage.TabIndex = 0;
            createAppointmentTabPage.Text = "Create Appointment";
            createAppointmentTabPage.UseVisualStyleBackColor = true;
            // 
            // initialDiagnosisTabPage
            // 
            initialDiagnosisTabPage.Controls.Add(dataGridView1);
            initialDiagnosisTabPage.Controls.Add(label3);
            initialDiagnosisTabPage.Controls.Add(initialDiagnosisTextBox);
            initialDiagnosisTabPage.Controls.Add(label2);
            initialDiagnosisTabPage.Controls.Add(label1);
            initialDiagnosisTabPage.Controls.Add(appointmentComboBox);
            initialDiagnosisTabPage.Location = new Point(4, 24);
            initialDiagnosisTabPage.Name = "initialDiagnosisTabPage";
            initialDiagnosisTabPage.Padding = new Padding(3);
            initialDiagnosisTabPage.Size = new Size(476, 381);
            initialDiagnosisTabPage.TabIndex = 1;
            initialDiagnosisTabPage.Text = "Enter Initial Diagnosis";
            initialDiagnosisTabPage.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(15, 171);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(453, 150);
            dataGridView1.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 150);
            label3.Name = "label3";
            label3.Size = new Size(106, 15);
            label3.TabIndex = 4;
            label3.Text = "Available Lab Tests";
            // 
            // initialDiagnosisTextBox
            // 
            initialDiagnosisTextBox.Location = new Point(15, 78);
            initialDiagnosisTextBox.Multiline = true;
            initialDiagnosisTextBox.Name = "initialDiagnosisTextBox";
            initialDiagnosisTextBox.Size = new Size(453, 46);
            initialDiagnosisTextBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 60);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 2;
            label2.Text = "Initial Diagnosis";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 22);
            label1.Name = "label1";
            label1.Size = new Size(115, 15);
            label1.TabIndex = 1;
            label1.Text = "Select Appointment:";
            // 
            // appointmentComboBox
            // 
            appointmentComboBox.FormattingEnabled = true;
            appointmentComboBox.Location = new Point(133, 19);
            appointmentComboBox.Name = "appointmentComboBox";
            appointmentComboBox.Size = new Size(121, 23);
            appointmentComboBox.TabIndex = 0;
            // 
            // AppointmentForm
            // 
            AcceptButton = bookButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(484, 411);
            Controls.Add(appointmentTabControl);
            Controls.Add(cancelButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AppointmentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create Appointment";
            appointmentTabControl.ResumeLayout(false);
            createAppointmentTabPage.ResumeLayout(false);
            createAppointmentTabPage.PerformLayout();
            initialDiagnosisTabPage.ResumeLayout(false);
            initialDiagnosisTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
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
        private TabControl appointmentTabControl;
        private TabPage createAppointmentTabPage;
        private TabPage initialDiagnosisTabPage;
        private Label label1;
        private ComboBox appointmentComboBox;
        private Label label2;
        private TextBox initialDiagnosisTextBox;
        private DataGridView dataGridView1;
        private Label label3;
    }


}