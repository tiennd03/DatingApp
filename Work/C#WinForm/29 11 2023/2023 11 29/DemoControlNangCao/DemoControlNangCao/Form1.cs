using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoControlNangCao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void solutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Create_Solution_frm f = new Form_Create_Solution_frm();
            Shared.SharedFunct.ShowFormInPanel(f, panel1);
            //f.ShowDialog();
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            panel1.Controls[0].Width = panel1.Width;
            panel1.Controls[0].Height = panel1.Height;
        }

        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            Shared.SharedFunct.ShowFormInPanel(f, panel1);
            //f.TopLevel = false;
            //panel1.Controls.Clear();
            //panel1.Controls.Add(f);
            //f.Show();
        }
    }
}
