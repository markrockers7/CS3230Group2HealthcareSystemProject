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
            appointmentTabControl = new TabControl();
            createAppointmentTabPage = new TabPage();
            orderTestTabPage = new TabPage();
            selectAppointmentErrorLabel = new Label();
            label2 = new Label();
            appointmentDataGridView = new DataGridView();
            doctorNameColumn = new DataGridViewTextBoxColumn();
            timeColumn = new DataGridViewTextBoxColumn();
            reasonColumn = new DataGridViewTextBoxColumn();
            label1 = new Label();
            orderTestPatientSearchControl = new PatientSearchControl();
            availableTestsLabel = new Label();
            testCheckedListBox = new CheckedListBox();
            appointmentTabControl.SuspendLayout();
            createAppointmentTabPage.SuspendLayout();
            orderTestTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)appointmentDataGridView).BeginInit();
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
            titleLabel.Location = new Point(6, 3);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(165, 21);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Create Appointment";
            // 
            // patientSearchControl
            // 
            patientSearchControl.Location = new Point(6, 38);
            patientSearchControl.Name = "patientSearchControl";
            patientSearchControl.Size = new Size(760, 300);
            patientSearchControl.TabIndex = 0;
            patientSearchControl.PatientSelected += patientSearchControl_PatientSelected;
            // 
            // patientNameLabel
            // 
            patientNameLabel.AutoSize = true;
            patientNameLabel.Location = new Point(6, 356);
            patientNameLabel.Name = "patientNameLabel";
            patientNameLabel.Size = new Size(47, 15);
            patientNameLabel.TabIndex = 2;
            patientNameLabel.Text = "Patient:";
            // 
            // patientNameTextBox
            // 
            patientNameTextBox.Location = new Point(116, 353);
            patientNameTextBox.Name = "patientNameTextBox";
            patientNameTextBox.ReadOnly = true;
            patientNameTextBox.Size = new Size(300, 23);
            patientNameTextBox.TabIndex = 3;
            patientNameTextBox.TabStop = false;
            // 
            // patientDobLabel
            // 
            patientDobLabel.AutoSize = true;
            patientDobLabel.Location = new Point(6, 391);
            patientDobLabel.Name = "patientDobLabel";
            patientDobLabel.Size = new Size(76, 15);
            patientDobLabel.TabIndex = 4;
            patientDobLabel.Text = "Date of birth:";
            // 
            // patientDobTextBox
            // 
            patientDobTextBox.Location = new Point(116, 388);
            patientDobTextBox.Name = "patientDobTextBox";
            patientDobTextBox.ReadOnly = true;
            patientDobTextBox.Size = new Size(300, 23);
            patientDobTextBox.TabIndex = 5;
            patientDobTextBox.TabStop = false;
            // 
            // inactivePatientLabel
            // 
            inactivePatientLabel.AutoSize = true;
            inactivePatientLabel.ForeColor = Color.Firebrick;
            inactivePatientLabel.Location = new Point(116, 416);
            inactivePatientLabel.Name = "inactivePatientLabel";
            inactivePatientLabel.Size = new Size(0, 15);
            inactivePatientLabel.TabIndex = 6;
            // 
            // doctorLabel
            // 
            doctorLabel.AutoSize = true;
            doctorLabel.Location = new Point(6, 446);
            doctorLabel.Name = "doctorLabel";
            doctorLabel.Size = new Size(46, 15);
            doctorLabel.TabIndex = 3;
            doctorLabel.Text = "Doctor:";
            // 
            // doctorComboBox
            // 
            doctorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            doctorComboBox.Location = new Point(116, 443);
            doctorComboBox.Name = "doctorComboBox";
            doctorComboBox.Size = new Size(300, 23);
            doctorComboBox.TabIndex = 1;
            doctorComboBox.SelectedIndexChanged += doctorComboBox_SelectedIndexChanged;
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = true;
            dateLabel.Location = new Point(6, 486);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(34, 15);
            dateLabel.TabIndex = 7;
            dateLabel.Text = "Date:";
            // 
            // appointmentDatePicker
            // 
            appointmentDatePicker.Format = DateTimePickerFormat.Short;
            appointmentDatePicker.Location = new Point(116, 483);
            appointmentDatePicker.Name = "appointmentDatePicker";
            appointmentDatePicker.Size = new Size(300, 23);
            appointmentDatePicker.TabIndex = 2;
            appointmentDatePicker.ValueChanged += appointmentDatePicker_ValueChanged;
            // 
            // timeSlotLabel
            // 
            timeSlotLabel.AutoSize = true;
            timeSlotLabel.Location = new Point(6, 526);
            timeSlotLabel.Name = "timeSlotLabel";
            timeSlotLabel.Size = new Size(59, 15);
            timeSlotLabel.TabIndex = 8;
            timeSlotLabel.Text = "Time slot:";
            // 
            // appointmentTimeComboBox
            // 
            appointmentTimeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            appointmentTimeComboBox.FormattingEnabled = true;
            appointmentTimeComboBox.Location = new Point(116, 523);
            appointmentTimeComboBox.Name = "appointmentTimeComboBox";
            appointmentTimeComboBox.Size = new Size(300, 23);
            appointmentTimeComboBox.TabIndex = 3;
            // 
            // availabilityStatusLabel
            // 
            availabilityStatusLabel.AutoSize = true;
            availabilityStatusLabel.ForeColor = Color.Firebrick;
            availabilityStatusLabel.Location = new Point(116, 549);
            availabilityStatusLabel.Name = "availabilityStatusLabel";
            availabilityStatusLabel.Size = new Size(0, 15);
            availabilityStatusLabel.TabIndex = 9;
            // 
            // reasonLabel
            // 
            reasonLabel.AutoSize = true;
            reasonLabel.Location = new Point(6, 581);
            reasonLabel.Name = "reasonLabel";
            reasonLabel.Size = new Size(48, 15);
            reasonLabel.TabIndex = 5;
            reasonLabel.Text = "Reason:";
            // 
            // reasonTextBox
            // 
            reasonTextBox.Location = new Point(116, 578);
            reasonTextBox.MaxLength = 255;
            reasonTextBox.Multiline = true;
            reasonTextBox.Name = "reasonTextBox";
            reasonTextBox.ScrollBars = ScrollBars.Vertical;
            reasonTextBox.Size = new Size(300, 80);
            reasonTextBox.TabIndex = 4;
            // 
            // bookButton
            // 
            bookButton.Location = new Point(236, 673);
            bookButton.Name = "bookButton";
            bookButton.Size = new Size(85, 30);
            bookButton.TabIndex = 5;
            bookButton.Text = "Book";
            bookButton.UseVisualStyleBackColor = true;
            bookButton.Click += bookButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(331, 673);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(85, 30);
            cancelButton.TabIndex = 6;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // appointmentTabControl
            // 
            appointmentTabControl.Controls.Add(createAppointmentTabPage);
            appointmentTabControl.Controls.Add(orderTestTabPage);
            appointmentTabControl.Location = new Point(0, 18);
            appointmentTabControl.Name = "appointmentTabControl";
            appointmentTabControl.SelectedIndex = 0;
            appointmentTabControl.Size = new Size(799, 742);
            appointmentTabControl.TabIndex = 10;
            // 
            // createAppointmentTabPage
            // 
            createAppointmentTabPage.Controls.Add(titleLabel);
            createAppointmentTabPage.Controls.Add(cancelButton);
            createAppointmentTabPage.Controls.Add(bookButton);
            createAppointmentTabPage.Controls.Add(patientSearchControl);
            createAppointmentTabPage.Controls.Add(reasonTextBox);
            createAppointmentTabPage.Controls.Add(patientNameLabel);
            createAppointmentTabPage.Controls.Add(reasonLabel);
            createAppointmentTabPage.Controls.Add(patientNameTextBox);
            createAppointmentTabPage.Controls.Add(availabilityStatusLabel);
            createAppointmentTabPage.Controls.Add(patientDobLabel);
            createAppointmentTabPage.Controls.Add(appointmentTimeComboBox);
            createAppointmentTabPage.Controls.Add(patientDobTextBox);
            createAppointmentTabPage.Controls.Add(timeSlotLabel);
            createAppointmentTabPage.Controls.Add(inactivePatientLabel);
            createAppointmentTabPage.Controls.Add(appointmentDatePicker);
            createAppointmentTabPage.Controls.Add(doctorLabel);
            createAppointmentTabPage.Controls.Add(dateLabel);
            createAppointmentTabPage.Controls.Add(doctorComboBox);
            createAppointmentTabPage.Location = new Point(4, 24);
            createAppointmentTabPage.Name = "createAppointmentTabPage";
            createAppointmentTabPage.Padding = new Padding(3);
            createAppointmentTabPage.Size = new Size(791, 714);
            createAppointmentTabPage.TabIndex = 0;
            createAppointmentTabPage.Text = "Create Appointment";
            createAppointmentTabPage.UseVisualStyleBackColor = true;
            // 
            // orderTestTabPage
            // 
            orderTestTabPage.Controls.Add(selectAppointmentErrorLabel);
            orderTestTabPage.Controls.Add(label2);
            orderTestTabPage.Controls.Add(appointmentDataGridView);
            orderTestTabPage.Controls.Add(label1);
            orderTestTabPage.Controls.Add(orderTestPatientSearchControl);
            orderTestTabPage.Controls.Add(availableTestsLabel);
            orderTestTabPage.Controls.Add(testCheckedListBox);
            orderTestTabPage.Location = new Point(4, 24);
            orderTestTabPage.Name = "orderTestTabPage";
            orderTestTabPage.Padding = new Padding(3);
            orderTestTabPage.Size = new Size(791, 714);
            orderTestTabPage.TabIndex = 1;
            orderTestTabPage.Text = "Order Tests";
            orderTestTabPage.UseVisualStyleBackColor = true;
            // 
            // selectAppointmentErrorLabel
            // 
            selectAppointmentErrorLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            selectAppointmentErrorLabel.ForeColor = Color.Red;
            selectAppointmentErrorLabel.Location = new Point(16, 341);
            selectAppointmentErrorLabel.Name = "selectAppointmentErrorLabel";
            selectAppointmentErrorLabel.Size = new Size(330, 23);
            selectAppointmentErrorLabel.TabIndex = 4;
            selectAppointmentErrorLabel.Text = "ERROR";
            selectAppointmentErrorLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(16, 366);
            label2.Name = "label2";
            label2.Size = new Size(162, 21);
            label2.TabIndex = 3;
            label2.Text = "Select Appointment";
            // 
            // availableTestsLabel
            // 
            availableTestsLabel.AutoSize = true;
            availableTestsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            availableTestsLabel.Location = new Point(365, 366);
            availableTestsLabel.Name = "availableTestsLabel";
            availableTestsLabel.Size = new Size(111, 21);
            availableTestsLabel.TabIndex = 5;
            availableTestsLabel.Text = "Available Tests";
            // 
            // appointmentDataGridView
            // 
            appointmentDataGridView.AllowUserToAddRows = false;
            appointmentDataGridView.AllowUserToDeleteRows = false;
            appointmentDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            appointmentDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            appointmentDataGridView.Columns.AddRange(new DataGridViewColumn[] { doctorNameColumn, timeColumn, reasonColumn });
            appointmentDataGridView.Location = new Point(16, 390);
            appointmentDataGridView.Name = "appointmentDataGridView";
            appointmentDataGridView.ReadOnly = true;
            appointmentDataGridView.Size = new Size(330, 134);
            appointmentDataGridView.TabIndex = 2;
            // 
            // testCheckedListBox
            // 
            testCheckedListBox.FormattingEnabled = true;
            testCheckedListBox.Location = new Point(365, 390);
            testCheckedListBox.Name = "testCheckedListBox";
            testCheckedListBox.Size = new Size(400, 134);
            testCheckedListBox.TabIndex = 6;
            // 
            // doctorNameColumn
            // 
            doctorNameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            doctorNameColumn.HeaderText = "Doctor Name";
            doctorNameColumn.Name = "doctorNameColumn";
            doctorNameColumn.ReadOnly = true;
            doctorNameColumn.Width = 95;
            // 
            // timeColumn
            // 
            timeColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            timeColumn.HeaderText = "Appointment Time";
            timeColumn.Name = "timeColumn";
            timeColumn.ReadOnly = true;
            timeColumn.Width = 122;
            // 
            // reasonColumn
            // 
            reasonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            reasonColumn.HeaderText = "Reason";
            reasonColumn.Name = "reasonColumn";
            reasonColumn.ReadOnly = true;
            reasonColumn.Width = 70;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Size = new Size(148, 21);
            label1.TabIndex = 1;
            label1.Text = "Search For Patient";
            // 
            // orderTestPatientSearchControl
            // 
            orderTestPatientSearchControl.Location = new Point(6, 38);
            orderTestPatientSearchControl.Name = "orderTestPatientSearchControl";
            orderTestPatientSearchControl.Size = new Size(760, 300);
            orderTestPatientSearchControl.TabIndex = 0;
            orderTestPatientSearchControl.PatientSelected += orderTestPatientSearch_PatientSelected;
            // 
            // AppointmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(800, 760);
            Controls.Add(appointmentTabControl);
            Controls.Add(loggedInLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AppointmentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Create Appointment";
            appointmentTabControl.ResumeLayout(false);
            createAppointmentTabPage.ResumeLayout(false);
            createAppointmentTabPage.PerformLayout();
            orderTestTabPage.ResumeLayout(false);
            orderTestTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)appointmentDataGridView).EndInit();
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
        private TabControl appointmentTabControl;
        private TabPage createAppointmentTabPage;
        private TabPage orderTestTabPage;
        private Label label1;
        private PatientSearchControl orderTestPatientSearchControl;
        private DataGridView appointmentDataGridView;
        private DataGridViewTextBoxColumn doctorNameColumn;
        private DataGridViewTextBoxColumn timeColumn;
        private DataGridViewTextBoxColumn reasonColumn;
        private Label selectAppointmentErrorLabel;
        private Label label2;
        private Label availableTestsLabel;
        private CheckedListBox testCheckedListBox;
    }
}