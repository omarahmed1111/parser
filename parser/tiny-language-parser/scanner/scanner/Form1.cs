﻿using System;
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
        public bool check(tree cur)
        {

            if (cur.text == "") return true;
            bool c = false;
            for (int i = 0; i < cur.friends.Count; i++) c |= check(cur.friends[i]);
            for (int i = 0; i < cur.children.Count; i++) c |= check(cur.children[i]);
            return c;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string f = textBox1.Text;
            try
            {
                
                string file_text = File.ReadAllText(f+".txt");
                sc = new parser(file_text);
                tree first = sc.parse("");
                bool valid = check(first);
                if (!sc.error&&!valid)
                {
                    SyntaxTree syntaxTree = new SyntaxTree(first);
                    syntaxTree.Show();
                    Hide();

                }
                else
                {
                    label2.Text = "syntax error";
                    label2.ForeColor = Color.Red;
                }


            }
            catch
            {
                label2.Text = "file does not exist";
                label2.ForeColor = Color.Red;
                
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
