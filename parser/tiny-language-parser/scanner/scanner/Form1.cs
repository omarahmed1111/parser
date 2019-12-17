using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace scanner
{
    public partial class Form1 : Form
    {
        int out_no;
        parser sc;
        StreamWriter writer;
        public Form1()
        {
            InitializeComponent();
            out_no = 1;
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string f = textBox1.Text;
            try
            {
                string output = f + "_output.txt";
                writer = new StreamWriter(output);
                string file_text = File.ReadAllText(f+".txt");
                sc = new parser(file_text);
                int done=0;
                if (done == 0)
                {
                    label2.Text = "success";
                    label2.ForeColor = Color.Green;
                    out_no++;
                }
                else
                {
                    label2.Text = "syntax error";
                    label2.ForeColor = Color.Red;
                }
                writer.Close();
               

            }
            catch
            {
                label2.Text = "file does not exist";
                label2.ForeColor = Color.Red;
                writer.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Btn_back_Click(object sender, EventArgs e)
        {
            SelectMode form = new SelectMode();
            form.Show();
            Hide();
        }
    }
}
