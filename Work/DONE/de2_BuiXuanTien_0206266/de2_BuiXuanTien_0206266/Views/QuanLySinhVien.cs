using de2_BuiXuanTien_0206266.Models;
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
    public partial class QuanLySinhVien : Form
    {
        public QuanLySinhVien()
        {
            InitializeComponent();
        }
        DataBaseDataContext db = new DataBaseDataContext();
        private void Load_Data()
        {
            try
            {
                var qr = from item in db.tbl_sinhviens select item;
                if (qr.Any())
                {
                    var dssv = qr.ToList();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dssv;
                }
                else
                {
                    MessageBox.Show("DSSV đang trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình tải danh sách sinh viên. Chi tiết lỗi: " + ex.Message);
            }
        }

        private void QuanLySinhVien_Load(object sender, EventArgs e)
        {
            this.Width = this.Parent.Width;
            this.Height = this.Parent.Height;
            Load_Data();
        }

        private void btn_themsinhvien_Click(object sender, EventArgs e)
        {
            if (txt_mssv.ReadOnly)
            {
                if (MessageBox.Show("Bạn đang trong chế độ sửa/xóa. Bạn có muốn hủy tác vụ hiện tại không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    txt_mssv.ReadOnly = false;
                    btn_suasinhvien.Visible = false;
                    btn_xoasinhvien.Visible = false;
                }
            }
            else
            {
                try
                {
                    var mssv = txt_mssv.Text;
                    var hoten = txt_hoten.Text;
                    var ngaysinh = dtp_ngaysinh.Value;
                    var gioitinh = cbx_gioitinh.Text;
                    var quequan = txt_quequan.Text;
                    var lop = txt_lop.Text;

                    if (!string.IsNullOrEmpty(mssv) && !string.IsNullOrEmpty(hoten))
                    {
                        tbl_sinhvien sv = new tbl_sinhvien();
                        if (gioitinh == "Nam") sv.svgioitinh = 1;
                        else sv.svgioitinh = 0;
                        sv.svma = mssv;
                        sv.svten = hoten;
                        sv.svngaysinh = ngaysinh;
                        sv.svquequan = quequan;
                        sv.lqlma = lop;

                        db.tbl_sinhviens.InsertOnSubmit(sv);
                        db.SubmitChanges();
                        Load_Data();
                        MessageBox.Show("Thêm mới sinh viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(mssv))
                        {
                            MessageBox.Show("Vui lòng nhập MSSV", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txt_mssv.Focus();
                            txt_mssv.BackColor = Color.Yellow;
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(hoten))
                            {
                                MessageBox.Show("Vui lòng nhập Họ tên", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txt_hoten.Focus();
                                txt_hoten.BackColor = Color.Yellow;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra trong quá trình thêm mới sinh viên. Chi tiết lỗi: " + ex.Message);
                    foreach (var i in db.GetChangeSet().Inserts)
                    {
                        if (i.GetType().Name == "tbl_SV")
                        {
                            db.tbl_sinhviens.DeleteOnSubmit((tbl_sinhvien)i);
                        }
                    }
                }
            }

        }
    }
}