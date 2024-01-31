using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace de2_BuiXuanTien_0206266.Views
{
    public partial class BuiXuanTien_0206266 : Form
    {
        public BuiXuanTien_0206266()
        {
            InitializeComponent();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        private void quảnLýLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shareds.ShareFunct.ShowFormInPanel(new Views.QuanLyLop(), panel1);
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            if (panel1.Controls.Count > 0)
            {
                panel1.Controls[0].Width = panel1.Width;
                panel1.Controls[0].Height = panel1.Height;
            }
        }

        private void quảnLýSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shareds.ShareFunct.ShowFormInPanel(new Views.QuanLySinhVien(), panel1);
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
        }
    }
}
