namespace HealthcareSystemProjectCS3230.view
{
    partial class AdminStatsForm
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
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            dateTimePicker2 = new DateTimePicker();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            testCode = new DataGridViewTextBoxColumn();
            testName = new DataGridViewTextBoxColumn();
            timesPerformed = new DataGridViewTextBoxColumn();
            numOfAllTest = new DataGridViewTextBoxColumn();
            testPercentage = new DataGridViewTextBoxColumn();
            normalResults = new DataGridViewTextBoxColumn();
            abnormalResults = new DataGridViewTextBoxColumn();
            generateButton = new Button();
            exitButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(25, 78);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(328, 22);
            label1.Name = "label1";
            label1.Size = new Size(105, 20);
            label1.TabIndex = 1;
            label1.Text = "Test Statistics";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(98, 60);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 2;
            label2.Text = "Start Date:";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(566, 78);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(636, 60);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 4;
            label3.Text = "End Date:";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { testCode, testName, timesPerformed, numOfAllTest, testPercentage, normalResults, abnormalResults });
            dataGridView1.Location = new Point(25, 107);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(741, 302);
            dataGridView1.TabIndex = 5;
            // 
            // testCode
            // 
            testCode.HeaderText = "Test Code";
            testCode.Name = "testCode";
            testCode.ReadOnly = true;
            // 
            // testName
            // 
            testName.HeaderText = "Test Name";
            testName.Name = "testName";
            testName.ReadOnly = true;
            // 
            // timesPerformed
            // 
            timesPerformed.HeaderText = "Times Performed";
            timesPerformed.Name = "timesPerformed";
            timesPerformed.ReadOnly = true;
            // 
            // numOfAllTest
            // 
            numOfAllTest.HeaderText = "Total Tests Performed";
            numOfAllTest.Name = "numOfAllTest";
            numOfAllTest.ReadOnly = true;
            // 
            // testPercentage
            // 
            testPercentage.HeaderText = "Test Percentage";
            testPercentage.Name = "testPercentage";
            testPercentage.ReadOnly = true;
            // 
            // normalResults
            // 
            normalResults.HeaderText = "Normal Results";
            normalResults.Name = "normalResults";
            normalResults.ReadOnly = true;
            // 
            // abnormalResults
            // 
            abnormalResults.HeaderText = "Abnormal Results";
            abnormalResults.Name = "abnormalResults";
            abnormalResults.ReadOnly = true;
            // 
            // generateButton
            // 
            generateButton.Location = new Point(317, 78);
            generateButton.Name = "generateButton";
            generateButton.Size = new Size(131, 23);
            generateButton.TabIndex = 6;
            generateButton.Text = "Generate Report";
            generateButton.UseVisualStyleBackColor = true;
            generateButton.Click += generateButton_Click;
            // 
            // exitButton
            // 
            exitButton.Location = new Point(358, 415);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(75, 23);
            exitButton.TabIndex = 7;
            exitButton.Text = "Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // AdminStatsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(exitButton);
            Controls.Add(generateButton);
            Controls.Add(dataGridView1);
            Controls.Add(label3);
            Controls.Add(dateTimePicker2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateTimePicker1);
            Name = "AdminStatsForm";
            Text = "AdminStatsForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePicker2;
        private Label label3;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn testCode;
        private DataGridViewTextBoxColumn testName;
        private DataGridViewTextBoxColumn timesPerformed;
        private DataGridViewTextBoxColumn numOfAllTest;
        private DataGridViewTextBoxColumn testPercentage;
        private DataGridViewTextBoxColumn normalResults;
        private DataGridViewTextBoxColumn abnormalResults;
        private Button generateButton;
        private Button exitButton;
    }
}