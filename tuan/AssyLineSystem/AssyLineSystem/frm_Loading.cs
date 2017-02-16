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
    public partial class frm_Loading : Form
    {
        public frm_Loading()
        {
            InitializeComponent();
        }

        private void frm_Loading_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        int timer_ = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer_++;
            if (timer_ == 10)
            {
                timer1.Stop();
                this.Close();
            }
        }
    }
}
