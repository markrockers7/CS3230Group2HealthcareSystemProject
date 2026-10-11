using HealthcareSystemProjectCS3230.controler;

namespace HealthcareSystemProjectCS3230.view
{
    partial class NurseForm
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
            NurseListView = new ListView();
            NurseID = new ColumnHeader();
            FirstName = new ColumnHeader();
            LastName = new ColumnHeader();
            Username = new ColumnHeader();
            addButton = new Button();
            personIDTextBox = new TextBox();
            addUsernameTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            updateUsernameTextBox = new TextBox();
            updateButton = new Button();
            label6 = new Label();
            selectedNurseID = new Label();
            SuspendLayout();
            // 
            // NurseListView
            // 
            NurseListView.Columns.AddRange(new ColumnHeader[] { NurseID, FirstName, LastName, Username });
            NurseListView.Location = new Point(12, 12);
            NurseListView.Name = "NurseListView";
            NurseListView.Size = new Size(302, 426);
            NurseListView.TabIndex = 0;
            NurseListView.UseCompatibleStateImageBehavior = false;
            NurseListView.View = View.Details;
            NurseListView.SelectedIndexChanged += NurseListView_SelectedIndexChanged;
            // 
            // NurseID
            // 
            NurseID.Text = "Nurse ID";
            NurseID.Width = 57;
            // 
            // FirstName
            // 
            FirstName.Text = "First Name";
            FirstName.Width = 80;
            // 
            // LastName
            // 
            LastName.Text = "Last Name";
            LastName.Width = 80;
            // 
            // Username
            // 
            Username.Text = "Username";
            Username.Width = 80;
            // 
            // addButton
            // 
            addButton.Location = new Point(639, 95);
            addButton.Name = "addButton";
            addButton.Size = new Size(75, 23);
            addButton.TabIndex = 1;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // personIDTextBox
            // 
            personIDTextBox.Location = new Point(565, 66);
            personIDTextBox.Name = "personIDTextBox";
            personIDTextBox.Size = new Size(100, 23);
            personIDTextBox.TabIndex = 2;
            // 
            // addUsernameTextBox
            // 
            addUsernameTextBox.Location = new Point(686, 66);
            addUsernameTextBox.Name = "addUsernameTextBox";
            addUsernameTextBox.Size = new Size(100, 23);
            addUsernameTextBox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(582, 48);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 4;
            label1.Text = "Person ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(705, 48);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 5;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(639, 9);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 6;
            label3.Text = "Add a Nurse";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(388, 9);
            label4.Name = "label4";
            label4.Size = new Size(79, 15);
            label4.TabIndex = 7;
            label4.Text = "Update Nurse";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(428, 48);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 9;
            label5.Text = "Username";
            // 
            // updateUsernameTextBox
            // 
            updateUsernameTextBox.Location = new Point(413, 66);
            updateUsernameTextBox.Name = "updateUsernameTextBox";
            updateUsernameTextBox.Size = new Size(100, 23);
            updateUsernameTextBox.TabIndex = 8;
            // 
            // updateButton
            // 
            updateButton.Location = new Point(388, 95);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(75, 23);
            updateButton.TabIndex = 10;
            updateButton.Text = "Update";
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += updateButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(345, 48);
            label6.Name = "label6";
            label6.Size = new Size(52, 15);
            label6.TabIndex = 11;
            label6.Text = "Nurse ID";
            // 
            // selectedNurseID
            // 
            selectedNurseID.AutoSize = true;
            selectedNurseID.Location = new Point(366, 69);
            selectedNurseID.Name = "selectedNurseID";
            selectedNurseID.Size = new Size(13, 15);
            selectedNurseID.TabIndex = 12;
            selectedNurseID.Text = "0";
            // 
            // NurseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(selectedNurseID);
            Controls.Add(label6);
            Controls.Add(updateButton);
            Controls.Add(label5);
            Controls.Add(updateUsernameTextBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(addUsernameTextBox);
            Controls.Add(personIDTextBox);
            Controls.Add(addButton);
            Controls.Add(NurseListView);
            Name = "NurseForm";
            Text = "NurseForm";
            Load += NurseForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView NurseListView;
        private ColumnHeader FirstName;
        private ColumnHeader LastName;
        private ColumnHeader Username;
        private Button addButton;
        private TextBox personIDTextBox;
        private TextBox addUsernameTextBox;
        private Label label1;
        private Label label2;
        private ColumnHeader NurseID;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox updateUsernameTextBox;
        private Button updateButton;
        private Label label6;
        private Label selectedNurseID;
    }
}