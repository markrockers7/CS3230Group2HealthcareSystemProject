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
            components = new System.ComponentModel.Container();
            NurseListView = new ListView();
            NurseID = new ColumnHeader();
            FirstName = new ColumnHeader();
            LastName = new ColumnHeader();
            Username = new ColumnHeader();
            addButton = new Button();
            fnameTextBox = new TextBox();
            usernameTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            addLabel = new Label();
            label7 = new Label();
            passwordTextBox = new TextBox();
            label8 = new Label();
            lnameTextBox = new TextBox();
            birthDateTimePicker = new DateTimePicker();
            label9 = new Label();
            zipCodeTextBox = new TextBox();
            label10 = new Label();
            streetTextBox = new TextBox();
            label11 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            stateComboBox = new ComboBox();
            label12 = new Label();
            label13 = new Label();
            cityTextBox = new TextBox();
            phoneNumberTextBox = new TextBox();
            label14 = new Label();
            updateCheckBox = new CheckBox();
            usernameErrorLabel = new Label();
            passwordErrorLabel = new Label();
            phoneNumberErrorLabel = new Label();
            cityErrorLabel = new Label();
            zipCodeErrorLabel = new Label();
            stateErrorLabel = new Label();
            streetErrorLabel = new Label();
            birthdateErrorLabel = new Label();
            fnameErrorLabel = new Label();
            lnameErrorLabel = new Label();
            clearFormButton = new Button();
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
            addButton.Location = new Point(516, 415);
            addButton.Name = "addButton";
            addButton.Size = new Size(75, 23);
            addButton.TabIndex = 1;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // fnameTextBox
            // 
            fnameTextBox.Location = new Point(457, 57);
            fnameTextBox.Name = "fnameTextBox";
            fnameTextBox.Size = new Size(100, 23);
            fnameTextBox.TabIndex = 2;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(438, 363);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(100, 23);
            usernameTextBox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(474, 39);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 4;
            label1.Text = "First Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(457, 345);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 5;
            label2.Text = "Username";
            // 
            // addLabel
            // 
            addLabel.AutoSize = true;
            addLabel.Location = new Point(516, 12);
            addLabel.Name = "addLabel";
            addLabel.Size = new Size(90, 15);
            addLabel.TabIndex = 6;
            addLabel.Text = "Add New Nurse";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(598, 345);
            label7.Name = "label7";
            label7.Size = new Size(57, 15);
            label7.TabIndex = 14;
            label7.Text = "Password";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(580, 363);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(100, 23);
            passwordTextBox.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(597, 39);
            label8.Name = "label8";
            label8.Size = new Size(63, 15);
            label8.TabIndex = 16;
            label8.Text = "Last Name";
            // 
            // lnameTextBox
            // 
            lnameTextBox.Location = new Point(580, 57);
            lnameTextBox.Name = "lnameTextBox";
            lnameTextBox.Size = new Size(100, 23);
            lnameTextBox.TabIndex = 15;
            // 
            // birthDateTimePicker
            // 
            birthDateTimePicker.Location = new Point(457, 103);
            birthDateTimePicker.Name = "birthDateTimePicker";
            birthDateTimePicker.Size = new Size(200, 23);
            birthDateTimePicker.TabIndex = 17;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(383, 109);
            label9.Name = "label9";
            label9.Size = new Size(59, 15);
            label9.TabIndex = 18;
            label9.Text = "Birth Date";
            // 
            // zipCodeTextBox
            // 
            zipCodeTextBox.Location = new Point(457, 195);
            zipCodeTextBox.Name = "zipCodeTextBox";
            zipCodeTextBox.Size = new Size(134, 23);
            zipCodeTextBox.TabIndex = 19;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(414, 239);
            label10.Name = "label10";
            label10.Size = new Size(28, 15);
            label10.TabIndex = 20;
            label10.Text = "City";
            // 
            // streetTextBox
            // 
            streetTextBox.Location = new Point(457, 148);
            streetTextBox.Name = "streetTextBox";
            streetTextBox.Size = new Size(221, 23);
            streetTextBox.TabIndex = 21;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(405, 151);
            label11.Name = "label11";
            label11.Size = new Size(37, 15);
            label11.TabIndex = 22;
            label11.Text = "Street";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // stateComboBox
            // 
            stateComboBox.FormattingEnabled = true;
            stateComboBox.Location = new Point(640, 195);
            stateComboBox.Name = "stateComboBox";
            stateComboBox.Size = new Size(40, 23);
            stateComboBox.TabIndex = 24;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(598, 198);
            label12.Name = "label12";
            label12.Size = new Size(33, 15);
            label12.TabIndex = 25;
            label12.Text = "State";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(389, 195);
            label13.Name = "label13";
            label13.Size = new Size(53, 15);
            label13.TabIndex = 26;
            label13.Text = "ZIP code";
            // 
            // cityTextBox
            // 
            cityTextBox.Location = new Point(457, 239);
            cityTextBox.Name = "cityTextBox";
            cityTextBox.Size = new Size(221, 23);
            cityTextBox.TabIndex = 27;
            // 
            // phoneNumberTextBox
            // 
            phoneNumberTextBox.Location = new Point(457, 290);
            phoneNumberTextBox.Name = "phoneNumberTextBox";
            phoneNumberTextBox.Size = new Size(221, 23);
            phoneNumberTextBox.TabIndex = 28;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(354, 293);
            label14.Name = "label14";
            label14.Size = new Size(88, 15);
            label14.TabIndex = 29;
            label14.Text = "Phone Number";
            // 
            // updateCheckBox
            // 
            updateCheckBox.AutoSize = true;
            updateCheckBox.Location = new Point(676, 415);
            updateCheckBox.Name = "updateCheckBox";
            updateCheckBox.Size = new Size(98, 19);
            updateCheckBox.TabIndex = 30;
            updateCheckBox.Text = "Update Mode";
            updateCheckBox.UseVisualStyleBackColor = true;
            updateCheckBox.CheckedChanged += updateCheckBox_CheckedChanged;
            // 
            // usernameErrorLabel
            // 
            usernameErrorLabel.AutoSize = true;
            usernameErrorLabel.ForeColor = Color.Red;
            usernameErrorLabel.Location = new Point(433, 393);
            usernameErrorLabel.Name = "usernameErrorLabel";
            usernameErrorLabel.Size = new Size(0, 15);
            usernameErrorLabel.TabIndex = 31;
            // 
            // passwordErrorLabel
            // 
            passwordErrorLabel.AutoSize = true;
            passwordErrorLabel.ForeColor = Color.Red;
            passwordErrorLabel.Location = new Point(579, 392);
            passwordErrorLabel.Name = "passwordErrorLabel";
            passwordErrorLabel.Size = new Size(0, 15);
            passwordErrorLabel.TabIndex = 32;
            // 
            // phoneNumberErrorLabel
            // 
            phoneNumberErrorLabel.AutoSize = true;
            phoneNumberErrorLabel.ForeColor = Color.Red;
            phoneNumberErrorLabel.Location = new Point(457, 316);
            phoneNumberErrorLabel.Name = "phoneNumberErrorLabel";
            phoneNumberErrorLabel.Size = new Size(0, 15);
            phoneNumberErrorLabel.TabIndex = 33;
            // 
            // cityErrorLabel
            // 
            cityErrorLabel.AutoSize = true;
            cityErrorLabel.ForeColor = Color.Red;
            cityErrorLabel.Location = new Point(457, 272);
            cityErrorLabel.Name = "cityErrorLabel";
            cityErrorLabel.Size = new Size(0, 15);
            cityErrorLabel.TabIndex = 34;
            // 
            // zipCodeErrorLabel
            // 
            zipCodeErrorLabel.AutoSize = true;
            zipCodeErrorLabel.ForeColor = Color.Red;
            zipCodeErrorLabel.Location = new Point(457, 221);
            zipCodeErrorLabel.Name = "zipCodeErrorLabel";
            zipCodeErrorLabel.Size = new Size(0, 15);
            zipCodeErrorLabel.TabIndex = 35;
            // 
            // stateErrorLabel
            // 
            stateErrorLabel.AutoSize = true;
            stateErrorLabel.ForeColor = Color.Red;
            stateErrorLabel.Location = new Point(606, 221);
            stateErrorLabel.Name = "stateErrorLabel";
            stateErrorLabel.Size = new Size(0, 15);
            stateErrorLabel.TabIndex = 36;
            // 
            // streetErrorLabel
            // 
            streetErrorLabel.AutoSize = true;
            streetErrorLabel.ForeColor = Color.Red;
            streetErrorLabel.Location = new Point(457, 177);
            streetErrorLabel.Name = "streetErrorLabel";
            streetErrorLabel.Size = new Size(0, 15);
            streetErrorLabel.TabIndex = 37;
            // 
            // birthdateErrorLabel
            // 
            birthdateErrorLabel.AutoSize = true;
            birthdateErrorLabel.ForeColor = Color.Red;
            birthdateErrorLabel.Location = new Point(457, 130);
            birthdateErrorLabel.Name = "birthdateErrorLabel";
            birthdateErrorLabel.Size = new Size(0, 15);
            birthdateErrorLabel.TabIndex = 38;
            // 
            // fnameErrorLabel
            // 
            fnameErrorLabel.AutoSize = true;
            fnameErrorLabel.ForeColor = Color.Red;
            fnameErrorLabel.Location = new Point(457, 83);
            fnameErrorLabel.Name = "fnameErrorLabel";
            fnameErrorLabel.Size = new Size(0, 15);
            fnameErrorLabel.TabIndex = 39;
            // 
            // lnameErrorLabel
            // 
            lnameErrorLabel.AutoSize = true;
            lnameErrorLabel.ForeColor = Color.Red;
            lnameErrorLabel.Location = new Point(580, 83);
            lnameErrorLabel.Name = "lnameErrorLabel";
            lnameErrorLabel.Size = new Size(0, 15);
            lnameErrorLabel.TabIndex = 40;
            // 
            // clearFormButton
            // 
            clearFormButton.Location = new Point(352, 411);
            clearFormButton.Name = "clearFormButton";
            clearFormButton.Size = new Size(75, 23);
            clearFormButton.TabIndex = 41;
            clearFormButton.Text = "Clear Form";
            clearFormButton.UseVisualStyleBackColor = true;
            clearFormButton.Click += clearFormButton_Click;
            // 
            // NurseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(clearFormButton);
            Controls.Add(lnameErrorLabel);
            Controls.Add(fnameErrorLabel);
            Controls.Add(birthdateErrorLabel);
            Controls.Add(streetErrorLabel);
            Controls.Add(stateErrorLabel);
            Controls.Add(zipCodeErrorLabel);
            Controls.Add(cityErrorLabel);
            Controls.Add(phoneNumberErrorLabel);
            Controls.Add(passwordErrorLabel);
            Controls.Add(usernameErrorLabel);
            Controls.Add(updateCheckBox);
            Controls.Add(label14);
            Controls.Add(phoneNumberTextBox);
            Controls.Add(cityTextBox);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(stateComboBox);
            Controls.Add(label11);
            Controls.Add(streetTextBox);
            Controls.Add(label10);
            Controls.Add(zipCodeTextBox);
            Controls.Add(label9);
            Controls.Add(birthDateTimePicker);
            Controls.Add(label8);
            Controls.Add(lnameTextBox);
            Controls.Add(label7);
            Controls.Add(passwordTextBox);
            Controls.Add(addLabel);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(usernameTextBox);
            Controls.Add(fnameTextBox);
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
        private TextBox fnameTextBox;
        private TextBox usernameTextBox;
        private TextBox zipCodeTextBox;
        private TextBox cityTextBox;
        private TextBox lnameTextBox;
        private TextBox streetTextBox;
        private ComboBox stateComboBox;
        private Label label1;
        private Label label2;
        private ColumnHeader NurseID;
        private Label addLabel;
        private Label label7;
        private TextBox passwordTextBox;
        private Label label8;
        private DateTimePicker birthDateTimePicker;
        private Label label9;
        private Label label10;
        private Label label11;
        private ContextMenuStrip contextMenuStrip1;
        private ComboBox comboBox1;
        private Label label12;
        private Label label13;
        private TextBox textBox3;
        private TextBox phoneNumberTextBox;
        private Label label14;
        private CheckBox updateCheckBox;
        private Label usernameErrorLabel;
        private Label passwordErrorLabel;
        private Label phoneNumberErrorLabel;
        private Label cityErrorLabel;
        private Label zipCodeErrorLabel;
        private Label stateErrorLabel;
        private Label streetErrorLabel;
        private Label birthdateErrorLabel;
        private Label fnameErrorLabel;
        private Label lnameErrorLabel;
        private Button clearFormButton;
    }
}