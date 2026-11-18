namespace company.db
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            button1 = new Button();
            groupBox1 = new GroupBox();
            cmdDepartment = new ComboBox();
            txtSearchName = new TextBox();
            numMinSalary = new NumericUpDown();
            numMaxSlary = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMinSalary).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaxSlary).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(569, 332);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(21, 350);
            button1.Name = "button1";
            button1.Size = new Size(129, 23);
            button1.TabIndex = 1;
            button1.Text = "Создать таблицу";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(numMaxSlary);
            groupBox1.Controls.Add(numMinSalary);
            groupBox1.Controls.Add(txtSearchName);
            groupBox1.Controls.Add(cmdDepartment);
            groupBox1.Location = new Point(816, 125);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(338, 206);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Фильтры";
            // 
            // cmdDepartment
            // 
            cmdDepartment.FormattingEnabled = true;
            cmdDepartment.Location = new Point(6, 35);
            cmdDepartment.Name = "cmdDepartment";
            cmdDepartment.Size = new Size(121, 23);
            cmdDepartment.TabIndex = 0;
            // 
            // txtSearchName
            // 
            txtSearchName.Location = new Point(6, 64);
            txtSearchName.Name = "txtSearchName";
            txtSearchName.Size = new Size(100, 23);
            txtSearchName.TabIndex = 1;
            // 
            // numMinSalary
            // 
            numMinSalary.Location = new Point(6, 93);
            numMinSalary.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numMinSalary.Name = "numMinSalary";
            numMinSalary.Size = new Size(120, 23);
            numMinSalary.TabIndex = 2;
            // 
            // numMaxSlary
            // 
            numMaxSlary.Location = new Point(7, 120);
            numMaxSlary.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numMaxSlary.Name = "numMaxSlary";
            numMaxSlary.Size = new Size(120, 23);
            numMaxSlary.TabIndex = 3;
            numMaxSlary.Value = new decimal(new int[] { 500000, 0, 0, 0 });
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1327, 590);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "FormMain";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMinSalary).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaxSlary).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private GroupBox groupBox1;
        private ComboBox cmdDepartment;
        private NumericUpDown numMinSalary;
        private TextBox txtSearchName;
        private NumericUpDown numMaxSlary;
    }
}
