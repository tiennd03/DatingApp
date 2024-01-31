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
    public partial class Form_Create_Solution_frm : Form
    {
        public Form_Create_Solution_frm()
        {
            InitializeComponent();
        }

        private void Form_Create_Solution_frm_Load(object sender, EventArgs e)
        {
            this.Width = this.Parent.Width;
            this.Height = this.Parent.Height;
        }
    }
}
