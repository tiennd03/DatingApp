using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        Button btn01 = new Button();
        Button btn02 = new Button();

        private void Form2_Load(object sender, EventArgs e)
        {
            btn01.Location = new Point(200, 200);
            btn01.BackColor = Color.Red;
            btn01.Text = "";
            btn01.Width = 50;
            btn01.Height  = 50;
            this.Controls.Add(btn01);

            btn02.Location = new Point(50, this.Height - 100);
            btn02.Text = "Run";
            btn02.Height = 50;
            btn02.Click += new EventHandler(this.btn_Run_Click);
            this.Controls.Add(btn02);

            t.Interval = 100;
            t.Tick += new EventHandler(timer_event);
        }

        public int delta_X = 30;
        public int delta_Y = -30;
        public void btn_Run_Click(object sender, EventArgs e)
        {
            t.Start();
        }

        public void timer_event(object sender, EventArgs e)
        {
            if (btn01.Location.X < 0 || btn01.Location.X + delta_X >= this.Width)
            {
                delta_X = -delta_X;
            }

            if (btn01.Location.Y < 0 || btn01.Location.Y + delta_Y >= this.Height)
            {
                delta_Y = -delta_Y;
            }
            btn01.Location = new Point(btn01.Location.X + delta_X, btn01.Location.Y + delta_Y);
        }

        Timer t = new Timer();

    }
}
