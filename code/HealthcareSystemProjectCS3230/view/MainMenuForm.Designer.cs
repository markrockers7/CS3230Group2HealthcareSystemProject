namespace HealthcareSystemProjectCS3230.view
{
    partial class MainMenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            appointmentButton = new Button();
            registerPatientButton = new Button();
            patientSearchButton = new Button();
            editPatientButton = new Button();
            usernameLabel = new Label();
            nurseManagerButton = new Button();
            LogoutButton = new Button();
            SuspendLayout();
            // 
            // appointmentButton
            // 
            appointmentButton.Location = new Point(17, 245);
            appointmentButton.Margin = new Padding(4, 5, 4, 5);
            appointmentButton.Name = "appointmentButton";
            appointmentButton.Size = new Size(180, 67);
            appointmentButton.TabIndex = 0;
            appointmentButton.Text = "Add Appointment";
            appointmentButton.UseVisualStyleBackColor = true;
            appointmentButton.Click += appointmentButton_Click;
            // 
            // registerPatientButton
            // 
            registerPatientButton.Location = new Point(17, 168);
            registerPatientButton.Margin = new Padding(4, 5, 4, 5);
            registerPatientButton.Name = "registerPatientButton";
            registerPatientButton.Size = new Size(180, 67);
            registerPatientButton.TabIndex = 2;
            registerPatientButton.Text = "Register Patient";
            registerPatientButton.UseVisualStyleBackColor = true;
            registerPatientButton.Click += registerPatientButton_Click;
            // 
            // patientSearchButton
            // 
            patientSearchButton.Location = new Point(17, 322);
            patientSearchButton.Margin = new Padding(4, 5, 4, 5);
            patientSearchButton.Name = "patientSearchButton";
            patientSearchButton.Size = new Size(180, 67);
            patientSearchButton.TabIndex = 1;
            patientSearchButton.Text = "Search Patients";
            patientSearchButton.UseVisualStyleBackColor = true;
            patientSearchButton.Click += patientSearchButton_Click;
            // 
            // editPatientButton
            // 
            editPatientButton.Location = new Point(17, 398);
            editPatientButton.Margin = new Padding(4, 5, 4, 5);
            editPatientButton.Name = "editPatientButton";
            editPatientButton.Size = new Size(180, 67);
            editPatientButton.TabIndex = 3;
            editPatientButton.Text = "Edit Patient";
            editPatientButton.UseVisualStyleBackColor = true;
            editPatientButton.Click += editPatientButton_Click;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(17, 15);
            usernameLabel.Margin = new Padding(4, 0, 4, 0);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(119, 25);
            usernameLabel.TabIndex = 4;
            usernameLabel.Text = "Hello, [USER]!";
            // 
            // nurseManagerButton
            // 
            nurseManagerButton.Location = new Point(17, 475);
            nurseManagerButton.Margin = new Padding(4, 5, 4, 5);
            nurseManagerButton.Name = "nurseManagerButton";
            nurseManagerButton.Size = new Size(180, 65);
            nurseManagerButton.TabIndex = 5;
            nurseManagerButton.Text = "Nurse Manager";
            nurseManagerButton.UseVisualStyleBackColor = true;
            nurseManagerButton.Click += nurseManagerButton_Click;
            // 
            // LogoutButton
            // 
            LogoutButton.Location = new Point(1019, 12);
            LogoutButton.Name = "LogoutButton";
            LogoutButton.Size = new Size(112, 34);
            LogoutButton.TabIndex = 6;
            LogoutButton.Text = "Logout";
            LogoutButton.UseVisualStyleBackColor = true;
            LogoutButton.Click += LogoutButton_Click;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(LogoutButton);
            Controls.Add(nurseManagerButton);
            Controls.Add(usernameLabel);
            Controls.Add(editPatientButton);
            Controls.Add(patientSearchButton);
            Controls.Add(registerPatientButton);
            Controls.Add(appointmentButton);
            Margin = new Padding(4, 5, 4, 5);
            Name = "MainMenuForm";
            Text = "MainMenuForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button appointmentButton;
        private Button registerPatientButton;
        private Button patientSearchButton;
        private Button editPatientButton;
        private Label usernameLabel;
        private Button nurseManagerButton;
        private Button LogoutButton;
    }
}