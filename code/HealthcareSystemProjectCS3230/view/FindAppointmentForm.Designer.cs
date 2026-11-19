namespace HealthcareSystemProjectCS3230.view
{
    partial class FindAppointmentForm
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
            DataGridViewCellStyle dateTimeCellStyle = new DataGridViewCellStyle();
            loggedInLabel = new Label();
            titleLabel = new Label();
            patientSearchControl = new PatientSearchControl();
            appointmentsLabel = new Label();
            appointmentsGrid = new DataGridView();
            dateTimeColumn = new DataGridViewTextBoxColumn();
            doctorColumn = new DataGridViewTextBoxColumn();
            reasonColumn = new DataGridViewTextBoxColumn();
            canEditColumn = new DataGridViewCheckBoxColumn();
            statusLabel = new Label();
            openButton = new Button();
            closeButton = new Button();
            ((System.ComponentModel.ISupportInitialize)appointmentsGrid).BeginInit();
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
            titleLabel.Text = "Find Appointment";
            //
            // patientSearchControl
            //
            patientSearchControl.Location = new Point(20, 75);
            patientSearchControl.Name = "patientSearchControl";
            patientSearchControl.Size = new Size(760, 300);
            patientSearchControl.TabIndex = 0;
            patientSearchControl.PatientSelected += patientSearchControl_PatientSelected;
            //
            // appointmentsLabel
            //
            appointmentsLabel.AutoSize = true;
            appointmentsLabel.Location = new Point(30, 385);
            appointmentsLabel.Name = "appointmentsLabel";
            appointmentsLabel.Text = "Appointments for selected patient:";
            //
            // appointmentsGrid
            //
            appointmentsGrid.AllowUserToAddRows = false;
            appointmentsGrid.AllowUserToDeleteRows = false;
            appointmentsGrid.AutoGenerateColumns = false;
            appointmentsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            appointmentsGrid.Columns.AddRange(new DataGridViewColumn[] { dateTimeColumn, doctorColumn, reasonColumn, canEditColumn });
            appointmentsGrid.Location = new Point(30, 405);
            appointmentsGrid.MultiSelect = false;
            appointmentsGrid.Name = "appointmentsGrid";
            appointmentsGrid.ReadOnly = true;
            appointmentsGrid.ScrollBars = ScrollBars.Both;
            appointmentsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            appointmentsGrid.Size = new Size(740, 200);
            appointmentsGrid.TabIndex = 1;
            appointmentsGrid.CellDoubleClick += appointmentsGrid_CellDoubleClick;
            appointmentsGrid.DataBindingComplete += appointmentsGrid_DataBindingComplete;
            appointmentsGrid.SelectionChanged += appointmentsGrid_SelectionChanged;
            //
            // dateTimeColumn
            //
            dateTimeCellStyle.Format = "g";
            dateTimeColumn.DataPropertyName = "AppointmentDateTime";
            dateTimeColumn.DefaultCellStyle = dateTimeCellStyle;
            dateTimeColumn.HeaderText = "Date / Time";
            dateTimeColumn.MinimumWidth = 140;
            dateTimeColumn.Name = "dateTimeColumn";
            dateTimeColumn.ReadOnly = true;
            //
            // doctorColumn
            //
            doctorColumn.DataPropertyName = "DoctorName";
            doctorColumn.HeaderText = "Doctor";
            doctorColumn.MinimumWidth = 140;
            doctorColumn.Name = "doctorColumn";
            doctorColumn.ReadOnly = true;
            //
            // reasonColumn
            //
            reasonColumn.DataPropertyName = "Reason";
            reasonColumn.FillWeight = 150F;
            reasonColumn.HeaderText = "Reason";
            reasonColumn.MinimumWidth = 300;
            reasonColumn.Name = "reasonColumn";
            reasonColumn.ReadOnly = true;
            //
            // canEditColumn
            //
            canEditColumn.DataPropertyName = "CanEdit";
            canEditColumn.FillWeight = 55F;
            canEditColumn.HeaderText = "Editable";
            canEditColumn.MinimumWidth = 70;
            canEditColumn.Name = "canEditColumn";
            canEditColumn.ReadOnly = true;
            //
            // statusLabel
            //
            statusLabel.AutoSize = true;
            statusLabel.ForeColor = Color.Firebrick;
            statusLabel.Location = new Point(30, 612);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(0, 15);
            //
            // openButton
            //
            openButton.Location = new Point(565, 635);
            openButton.Name = "openButton";
            openButton.Size = new Size(130, 30);
            openButton.TabIndex = 2;
            openButton.Text = "Edit Appointment";
            openButton.UseVisualStyleBackColor = true;
            openButton.Click += openButton_Click;
            //
            // closeButton
            //
            closeButton.Location = new Point(700, 635);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(70, 30);
            closeButton.TabIndex = 3;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            //
            // FindAppointmentForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = closeButton;
            ClientSize = new Size(800, 685);
            Controls.Add(loggedInLabel);
            Controls.Add(titleLabel);
            Controls.Add(patientSearchControl);
            Controls.Add(appointmentsLabel);
            Controls.Add(appointmentsGrid);
            Controls.Add(statusLabel);
            Controls.Add(openButton);
            Controls.Add(closeButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FindAppointmentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Find Appointment";
            ((System.ComponentModel.ISupportInitialize)appointmentsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label loggedInLabel;
        private Label titleLabel;
        private PatientSearchControl patientSearchControl;
        private Label appointmentsLabel;
        private DataGridView appointmentsGrid;
        private DataGridViewTextBoxColumn dateTimeColumn;
        private DataGridViewTextBoxColumn doctorColumn;
        private DataGridViewTextBoxColumn reasonColumn;
        private DataGridViewCheckBoxColumn canEditColumn;
        private Label statusLabel;
        private Button openButton;
        private Button closeButton;
    }
}