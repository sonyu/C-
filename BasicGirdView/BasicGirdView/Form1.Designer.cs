namespace BasicGirdView
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
            this.major = new System.Windows.Forms.TabControl();
            this.user = new System.Windows.Forms.TabPage();
            this.btsearch = new System.Windows.Forms.Button();
            this.btdelete = new System.Windows.Forms.Button();
            this.btupdate = new System.Windows.Forms.Button();
            this.btinsert = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.department = new System.Windows.Forms.TabPage();
            this.position = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.major.SuspendLayout();
            this.user.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // major
            // 
            this.major.Controls.Add(this.user);
            this.major.Controls.Add(this.department);
            this.major.Controls.Add(this.position);
            this.major.Controls.Add(this.tabPage4);
            this.major.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.major.Location = new System.Drawing.Point(0, -1);
            this.major.Name = "major";
            this.major.SelectedIndex = 0;
            this.major.Size = new System.Drawing.Size(1270, 626);
            this.major.TabIndex = 0;
            // 
            // user
            // 
            this.user.Controls.Add(this.btsearch);
            this.user.Controls.Add(this.btdelete);
            this.user.Controls.Add(this.btupdate);
            this.user.Controls.Add(this.btinsert);
            this.user.Controls.Add(this.dataGridView1);
            this.user.Location = new System.Drawing.Point(4, 29);
            this.user.Name = "user";
            this.user.Padding = new System.Windows.Forms.Padding(3);
            this.user.Size = new System.Drawing.Size(1262, 593);
            this.user.TabIndex = 0;
            this.user.Text = "Users";
            this.user.UseVisualStyleBackColor = true;
            // 
            // btsearch
            // 
            this.btsearch.Location = new System.Drawing.Point(1072, 274);
            this.btsearch.Name = "btsearch";
            this.btsearch.Size = new System.Drawing.Size(161, 53);
            this.btsearch.TabIndex = 4;
            this.btsearch.Text = "SEARCH";
            this.btsearch.UseVisualStyleBackColor = true;
            this.btsearch.Click += new System.EventHandler(this.btsearch_Click);
            // 
            // btdelete
            // 
            this.btdelete.Location = new System.Drawing.Point(1072, 185);
            this.btdelete.Name = "btdelete";
            this.btdelete.Size = new System.Drawing.Size(161, 53);
            this.btdelete.TabIndex = 3;
            this.btdelete.Text = "DELETE";
            this.btdelete.UseVisualStyleBackColor = true;
            this.btdelete.Click += new System.EventHandler(this.btdelete_Click);
            // 
            // btupdate
            // 
            this.btupdate.Location = new System.Drawing.Point(1075, 94);
            this.btupdate.Name = "btupdate";
            this.btupdate.Size = new System.Drawing.Size(161, 53);
            this.btupdate.TabIndex = 2;
            this.btupdate.Text = "UPDATE";
            this.btupdate.UseVisualStyleBackColor = true;
            this.btupdate.Click += new System.EventHandler(this.btupdate_Click);
            // 
            // btinsert
            // 
            this.btinsert.Location = new System.Drawing.Point(1072, 7);
            this.btinsert.Name = "btinsert";
            this.btinsert.Size = new System.Drawing.Size(161, 53);
            this.btinsert.TabIndex = 1;
            this.btinsert.Text = "INSERT";
            this.btinsert.UseVisualStyleBackColor = true;
            this.btinsert.Click += new System.EventHandler(this.btinsert_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 7);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1027, 583);
            this.dataGridView1.TabIndex = 0;
            // 
            // department
            // 
            this.department.Location = new System.Drawing.Point(4, 29);
            this.department.Name = "department";
            this.department.Padding = new System.Windows.Forms.Padding(3);
            this.department.Size = new System.Drawing.Size(1262, 593);
            this.department.TabIndex = 1;
            this.department.Text = "Department";
            this.department.UseVisualStyleBackColor = true;
            // 
            // position
            // 
            this.position.Location = new System.Drawing.Point(4, 29);
            this.position.Name = "position";
            this.position.Padding = new System.Windows.Forms.Padding(3);
            this.position.Size = new System.Drawing.Size(1262, 593);
            this.position.TabIndex = 2;
            this.position.Text = "Positions";
            this.position.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1262, 593);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Majors";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 625);
            this.Controls.Add(this.major);
            this.Name = "Form1";
            this.Text = "Form1";
            this.major.ResumeLayout(false);
            this.user.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl major;
        private System.Windows.Forms.TabPage user;
        private System.Windows.Forms.Button btsearch;
        private System.Windows.Forms.Button btdelete;
        private System.Windows.Forms.Button btupdate;
        private System.Windows.Forms.Button btinsert;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage department;
        private System.Windows.Forms.TabPage position;
        private System.Windows.Forms.TabPage tabPage4;
    }
}

