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
    public partial class Output : Form
    {
        public Output(List<string> t, List<string> v,int k)
        {
            InitializeComponent();
            Label old_lb = new Label();
            old_lb = this.lbl_p1;
            int y = 60;
            for (int i = 0; i < k; i++)
            {
                Label new_lb = new Label();
                new_lb.Size = old_lb.Size;
                new_lb.Visible = true;
                new_lb.Location = new Point(old_lb.Location.X, old_lb.Location.Y + y - 60);
                new_lb.Text = t[i];
                new_lb.Font = old_lb.Font;
                new_lb.BackColor = old_lb.BackColor;
                new_lb.TextAlign = old_lb.TextAlign;
                new_lb.Visible = true;
                this.groupBox_processDetail.Controls.Add(new_lb);
                y = y + 60;
            }


            old_lb = new Label();
            old_lb = this.label2;
            y = 60;
            for (int i = 0; i < k; i++)
            {
                Label new_lb = new Label();
                new_lb.Size = old_lb.Size;
                new_lb.AutoSize = true;
                new_lb.Location = new Point(old_lb.Location.X, old_lb.Location.Y + y - 60);
                new_lb.Visible = true;
                new_lb.Text = v[i];
                new_lb.Font = old_lb.Font;
                new_lb.BackColor = old_lb.BackColor;
                new_lb.TextAlign = old_lb.TextAlign;
                new_lb.Visible = true;
                this.groupBox_processDetail.Controls.Add(new_lb);
                y = y + 60;
            }
        }

        private void Btn_back_Click(object sender, EventArgs e)
        {
            SelectMode form = new SelectMode();
            form.Show();
            Hide();
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
