using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoWindowsFormBasic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            string tk = txt_tk.Text;
            string mk = txt_mk.Text;

            if (!string.IsNullOrEmpty(tk) && !string.IsNullOrEmpty(mk))
            {
                //người dùng đã nhập đầy đủ tk và mk
                if (tk == "duongnh" && mk == "123456")
                {
                    MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại do sai tài khoản hoặc mật khẩu", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //người dùng nhập thiếu dữ liệu 
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu (thì tao mới xử lý nhé)", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //MessageBox.Show("Mày vừa click vào tao nhé!");
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            txt_tk.Text = "";
            txt_mk.Text = "";
        }

        private void txt_tk_Enter(object sender, EventArgs e)
        {
            txt_tk.BackColor = SystemColors.GradientActiveCaption;
            lbl_tk.ForeColor = Color.Blue;
        }

        private void txt_tk_Leave(object sender, EventArgs e)
        {
            txt_tk.BackColor = SystemColors.Window;
            lbl_tk.ForeColor = Color.Black;
        }

        private void txt_mk_Enter(object sender, EventArgs e)
        {
            txt_mk.BackColor = SystemColors.GradientActiveCaption;
            lbl_mk.ForeColor = Color.Blue;
        }

        private void txt_mk_Leave(object sender, EventArgs e)
        {
            txt_mk.BackColor = SystemColors.Window;
            lbl_mk.ForeColor = Color.Black;
        }
    }
}
