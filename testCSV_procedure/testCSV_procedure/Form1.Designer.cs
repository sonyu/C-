namespace testCSV_procedure
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.user = new System.Windows.Forms.TabPage();
            this.department = new System.Windows.Forms.TabPage();
            this.position = new System.Windows.Forms.TabPage();
            this.major = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btInsert = new System.Windows.Forms.Button();
            this.btupdate = new System.Windows.Forms.Button();
            this.btdelete = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.user.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.user);
            this.tabControl1.Controls.Add(this.department);
            this.tabControl1.Controls.Add(this.position);
            this.tabControl1.Controls.Add(this.major);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1282, 625);
            this.tabControl1.TabIndex = 0;
            // 
            // user
            // 
            this.user.Controls.Add(this.button4);
            this.user.Controls.Add(this.btdelete);
            this.user.Controls.Add(this.btupdate);
            this.user.Controls.Add(this.btInsert);
            this.user.Controls.Add(this.dataGridView1);
            this.user.Location = new System.Drawing.Point(4, 38);
            this.user.Name = "user";
            this.user.Padding = new System.Windows.Forms.Padding(3);
            this.user.Size = new System.Drawing.Size(1274, 583);
            this.user.TabIndex = 0;
            this.user.Text = "Users";
            this.user.UseVisualStyleBackColor = true;
            // 
            // department
            // 
            this.department.Location = new System.Drawing.Point(4, 38);
            this.department.Name = "department";
            this.department.Padding = new System.Windows.Forms.Padding(3);
            this.department.Size = new System.Drawing.Size(1168, 538);
            this.department.TabIndex = 1;
            this.department.Text = "Departments";
            this.department.UseVisualStyleBackColor = true;
            // 
            // position
            // 
            this.position.Location = new System.Drawing.Point(4, 38);
            this.position.Name = "position";
            this.position.Padding = new System.Windows.Forms.Padding(3);
            this.position.Size = new System.Drawing.Size(1168, 538);
            this.position.TabIndex = 2;
            this.position.Text = "Positions";
            this.position.UseVisualStyleBackColor = true;
            // 
            // major
            // 
            this.major.Location = new System.Drawing.Point(4, 38);
            this.major.Name = "major";
            this.major.Padding = new System.Windows.Forms.Padding(3);
            this.major.Size = new System.Drawing.Size(1168, 538);
            this.major.TabIndex = 3;
            this.major.Text = "Major";
            this.major.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(944, 559);
            this.dataGridView1.TabIndex = 0;
            // 
            // btInsert
            // 
            this.btInsert.Location = new System.Drawing.Point(1031, 30);
            this.btInsert.Name = "btInsert";
            this.btInsert.Size = new System.Drawing.Size(173, 61);
            this.btInsert.TabIndex = 1;
            this.btInsert.Text = "Insert";
            this.btInsert.UseVisualStyleBackColor = true;
            this.btInsert.Click += new System.EventHandler(this.btInsert_Click);
            // 
            // btupdate
            // 
            this.btupdate.Location = new System.Drawing.Point(1031, 118);
            this.btupdate.Name = "btupdate";
            this.btupdate.Size = new System.Drawing.Size(173, 61);
            this.btupdate.TabIndex = 1;
            this.btupdate.Text = "Update";
            this.btupdate.UseVisualStyleBackColor = true;
            // 
            // btdelete
            // 
            this.btdelete.Location = new System.Drawing.Point(1031, 208);
            this.btdelete.Name = "btdelete";
            this.btdelete.Size = new System.Drawing.Size(173, 61);
            this.btdelete.TabIndex = 1;
            this.btdelete.Text = "Delete";
            this.btdelete.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1031, 301);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(173, 61);
            this.button4.TabIndex = 1;
            this.button4.Text = "Search";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 626);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.user.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage user;
        private System.Windows.Forms.TabPage department;
        private System.Windows.Forms.TabPage position;
        private System.Windows.Forms.TabPage major;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btdelete;
        private System.Windows.Forms.Button btupdate;
        private System.Windows.Forms.Button btInsert;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

