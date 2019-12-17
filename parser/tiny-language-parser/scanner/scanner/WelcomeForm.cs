using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scanner
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
            Graphics myGraphics = base.CreateGraphics();
            Pen myPen = new Pen(Color.Red);
            SolidBrush mySolidBrush = new SolidBrush(Color.Red);
            myGraphics.DrawEllipse(myPen, 10, 10, 150, 150);
        }

        private void Lbl_projectName_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Btn_next_Click(object sender, EventArgs e)
        {
           
            SelectMode form = new SelectMode();
            form.Show();
            Hide();
        }
    }
}
