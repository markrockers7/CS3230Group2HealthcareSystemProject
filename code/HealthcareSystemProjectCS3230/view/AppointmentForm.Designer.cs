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
            DataGridViewCellStyle testResultsVisitDateCellStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle testResultsPerformedCellStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle viewVisitsVisitDateCellStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle viewVisitsPerformedCellStyle = new DataGridViewCellStyle();
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
            errorLabel = new Label();
            bookButton = new Button();
            cancelButton = new Button();
            appointmentTabControl = new TabControl();
            createAppointmentTabPage = new TabPage();
            orderTestTabPage = new TabPage();
            visitAndOrderTestErrorLabel = new Label();
            label2 = new Label();
            appointmentDataGridView = new DataGridView();
            appointmentIdColumn = new DataGridViewTextBoxColumn();
            doctorNameColumn = new DataGridViewTextBoxColumn();
            timeColumn = new DataGridViewTextBoxColumn();
            reasonColumn = new DataGridViewTextBoxColumn();
            label1 = new Label();
            orderTestPatientSearchControl = new PatientSearchControl();
            availableTestsLabel = new Label();
            testCheckedListBox = new CheckedListBox();
            visitDetailsLabel = new Label();
            systolicLabel = new Label();
            systolicTextBox = new TextBox();
            diastolicLabel = new Label();
            diastolicTextBox = new TextBox();
            pulseLabel = new Label();
            pulseTextBox = new TextBox();
            bodyTemperatureLabel = new Label();
            bodyTemperatureTextBox = new TextBox();
            heightLabel = new Label();
            heightTextBox = new TextBox();
            weightLabel = new Label();
            weightTextBox = new TextBox();
            symptomsLabel = new Label();
            symptomsTextBox = new TextBox();
            initialDiagnosisLabel = new Label();
            initialDiagnosisTextBox = new TextBox();
            submitVisitButton = new Button();
            testResultsTabPage = new TabPage();
            testResultsTitleLabel = new Label();
            testResultsPatientSearchControl = new PatientSearchControl();
            testResultsErrorLabel = new Label();
            testResultsSelectVisitLabel = new Label();
            testResultsVisitGrid = new DataGridView();
            testResultsVisitDateColumn = new DataGridViewTextBoxColumn();
            testResultsVisitDoctorColumn = new DataGridViewTextBoxColumn();
            testResultsVisitStatusColumn = new DataGridViewTextBoxColumn();
            testResultsOrderedTestsLabel = new Label();
            testResultsTestsGrid = new DataGridView();
            testResultsTestNameColumn = new DataGridViewTextBoxColumn();
            testResultsNormalRangeColumn = new DataGridViewTextBoxColumn();
            testResultsResultColumn = new DataGridViewTextBoxColumn();
            testResultsAbnormalColumn = new DataGridViewTextBoxColumn();
            testResultsPerformedColumn = new DataGridViewTextBoxColumn();
            testResultsPatientInfoLabel = new Label();
            testResultsSelectedTestLabel = new Label();
            testResultsDatePerformedLabel = new Label();
            testResultsDatePerformedPicker = new DateTimePicker();
            testResultsResultLabel = new Label();
            testResultsResultTextBox = new TextBox();
            testResultsAbnormalCheckBox = new CheckBox();
            testResultsSaveButton = new Button();
            finalDiagnosisTabPage = new TabPage();
            finalDiagnosisWarningLabel = new Label();
            finalDiagnosisSubmitButton = new Button();
            label5 = new Label();
            finalDiagnosisTextBox = new TextBox();
            label4 = new Label();
            visitDataGridView = new DataGridView();
            finalDiagnosisAppointmentIdColumn = new DataGridViewTextBoxColumn();
            visitDoctorNameColumn = new DataGridViewTextBoxColumn();
            visitInitialDiagnosisColumn = new DataGridViewTextBoxColumn();
            label3 = new Label();
            finalDiagnosisPatientSearchControl = new PatientSearchControl();
            viewVisitsTabPage = new TabPage();
            viewVisitsTitleLabel = new Label();
            viewVisitsPatientSearchControl = new PatientSearchControl();
            viewVisitsErrorLabel = new Label();
            viewVisitsSelectVisitLabel = new Label();
            viewVisitsVisitGrid = new DataGridView();
            viewVisitsVisitDateColumn = new DataGridViewTextBoxColumn();
            viewVisitsVisitDoctorColumn = new DataGridViewTextBoxColumn();
            viewVisitsVisitStatusColumn = new DataGridViewTextBoxColumn();
            viewVisitsDetailsLabel = new Label();
            viewVisitsDetailsTextBox = new TextBox();
            viewVisitsTestsLabel = new Label();
            viewVisitsTestsGrid = new DataGridView();
            viewVisitsTestNameColumn = new DataGridViewTextBoxColumn();
            viewVisitsNormalRangeColumn = new DataGridViewTextBoxColumn();
            viewVisitsResultColumn = new DataGridViewTextBoxColumn();
            viewVisitsAbnormalColumn = new DataGridViewTextBoxColumn();
            viewVisitsPerformedColumn = new DataGridViewTextBoxColumn();
            appointmentTabControl.SuspendLayout();
            createAppointmentTabPage.SuspendLayout();
            orderTestTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)appointmentDataGridView).BeginInit();
            testResultsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)testResultsVisitGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)testResultsTestsGrid).BeginInit();
            finalDiagnosisTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)visitDataGridView).BeginInit();
            viewVisitsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)viewVisitsVisitGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)viewVisitsTestsGrid).BeginInit();
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
            patientSearchControl.Margin = new Padding(4, 5, 4, 5);
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
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.ForeColor = Color.Firebrick;
            errorLabel.Location = new Point(430, 680);
            errorLabel.MaximumSize = new Size(350, 0);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(0, 15);
            errorLabel.TabIndex = 10;
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
            appointmentTabControl.Controls.Add(testResultsTabPage);
            appointmentTabControl.Controls.Add(finalDiagnosisTabPage);
            appointmentTabControl.Controls.Add(viewVisitsTabPage);
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
            createAppointmentTabPage.Controls.Add(errorLabel);
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
            orderTestTabPage.AutoScroll = true;
            orderTestTabPage.Controls.Add(visitAndOrderTestErrorLabel);
            orderTestTabPage.Controls.Add(label2);
            orderTestTabPage.Controls.Add(appointmentDataGridView);
            orderTestTabPage.Controls.Add(label1);
            orderTestTabPage.Controls.Add(orderTestPatientSearchControl);
            orderTestTabPage.Controls.Add(availableTestsLabel);
            orderTestTabPage.Controls.Add(testCheckedListBox);
            orderTestTabPage.Controls.Add(visitDetailsLabel);
            orderTestTabPage.Controls.Add(systolicLabel);
            orderTestTabPage.Controls.Add(systolicTextBox);
            orderTestTabPage.Controls.Add(diastolicLabel);
            orderTestTabPage.Controls.Add(diastolicTextBox);
            orderTestTabPage.Controls.Add(pulseLabel);
            orderTestTabPage.Controls.Add(pulseTextBox);
            orderTestTabPage.Controls.Add(bodyTemperatureLabel);
            orderTestTabPage.Controls.Add(bodyTemperatureTextBox);
            orderTestTabPage.Controls.Add(heightLabel);
            orderTestTabPage.Controls.Add(heightTextBox);
            orderTestTabPage.Controls.Add(weightLabel);
            orderTestTabPage.Controls.Add(weightTextBox);
            orderTestTabPage.Controls.Add(symptomsLabel);
            orderTestTabPage.Controls.Add(symptomsTextBox);
            orderTestTabPage.Controls.Add(initialDiagnosisLabel);
            orderTestTabPage.Controls.Add(initialDiagnosisTextBox);
            orderTestTabPage.Controls.Add(submitVisitButton);
            orderTestTabPage.Location = new Point(4, 24);
            orderTestTabPage.Name = "orderTestTabPage";
            orderTestTabPage.Padding = new Padding(3);
            orderTestTabPage.Size = new Size(791, 714);
            orderTestTabPage.TabIndex = 1;
            orderTestTabPage.Text = "Visit / Order Tests";
            orderTestTabPage.UseVisualStyleBackColor = true;
            // 
            // visitAndOrderTestErrorLabel
            // 
            visitAndOrderTestErrorLabel.AutoEllipsis = true;
            visitAndOrderTestErrorLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            visitAndOrderTestErrorLabel.ForeColor = Color.Red;
            visitAndOrderTestErrorLabel.Location = new Point(16, 341);
            visitAndOrderTestErrorLabel.Name = "visitAndOrderTestErrorLabel";
            visitAndOrderTestErrorLabel.Size = new Size(740, 23);
            visitAndOrderTestErrorLabel.TabIndex = 4;
            visitAndOrderTestErrorLabel.Text = "ERROR";
            visitAndOrderTestErrorLabel.TextAlign = ContentAlignment.MiddleCenter;
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
            // appointmentDataGridView
            // 
            appointmentDataGridView.AllowUserToAddRows = false;
            appointmentDataGridView.AllowUserToDeleteRows = false;
            appointmentDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            appointmentDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            appointmentDataGridView.Columns.AddRange(new DataGridViewColumn[] { appointmentIdColumn, doctorNameColumn, timeColumn, reasonColumn });
            appointmentDataGridView.Location = new Point(16, 390);
            appointmentDataGridView.MultiSelect = false;
            appointmentDataGridView.Name = "appointmentDataGridView";
            appointmentDataGridView.ReadOnly = true;
            appointmentDataGridView.RowHeadersVisible = false;
            appointmentDataGridView.RowHeadersWidth = 62;
            appointmentDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            appointmentDataGridView.Size = new Size(330, 134);
            appointmentDataGridView.TabIndex = 2;
            // 
            // appointmentIdColumn
            // 
            appointmentIdColumn.HeaderText = "Appointment ID";
            appointmentIdColumn.MinimumWidth = 8;
            appointmentIdColumn.Name = "appointmentIdColumn";
            appointmentIdColumn.ReadOnly = true;
            appointmentIdColumn.Visible = false;
            appointmentIdColumn.Width = 150;
            // 
            // doctorNameColumn
            // 
            doctorNameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            doctorNameColumn.HeaderText = "Doctor Name";
            doctorNameColumn.MinimumWidth = 8;
            doctorNameColumn.Name = "doctorNameColumn";
            doctorNameColumn.ReadOnly = true;
            doctorNameColumn.Width = 95;
            // 
            // timeColumn
            // 
            timeColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            timeColumn.HeaderText = "Appointment Time";
            timeColumn.MinimumWidth = 8;
            timeColumn.Name = "timeColumn";
            timeColumn.ReadOnly = true;
            timeColumn.Width = 122;
            // 
            // reasonColumn
            // 
            reasonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            reasonColumn.HeaderText = "Reason";
            reasonColumn.MinimumWidth = 8;
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
            orderTestPatientSearchControl.Margin = new Padding(4, 5, 4, 5);
            orderTestPatientSearchControl.Name = "orderTestPatientSearchControl";
            orderTestPatientSearchControl.Size = new Size(760, 300);
            orderTestPatientSearchControl.TabIndex = 0;
            orderTestPatientSearchControl.PatientSelected += orderTestPatientSearch_PatientSelected;
            // 
            // availableTestsLabel
            // 
            availableTestsLabel.AutoSize = true;
            availableTestsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            availableTestsLabel.Location = new Point(365, 366);
            availableTestsLabel.Name = "availableTestsLabel";
            availableTestsLabel.Size = new Size(123, 21);
            availableTestsLabel.TabIndex = 5;
            availableTestsLabel.Text = "Available Tests";
            // 
            // testCheckedListBox
            // 
            testCheckedListBox.FormattingEnabled = true;
            testCheckedListBox.Location = new Point(365, 390);
            testCheckedListBox.Name = "testCheckedListBox";
            testCheckedListBox.Size = new Size(400, 112);
            testCheckedListBox.TabIndex = 6;
            // 
            // visitDetailsLabel
            // 
            visitDetailsLabel.AutoSize = true;
            visitDetailsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            visitDetailsLabel.Location = new Point(16, 540);
            visitDetailsLabel.Name = "visitDetailsLabel";
            visitDetailsLabel.Size = new Size(181, 21);
            visitDetailsLabel.TabIndex = 7;
            visitDetailsLabel.Text = "Visit Vitals and Details";
            // 
            // systolicLabel
            // 
            systolicLabel.AutoSize = true;
            systolicLabel.Location = new Point(16, 574);
            systolicLabel.Name = "systolicLabel";
            systolicLabel.Size = new Size(104, 15);
            systolicLabel.TabIndex = 8;
            systolicLabel.Text = "Systolic (mm/Hg):";
            // 
            // systolicTextBox
            // 
            systolicTextBox.Location = new Point(126, 570);
            systolicTextBox.Name = "systolicTextBox";
            systolicTextBox.Size = new Size(59, 23);
            systolicTextBox.TabIndex = 7;
            // 
            // diastolicLabel
            // 
            diastolicLabel.AutoSize = true;
            diastolicLabel.Location = new Point(205, 574);
            diastolicLabel.Name = "diastolicLabel";
            diastolicLabel.Size = new Size(109, 15);
            diastolicLabel.TabIndex = 9;
            diastolicLabel.Text = "Diastolic (mm/Hg):";
            // 
            // diastolicTextBox
            // 
            diastolicTextBox.Location = new Point(320, 570);
            diastolicTextBox.Name = "diastolicTextBox";
            diastolicTextBox.Size = new Size(58, 23);
            diastolicTextBox.TabIndex = 8;
            // 
            // pulseLabel
            // 
            pulseLabel.AutoSize = true;
            pulseLabel.Location = new Point(400, 574);
            pulseLabel.Name = "pulseLabel";
            pulseLabel.Size = new Size(74, 15);
            pulseLabel.TabIndex = 10;
            pulseLabel.Text = "Pulse (BPM):";
            // 
            // pulseTextBox
            // 
            pulseTextBox.Location = new Point(475, 570);
            pulseTextBox.Name = "pulseTextBox";
            pulseTextBox.Size = new Size(48, 23);
            pulseTextBox.TabIndex = 9;
            // 
            // bodyTemperatureLabel
            // 
            bodyTemperatureLabel.AutoSize = true;
            bodyTemperatureLabel.Location = new Point(540, 574);
            bodyTemperatureLabel.Name = "bodyTemperatureLabel";
            bodyTemperatureLabel.Size = new Size(84, 15);
            bodyTemperatureLabel.TabIndex = 11;
            bodyTemperatureLabel.Text = "Body temp (°):";
            // 
            // bodyTemperatureTextBox
            // 
            bodyTemperatureTextBox.Location = new Point(635, 570);
            bodyTemperatureTextBox.Name = "bodyTemperatureTextBox";
            bodyTemperatureTextBox.Size = new Size(100, 23);
            bodyTemperatureTextBox.TabIndex = 10;
            // 
            // heightLabel
            // 
            heightLabel.AutoSize = true;
            heightLabel.Location = new Point(16, 609);
            heightLabel.Name = "heightLabel";
            heightLabel.Size = new Size(67, 15);
            heightLabel.TabIndex = 12;
            heightLabel.Text = "Height (in):";
            // 
            // heightTextBox
            // 
            heightTextBox.Location = new Point(105, 605);
            heightTextBox.Name = "heightTextBox";
            heightTextBox.Size = new Size(80, 23);
            heightTextBox.TabIndex = 11;
            // 
            // weightLabel
            // 
            weightLabel.AutoSize = true;
            weightLabel.Location = new Point(205, 609);
            weightLabel.Name = "weightLabel";
            weightLabel.Size = new Size(77, 15);
            weightLabel.TabIndex = 13;
            weightLabel.Text = "Weight (Lbs):";
            // 
            // weightTextBox
            // 
            weightTextBox.Location = new Point(298, 605);
            weightTextBox.Name = "weightTextBox";
            weightTextBox.Size = new Size(80, 23);
            weightTextBox.TabIndex = 12;
            // 
            // symptomsLabel
            // 
            symptomsLabel.AutoSize = true;
            symptomsLabel.Location = new Point(16, 647);
            symptomsLabel.Name = "symptomsLabel";
            symptomsLabel.Size = new Size(67, 15);
            symptomsLabel.TabIndex = 14;
            symptomsLabel.Text = "Symptoms:";
            // 
            // symptomsTextBox
            // 
            symptomsTextBox.Location = new Point(105, 643);
            symptomsTextBox.Multiline = true;
            symptomsTextBox.Name = "symptomsTextBox";
            symptomsTextBox.ScrollBars = ScrollBars.Vertical;
            symptomsTextBox.Size = new Size(630, 48);
            symptomsTextBox.TabIndex = 13;
            // 
            // initialDiagnosisLabel
            // 
            initialDiagnosisLabel.AutoSize = true;
            initialDiagnosisLabel.Location = new Point(16, 709);
            initialDiagnosisLabel.Name = "initialDiagnosisLabel";
            initialDiagnosisLabel.Size = new Size(92, 15);
            initialDiagnosisLabel.TabIndex = 15;
            initialDiagnosisLabel.Text = "Initial diagnosis:";
            // 
            // initialDiagnosisTextBox
            // 
            initialDiagnosisTextBox.Location = new Point(105, 705);
            initialDiagnosisTextBox.Multiline = true;
            initialDiagnosisTextBox.Name = "initialDiagnosisTextBox";
            initialDiagnosisTextBox.ScrollBars = ScrollBars.Vertical;
            initialDiagnosisTextBox.Size = new Size(630, 48);
            initialDiagnosisTextBox.TabIndex = 14;
            // 
            // submitVisitButton
            // 
            submitVisitButton.Location = new Point(650, 767);
            submitVisitButton.Name = "submitVisitButton";
            submitVisitButton.Size = new Size(115, 32);
            submitVisitButton.TabIndex = 15;
            submitVisitButton.Text = "Submit Visit";
            submitVisitButton.UseVisualStyleBackColor = true;
            submitVisitButton.Click += submitVisitButton_Click;
            // 
            // testResultsTabPage
            // 
            testResultsTabPage.Controls.Add(testResultsTitleLabel);
            testResultsTabPage.Controls.Add(testResultsPatientSearchControl);
            testResultsTabPage.Controls.Add(testResultsErrorLabel);
            testResultsTabPage.Controls.Add(testResultsSelectVisitLabel);
            testResultsTabPage.Controls.Add(testResultsVisitGrid);
            testResultsTabPage.Controls.Add(testResultsOrderedTestsLabel);
            testResultsTabPage.Controls.Add(testResultsTestsGrid);
            testResultsTabPage.Controls.Add(testResultsPatientInfoLabel);
            testResultsTabPage.Controls.Add(testResultsSelectedTestLabel);
            testResultsTabPage.Controls.Add(testResultsDatePerformedLabel);
            testResultsTabPage.Controls.Add(testResultsDatePerformedPicker);
            testResultsTabPage.Controls.Add(testResultsResultLabel);
            testResultsTabPage.Controls.Add(testResultsResultTextBox);
            testResultsTabPage.Controls.Add(testResultsAbnormalCheckBox);
            testResultsTabPage.Controls.Add(testResultsSaveButton);
            testResultsTabPage.Location = new Point(4, 24);
            testResultsTabPage.Name = "testResultsTabPage";
            testResultsTabPage.Padding = new Padding(3);
            testResultsTabPage.Size = new Size(791, 714);
            testResultsTabPage.TabIndex = 3;
            testResultsTabPage.Text = "Enter Test Results";
            testResultsTabPage.UseVisualStyleBackColor = true;
            // 
            // testResultsTitleLabel
            // 
            testResultsTitleLabel.AutoSize = true;
            testResultsTitleLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            testResultsTitleLabel.Location = new Point(3, 3);
            testResultsTitleLabel.Name = "testResultsTitleLabel";
            testResultsTitleLabel.Size = new Size(148, 21);
            testResultsTitleLabel.TabIndex = 1;
            testResultsTitleLabel.Text = "Search For Patient";
            // 
            // testResultsPatientSearchControl
            // 
            testResultsPatientSearchControl.Location = new Point(6, 38);
            testResultsPatientSearchControl.Margin = new Padding(4, 5, 4, 5);
            testResultsPatientSearchControl.Name = "testResultsPatientSearchControl";
            testResultsPatientSearchControl.Size = new Size(760, 300);
            testResultsPatientSearchControl.TabIndex = 0;
            testResultsPatientSearchControl.PatientSelected += testResultsPatientSearchControl_PatientSelected;
            // 
            // testResultsErrorLabel
            // 
            testResultsErrorLabel.AutoEllipsis = true;
            testResultsErrorLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            testResultsErrorLabel.ForeColor = Color.Red;
            testResultsErrorLabel.Location = new Point(16, 341);
            testResultsErrorLabel.Name = "testResultsErrorLabel";
            testResultsErrorLabel.Size = new Size(740, 23);
            testResultsErrorLabel.TabIndex = 2;
            testResultsErrorLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // testResultsSelectVisitLabel
            // 
            testResultsSelectVisitLabel.AutoSize = true;
            testResultsSelectVisitLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            testResultsSelectVisitLabel.Location = new Point(16, 366);
            testResultsSelectVisitLabel.Name = "testResultsSelectVisitLabel";
            testResultsSelectVisitLabel.Size = new Size(94, 21);
            testResultsSelectVisitLabel.TabIndex = 3;
            testResultsSelectVisitLabel.Text = "Select Visit";
            // 
            // testResultsVisitGrid
            // 
            testResultsVisitGrid.AllowUserToAddRows = false;
            testResultsVisitGrid.AllowUserToDeleteRows = false;
            testResultsVisitGrid.AutoGenerateColumns = false;
            testResultsVisitGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            testResultsVisitGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            testResultsVisitGrid.Columns.AddRange(new DataGridViewColumn[] { testResultsVisitDateColumn, testResultsVisitDoctorColumn, testResultsVisitStatusColumn });
            testResultsVisitGrid.Location = new Point(16, 390);
            testResultsVisitGrid.MultiSelect = false;
            testResultsVisitGrid.Name = "testResultsVisitGrid";
            testResultsVisitGrid.ReadOnly = true;
            testResultsVisitGrid.RowHeadersVisible = false;
            testResultsVisitGrid.ScrollBars = ScrollBars.Both;
            testResultsVisitGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            testResultsVisitGrid.Size = new Size(360, 150);
            testResultsVisitGrid.TabIndex = 4;
            testResultsVisitGrid.DataBindingComplete += testResultsVisitGrid_DataBindingComplete;
            testResultsVisitGrid.SelectionChanged += testResultsVisitGrid_SelectionChanged;
            // 
            // testResultsVisitDateColumn
            // 
            testResultsVisitDateCellStyle.Format = "g";
            testResultsVisitDateColumn.DataPropertyName = "AppointmentDateTime";
            testResultsVisitDateColumn.DefaultCellStyle = testResultsVisitDateCellStyle;
            testResultsVisitDateColumn.HeaderText = "Visit Date";
            testResultsVisitDateColumn.MinimumWidth = 120;
            testResultsVisitDateColumn.Name = "testResultsVisitDateColumn";
            testResultsVisitDateColumn.ReadOnly = true;
            // 
            // testResultsVisitDoctorColumn
            // 
            testResultsVisitDoctorColumn.DataPropertyName = "DoctorName";
            testResultsVisitDoctorColumn.HeaderText = "Doctor";
            testResultsVisitDoctorColumn.MinimumWidth = 110;
            testResultsVisitDoctorColumn.Name = "testResultsVisitDoctorColumn";
            testResultsVisitDoctorColumn.ReadOnly = true;
            // 
            // testResultsVisitStatusColumn
            // 
            testResultsVisitStatusColumn.DataPropertyName = "StatusText";
            testResultsVisitStatusColumn.HeaderText = "Status";
            testResultsVisitStatusColumn.MinimumWidth = 100;
            testResultsVisitStatusColumn.Name = "testResultsVisitStatusColumn";
            testResultsVisitStatusColumn.ReadOnly = true;
            // 
            // testResultsOrderedTestsLabel
            // 
            testResultsOrderedTestsLabel.AutoSize = true;
            testResultsOrderedTestsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            testResultsOrderedTestsLabel.Location = new Point(390, 366);
            testResultsOrderedTestsLabel.Name = "testResultsOrderedTestsLabel";
            testResultsOrderedTestsLabel.Size = new Size(118, 21);
            testResultsOrderedTestsLabel.TabIndex = 5;
            testResultsOrderedTestsLabel.Text = "Ordered Tests";
            // 
            // testResultsTestsGrid
            // 
            testResultsTestsGrid.AllowUserToAddRows = false;
            testResultsTestsGrid.AllowUserToDeleteRows = false;
            testResultsTestsGrid.AutoGenerateColumns = false;
            testResultsTestsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            testResultsTestsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            testResultsTestsGrid.Columns.AddRange(new DataGridViewColumn[] { testResultsTestNameColumn, testResultsNormalRangeColumn, testResultsResultColumn, testResultsAbnormalColumn, testResultsPerformedColumn });
            testResultsTestsGrid.Location = new Point(390, 390);
            testResultsTestsGrid.MultiSelect = false;
            testResultsTestsGrid.Name = "testResultsTestsGrid";
            testResultsTestsGrid.ReadOnly = true;
            testResultsTestsGrid.RowHeadersVisible = false;
            testResultsTestsGrid.ScrollBars = ScrollBars.Both;
            testResultsTestsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            testResultsTestsGrid.Size = new Size(375, 150);
            testResultsTestsGrid.TabIndex = 6;
            testResultsTestsGrid.DataBindingComplete += testResultsTestsGrid_DataBindingComplete;
            testResultsTestsGrid.SelectionChanged += testResultsTestsGrid_SelectionChanged;
            // 
            // testResultsTestNameColumn
            // 
            testResultsTestNameColumn.DataPropertyName = "TestName";
            testResultsTestNameColumn.HeaderText = "Test";
            testResultsTestNameColumn.MinimumWidth = 110;
            testResultsTestNameColumn.Name = "testResultsTestNameColumn";
            testResultsTestNameColumn.ReadOnly = true;
            // 
            // testResultsNormalRangeColumn
            // 
            testResultsNormalRangeColumn.DataPropertyName = "NormalRange";
            testResultsNormalRangeColumn.HeaderText = "Normal Range";
            testResultsNormalRangeColumn.MinimumWidth = 100;
            testResultsNormalRangeColumn.Name = "testResultsNormalRangeColumn";
            testResultsNormalRangeColumn.ReadOnly = true;
            // 
            // testResultsResultColumn
            // 
            testResultsResultColumn.DataPropertyName = "ResultText";
            testResultsResultColumn.HeaderText = "Result";
            testResultsResultColumn.MinimumWidth = 70;
            testResultsResultColumn.Name = "testResultsResultColumn";
            testResultsResultColumn.ReadOnly = true;
            // 
            // testResultsAbnormalColumn
            // 
            testResultsAbnormalColumn.DataPropertyName = "AbnormalText";
            testResultsAbnormalColumn.HeaderText = "Abnormal";
            testResultsAbnormalColumn.MinimumWidth = 65;
            testResultsAbnormalColumn.Name = "testResultsAbnormalColumn";
            testResultsAbnormalColumn.ReadOnly = true;
            // 
            // testResultsPerformedColumn
            // 
            testResultsPerformedCellStyle.Format = "g";
            testResultsPerformedColumn.DataPropertyName = "DatePerformed";
            testResultsPerformedColumn.DefaultCellStyle = testResultsPerformedCellStyle;
            testResultsPerformedColumn.HeaderText = "Performed";
            testResultsPerformedColumn.MinimumWidth = 115;
            testResultsPerformedColumn.Name = "testResultsPerformedColumn";
            testResultsPerformedColumn.ReadOnly = true;
            // 
            // testResultsPatientInfoLabel
            // 
            testResultsPatientInfoLabel.AutoSize = true;
            testResultsPatientInfoLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            testResultsPatientInfoLabel.Location = new Point(16, 550);
            testResultsPatientInfoLabel.Name = "testResultsPatientInfoLabel";
            testResultsPatientInfoLabel.Size = new Size(0, 15);
            testResultsPatientInfoLabel.TabIndex = 7;
            // 
            // testResultsSelectedTestLabel
            // 
            testResultsSelectedTestLabel.AutoSize = true;
            testResultsSelectedTestLabel.Location = new Point(16, 577);
            testResultsSelectedTestLabel.MaximumSize = new Size(750, 0);
            testResultsSelectedTestLabel.Name = "testResultsSelectedTestLabel";
            testResultsSelectedTestLabel.Size = new Size(0, 15);
            testResultsSelectedTestLabel.TabIndex = 8;
            // 
            // testResultsDatePerformedLabel
            // 
            testResultsDatePerformedLabel.AutoSize = true;
            testResultsDatePerformedLabel.Location = new Point(16, 608);
            testResultsDatePerformedLabel.Name = "testResultsDatePerformedLabel";
            testResultsDatePerformedLabel.Size = new Size(122, 15);
            testResultsDatePerformedLabel.TabIndex = 9;
            testResultsDatePerformedLabel.Text = "Date/time performed:";
            // 
            // testResultsDatePerformedPicker
            // 
            testResultsDatePerformedPicker.CustomFormat = "MM/dd/yyyy hh:mm tt";
            testResultsDatePerformedPicker.Format = DateTimePickerFormat.Custom;
            testResultsDatePerformedPicker.Location = new Point(150, 605);
            testResultsDatePerformedPicker.Name = "testResultsDatePerformedPicker";
            testResultsDatePerformedPicker.Size = new Size(220, 23);
            testResultsDatePerformedPicker.TabIndex = 10;
            // 
            // testResultsResultLabel
            // 
            testResultsResultLabel.AutoSize = true;
            testResultsResultLabel.Location = new Point(16, 643);
            testResultsResultLabel.Name = "testResultsResultLabel";
            testResultsResultLabel.Size = new Size(42, 15);
            testResultsResultLabel.TabIndex = 11;
            testResultsResultLabel.Text = "Result:";
            // 
            // testResultsResultTextBox
            // 
            testResultsResultTextBox.Location = new Point(150, 640);
            testResultsResultTextBox.MaxLength = 100;
            testResultsResultTextBox.Name = "testResultsResultTextBox";
            testResultsResultTextBox.Size = new Size(220, 23);
            testResultsResultTextBox.TabIndex = 12;
            testResultsResultTextBox.TextChanged += testResultsResultTextBox_TextChanged;
            // 
            // testResultsAbnormalCheckBox
            // 
            testResultsAbnormalCheckBox.AutoSize = true;
            testResultsAbnormalCheckBox.Location = new Point(390, 642);
            testResultsAbnormalCheckBox.Name = "testResultsAbnormalCheckBox";
            testResultsAbnormalCheckBox.Size = new Size(77, 19);
            testResultsAbnormalCheckBox.TabIndex = 13;
            testResultsAbnormalCheckBox.Text = "Abnormal";
            testResultsAbnormalCheckBox.UseVisualStyleBackColor = true;
            // 
            // testResultsSaveButton
            // 
            testResultsSaveButton.Location = new Point(650, 670);
            testResultsSaveButton.Name = "testResultsSaveButton";
            testResultsSaveButton.Size = new Size(115, 32);
            testResultsSaveButton.TabIndex = 14;
            testResultsSaveButton.Text = "Save Result";
            testResultsSaveButton.UseVisualStyleBackColor = true;
            testResultsSaveButton.Click += testResultsSaveButton_Click;
            // 
            // finalDiagnosisTabPage
            // 
            finalDiagnosisTabPage.Controls.Add(finalDiagnosisWarningLabel);
            finalDiagnosisTabPage.Controls.Add(finalDiagnosisSubmitButton);
            finalDiagnosisTabPage.Controls.Add(label5);
            finalDiagnosisTabPage.Controls.Add(finalDiagnosisTextBox);
            finalDiagnosisTabPage.Controls.Add(label4);
            finalDiagnosisTabPage.Controls.Add(visitDataGridView);
            finalDiagnosisTabPage.Controls.Add(label3);
            finalDiagnosisTabPage.Controls.Add(finalDiagnosisPatientSearchControl);
            finalDiagnosisTabPage.Location = new Point(4, 24);
            finalDiagnosisTabPage.Name = "finalDiagnosisTabPage";
            finalDiagnosisTabPage.Padding = new Padding(3);
            finalDiagnosisTabPage.Size = new Size(791, 714);
            finalDiagnosisTabPage.TabIndex = 2;
            finalDiagnosisTabPage.Text = "Enter Final Diagnosis";
            finalDiagnosisTabPage.UseVisualStyleBackColor = true;
            // 
            // finalDiagnosisWarningLabel
            // 
            finalDiagnosisWarningLabel.AutoEllipsis = true;
            finalDiagnosisWarningLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            finalDiagnosisWarningLabel.ForeColor = Color.Red;
            finalDiagnosisWarningLabel.Location = new Point(16, 343);
            finalDiagnosisWarningLabel.Name = "finalDiagnosisWarningLabel";
            finalDiagnosisWarningLabel.Size = new Size(740, 23);
            finalDiagnosisWarningLabel.TabIndex = 17;
            finalDiagnosisWarningLabel.Text = "ERROR";
            finalDiagnosisWarningLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // finalDiagnosisSubmitButton
            // 
            finalDiagnosisSubmitButton.Location = new Point(676, 682);
            finalDiagnosisSubmitButton.Name = "finalDiagnosisSubmitButton";
            finalDiagnosisSubmitButton.Size = new Size(115, 32);
            finalDiagnosisSubmitButton.TabIndex = 16;
            finalDiagnosisSubmitButton.Text = "Submit Diagnosis";
            finalDiagnosisSubmitButton.UseVisualStyleBackColor = true;
            finalDiagnosisSubmitButton.Click += finalDiagnosisSubmitButton_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(16, 557);
            label5.Name = "label5";
            label5.Size = new Size(170, 21);
            label5.TabIndex = 6;
            label5.Text = "Enter Final Diagnosis";
            // 
            // finalDiagnosisTextBox
            // 
            finalDiagnosisTextBox.Location = new Point(16, 581);
            finalDiagnosisTextBox.Multiline = true;
            finalDiagnosisTextBox.Name = "finalDiagnosisTextBox";
            finalDiagnosisTextBox.Size = new Size(728, 87);
            finalDiagnosisTextBox.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(16, 366);
            label4.Name = "label4";
            label4.Size = new Size(94, 21);
            label4.TabIndex = 4;
            label4.Text = "Select Visit";
            // 
            // visitDataGridView
            // 
            visitDataGridView.AllowUserToAddRows = false;
            visitDataGridView.AllowUserToDeleteRows = false;
            visitDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            visitDataGridView.Columns.AddRange(new DataGridViewColumn[] { finalDiagnosisAppointmentIdColumn, visitDoctorNameColumn, visitInitialDiagnosisColumn });
            visitDataGridView.Location = new Point(16, 390);
            visitDataGridView.Name = "visitDataGridView";
            visitDataGridView.ReadOnly = true;
            visitDataGridView.RowHeadersWidth = 62;
            visitDataGridView.Size = new Size(464, 150);
            visitDataGridView.TabIndex = 3;
            // 
            // finalDiagnosisAppointmentIdColumn
            // 
            finalDiagnosisAppointmentIdColumn.HeaderText = "Appointment ID";
            finalDiagnosisAppointmentIdColumn.MinimumWidth = 8;
            finalDiagnosisAppointmentIdColumn.Name = "finalDiagnosisAppointmentIdColumn";
            finalDiagnosisAppointmentIdColumn.ReadOnly = true;
            finalDiagnosisAppointmentIdColumn.Width = 150;
            // 
            // visitDoctorNameColumn
            // 
            visitDoctorNameColumn.HeaderText = "Doctor Name";
            visitDoctorNameColumn.Name = "visitDoctorNameColumn";
            visitDoctorNameColumn.ReadOnly = true;
            // 
            // visitInitialDiagnosisColumn
            // 
            visitInitialDiagnosisColumn.HeaderText = "Initial Diagnosis";
            visitInitialDiagnosisColumn.MinimumWidth = 8;
            visitInitialDiagnosisColumn.Name = "visitInitialDiagnosisColumn";
            visitInitialDiagnosisColumn.ReadOnly = true;
            visitInitialDiagnosisColumn.Width = 150;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(3, 3);
            label3.Name = "label3";
            label3.Size = new Size(148, 21);
            label3.TabIndex = 2;
            label3.Text = "Search For Patient";
            // 
            // finalDiagnosisPatientSearchControl
            // 
            finalDiagnosisPatientSearchControl.Location = new Point(6, 38);
            finalDiagnosisPatientSearchControl.Margin = new Padding(4, 5, 4, 5);
            finalDiagnosisPatientSearchControl.Name = "finalDiagnosisPatientSearchControl";
            finalDiagnosisPatientSearchControl.Size = new Size(760, 300);
            finalDiagnosisPatientSearchControl.TabIndex = 0;
            finalDiagnosisPatientSearchControl.PatientSelected += finalDiagnosisPatientSearchControl_PatientSelected;
            // 
            // viewVisitsTabPage
            // 
            viewVisitsTabPage.Controls.Add(viewVisitsTitleLabel);
            viewVisitsTabPage.Controls.Add(viewVisitsPatientSearchControl);
            viewVisitsTabPage.Controls.Add(viewVisitsErrorLabel);
            viewVisitsTabPage.Controls.Add(viewVisitsSelectVisitLabel);
            viewVisitsTabPage.Controls.Add(viewVisitsVisitGrid);
            viewVisitsTabPage.Controls.Add(viewVisitsDetailsLabel);
            viewVisitsTabPage.Controls.Add(viewVisitsDetailsTextBox);
            viewVisitsTabPage.Controls.Add(viewVisitsTestsLabel);
            viewVisitsTabPage.Controls.Add(viewVisitsTestsGrid);
            viewVisitsTabPage.Location = new Point(4, 24);
            viewVisitsTabPage.Name = "viewVisitsTabPage";
            viewVisitsTabPage.Padding = new Padding(3);
            viewVisitsTabPage.Size = new Size(791, 714);
            viewVisitsTabPage.TabIndex = 4;
            viewVisitsTabPage.Text = "View Visits";
            viewVisitsTabPage.UseVisualStyleBackColor = true;
            // 
            // viewVisitsTitleLabel
            // 
            viewVisitsTitleLabel.AutoSize = true;
            viewVisitsTitleLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewVisitsTitleLabel.Location = new Point(3, 3);
            viewVisitsTitleLabel.Name = "viewVisitsTitleLabel";
            viewVisitsTitleLabel.Size = new Size(148, 21);
            viewVisitsTitleLabel.TabIndex = 1;
            viewVisitsTitleLabel.Text = "Search For Patient";
            // 
            // viewVisitsPatientSearchControl
            // 
            viewVisitsPatientSearchControl.Location = new Point(6, 38);
            viewVisitsPatientSearchControl.Margin = new Padding(4, 5, 4, 5);
            viewVisitsPatientSearchControl.Name = "viewVisitsPatientSearchControl";
            viewVisitsPatientSearchControl.Size = new Size(760, 300);
            viewVisitsPatientSearchControl.TabIndex = 0;
            viewVisitsPatientSearchControl.PatientSelected += viewVisitsPatientSearchControl_PatientSelected;
            // 
            // viewVisitsErrorLabel
            // 
            viewVisitsErrorLabel.AutoEllipsis = true;
            viewVisitsErrorLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewVisitsErrorLabel.ForeColor = Color.Red;
            viewVisitsErrorLabel.Location = new Point(16, 341);
            viewVisitsErrorLabel.Name = "viewVisitsErrorLabel";
            viewVisitsErrorLabel.Size = new Size(740, 23);
            viewVisitsErrorLabel.TabIndex = 2;
            viewVisitsErrorLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // viewVisitsSelectVisitLabel
            // 
            viewVisitsSelectVisitLabel.AutoSize = true;
            viewVisitsSelectVisitLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewVisitsSelectVisitLabel.Location = new Point(16, 366);
            viewVisitsSelectVisitLabel.Name = "viewVisitsSelectVisitLabel";
            viewVisitsSelectVisitLabel.Size = new Size(94, 21);
            viewVisitsSelectVisitLabel.TabIndex = 3;
            viewVisitsSelectVisitLabel.Text = "Select Visit";
            // 
            // viewVisitsVisitGrid
            // 
            viewVisitsVisitGrid.AllowUserToAddRows = false;
            viewVisitsVisitGrid.AllowUserToDeleteRows = false;
            viewVisitsVisitGrid.AutoGenerateColumns = false;
            viewVisitsVisitGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            viewVisitsVisitGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            viewVisitsVisitGrid.Columns.AddRange(new DataGridViewColumn[] { viewVisitsVisitDateColumn, viewVisitsVisitDoctorColumn, viewVisitsVisitStatusColumn });
            viewVisitsVisitGrid.Location = new Point(16, 390);
            viewVisitsVisitGrid.MultiSelect = false;
            viewVisitsVisitGrid.Name = "viewVisitsVisitGrid";
            viewVisitsVisitGrid.ReadOnly = true;
            viewVisitsVisitGrid.RowHeadersVisible = false;
            viewVisitsVisitGrid.ScrollBars = ScrollBars.Both;
            viewVisitsVisitGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            viewVisitsVisitGrid.Size = new Size(360, 170);
            viewVisitsVisitGrid.TabIndex = 4;
            viewVisitsVisitGrid.DataBindingComplete += viewVisitsVisitGrid_DataBindingComplete;
            viewVisitsVisitGrid.SelectionChanged += viewVisitsVisitGrid_SelectionChanged;
            // 
            // viewVisitsVisitDateColumn
            // 
            viewVisitsVisitDateCellStyle.Format = "g";
            viewVisitsVisitDateColumn.DataPropertyName = "AppointmentDateTime";
            viewVisitsVisitDateColumn.DefaultCellStyle = viewVisitsVisitDateCellStyle;
            viewVisitsVisitDateColumn.HeaderText = "Visit Date";
            viewVisitsVisitDateColumn.MinimumWidth = 120;
            viewVisitsVisitDateColumn.Name = "viewVisitsVisitDateColumn";
            viewVisitsVisitDateColumn.ReadOnly = true;
            // 
            // viewVisitsVisitDoctorColumn
            // 
            viewVisitsVisitDoctorColumn.DataPropertyName = "DoctorName";
            viewVisitsVisitDoctorColumn.HeaderText = "Doctor";
            viewVisitsVisitDoctorColumn.MinimumWidth = 110;
            viewVisitsVisitDoctorColumn.Name = "viewVisitsVisitDoctorColumn";
            viewVisitsVisitDoctorColumn.ReadOnly = true;
            // 
            // viewVisitsVisitStatusColumn
            // 
            viewVisitsVisitStatusColumn.DataPropertyName = "StatusText";
            viewVisitsVisitStatusColumn.HeaderText = "Status";
            viewVisitsVisitStatusColumn.MinimumWidth = 100;
            viewVisitsVisitStatusColumn.Name = "viewVisitsVisitStatusColumn";
            viewVisitsVisitStatusColumn.ReadOnly = true;
            // 
            // viewVisitsDetailsLabel
            // 
            viewVisitsDetailsLabel.AutoSize = true;
            viewVisitsDetailsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewVisitsDetailsLabel.Location = new Point(390, 366);
            viewVisitsDetailsLabel.Name = "viewVisitsDetailsLabel";
            viewVisitsDetailsLabel.Size = new Size(104, 21);
            viewVisitsDetailsLabel.TabIndex = 5;
            viewVisitsDetailsLabel.Text = "Visit Details";
            // 
            // viewVisitsDetailsTextBox
            // 
            viewVisitsDetailsTextBox.BackColor = SystemColors.Window;
            viewVisitsDetailsTextBox.Location = new Point(390, 390);
            viewVisitsDetailsTextBox.Multiline = true;
            viewVisitsDetailsTextBox.Name = "viewVisitsDetailsTextBox";
            viewVisitsDetailsTextBox.ReadOnly = true;
            viewVisitsDetailsTextBox.ScrollBars = ScrollBars.Vertical;
            viewVisitsDetailsTextBox.Size = new Size(375, 170);
            viewVisitsDetailsTextBox.TabIndex = 6;
            viewVisitsDetailsTextBox.TabStop = false;
            // 
            // viewVisitsTestsLabel
            // 
            viewVisitsTestsLabel.AutoSize = true;
            viewVisitsTestsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewVisitsTestsLabel.Location = new Point(16, 568);
            viewVisitsTestsLabel.Name = "viewVisitsTestsLabel";
            viewVisitsTestsLabel.Size = new Size(47, 21);
            viewVisitsTestsLabel.TabIndex = 7;
            viewVisitsTestsLabel.Text = "Tests";
            // 
            // viewVisitsTestsGrid
            // 
            viewVisitsTestsGrid.AllowUserToAddRows = false;
            viewVisitsTestsGrid.AllowUserToDeleteRows = false;
            viewVisitsTestsGrid.AutoGenerateColumns = false;
            viewVisitsTestsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            viewVisitsTestsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            viewVisitsTestsGrid.Columns.AddRange(new DataGridViewColumn[] { viewVisitsTestNameColumn, viewVisitsNormalRangeColumn, viewVisitsResultColumn, viewVisitsAbnormalColumn, viewVisitsPerformedColumn });
            viewVisitsTestsGrid.Location = new Point(16, 592);
            viewVisitsTestsGrid.MultiSelect = false;
            viewVisitsTestsGrid.Name = "viewVisitsTestsGrid";
            viewVisitsTestsGrid.ReadOnly = true;
            viewVisitsTestsGrid.RowHeadersVisible = false;
            viewVisitsTestsGrid.ScrollBars = ScrollBars.Both;
            viewVisitsTestsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            viewVisitsTestsGrid.Size = new Size(749, 112);
            viewVisitsTestsGrid.TabIndex = 8;
            viewVisitsTestsGrid.CellFormatting += viewVisitsTestsGrid_CellFormatting;
            viewVisitsTestsGrid.DataBindingComplete += viewVisitsTestsGrid_DataBindingComplete;
            // 
            // viewVisitsTestNameColumn
            // 
            viewVisitsTestNameColumn.DataPropertyName = "TestName";
            viewVisitsTestNameColumn.HeaderText = "Test";
            viewVisitsTestNameColumn.MinimumWidth = 140;
            viewVisitsTestNameColumn.Name = "viewVisitsTestNameColumn";
            viewVisitsTestNameColumn.ReadOnly = true;
            // 
            // viewVisitsNormalRangeColumn
            // 
            viewVisitsNormalRangeColumn.DataPropertyName = "NormalRange";
            viewVisitsNormalRangeColumn.HeaderText = "Normal Range";
            viewVisitsNormalRangeColumn.MinimumWidth = 140;
            viewVisitsNormalRangeColumn.Name = "viewVisitsNormalRangeColumn";
            viewVisitsNormalRangeColumn.ReadOnly = true;
            // 
            // viewVisitsResultColumn
            // 
            viewVisitsResultColumn.DataPropertyName = "ResultText";
            viewVisitsResultColumn.HeaderText = "Result";
            viewVisitsResultColumn.MinimumWidth = 100;
            viewVisitsResultColumn.Name = "viewVisitsResultColumn";
            viewVisitsResultColumn.ReadOnly = true;
            // 
            // viewVisitsAbnormalColumn
            // 
            viewVisitsAbnormalColumn.DataPropertyName = "AbnormalText";
            viewVisitsAbnormalColumn.HeaderText = "Abnormal";
            viewVisitsAbnormalColumn.MinimumWidth = 75;
            viewVisitsAbnormalColumn.Name = "viewVisitsAbnormalColumn";
            viewVisitsAbnormalColumn.ReadOnly = true;
            // 
            // viewVisitsPerformedColumn
            // 
            viewVisitsPerformedCellStyle.Format = "g";
            viewVisitsPerformedColumn.DataPropertyName = "DatePerformed";
            viewVisitsPerformedColumn.DefaultCellStyle = viewVisitsPerformedCellStyle;
            viewVisitsPerformedColumn.HeaderText = "Performed";
            viewVisitsPerformedColumn.MinimumWidth = 130;
            viewVisitsPerformedColumn.Name = "viewVisitsPerformedColumn";
            viewVisitsPerformedColumn.ReadOnly = true;
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
            testResultsTabPage.ResumeLayout(false);
            testResultsTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)testResultsVisitGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)testResultsTestsGrid).EndInit();
            finalDiagnosisTabPage.ResumeLayout(false);
            finalDiagnosisTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)visitDataGridView).EndInit();
            viewVisitsTabPage.ResumeLayout(false);
            viewVisitsTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)viewVisitsVisitGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)viewVisitsTestsGrid).EndInit();
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
        private Label errorLabel;
        private Button bookButton;
        private Button cancelButton;
        private TabControl appointmentTabControl;
        private TabPage createAppointmentTabPage;
        private TabPage orderTestTabPage;
        private Label label1;
        private PatientSearchControl orderTestPatientSearchControl;
        private DataGridView appointmentDataGridView;
        private DataGridViewTextBoxColumn appointmentIdColumn;
        private DataGridViewTextBoxColumn doctorNameColumn;
        private DataGridViewTextBoxColumn timeColumn;
        private DataGridViewTextBoxColumn reasonColumn;
        private Label visitAndOrderTestErrorLabel;
        private Label label2;
        private Label availableTestsLabel;
        private CheckedListBox testCheckedListBox;
        private Label visitDetailsLabel;
        private Label systolicLabel;
        private TextBox systolicTextBox;
        private Label diastolicLabel;
        private TextBox diastolicTextBox;
        private Label pulseLabel;
        private TextBox pulseTextBox;
        private Label bodyTemperatureLabel;
        private TextBox bodyTemperatureTextBox;
        private Label heightLabel;
        private TextBox heightTextBox;
        private Label weightLabel;
        private TextBox weightTextBox;
        private Label symptomsLabel;
        private TextBox symptomsTextBox;
        private Label initialDiagnosisLabel;
        private TextBox initialDiagnosisTextBox;
        private Button submitVisitButton;
        private TabPage testResultsTabPage;
        private Label testResultsTitleLabel;
        private PatientSearchControl testResultsPatientSearchControl;
        private Label testResultsErrorLabel;
        private Label testResultsSelectVisitLabel;
        private DataGridView testResultsVisitGrid;
        private DataGridViewTextBoxColumn testResultsVisitDateColumn;
        private DataGridViewTextBoxColumn testResultsVisitDoctorColumn;
        private DataGridViewTextBoxColumn testResultsVisitStatusColumn;
        private Label testResultsOrderedTestsLabel;
        private DataGridView testResultsTestsGrid;
        private DataGridViewTextBoxColumn testResultsTestNameColumn;
        private DataGridViewTextBoxColumn testResultsNormalRangeColumn;
        private DataGridViewTextBoxColumn testResultsResultColumn;
        private DataGridViewTextBoxColumn testResultsAbnormalColumn;
        private DataGridViewTextBoxColumn testResultsPerformedColumn;
        private Label testResultsPatientInfoLabel;
        private Label testResultsSelectedTestLabel;
        private Label testResultsDatePerformedLabel;
        private DateTimePicker testResultsDatePerformedPicker;
        private Label testResultsResultLabel;
        private TextBox testResultsResultTextBox;
        private CheckBox testResultsAbnormalCheckBox;
        private Button testResultsSaveButton;
        private TabPage finalDiagnosisTabPage;
        private DataGridView visitDataGridView;
        private Label label3;
        private PatientSearchControl finalDiagnosisPatientSearchControl;
        private Label label4;
        private Button finalDiagnosisSubmitButton;
        private Label label5;
        private TextBox finalDiagnosisTextBox;
        private DataGridViewTextBoxColumn finalDiagnosisAppointmentIdColumn;
        private DataGridViewTextBoxColumn visitDoctorNameColumn;
        private DataGridViewTextBoxColumn visitInitialDiagnosisColumn;
        private Label finalDiagnosisWarningLabel;
        private TabPage viewVisitsTabPage;
        private Label viewVisitsTitleLabel;
        private PatientSearchControl viewVisitsPatientSearchControl;
        private Label viewVisitsErrorLabel;
        private Label viewVisitsSelectVisitLabel;
        private DataGridView viewVisitsVisitGrid;
        private DataGridViewTextBoxColumn viewVisitsVisitDateColumn;
        private DataGridViewTextBoxColumn viewVisitsVisitDoctorColumn;
        private DataGridViewTextBoxColumn viewVisitsVisitStatusColumn;
        private Label viewVisitsDetailsLabel;
        private TextBox viewVisitsDetailsTextBox;
        private Label viewVisitsTestsLabel;
        private DataGridView viewVisitsTestsGrid;
        private DataGridViewTextBoxColumn viewVisitsTestNameColumn;
        private DataGridViewTextBoxColumn viewVisitsNormalRangeColumn;
        private DataGridViewTextBoxColumn viewVisitsResultColumn;
        private DataGridViewTextBoxColumn viewVisitsAbnormalColumn;
        private DataGridViewTextBoxColumn viewVisitsPerformedColumn;
    }
}