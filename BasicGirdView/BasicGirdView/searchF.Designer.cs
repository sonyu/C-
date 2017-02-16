namespace BasicGirdView
{
    partial class searchF
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
            this.name = new System.Windows.Forms.Label();
            this.txsname = new System.Windows.Forms.TextBox();
            this.txsmajor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txsposition = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txsdeparment = new System.Windows.Forms.TextBox();
            this.department = new System.Windows.Forms.Label();
            this.btsfind = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(72, 41);
            this.name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(50, 20);
            this.name.TabIndex = 0;
            this.name.Text = "name";
            // 
            // txsname
            // 
            this.txsname.Location = new System.Drawing.Point(266, 38);
            this.txsname.Margin = new System.Windows.Forms.Padding(4);
            this.txsname.Name = "txsname";
            this.txsname.Size = new System.Drawing.Size(245, 26);
            this.txsname.TabIndex = 1;
            // 
            // txsmajor
            // 
            this.txsmajor.Location = new System.Drawing.Point(266, 269);
            this.txsmajor.Margin = new System.Windows.Forms.Padding(4);
            this.txsmajor.Name = "txsmajor";
            this.txsmajor.Size = new System.Drawing.Size(245, 26);
            this.txsmajor.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 272);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Major";
            // 
            // txsposition
            // 
            this.txsposition.Location = new System.Drawing.Point(266, 190);
            this.txsposition.Margin = new System.Windows.Forms.Padding(4);
            this.txsposition.Name = "txsposition";
            this.txsposition.Size = new System.Drawing.Size(245, 26);
            this.txsposition.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 194);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Position";
            // 
            // txsdeparment
            // 
            this.txsdeparment.Location = new System.Drawing.Point(266, 115);
            this.txsdeparment.Margin = new System.Windows.Forms.Padding(4);
            this.txsdeparment.Name = "txsdeparment";
            this.txsdeparment.Size = new System.Drawing.Size(245, 26);
            this.txsdeparment.TabIndex = 7;
            // 
            // department
            // 
            this.department.AutoSize = true;
            this.department.Location = new System.Drawing.Point(72, 119);
            this.department.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.department.Name = "department";
            this.department.Size = new System.Drawing.Size(97, 20);
            this.department.TabIndex = 6;
            this.department.Text = "Department";
            // 
            // btsfind
            // 
            this.btsfind.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btsfind.Location = new System.Drawing.Point(664, 59);
            this.btsfind.Margin = new System.Windows.Forms.Padding(4);
            this.btsfind.Name = "btsfind";
            this.btsfind.Size = new System.Drawing.Size(244, 236);
            this.btsfind.TabIndex = 8;
            this.btsfind.Text = "Find";
            this.btsfind.UseVisualStyleBackColor = true;
            this.btsfind.Click += new System.EventHandler(this.btsfind_Click);
            // 
            // searchF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 421);
            this.Controls.Add(this.btsfind);
            this.Controls.Add(this.txsdeparment);
            this.Controls.Add(this.department);
            this.Controls.Add(this.txsposition);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txsmajor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txsname);
            this.Controls.Add(this.name);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "searchF";
            this.Text = "searchF";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label name;
        private System.Windows.Forms.TextBox txsname;
        private System.Windows.Forms.TextBox txsmajor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txsposition;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txsdeparment;
        private System.Windows.Forms.Label department;
        private System.Windows.Forms.Button btsfind;
    }
}