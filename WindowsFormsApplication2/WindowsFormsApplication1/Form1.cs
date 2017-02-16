using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication2;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        ConnectSQL conn = new ConnectSQL();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication2.Form1 TEST = new WindowsFormsApplication2.Form1();
            TEST.Show();
        }
        private form_load(){

        }
    }
}
