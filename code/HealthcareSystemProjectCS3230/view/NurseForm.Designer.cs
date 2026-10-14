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
            addFnameTextBox = new TextBox();
            addUsernameTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            addLabel = new Label();
            label7 = new Label();
            addPasswordTextBox = new TextBox();
            label8 = new Label();
            addLnameTextBox = new TextBox();
            addBirthDateTimePicker = new DateTimePicker();
            label9 = new Label();
            addZipCodeTextBox = new TextBox();
            label10 = new Label();
            addStreetTextBox = new TextBox();
            label11 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            addStateComboBox = new ComboBox();
            label12 = new Label();
            label13 = new Label();
            addCityTextBox = new TextBox();
            addPhoneNumberTextBox = new TextBox();
            label14 = new Label();
            updateCheckBox = new CheckBox();
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
            addButton.Location = new Point(516, 361);
            addButton.Name = "addButton";
            addButton.Size = new Size(75, 23);
            addButton.TabIndex = 1;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // addFnameTextBox
            // 
            addFnameTextBox.Location = new Point(457, 75);
            addFnameTextBox.Name = "addFnameTextBox";
            addFnameTextBox.Size = new Size(100, 23);
            addFnameTextBox.TabIndex = 2;
            // 
            // addUsernameTextBox
            // 
            addUsernameTextBox.Location = new Point(438, 332);
            addUsernameTextBox.Name = "addUsernameTextBox";
            addUsernameTextBox.Size = new Size(100, 23);
            addUsernameTextBox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(474, 57);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 4;
            label1.Text = "First Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(457, 314);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 5;
            label2.Text = "Username";
            // 
            // addLabel
            // 
            addLabel.AutoSize = true;
            addLabel.Location = new Point(516, 23);
            addLabel.Name = "addLabel";
            addLabel.Size = new Size(90, 15);
            addLabel.TabIndex = 6;
            addLabel.Text = "Add New Nurse";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(598, 314);
            label7.Name = "label7";
            label7.Size = new Size(57, 15);
            label7.TabIndex = 14;
            label7.Text = "Password";
            // 
            // addPasswordTextBox
            // 
            addPasswordTextBox.Location = new Point(580, 332);
            addPasswordTextBox.Name = "addPasswordTextBox";
            addPasswordTextBox.Size = new Size(100, 23);
            addPasswordTextBox.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(597, 57);
            label8.Name = "label8";
            label8.Size = new Size(63, 15);
            label8.TabIndex = 16;
            label8.Text = "Last Name";
            // 
            // addLnameTextBox
            // 
            addLnameTextBox.Location = new Point(580, 75);
            addLnameTextBox.Name = "addLnameTextBox";
            addLnameTextBox.Size = new Size(100, 23);
            addLnameTextBox.TabIndex = 15;
            // 
            // addBirthDateTimePicker
            // 
            addBirthDateTimePicker.Location = new Point(457, 114);
            addBirthDateTimePicker.Name = "addBirthDateTimePicker";
            addBirthDateTimePicker.Size = new Size(200, 23);
            addBirthDateTimePicker.TabIndex = 17;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(383, 120);
            label9.Name = "label9";
            label9.Size = new Size(59, 15);
            label9.TabIndex = 18;
            label9.Text = "Birth Date";
            // 
            // addZipCodeTextBox
            // 
            addZipCodeTextBox.Location = new Point(457, 183);
            addZipCodeTextBox.Name = "addZipCodeTextBox";
            addZipCodeTextBox.Size = new Size(134, 23);
            addZipCodeTextBox.TabIndex = 19;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(414, 224);
            label10.Name = "label10";
            label10.Size = new Size(28, 15);
            label10.TabIndex = 20;
            label10.Text = "City";
            // 
            // addStreetTextBox
            // 
            addStreetTextBox.Location = new Point(457, 148);
            addStreetTextBox.Name = "addStreetTextBox";
            addStreetTextBox.Size = new Size(221, 23);
            addStreetTextBox.TabIndex = 21;
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
            // addStateComboBox
            // 
            addStateComboBox.FormattingEnabled = true;
            addStateComboBox.Location = new Point(640, 183);
            addStateComboBox.Name = "addStateComboBox";
            addStateComboBox.Size = new Size(40, 23);
            addStateComboBox.TabIndex = 24;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(597, 186);
            label12.Name = "label12";
            label12.Size = new Size(33, 15);
            label12.TabIndex = 25;
            label12.Text = "State";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(389, 183);
            label13.Name = "label13";
            label13.Size = new Size(53, 15);
            label13.TabIndex = 26;
            label13.Text = "ZIP code";
            // 
            // addCityTextBox
            // 
            addCityTextBox.Location = new Point(457, 221);
            addCityTextBox.Name = "addCityTextBox";
            addCityTextBox.Size = new Size(221, 23);
            addCityTextBox.TabIndex = 27;
            // 
            // addPhoneNumberTextBox
            // 
            addPhoneNumberTextBox.Location = new Point(457, 264);
            addPhoneNumberTextBox.Name = "addPhoneNumberTextBox";
            addPhoneNumberTextBox.Size = new Size(221, 23);
            addPhoneNumberTextBox.TabIndex = 28;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(354, 267);
            label14.Name = "label14";
            label14.Size = new Size(88, 15);
            label14.TabIndex = 29;
            label14.Text = "Phone Number";
            // 
            // updateCheckBox
            // 
            updateCheckBox.AutoSize = true;
            updateCheckBox.Location = new Point(684, 392);
            updateCheckBox.Name = "updateCheckBox";
            updateCheckBox.Size = new Size(98, 19);
            updateCheckBox.TabIndex = 30;
            updateCheckBox.Text = "Update Mode";
            updateCheckBox.UseVisualStyleBackColor = true;
            updateCheckBox.CheckedChanged += updateCheckBox_CheckedChanged;
            // 
            // NurseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(updateCheckBox);
            Controls.Add(label14);
            Controls.Add(addPhoneNumberTextBox);
            Controls.Add(addCityTextBox);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(addStateComboBox);
            Controls.Add(label11);
            Controls.Add(addStreetTextBox);
            Controls.Add(label10);
            Controls.Add(addZipCodeTextBox);
            Controls.Add(label9);
            Controls.Add(addBirthDateTimePicker);
            Controls.Add(label8);
            Controls.Add(addLnameTextBox);
            Controls.Add(label7);
            Controls.Add(addPasswordTextBox);
            Controls.Add(addLabel);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(addUsernameTextBox);
            Controls.Add(addFnameTextBox);
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
        private TextBox addFnameTextBox;
        private TextBox addUsernameTextBox;
        private TextBox addZipCodeTextBox;
        private TextBox addCityTextBox;
        private TextBox addLnameTextBox;
        private TextBox addStreetTextBox;
        private TextBox addPasswordTextBox;
        private ComboBox addStateComboBox;
        private Label label1;
        private Label label2;
        private ColumnHeader NurseID;
        private Label addLabel;
        private Label label7;
        private TextBox passwordTextBox;
        private Label label8;
        private DateTimePicker addBirthDateTimePicker;
        private Label label9;
        private Label label10;
        private Label label11;
        private ContextMenuStrip contextMenuStrip1;
        private ComboBox comboBox1;
        private Label label12;
        private Label label13;
        private TextBox textBox3;
        private TextBox addPhoneNumberTextBox;
        private Label label14;
        private CheckBox updateCheckBox;
    }
}