using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AssyLineSystem
{
    public partial class frm_Cal : Form
    {
        public frm_Cal()
        {
            InitializeComponent();
        }
        public string result;
        public int x, y;
        private void frm_Cal_Load(object sender, EventArgs e)
        {
            this.Location = new Point(x, y);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            result = txtView.Text;
            this.Close();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtView.Text += btn1.Text;
            txtView.Select(txtView.TextLength, 0);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtView.Text += btn2.Text;
            txtView.Select(txtView.TextLength, 0);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtView.Text += btn3.Text;
            txtView.Select(txtView.TextLength, 0);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtView.Text += btn4.Text;
            txtView.Select(txtView.TextLength, 0);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtView.Text += btn5.Text;
            txtView.Select(txtView.TextLength, 0);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtView.Text += btn6.Text;
            txtView.Select(txtView.TextLength, 0);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtView.Text += btn7.Text;
            txtView.Select(txtView.TextLength, 0);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtView.Text += btn8.Text;
            txtView.Select(txtView.TextLength, 0);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtView.Text += btn9.Text;
            txtView.Select(txtView.TextLength, 0);
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtView.Text += btn0.Text;
            txtView.Select(txtView.TextLength, 0);
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            if (txtView.Text.Length > 0)
            {
                txtView.Text = txtView.Text.Remove(txtView.Text.Length - 1, 1);
            }
        }
    }
}
