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
            nurseManagerButton = new Button();
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
            // nurseManagerButton
            // 
            nurseManagerButton.Location = new Point(349, 76);
            nurseManagerButton.Name = "nurseManagerButton";
            nurseManagerButton.Size = new Size(126, 40);
            nurseManagerButton.TabIndex = 1;
            nurseManagerButton.Text = "Nurse Manager (Admin Only)";
            nurseManagerButton.UseVisualStyleBackColor = true;
            nurseManagerButton.Click += nurseManagerButton_Click;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(nurseManagerButton);
            Controls.Add(appointmentButton);
            Name = "MainMenuForm";
            Text = "MainMenuForm";
            ResumeLayout(false);
        }

        #endregion

        private Button appointmentButton;
        private Button nurseManagerButton;
    }
}