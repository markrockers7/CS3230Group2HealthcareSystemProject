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
            finalDiagnosisTabPage = new TabPage();
            label4 = new Label();
            visitDataGridView = new DataGridView();
            label3 = new Label();
            finalDiagnosisPatientSearchControl = new PatientSearchControl();
            appointmentId = new DataGridViewTextBoxColumn();
            doctorName = new DataGridViewTextBoxColumn();
            initialDiagnosis = new DataGridViewTextBoxColumn();
            appointmentTabControl.SuspendLayout();
            createAppointmentTabPage.SuspendLayout();
            orderTestTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)appointmentDataGridView).BeginInit();
            finalDiagnosisTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)visitDataGridView).BeginInit();
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
            appointmentTabControl.Controls.Add(finalDiagnosisTabPage);
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
            orderTestTabPage.AutoScroll = true;
            orderTestTabPage.Controls.Add(selectAppointmentErrorLabel);
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
            // selectAppointmentErrorLabel
            // 
            selectAppointmentErrorLabel.AutoEllipsis = true;
            selectAppointmentErrorLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            selectAppointmentErrorLabel.ForeColor = Color.Red;
            selectAppointmentErrorLabel.Location = new Point(16, 341);
            selectAppointmentErrorLabel.Name = "selectAppointmentErrorLabel";
            selectAppointmentErrorLabel.Size = new Size(740, 23);
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
            systolicLabel.Size = new Size(50, 15);
            systolicLabel.TabIndex = 8;
            systolicLabel.Text = "Systolic:";
            // 
            // systolicTextBox
            // 
            systolicTextBox.Location = new Point(105, 570);
            systolicTextBox.Name = "systolicTextBox";
            systolicTextBox.Size = new Size(80, 23);
            systolicTextBox.TabIndex = 7;
            // 
            // diastolicLabel
            // 
            diastolicLabel.AutoSize = true;
            diastolicLabel.Location = new Point(205, 574);
            diastolicLabel.Name = "diastolicLabel";
            diastolicLabel.Size = new Size(55, 15);
            diastolicLabel.TabIndex = 9;
            diastolicLabel.Text = "Diastolic:";
            // 
            // diastolicTextBox
            // 
            diastolicTextBox.Location = new Point(298, 570);
            diastolicTextBox.Name = "diastolicTextBox";
            diastolicTextBox.Size = new Size(80, 23);
            diastolicTextBox.TabIndex = 8;
            // 
            // pulseLabel
            // 
            pulseLabel.AutoSize = true;
            pulseLabel.Location = new Point(400, 574);
            pulseLabel.Name = "pulseLabel";
            pulseLabel.Size = new Size(38, 15);
            pulseLabel.TabIndex = 10;
            pulseLabel.Text = "Pulse:";
            // 
            // pulseTextBox
            // 
            pulseTextBox.Location = new Point(443, 570);
            pulseTextBox.Name = "pulseTextBox";
            pulseTextBox.Size = new Size(80, 23);
            pulseTextBox.TabIndex = 9;
            // 
            // bodyTemperatureLabel
            // 
            bodyTemperatureLabel.AutoSize = true;
            bodyTemperatureLabel.Location = new Point(540, 574);
            bodyTemperatureLabel.Name = "bodyTemperatureLabel";
            bodyTemperatureLabel.Size = new Size(68, 15);
            bodyTemperatureLabel.TabIndex = 11;
            bodyTemperatureLabel.Text = "Body temp:";
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
            heightLabel.Size = new Size(46, 15);
            heightLabel.TabIndex = 12;
            heightLabel.Text = "Height:";
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
            weightLabel.Size = new Size(48, 15);
            weightLabel.TabIndex = 13;
            weightLabel.Text = "Weight:";
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
            // finalDiagnosisTabPage
            // 
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
            visitDataGridView.Columns.AddRange(new DataGridViewColumn[] { appointmentId, doctorName, initialDiagnosis });
            visitDataGridView.Location = new Point(16, 390);
            visitDataGridView.Name = "visitDataGridView";
            visitDataGridView.ReadOnly = true;
            visitDataGridView.RowHeadersWidth = 62;
            visitDataGridView.Size = new Size(543, 150);
            visitDataGridView.TabIndex = 3;
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
            finalDiagnosisPatientSearchControl.SearchRequested += finalDiagnosisPatientSearchControl_SearchRequested;
            finalDiagnosisPatientSearchControl.PatientSelected += finalDiagnosisPatientSearchControl_PatientSelected;
            // 
            // appointmentId
            // 
            appointmentId.HeaderText = "Appointment ID";
            appointmentId.MinimumWidth = 8;
            appointmentId.Name = "appointmentId";
            appointmentId.ReadOnly = true;
            appointmentId.Width = 150;
            // 
            // doctorName
            // 
            doctorName.HeaderText = "Doctor Name";
            doctorName.Name = "doctorName";
            doctorName.ReadOnly = true;
            // 
            // initialDiagnosis
            // 
            initialDiagnosis.HeaderText = "Initial Diagnosis";
            initialDiagnosis.MinimumWidth = 8;
            initialDiagnosis.Name = "initialDiagnosis";
            initialDiagnosis.ReadOnly = true;
            initialDiagnosis.Width = 150;
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
            finalDiagnosisTabPage.ResumeLayout(false);
            finalDiagnosisTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)visitDataGridView).EndInit();
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
        private DataGridViewTextBoxColumn appointmentIdColumn;
        private DataGridViewTextBoxColumn doctorNameColumn;
        private DataGridViewTextBoxColumn timeColumn;
        private DataGridViewTextBoxColumn reasonColumn;
        private Label selectAppointmentErrorLabel;
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
        private TabPage finalDiagnosisTabPage;
        private DataGridView visitDataGridView;
        private Label label3;
        private PatientSearchControl finalDiagnosisPatientSearchControl;
        private Label label4;
        private DataGridViewTextBoxColumn appointmentId;
        private DataGridViewTextBoxColumn doctorName;
        private DataGridViewTextBoxColumn initialDiagnosis;
    }
}