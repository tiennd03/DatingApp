using DemoControlNangCao02.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoControlNangCao02.Views
{
    public partial class DSSV_frm : Form
    {
        public DSSV_frm()
        {
            InitializeComponent();
        }

        DatabaseDataContext db = new DatabaseDataContext();

        //hàm này đã code hôm trước để tải dữ liệu lên dtg nhé. Giờ dùng lại thì chỉ gọi lại là xong. :D 
        //OK k?
        private void Load_Data()
        {
            var qr = db.tbl_SVs.Where(o => o.isDelete == null || o.isDelete == 0);
            if (qr.Any())
            {
                var dssv = qr.ToList();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dssv;
                //việc ẩn cột có thể xử lý bằng nhiều cách
                //1 là visible = false
                //2 là xóa bỏ
                //3 là chuẩn bị dữ liệu trước khi đổ lên dtg
                //ví dụ: chọn cách 1 là ẩn cột
                //sau khi đổ dữ liệu lên dtg, ta chọn cột cần ẩn và ẩn đi
                dataGridView1.Columns[2].Visible = false; //cột mật khẩu
                dataGridView1.Columns[3].Visible = false; //cột isDelete
                dataGridView1.Columns[4].Visible = false; //Cột delete time

                //cơ mà kiểm tra lại xem các code khác có bị ảnh hưởng không nhé. 
                //Vì có thể nó sẽ thay đổi index của các column/các cell
                //nên khi gọi thì có thể nó sẽ bị lỗi vì gọi vào index sai
            }
            else
            {
                MessageBox.Show("DSSV đang trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DSSV_frm_Load(object sender, EventArgs e)
        {
            //thay đổi kích thước form vừa với cha
            this.Width = this.Parent.Width;
            this.Height = this.Parent.Height;

            //Load data
            Load_Data();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (txt_mssv.ReadOnly)
            {
                //trong trường hợp txt_mssv.readonly = true thì là đang trong chức năng sửa/xóa => cần chuyển chế độ.

                if (MessageBox.Show("Bạn đang trong chế độ sửa/xóa. Bạn có muốn hủy tác vụ hiện tại không?","Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    //trường hợp người dùng chọn yes tức là họ muốn về chế độ thêm mới=>copy code thêm vào đây
                    //trước khi thực hiện thêm mới thì điều khiển control view
                    txt_mssv.ReadOnly = false;
                    btn_sua.Visible = false;
                    btn_xoa.Visible = false;
                }
                //trường hợp người dùng chọn no thì kệ.
            }
            else
            {
                //nếu txt_mssv.readonly = false thì đang trong chức năng thêm mới => code thêm mới bình thường chỗ này.
                try
                {
                    //lấy về các dữ liệu có trên form
                    var mssv = txt_mssv.Text;
                    var hoten = txt_hoten.Text;
                    var ngaysinh = dtp_ngaysinh.Value;
                    var gioitinh = cbx_gioitinh.Text;

                    if (!string.IsNullOrEmpty(mssv) && !string.IsNullOrEmpty(hoten))
                    {
                        //các trường dữ liệu bắt buộc đã được nhập
                        tbl_SV sv = new tbl_SV();
                        sv.MSSV = mssv;
                        sv.HoTen = hoten;
                        sv.NgaySinh = ngaysinh;
                        sv.GioiTinh = gioitinh;

                        db.tbl_SVs.InsertOnSubmit(sv);
                        db.SubmitChanges();

                        //load lại dữ liệu trên datagridview
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

                    //trong phần này nhé. Tìm xem có lệnh insert nào bị lỗi k thì xóa béng đi là đc.
                    //duyệt qua tất cả các lệnh insert này
                    foreach (var i in db.GetChangeSet().Inserts)
                    {
                        //kiểm tra xem nó có phải lệnh insert sv k
                        if (i.GetType().Name == "tbl_SV")
                        {
                            //nếu là lệnh insert sv thì xóa nó đi
                            db.tbl_SVs.DeleteOnSubmit((tbl_SV)i);
                        }
                    }
                    //thử nhé
                }
            }

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            //Bắt sự kiện onclick của btn_sua            
            try
            {
                //lấy về các dữ liệu trên form
                string mssv = txt_mssv.Text;
                string hoten = txt_hoten.Text;

                //kiểm tra xem có mssv và họ tên chưa?
                if (!string.IsNullOrEmpty(mssv) && !string.IsNullOrEmpty(hoten))
                {
                    //nếu đã có mssv và họ tên thì bắt đầu sửa
                    //chọn đối tượng cần sửa
                    //phần này tương tự, cần lọc ra sinh viên chưa bị xóa mềm
                    var qr = db.tbl_SVs.Where(o => o.MSSV == mssv && (o.isDelete == 0 || o.isDelete == null));
                    //kiểm tra xem có lấy được đối tượng thỏa mãn không?
                    if (qr.Any())
                    {
                        //trường hợp có đối tượng thỏa mãn thì đây là đối tượng sv duy nhất (do search theo primary key)
                        var sv = qr.SingleOrDefault();
                        //cập nhật các dữ liệu cho đối tượng sinh viên
                        sv.MSSV = mssv;
                        sv.HoTen = hoten;
                        sv.NgaySinh = dtp_ngaysinh.Value;
                        sv.GioiTinh = cbx_gioitinh.Text;

                        //cập nhật thay đổi vào db
                        db.SubmitChanges();

                        //load lại dữ liệu sau khi cập nhật thành công. Hàm load dữ liệu đã có nên gọi lại thôi.
                        Load_Data();

                        //sau khi cập nhật thành công thì thông báo cho người dùng
                        MessageBox.Show("Cập nhật thông tin sinh viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //đây là trường hợp không tìm thấy đối tượng cần sửa => thông báo không tìm thấy
                        MessageBox.Show("Không tìm thấy sinh viên có MSSV=" + mssv, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    //đây là trường hợp người dùng chưa nhập đủ dữ liệu bắt buộc => cảnh báo cho người dùng
                    MessageBox.Show("Vui lòng nhập đầy đủ MSSV và Họ tên", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                //trường hợp xảy ra lỗi trong quá trình cập nhật thì thông báo chi tiết lỗi
                MessageBox.Show("Có lỗi xảy ra trong quá trình cập nhật thông tin sinh viên. Chi tiết lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //lấy về hàng vừa được click trên dtg
            var crr_row = dataGridView1.Rows[e.RowIndex];

            if (crr_row != null)
            {
                var mssv = "";
                var hoten = "";
                var gioitinh = "";
                DateTime ngaysinh = DateTime.Now;

                if (crr_row.Cells[0].Value != null)
                {
                    mssv = crr_row.Cells[0].Value.ToString();
                }
                if (crr_row.Cells[1].Value != null)
                {
                    hoten = crr_row.Cells[1].Value.ToString();
                }
                if (crr_row.Cells[5].Value != null)
                {
                    gioitinh = crr_row.Cells[5].Value.ToString();
                }
                if (crr_row.Cells[6].Value != null)
                {
                    ngaysinh = (DateTime)crr_row.Cells[6].Value;
                }

                txt_mssv.Text = mssv;
                txt_hoten.Text = hoten;

                cbx_gioitinh.Text = gioitinh;
                dtp_ngaysinh.Value = ngaysinh;

                //điều khiển control trên form
                txt_mssv.ReadOnly = true;
                btn_sua.Visible = true;
                btn_xoa.Visible = true;
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            //messagebox cũng có thể sử dụng để confirm nhé. Check xem nó trả về yes or no là được này.
            if (MessageBox.Show("Bạn có thực sự muốn xóa dữ liệu này không? ", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                //nếu người dùng click vào yes thì thực hiện xóa. Không thì thôi
                //gọi là xóa nhưng nó là chức năng sửa => clone từ chức năng sửa sang thôi

                //Bắt sự kiện onclick của btn_xoa            
                try
                {
                    //lấy về các dữ liệu trên form
                    string mssv = txt_mssv.Text;
                    //string hoten = txt_hoten.Text; //cái này k cần vì m chỉ xóa thôi => bỏ đi

                    //kiểm tra xem có mssv và họ tên chưa?
                    if (!string.IsNullOrEmpty(mssv) /* && !string.IsNullOrEmpty(hoten) */) //phần check họ tên cũng k cần nên xóa đi
                    {
                        //nếu đã có mssv thì bắt đầu xóa
                        //chọn đối tượng cần xóa
                        //quên mất chỗ này phải lọc isdelete nữa nhé
                        var qr = db.tbl_SVs.Where(o => o.MSSV == mssv && (o.isDelete == 0 || o.isDelete == null));
                        //kiểm tra xem có lấy được đối tượng thỏa mãn không?
                        if (qr.Any())
                        {
                            //trường hợp có đối tượng thỏa mãn thì đây là đối tượng sv duy nhất (do search theo primary key)
                            var sv = qr.SingleOrDefault();

                            //sau khi chọn được đối tượng cần xóa thì cập nhật isDelete của nó thành 1 và ghi nhận thời gian xóa
                            sv.isDelete = 1;
                            sv.DeleteTime = DateTime.Now.ToString();

                            //toàn bộ phần bên dưới này giống với sửa nên k cần sửa code nữa
                            //cập nhật thay đổi vào db
                            db.SubmitChanges();

                            //load lại dữ liệu sau khi xóa thành công. Hàm load dữ liệu đã có nên gọi lại thôi.
                            Load_Data();

                            //sau khi xóa thành công thì thông báo cho người dùng
                            MessageBox.Show("Xóa sinh viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            //đây là trường hợp không tìm thấy đối tượng cần sửa => thông báo không tìm thấy
                            MessageBox.Show("Không tìm thấy sinh viên có MSSV=" + mssv, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        //đây là trường hợp người dùng chưa nhập đủ dữ liệu bắt buộc => cảnh báo cho người dùng
                        MessageBox.Show("Vui lòng nhập đầy đủ MSSV", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    //trường hợp xảy ra lỗi trong quá trình cập nhật thì thông báo chi tiết lỗi
                    MessageBox.Show("Có lỗi xảy ra trong quá trình xóa sinh viên. Chi tiết lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //paste toàn bộ code xóa vào trong if
        }

        private void txt_search_val_Enter(object sender, EventArgs e)
        {
            //kiểm tra xem phần nhập giá trị tìm kiếm có phải đang chứa text "Nhập giá trị tìm kiếm" không. Nếu đúng thì xóa trắng.
            if (txt_search_val.Text == "Nhập giá trị tìm kiếm")
            {
                txt_search_val.Text = "";
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            //bắt sự kiện onclick
            //lấy về giá trị tìm kiếm
            string search_val = txt_search_val.Text;
            //lấy về tiêu chí tìm kiếm
            string search_type = cbx_search_type.Text;

            //kiểm tra xem có dữ liệu tìm kiếm không
            if (string.IsNullOrEmpty(search_val))
            {
                //nếu không có giá trị tìm kiếm thì coi như load all => gọi hàm load data
                Load_Data();
            }
            else
            {
                if (search_type == "Chọn tiêu chí tìm kiếm")
                {
                    //nếu chưa nhập tiêu chí tìm kiếm thì yêu cầu nhập tiêu chí tìm kiếm
                    MessageBox.Show("Vui lòng chọn tiêu chí tìm kiếm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //trường hợp này là có đủ cả search_val và search_type rồi
                    //thực hiện tìm kiếm
                    IQueryable<tbl_SV> qr = null;
                    switch (search_type)
                    {
                        case "MSSV":
                            //tìm kiếm theo mssv 
                            qr = db.tbl_SVs.Where(o=> o.MSSV == search_val &&(o.isDelete == null || o.isDelete == 0));
                            break;
                        case "Họ tên":
                            //tìm kiếm theo hoten
                            qr = db.tbl_SVs.Where(o => o.HoTen.Contains(search_val) && (o.isDelete == null || o.isDelete == 0));
                            break;
                    }

                    //kiểm tra xem có dữ liệu tìm kiếm thỏa mãn k
                    if (qr.Any())
                    {
                        //nếu có dữ liệu thì đổ lên dtg
                        var dssv = qr.ToList();
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = dssv;
                    }
                    else
                    {
                        //nếu không có dữ liệu thì thông báo cho người dùng
                        MessageBox.Show("Không tìm thấy dữ liệu thỏa mãn điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }
}
