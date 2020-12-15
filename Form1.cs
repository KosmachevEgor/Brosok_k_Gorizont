using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABA__
{
    public partial class Form1 : Form
    {
        double x = 0;
        double a;
        double t = 0;
        double V;
        double V0y, V0x, Hmax, Lmax, h0, Tmax,alpha;
        const double g = 9.8;

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            In();
            Calc();
            Out();
            timer1.Start();
            this.Paint += new PaintEventHandler(PictureBox1_Paint);
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = true;
            timer1.Interval = 50;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            In();
            Calc();
            Out();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen p1 = new Pen(System.Drawing.Color.Black);
            e.Graphics.DrawLine(p1, 0,400, 400, 400);
            e.Graphics.DrawLine(p1, 0, 400, 0, 0);
            e.Graphics.FillEllipse(Brushes.Red, new Rectangle((int)(50 * x), (int)(400 - 50 * h0), 5, 5));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            a = ((alpha * Math.PI) / 180);
            t += 0.01;
            x = (V * Math.Cos(a)) * t;
            h0 = (V * Math.Sin(a)) * t - g * t * t / 2;
            if(h0<0)
            {
                timer1.Stop();
            }
            Invalidate();
        }
        public void Calc()
        {
            V0x = V * Math.Cos(alpha * Math.PI / 180);
            V0y = V * Math.Sin(alpha * Math.PI / 180);
            Hmax = h0 + (V0y * V0y) / (2 * 9.81);
            Tmax = (V0y + Math.Sqrt(V0y * V0y + 2 * 9.81 * h0)) / 9.81;
            Lmax = V0x * Tmax;
        }
        public void In()
        {
            try
            {
                V = Convert.ToDouble(textBox1.Text);
                alpha = Convert.ToDouble(textBox2.Text);
                h0 = Convert.ToDouble(textBox3.Text);
            }
            catch
            {

            }
        }
        public void Out()
        {
            textBox4.Text = Convert.ToString(Hmax);
            textBox5.Text = Convert.ToString(Lmax);
            textBox6.Text = Convert.ToString(Tmax);
        }
    }
}
