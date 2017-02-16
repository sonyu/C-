using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Manage_AssyLine
{
    public partial class MForm : Form
    {
        int HeightScreen = Screen.PrimaryScreen.Bounds.Height;
        int WidthScreen = Screen.PrimaryScreen.Bounds.Width;
        ConnectSQL conn = new ConnectSQL();
        public MForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            //FormBorderStyle = FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(WidthScreen, HeightScreen);
        }
        private void main_form_MaximumSizeChanged(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                int newh, neww, fontsize, child_w, child_h;

                newh = HeightScreen * c.Size.Height / 768;
                neww = WidthScreen * c.Size.Width / 1024;
                fontsize = Convert.ToInt32(c.Font.Size) * WidthScreen / 1024;
                c.Size = new Size(neww, newh);
                c.Location = new Point(c.Location.X * WidthScreen / 1024, c.Location.Y * HeightScreen / 768);
                c.Font = new Font(c.Font.FontFamily, fontsize);
                // MessageBox.Show("x =" + c.Location.X + "y = " + c.Location.Y + "dx = " + c.Size.Width + " dy = " + c.Size.Height);
                if (c.Controls.Count > 0)
                {

                    foreach (Control child_c in c.Controls)
                    {
                        // MessageBox.Show("x =" + child_c.Location.X + "y = " + child_c.Location.Y + "dx = " + child_c.Size.Width + " dy = " + child_c.Size.Height);
                        child_h = HeightScreen * child_c.Size.Height / 768;
                        child_w = WidthScreen * child_c.Size.Width / 1024;
                        child_c.Size = new Size(child_w, child_h);
                        child_c.Location = new Point(child_c.Location.X * WidthScreen / 1024, child_c.Location.Y * HeightScreen / 768);
                        //MessageBox.Show("x =" + child_c.Location.X + "y = " + child_c.Location.Y + "dx = " + child_c.Size.Width + " dy = " + child_c.Size.Height);
                    }
                }
            }

        }

        private void MForm_MaximumSizeChanged(object sender, EventArgs e)
        {

            foreach (Control c in this.Controls)
            {
                int newh, neww, fontsize, child_w, child_h;

                newh = HeightScreen * c.Size.Height / 768;
                neww = WidthScreen * c.Size.Width / 1024;
                fontsize = Convert.ToInt32(c.Font.Size) * WidthScreen / 1024;
                c.Size = new Size(neww, newh);
                c.Location = new Point(c.Location.X * WidthScreen / 1024, c.Location.Y * HeightScreen / 768);
                c.Font = new Font(c.Font.FontFamily, fontsize);
                // MessageBox.Show("x =" + c.Location.X + "y = " + c.Location.Y + "dx = " + c.Size.Width + " dy = " + c.Size.Height);
                if (c.Controls.Count > 0)
                {

                    foreach (Control child_c in c.Controls)
                    {
                        // MessageBox.Show("x =" + child_c.Location.X + "y = " + child_c.Location.Y + "dx = " + child_c.Size.Width + " dy = " + child_c.Size.Height);
                        child_h = HeightScreen * child_c.Size.Height / 768;
                        child_w = WidthScreen * child_c.Size.Width / 1024;
                        child_c.Size = new Size(child_w, child_h);
                        child_c.Location = new Point(child_c.Location.X * WidthScreen / 1024, child_c.Location.Y * HeightScreen / 768);
                        //MessageBox.Show("x =" + child_c.Location.X + "y = " + child_c.Location.Y + "dx = " + child_c.Size.Width + " dy = " + child_c.Size.Height);
                    }
                }
            }
        }
    }
}
