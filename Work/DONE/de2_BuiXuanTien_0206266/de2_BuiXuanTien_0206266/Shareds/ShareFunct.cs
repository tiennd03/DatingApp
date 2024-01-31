using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace de2_BuiXuanTien_0206266.Shareds
{
    internal class ShareFunct
    {
        public static void ShowFormInPanel(Form f, Panel p)
        {
            f.TopLevel = false;
            p.Controls.Clear();
            p.Controls.Add(f);
            f.Show();
        }
    }
}
