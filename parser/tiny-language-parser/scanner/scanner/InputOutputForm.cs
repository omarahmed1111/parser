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
    public partial class InputOutputForm : Form
    {
        int out_no;
        parser sc;
        StreamWriter writer;
        public InputOutputForm()
        {
            InitializeComponent();
            out_no = 1;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string f = textBox1.Text;
            
               
               
            sc = new parser(f);
            tree first = sc.parse("");
            if (!sc.error) {
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

        private void Btn_back_Click(object sender, EventArgs e)
        {
            SelectMode form = new SelectMode();
            form.Show();
            Hide();
        }
    }
}