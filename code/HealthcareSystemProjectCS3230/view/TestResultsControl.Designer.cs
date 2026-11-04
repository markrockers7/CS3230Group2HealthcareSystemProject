namespace HealthcareSystemProjectCS3230.view
{
    partial class TestResultsControl
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle visitDateCellStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle performedCellStyle = new DataGridViewCellStyle();
            titleLabel = new Label();
            patientSearchControl = new PatientSearchControl();
            errorLabel = new Label();
            selectVisitLabel = new Label();
            visitGrid = new DataGridView();
            visitDateColumn = new DataGridViewTextBoxColumn();
            visitDoctorColumn = new DataGridViewTextBoxColumn();
            visitStatusColumn = new DataGridViewTextBoxColumn();
            orderedTestsLabel = new Label();
            testsGrid = new DataGridView();
            testNameColumn = new DataGridViewTextBoxColumn();
            normalRangeColumn = new DataGridViewTextBoxColumn();
            resultColumn = new DataGridViewTextBoxColumn();
            abnormalColumn = new DataGridViewTextBoxColumn();
            performedColumn = new DataGridViewTextBoxColumn();
            patientInfoLabel = new Label();
            selectedTestLabel = new Label();
            datePerformedLabel = new Label();
            datePerformedPicker = new DateTimePicker();
            resultLabel = new Label();
            resultTextBox = new TextBox();
            abnormalCheckBox = new CheckBox();
            saveResultButton = new Button();
            ((System.ComponentModel.ISupportInitialize)visitGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)testsGrid).BeginInit();
            SuspendLayout();
            //
            // titleLabel
            //
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            titleLabel.Location = new Point(3, 3);
            titleLabel.Name = "titleLabel";
            titleLabel.Text = "Search For Patient";
            //
            // patientSearchControl
            //
            patientSearchControl.Location = new Point(6, 38);
            patientSearchControl.Name = "patientSearchControl";
            patientSearchControl.Size = new Size(760, 300);
            patientSearchControl.TabIndex = 0;
            patientSearchControl.PatientSelected += patientSearchControl_PatientSelected;
            //
            // errorLabel
            //
            errorLabel.AutoEllipsis = true;
            errorLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(16, 341);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(740, 23);
            errorLabel.TextAlign = ContentAlignment.MiddleCenter;
            //
            // selectVisitLabel
            //
            selectVisitLabel.AutoSize = true;
            selectVisitLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            selectVisitLabel.Location = new Point(16, 366);
            selectVisitLabel.Name = "selectVisitLabel";
            selectVisitLabel.Text = "Select Visit";
            //
            // visitGrid
            //
            visitGrid.AllowUserToAddRows = false;
            visitGrid.AllowUserToDeleteRows = false;
            visitGrid.AutoGenerateColumns = false;
            visitGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            visitGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            visitGrid.Columns.AddRange(new DataGridViewColumn[] { visitDateColumn, visitDoctorColumn, visitStatusColumn });
            visitGrid.Location = new Point(16, 390);
            visitGrid.MultiSelect = false;
            visitGrid.Name = "visitGrid";
            visitGrid.ReadOnly = true;
            visitGrid.RowHeadersVisible = false;
            visitGrid.ScrollBars = ScrollBars.Both;
            visitGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            visitGrid.Size = new Size(360, 150);
            visitGrid.TabIndex = 1;
            visitGrid.DataBindingComplete += visitGrid_DataBindingComplete;
            visitGrid.SelectionChanged += visitGrid_SelectionChanged;
            //
            // visitDateColumn
            //
            visitDateCellStyle.Format = "g";
            visitDateColumn.DataPropertyName = "AppointmentDateTime";
            visitDateColumn.DefaultCellStyle = visitDateCellStyle;
            visitDateColumn.HeaderText = "Visit Date";
            visitDateColumn.MinimumWidth = 120;
            visitDateColumn.Name = "visitDateColumn";
            visitDateColumn.ReadOnly = true;
            //
            // visitDoctorColumn
            //
            visitDoctorColumn.DataPropertyName = "DoctorName";
            visitDoctorColumn.HeaderText = "Doctor";
            visitDoctorColumn.MinimumWidth = 110;
            visitDoctorColumn.Name = "visitDoctorColumn";
            visitDoctorColumn.ReadOnly = true;
            //
            // visitStatusColumn
            //
            visitStatusColumn.DataPropertyName = "StatusText";
            visitStatusColumn.HeaderText = "Status";
            visitStatusColumn.MinimumWidth = 100;
            visitStatusColumn.Name = "visitStatusColumn";
            visitStatusColumn.ReadOnly = true;
            //
            // orderedTestsLabel
            //
            orderedTestsLabel.AutoSize = true;
            orderedTestsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            orderedTestsLabel.Location = new Point(390, 366);
            orderedTestsLabel.Name = "orderedTestsLabel";
            orderedTestsLabel.Text = "Ordered Tests";
            //
            // testsGrid
            //
            testsGrid.AllowUserToAddRows = false;
            testsGrid.AllowUserToDeleteRows = false;
            testsGrid.AutoGenerateColumns = false;
            testsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            testsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            testsGrid.Columns.AddRange(new DataGridViewColumn[] { testNameColumn, normalRangeColumn, resultColumn, abnormalColumn, performedColumn });
            testsGrid.Location = new Point(390, 390);
            testsGrid.MultiSelect = false;
            testsGrid.Name = "testsGrid";
            testsGrid.ReadOnly = true;
            testsGrid.RowHeadersVisible = false;
            testsGrid.ScrollBars = ScrollBars.Both;
            testsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            testsGrid.Size = new Size(375, 150);
            testsGrid.TabIndex = 2;
            testsGrid.DataBindingComplete += testsGrid_DataBindingComplete;
            testsGrid.SelectionChanged += testsGrid_SelectionChanged;
            //
            // testNameColumn
            //
            testNameColumn.DataPropertyName = "TestName";
            testNameColumn.HeaderText = "Test";
            testNameColumn.MinimumWidth = 110;
            testNameColumn.Name = "testNameColumn";
            testNameColumn.ReadOnly = true;
            //
            // normalRangeColumn
            //
            normalRangeColumn.DataPropertyName = "NormalRange";
            normalRangeColumn.HeaderText = "Normal Range";
            normalRangeColumn.MinimumWidth = 100;
            normalRangeColumn.Name = "normalRangeColumn";
            normalRangeColumn.ReadOnly = true;
            //
            // resultColumn
            //
            resultColumn.DataPropertyName = "ResultText";
            resultColumn.HeaderText = "Result";
            resultColumn.MinimumWidth = 70;
            resultColumn.Name = "resultColumn";
            resultColumn.ReadOnly = true;
            //
            // abnormalColumn
            //
            abnormalColumn.DataPropertyName = "AbnormalText";
            abnormalColumn.HeaderText = "Abnormal";
            abnormalColumn.MinimumWidth = 65;
            abnormalColumn.Name = "abnormalColumn";
            abnormalColumn.ReadOnly = true;
            //
            // performedColumn
            //
            performedCellStyle.Format = "g";
            performedColumn.DataPropertyName = "DatePerformed";
            performedColumn.DefaultCellStyle = performedCellStyle;
            performedColumn.HeaderText = "Performed";
            performedColumn.MinimumWidth = 115;
            performedColumn.Name = "performedColumn";
            performedColumn.ReadOnly = true;
            //
            // patientInfoLabel
            //
            patientInfoLabel.AutoSize = true;
            patientInfoLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            patientInfoLabel.Location = new Point(16, 550);
            patientInfoLabel.Name = "patientInfoLabel";
            patientInfoLabel.Size = new Size(0, 15);
            //
            // selectedTestLabel
            //
            selectedTestLabel.AutoSize = true;
            selectedTestLabel.Location = new Point(16, 577);
            selectedTestLabel.MaximumSize = new Size(750, 0);
            selectedTestLabel.Name = "selectedTestLabel";
            selectedTestLabel.Size = new Size(0, 15);
            //
            // datePerformedLabel
            //
            datePerformedLabel.AutoSize = true;
            datePerformedLabel.Location = new Point(16, 608);
            datePerformedLabel.Name = "datePerformedLabel";
            datePerformedLabel.Text = "Date/time performed:";
            //
            // datePerformedPicker
            //
            datePerformedPicker.CustomFormat = "MM/dd/yyyy hh:mm tt";
            datePerformedPicker.Format = DateTimePickerFormat.Custom;
            datePerformedPicker.Location = new Point(150, 605);
            datePerformedPicker.Name = "datePerformedPicker";
            datePerformedPicker.Size = new Size(220, 23);
            datePerformedPicker.TabIndex = 3;
            //
            // resultLabel
            //
            resultLabel.AutoSize = true;
            resultLabel.Location = new Point(16, 643);
            resultLabel.Name = "resultLabel";
            resultLabel.Text = "Result:";
            //
            // resultTextBox
            //
            resultTextBox.Location = new Point(150, 640);
            resultTextBox.MaxLength = 100;
            resultTextBox.Name = "resultTextBox";
            resultTextBox.Size = new Size(220, 23);
            resultTextBox.TabIndex = 4;
            resultTextBox.TextChanged += resultTextBox_TextChanged;
            //
            // abnormalCheckBox
            //
            abnormalCheckBox.AutoSize = true;
            abnormalCheckBox.Location = new Point(390, 642);
            abnormalCheckBox.Name = "abnormalCheckBox";
            abnormalCheckBox.TabIndex = 5;
            abnormalCheckBox.Text = "Abnormal";
            abnormalCheckBox.UseVisualStyleBackColor = true;
            //
            // saveResultButton
            //
            saveResultButton.Location = new Point(650, 670);
            saveResultButton.Name = "saveResultButton";
            saveResultButton.Size = new Size(115, 32);
            saveResultButton.TabIndex = 6;
            saveResultButton.Text = "Save Result";
            saveResultButton.UseVisualStyleBackColor = true;
            saveResultButton.Click += saveResultButton_Click;
            //
            // TestResultsControl
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(titleLabel);
            Controls.Add(patientSearchControl);
            Controls.Add(errorLabel);
            Controls.Add(selectVisitLabel);
            Controls.Add(visitGrid);
            Controls.Add(orderedTestsLabel);
            Controls.Add(testsGrid);
            Controls.Add(patientInfoLabel);
            Controls.Add(selectedTestLabel);
            Controls.Add(datePerformedLabel);
            Controls.Add(datePerformedPicker);
            Controls.Add(resultLabel);
            Controls.Add(resultTextBox);
            Controls.Add(abnormalCheckBox);
            Controls.Add(saveResultButton);
            Name = "TestResultsControl";
            Size = new Size(785, 705);
            ((System.ComponentModel.ISupportInitialize)visitGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)testsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private PatientSearchControl patientSearchControl;
        private Label errorLabel;
        private Label selectVisitLabel;
        private DataGridView visitGrid;
        private DataGridViewTextBoxColumn visitDateColumn;
        private DataGridViewTextBoxColumn visitDoctorColumn;
        private DataGridViewTextBoxColumn visitStatusColumn;
        private Label orderedTestsLabel;
        private DataGridView testsGrid;
        private DataGridViewTextBoxColumn testNameColumn;
        private DataGridViewTextBoxColumn normalRangeColumn;
        private DataGridViewTextBoxColumn resultColumn;
        private DataGridViewTextBoxColumn abnormalColumn;
        private DataGridViewTextBoxColumn performedColumn;
        private Label patientInfoLabel;
        private Label selectedTestLabel;
        private Label datePerformedLabel;
        private DateTimePicker datePerformedPicker;
        private Label resultLabel;
        private TextBox resultTextBox;
        private CheckBox abnormalCheckBox;
        private Button saveResultButton;
    }
}