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
    public partial class SyntaxTree : Form
    {
        tree f;
        Panel p;
        List<Color> colors;
        int dep;
        public SyntaxTree(tree first)
        { 
            InitializeComponent();
            //this.DoubleBuffered = true;
            colors = new List<Color>();
            
            dep = 0;
            this.AutoScroll = true;
            f = first;
            pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint);
        }
        
        public void drCircle(int x,int y,string text, Graphics e)
        {
            Pen myPen;
            if (dep == 0)
            {
                myPen = new Pen(Color.Red);
            }
            else if (dep == 1)
            {
                myPen = new Pen(Color.Blue);
            }
            else if (dep == 2)
            {
                myPen = new Pen(Color.Green);
            }
            else if (dep == 3)
            {
                myPen = new Pen(Color.Orange);
            }
            else if (dep == 4)
            {
                myPen = new Pen(Color.Tomato);
            }
            else
            {
                myPen = new Pen(Color.Violet);
            }
            
            
            Pen mytextPen = new Pen(Color.Green);
            Font drawFont = new Font("Arial", 8);
            SolidBrush mySolidBrush = new SolidBrush(Color.Red);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            e.DrawEllipse(myPen, x, y, 50, 50);
            StringFormat drawFormat = new StringFormat();
            e.DrawString(text, drawFont, drawBrush, x + 17, y + 10, drawFormat);
            
        }
        public void drrect(int x, int y, string text, Graphics e)
        {
            Pen myPen;
            if (dep == 0)
            {
                myPen = new Pen(Color.Red);
            }
            else if (dep == 1)
            {
                myPen = new Pen(Color.Blue);
            }
            else if (dep == 2)
            {
                myPen = new Pen(Color.Green);
            }
            else if (dep == 3)
            {
                myPen = new Pen(Color.Orange);
            }
            else if (dep == 4)
            {
                myPen = new Pen(Color.Tomato);
            }
            else
            {
                myPen = new Pen(Color.Violet);
            }

            
            Pen mytextPen = new Pen(Color.Green);
            Font drawFont = new Font("Arial", 8);
            SolidBrush mySolidBrush = new SolidBrush(Color.Red);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            e.DrawRectangle(myPen, x, y, 50, 50);
            StringFormat drawFormat = new StringFormat();
            e.DrawString(text, drawFont, drawBrush, x + 5, y + 10, drawFormat);
        }
        public void drline(int x1,int y1,int x2,int y2, Graphics e)
        {
            Pen myPen;
            if (dep == 0)
            {
                myPen = new Pen(Color.Red);
            }
            else if (dep == 1)
            {
                myPen = new Pen(Color.Blue);
            }
            else if (dep == 2)
            {
                myPen = new Pen(Color.Green);
            }
            else if (dep == 3)
            {
                myPen = new Pen(Color.Orange);
            }
            else if (dep == 4)
            {
                myPen = new Pen(Color.Tomato);
            }
            else
            {
                myPen = new Pen(Color.Violet);
            }
            Graphics myGraphics = base.CreateGraphics();
            
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            e.DrawLine(myPen, new Point(x1, y1), new Point(x2, y2));
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }
        void draw(tree cur, int x, int y,Graphics g)
        {
            
            if (cur.type)
            {
                drCircle(x, y, cur.text,g);
            }
            else
            {
                drrect(x, y, cur.text,g);
            }
            int tempx = x,tempy=y;
            for (int i = 0; i < (cur.friends).Count; i++)
            {

                drline(tempx+50,tempy+25,tempx+400,tempy+75,g);
                draw(cur.friends[i],tempx+400, tempy+50,g);
                tempx += 400; tempy += 50;
            }
            if (cur.children.Count == 1)
            {
                dep++;
                drline(x + 25, y + 50, x + 25, y + 220,g);
                draw(cur.children[0], x , y + 220,g);
                dep--;
            }
            else if (cur.children.Count == 2)
            {
                dep++;
                drline(x + 25, y + 50, x - 100, y + 220,g);
                draw(cur.children[0], x - 125, y + 220,g);
                drline(x + 25, y + 50, x + 150, y + 220, g);
                draw(cur.children[1], x+125, y + 220, g);
                dep--;
            }
            else if (cur.children.Count == 3)
            {
                dep++;
                drline(x + 25, y + 50, x - 125, y + 220,g);
                draw(cur.children[0], x -150, y + 220,g);
                drline(x + 25, y + 50, x + 25, y + 220, g);
                draw(cur.children[1], x, y + 220, g);
                drline(x + 25, y + 50, x + 175, y + 220,g);
                draw(cur.children[2], x + 150, y + 220,g);
                dep--;
            }
            
        }
        void SyntaxTree_Paint(object sender, PaintEventArgs e)
        {
            draw(f, 50, 20, e.Graphics);
        }
        /*
        protected override void OnPaint(PaintEventArgs e)
        {
            
            this.AutoScroll = true;
            base.OnPaint(e);
            this.draw(f, 50, 20,e.Graphics);
            
        }
        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);
            this.Validate();
        }
        */
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.Style |= 0x00200000; // WS_VSCROLL
                return cp;
            }
        }

        private void SyntaxTree_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SelectMode b = new SelectMode();
            b.Show();
            Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
            draw(f, 50, 20, e.Graphics);
        }
    }
}
