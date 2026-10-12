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
            SuspendLayout();
            // 
            // appointmentButton
            // 
            appointmentButton.Location = new Point(12, 147);
            appointmentButton.Name = "appointmentButton";
            appointmentButton.Size = new Size(126, 40);
            appointmentButton.TabIndex = 0;
            appointmentButton.Text = "Add Appointment";
            appointmentButton.UseVisualStyleBackColor = true;
            appointmentButton.Click += appointmentButton_Click;
            // 
            // registerPatientButton
            // 
            registerPatientButton.Location = new Point(12, 101);
            registerPatientButton.Name = "registerPatientButton";
            registerPatientButton.Size = new Size(126, 40);
            registerPatientButton.TabIndex = 2;
            registerPatientButton.Text = "Register Patient";
            registerPatientButton.UseVisualStyleBackColor = true;
            registerPatientButton.Click += registerPatientButton_Click;
            // 
            // patientSearchButton
            // 
            patientSearchButton.Location = new Point(12, 193);
            patientSearchButton.Name = "patientSearchButton";
            patientSearchButton.Size = new Size(126, 40);
            patientSearchButton.TabIndex = 1;
            patientSearchButton.Text = "Search Patients";
            patientSearchButton.UseVisualStyleBackColor = true;
            patientSearchButton.Click += patientSearchButton_Click;
            // 
            // editPatientButton
            // 
            editPatientButton.Location = new Point(12, 239);
            editPatientButton.Name = "editPatientButton";
            editPatientButton.Size = new Size(126, 40);
            editPatientButton.TabIndex = 3;
            editPatientButton.Text = "Edit Patient";
            editPatientButton.UseVisualStyleBackColor = true;
            editPatientButton.Click += editPatientButton_Click;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(editPatientButton);
            Controls.Add(patientSearchButton);
            Controls.Add(registerPatientButton);
            Controls.Add(appointmentButton);
            Name = "MainMenuForm";
            Text = "MainMenuForm";
            ResumeLayout(false);
        }

        #endregion

        private Button appointmentButton;
        private Button registerPatientButton;
        private Button patientSearchButton;
        private Button editPatientButton;
    }
}