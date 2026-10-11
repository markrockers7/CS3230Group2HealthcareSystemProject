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
            editPatientButton = new Button();
            SuspendLayout();
            // 
            // appointmentButton
            // 
            appointmentButton.Location = new Point(49, 76);
            appointmentButton.Name = "appointmentButton";
            appointmentButton.Size = new Size(126, 40);
            appointmentButton.TabIndex = 0;
            appointmentButton.Text = "Add Appointment";
            appointmentButton.UseVisualStyleBackColor = true;
            appointmentButton.Click += appointmentButton_Click;
            // 
            // registerPatientButton
            // 
            registerPatientButton.Location = new Point(200, 76);
            registerPatientButton.Name = "registerPatientButton";
            registerPatientButton.Size = new Size(140, 40);
            registerPatientButton.TabIndex = 1;
            registerPatientButton.Text = "Register Patient";
            registerPatientButton.UseVisualStyleBackColor = true;
            registerPatientButton.Click += registerPatientButton_Click;
            // 
            // editPatientButton
            // 
            editPatientButton.Location = new Point(360, 76);
            editPatientButton.Name = "editPatientButton";
            editPatientButton.Size = new Size(140, 40);
            editPatientButton.TabIndex = 2;
            editPatientButton.Text = "Edit Patient";
            editPatientButton.UseVisualStyleBackColor = true;
            editPatientButton.Click += editPatientButton_Click;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(appointmentButton);
            Controls.Add(registerPatientButton);
            Controls.Add(editPatientButton);
            Name = "MainMenuForm";
            Text = "MainMenuForm";
            ResumeLayout(false);
        }

        #endregion

        private Button appointmentButton;
        private Button registerPatientButton;
        private Button editPatientButton;
    }
}