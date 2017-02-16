namespace Manage_AssyLine
{
    partial class pop_form
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.line_cb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.emp_tx = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.shift_cb = new System.Windows.Forms.ComboBox();
            this.start_bt = new System.Windows.Forms.Button();
            this.fresh_bt = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.result_bl = new System.Windows.Forms.Label();
            this.total_tx = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ng_tx = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ok_tx = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.code_check_tx = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.enter_code_tx = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.save_bt = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 62);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(864, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 42);
            this.button1.TabIndex = 3;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(413, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "POP SYSTEM";
            // 
            // line_cb
            // 
            this.line_cb.DisplayMember = "P";
            this.line_cb.FormattingEnabled = true;
            this.line_cb.Items.AddRange(new object[] {
            "Line 1",
            "Line 2",
            "Line 3",
            "Line 4",
            "Line 5",
            "Line 6",
            "Line 7"});
            this.line_cb.Location = new System.Drawing.Point(150, 93);
            this.line_cb.Name = "line_cb";
            this.line_cb.Size = new System.Drawing.Size(156, 21);
            this.line_cb.TabIndex = 1;
            this.line_cb.ValueMember = "P150001,P150002,P150003,P150004";
            this.line_cb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.line_cb_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Line number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Employee Name";
            // 
            // emp_tx
            // 
            this.emp_tx.Location = new System.Drawing.Point(150, 126);
            this.emp_tx.Name = "emp_tx";
            this.emp_tx.Size = new System.Drawing.Size(156, 20);
            this.emp_tx.TabIndex = 4;
            this.emp_tx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.emp_tx_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Shift";
            // 
            // shift_cb
            // 
            this.shift_cb.FormattingEnabled = true;
            this.shift_cb.Items.AddRange(new object[] {
            "DT",
            "NT",
            ""});
            this.shift_cb.Location = new System.Drawing.Point(150, 162);
            this.shift_cb.Name = "shift_cb";
            this.shift_cb.Size = new System.Drawing.Size(156, 21);
            this.shift_cb.TabIndex = 6;
            this.shift_cb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.shift_cb_KeyDown);
            // 
            // start_bt
            // 
            this.start_bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_bt.Location = new System.Drawing.Point(584, 109);
            this.start_bt.Name = "start_bt";
            this.start_bt.Size = new System.Drawing.Size(122, 90);
            this.start_bt.TabIndex = 7;
            this.start_bt.Text = "Start";
            this.start_bt.UseVisualStyleBackColor = true;
            this.start_bt.Click += new System.EventHandler(this.button2_Click);
            // 
            // fresh_bt
            // 
            this.fresh_bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fresh_bt.Location = new System.Drawing.Point(373, 109);
            this.fresh_bt.Name = "fresh_bt";
            this.fresh_bt.Size = new System.Drawing.Size(122, 90);
            this.fresh_bt.TabIndex = 9;
            this.fresh_bt.Text = "New";
            this.fresh_bt.UseVisualStyleBackColor = true;
            this.fresh_bt.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.result_bl);
            this.panel2.Controls.Add(this.total_tx);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.ng_tx);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.ok_tx);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.code_check_tx);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(3, 251);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1024, 475);
            this.panel2.TabIndex = 10;
            // 
            // result_bl
            // 
            this.result_bl.AutoSize = true;
            this.result_bl.BackColor = System.Drawing.Color.PapayaWhip;
            this.result_bl.Font = new System.Drawing.Font("Microsoft Sans Serif", 130F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.result_bl.Location = new System.Drawing.Point(501, 162);
            this.result_bl.Name = "result_bl";
            this.result_bl.Size = new System.Drawing.Size(0, 198);
            this.result_bl.TabIndex = 18;
            this.result_bl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // total_tx
            // 
            this.total_tx.BackColor = System.Drawing.Color.PapayaWhip;
            this.total_tx.Enabled = false;
            this.total_tx.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.total_tx.Location = new System.Drawing.Point(290, 334);
            this.total_tx.Name = "total_tx";
            this.total_tx.Size = new System.Drawing.Size(73, 38);
            this.total_tx.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(142, 334);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 31);
            this.label8.TabIndex = 16;
            this.label8.Text = "TOTAL";
            // 
            // ng_tx
            // 
            this.ng_tx.BackColor = System.Drawing.Color.PapayaWhip;
            this.ng_tx.Enabled = false;
            this.ng_tx.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ng_tx.Location = new System.Drawing.Point(290, 241);
            this.ng_tx.Name = "ng_tx";
            this.ng_tx.Size = new System.Drawing.Size(73, 38);
            this.ng_tx.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(189, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 31);
            this.label7.TabIndex = 14;
            this.label7.Text = "NG";
            // 
            // ok_tx
            // 
            this.ok_tx.BackColor = System.Drawing.Color.PapayaWhip;
            this.ok_tx.Enabled = false;
            this.ok_tx.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ok_tx.Location = new System.Drawing.Point(290, 147);
            this.ok_tx.Name = "ok_tx";
            this.ok_tx.ReadOnly = true;
            this.ok_tx.Size = new System.Drawing.Size(73, 38);
            this.ok_tx.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(191, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 31);
            this.label6.TabIndex = 12;
            this.label6.Text = "OK";
            // 
            // code_check_tx
            // 
            this.code_check_tx.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.code_check_tx.Enabled = false;
            this.code_check_tx.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.code_check_tx.Location = new System.Drawing.Point(290, 60);
            this.code_check_tx.Name = "code_check_tx";
            this.code_check_tx.Size = new System.Drawing.Size(528, 38);
            this.code_check_tx.TabIndex = 11;
            this.code_check_tx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.code_check_tx_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(86, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(196, 31);
            this.label5.TabIndex = 0;
            this.label5.Text = "CODE CHECK";
            // 
            // enter_code_tx
            // 
            this.enter_code_tx.Location = new System.Drawing.Point(150, 201);
            this.enter_code_tx.Name = "enter_code_tx";
            this.enter_code_tx.Size = new System.Drawing.Size(156, 20);
            this.enter_code_tx.TabIndex = 12;
            this.enter_code_tx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_code_tx_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(48, 204);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Enter Code";
            // 
            // save_bt
            // 
            this.save_bt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_bt.Location = new System.Drawing.Point(801, 109);
            this.save_bt.Name = "save_bt";
            this.save_bt.Size = new System.Drawing.Size(122, 90);
            this.save_bt.TabIndex = 13;
            this.save_bt.Text = "Save";
            this.save_bt.UseVisualStyleBackColor = true;
            this.save_bt.Click += new System.EventHandler(this.save_bt_Click);
            // 
            // pop_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.save_bt);
            this.Controls.Add(this.enter_code_tx);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.fresh_bt);
            this.Controls.Add(this.start_bt);
            this.Controls.Add(this.shift_cb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.emp_tx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.line_cb);
            this.Controls.Add(this.panel1);
            this.Name = "pop_form";
            this.Text = "POP form";
            this.MaximumSizeChanged += new System.EventHandler(this.pop_form_MaximumSizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox line_cb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox emp_tx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox shift_cb;
        private System.Windows.Forms.Button start_bt;
        private System.Windows.Forms.Button fresh_bt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox code_check_tx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox total_tx;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ng_tx;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ok_tx;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox enter_code_tx;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button save_bt;
        private System.Windows.Forms.Label result_bl;
    }
}