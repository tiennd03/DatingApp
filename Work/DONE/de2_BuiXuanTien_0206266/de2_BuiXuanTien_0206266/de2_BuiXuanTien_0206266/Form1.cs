using de2_BuiXuanTien_0206266.Models;
using de2_BuiXuanTien_0206266.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace de2_BuiXuanTien_0206266
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        DataBaseDataContext db = new DataBaseDataContext();
        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            try
            {
                string taikhoan = txt_taikhoan.Text;
                string matkhau = txt_matkhau.Text;
                if (!string.IsNullOrEmpty(taikhoan) && !string.IsNullOrEmpty(matkhau))
                {
                    var user = db.tbl_taikhoans.Where(u => u.tktaikhoan == taikhoan && u.tkmatkhau == matkhau).FirstOrDefault();
                    if (user != null)
                    {
                        MessageBox.Show("Đăng nhập thành công!");
                        this.Hide();
                        BuiXuanTien_0206266 formMain = new BuiXuanTien_0206266();
                        formMain.Show();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không tồn tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình đăng nhập. Chi tiết lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

