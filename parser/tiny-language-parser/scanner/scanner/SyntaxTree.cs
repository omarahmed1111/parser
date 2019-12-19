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
        public int max_level = 0;
        Panel p;
        List<Color> colors;
        int dep;
        int moo = 0;
        List<Point> drawn;
        List<int> max_x;
        List<int> maxato;
        List<int> TTT;
        Pen penused()
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
            return myPen;
        }
        public SyntaxTree(tree first)
        { 
            InitializeComponent();
            this.DoubleBuffered = true;
            colors = new List<Color>();
            drawn = new List<Point>();
            max_x = new List<int>();
            maxato = new List<int>();
            TTT = new List<int>();
            for (int i = 0; i < 200; i++) {
                max_x.Add(50);
                maxato.Add(0);
                TTT.Add(0);
            }
            dep = 0;
            //this.AutoScroll = true;
            f = first;
            depth_est(f,1);
            hiii();
            pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint);
           
        }
        
        public void drCircle(int x,int y,string text, Graphics e)
        {
            Pen myPen = penused();
            Pen mytextPen = new Pen(Color.Green);
            Font drawFont = new Font("Arial", 8);
            SolidBrush mySolidBrush = new SolidBrush(Color.Red);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            e.DrawEllipse(myPen, x, y, 50, 50);
            StringFormat drawFormat = new StringFormat();
            e.DrawString(text, drawFont, drawBrush, x + 5, y + 10, drawFormat);
            
        }
        public void drrect(int x, int y, string text, Graphics e)
        {
            Pen myPen = penused();
            
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
            Pen myPen = penused();
            Graphics myGraphics = base.CreateGraphics();
            
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            e.DrawLine(myPen, new Point(x1, y1), new Point(x2, y2));
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }

        public void depth_est(tree cur,int l) {
            cur.level = l;
            if (max_level < l) {
                max_level = l;
            }
            maxato[l]++;
            cur.y = l * 110 -20 ;
            for (int i = 0; i < cur.friends.Count(); i++) {
                depth_est(cur.friends[i], l);
            }
            for (int i = 0; i < cur.children.Count(); i++)
            {
                depth_est(cur.children[i], l+1);
            }
        }

        public void hiii()
        {
            for (int i = 0; i <= max_level; i++)
            {
                if (maxato[i] > moo)
                {
                    moo = maxato[i];
                }
            }
            moo = 100 * moo;
            for (int i = 1; i <= max_level; i++)
            {
                TTT[i] = moo / (maxato[i]);
            }
        }

        void draw2(tree cur, Graphics g,bool v) {
            max_x[cur.level] = max_x[cur.level] + TTT[cur.level];
            cur.x = max_x[cur.level];
            if (v)
            {
                v = false;
                cur.x = 100;
                cur.y = 100;
            }
            if (cur.type)
            {
                drCircle(cur.x, cur.y, cur.text, g);
            }
            else
            {
                drrect(cur.x, cur.y, cur.text, g);
            }
            for (int i = 0; i < (cur.children).Count; i++)
            {
                draw2(cur.children[i], g,v);
                drline(cur.x + 25, cur.y + 50, cur.children[i].x + 25, cur.children[i].y, g);
            }
            for (int i = 0; i < (cur.friends).Count; i++)
            {
                draw2(cur.friends[i], g,v);
                if (i == 0)
                {
                    drline(cur.x + 50, cur.y + 25, cur.friends[i].x, cur.y + 25, g);
                }
                else {
                    drline(cur.friends[i-1].x + 50, cur.y + 25, cur.friends[i].x, cur.y + 25, g);
                }
            }
        }

        void SyntaxTree_Paint(object sender, PaintEventArgs e)
        {
            ////pictureBox1_Paint(sender, e);

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
            bool v = true;
            draw2(f, e.Graphics,v);
            moo = 0;
            max_x = new List<int>();
            maxato = new List<int>();
            TTT = new List<int>();
            for (int i = 0; i < 200; i++)
            {
                max_x.Add(50);
                maxato.Add(0);
                TTT.Add(0);
            }

            //this.AutoScroll = true;

            depth_est(f, 1);
            hiii();
            //draw(f, 100, 100, e.Graphics);
        }
    }
}
