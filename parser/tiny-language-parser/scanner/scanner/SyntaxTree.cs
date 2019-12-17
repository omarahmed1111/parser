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
        public SyntaxTree(tree first)
        { 
            InitializeComponent();
            this.DoubleBuffered = true;
            this.AutoScroll = true;
            f = first;
        }
        
        public void drCircle(int x,int y,string text, Graphics e)
        {
            
            Pen myPen = new Pen(Color.Red);
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
            
            Pen myPen = new Pen(Color.Red);
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
            Graphics myGraphics = base.CreateGraphics();
            Pen p = new Pen(Color.Blue);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            e.DrawLine(p, new Point(x1, y1), new Point(x2, y2));
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
            for (int i = 0; i < (cur.friends).Count; i++)
            {
                drline(x+50+150*i,y+25,x+150+200*i,y+25,g);
                draw(cur.friends[i], x + 150+200*i, y,g);
            }
            if (cur.children.Count == 1)
            {
                drline(x + 25, y + 50, x + 25, y + 150,g);
                draw(cur.children[0], x , y + 150,g);
            }
            else if (cur.children.Count == 2)
            {
                drline(x + 25, y + 50, x - 75, y + 150,g);
                draw(cur.children[0], x - 100, y + 150,g);
                drline(x + 25, y + 50, x +125, y + 150,g);
                draw(cur.children[1], x + 100, y + 150,g);
            }
            else if (cur.children.Count == 3)
            {
                drline(x + 25, y + 50, x - 125, y + 150,g);
                draw(cur.children[0], x -150, y + 150,g);
                drline(x + 25, y + 50, x+25 , y + 150,g);
                draw(cur.children[1], x , y + 150,g);
                drline(x + 25, y + 50, x + 175, y + 150,g);
                draw(cur.children[2], x + 150, y + 150,g);

            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            this.AutoScroll = true;
            base.OnPaint(e);
            this.draw(f, 50, 20,e.Graphics);
        }
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
    }
}
