using DemoASPNetBasic.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoASPNetBasic.Controllers
{
    public class QLSVController : Controller
    {

        public DatabaseDataContext db = new DatabaseDataContext();

        // GET: QLSV
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.Session["is_login"] != null)
            {
                if ((bool)Session["is_login"])
                {
                    //trường hợp đã login rồi
                    return View();
                }
            }
            return RedirectToAction("DangNhap","TaiKhoan");
        }

        public ActionResult ThemSV()
        {
            if(Shareds.Utils.check_login(Session))
            {
                return View();
            }                
            return RedirectToAction("DangNhap", "TaiKhoan");
        }

        public ActionResult SuaSV()
        {
            //Kiểm tra đăng nhập trước khi cho phép truy cập vào trang SuaSV
            if (Shareds.Utils.check_login(Session))
            {
                return View();
            }
            return RedirectToAction("DangNhap", "TaiKhoan");
        }
        public ActionResult DSSV()
        {
            //Kiểm tra đăng nhập trước khi cho phép truy cập vào trang SuaSV
            if (Shareds.Utils.check_login(Session))
            {
                return View();
            }
            return RedirectToAction("DangNhap", "TaiKhoan");
        }

        public string Add()
        {
            //ví dụ về linq to sql
            //var qr = db.tbl_SVs; //select * from tbl_SV
            //var qr1 = db.tbl_SVs.Where(o => o.MSSV == "1234"); //select * from tbl_SV where mssv == "1234"

            string mssv = Request["txt_mssv"];
            string hoten = Request["txt_hoten"];
            string mk = Request["txt_mk"];
            string nhaclaimk = Request["txt_nhaclaimk"];

            //validate input
            if (!string.IsNullOrEmpty(mssv) && !string.IsNullOrEmpty(hoten) && !string.IsNullOrEmpty(mk) && !string.IsNullOrEmpty(nhaclaimk))
            {
                if (mk == nhaclaimk)
                {
                    try
                    {
                        //trường hợp muốn insert
                        tbl_SV sv = new tbl_SV();
                        sv.MSSV = mssv;
                        sv.HoTen = hoten;
                        sv.MatKhau = mk;

                        db.tbl_SVs.InsertOnSubmit(sv);
                        db.SubmitChanges();

                        return "Thêm mới sinh viên thành công";
                    }
                    catch (Exception ex)
                    {
                        return "Thêm mới sinh viên thất bại. Chi tiết lỗi: " + ex.Message;
                    }
                    //ok
                    //return "MSSV: " + mssv + "; Họ tên: " + hoten + "; Mật khẩu: " + mk;
                }
                else
                {
                    //trường hợp dữ liệu input không hợp lệ
                    return "Mật khẩu nhắc lại không khớp. Vui lòng kiểm tra lại";
                }
            }
            else
            {
                return "Mày chơi tao không được đâu";
            }


        }

        public string get_SV_Info()
        {
            string mssv = Request["mssv"];

            //validate input
            if (!string.IsNullOrEmpty(mssv))
            {
                try
                {
                    //trường hợp lấy được mssv từ trang suaSV
                    var qr = db.tbl_SVs.Where(o => o.MSSV == mssv);
                    if (qr.Any())
                    {
                        //trường hợp có dữ liệu trả về - tìm thấy sv có mssv theo yêu cầu
                        var sv_obj = qr.SingleOrDefault();

                        return JsonConvert.SerializeObject(sv_obj);
                    }
                    else
                    {
                        return "Không tìm thấy SV có MSSV=" + mssv;
                    }
                    
                }
                catch (Exception ex)
                {
                    return "Lấy thông tin sinh viên thất bại. Chi tiết lỗi: " + ex.Message;
                }
                //ok
                //return "MSSV: " + mssv + "; Họ tên: " + hoten + "; Mật khẩu: " + mk;

            }
            else
            {
                return "Vui lòng chọn sinh viên để chỉnh sửa";
            }
        }

        public string get_SV_Edit()
        {
            string mssv = Request["id"];

            //validate input
            if (!string.IsNullOrEmpty(mssv))
            {
                try
                {
                    //trường hợp muốn update
                    var qrs = db.tbl_SVs.Where(o => o.MSSV == mssv);
                    if (qrs.Any())
                    {
                        //có trả về bản ghi.
                        tbl_SV sv = qrs.SingleOrDefault();

                        return JsonConvert.SerializeObject(sv);
                    }
                    else
                    {
                        return "KHÔNG tìm thấy sv có mssv = " + mssv;
                    }
                }
                catch (Exception ex)
                {
                    return "Cập nhật thông tin sinh viên thất bại. Chi tiết lỗi: " + ex.Message;
                }
            }
            else
            {
                return "Mày chơi tao không được đâu";
            }
        }

        public string Edit()
        {
            //ví dụ về linq to sql
            //var qr = db.tbl_SVs; //select * from tbl_SV
            //var qr1 = db.tbl_SVs.Where(o => o.MSSV == "1234"); //select * from tbl_SV where mssv == "1234"

            string id = Request["txt_id"];
            string mssv = Request["txt_mssv"];
            string hoten = Request["txt_hoten"];
            string mk = Request["txt_mk"];
            string nhaclaimk = Request["txt_nhaclaimk"];

            //validate input
            if (!string.IsNullOrEmpty(id) &&!string.IsNullOrEmpty(mssv) && !string.IsNullOrEmpty(hoten) && !string.IsNullOrEmpty(mk) && !string.IsNullOrEmpty(nhaclaimk))
            {
                if (id == mssv)
                {
                    if (mk == nhaclaimk)
                    {
                        try
                        {
                            //trường hợp muốn update
                            var qrs = db.tbl_SVs.Where(o => o.MSSV == mssv);
                            if (qrs.Any())
                            {
                                //có trả về bản ghi.
                                tbl_SV sv = qrs.SingleOrDefault();
                                sv.HoTen = hoten;
                                sv.MatKhau = mk;

                                db.SubmitChanges();

                                return "Cập nhật thông tin sinh viên thành công";
                            }
                            else
                            {
                                return "KHÔNG tìm thấy sv có mssv = " + mssv;
                            }
                        }
                        catch (Exception ex)
                        {
                            return "Cập nhật thông tin sinh viên thất bại. Chi tiết lỗi: " + ex.Message;
                        }
                    }
                    else
                    {
                        //trường hợp dữ liệu input không hợp lệ
                        return "Mật khẩu nhắc lại không khớp. Vui lòng kiểm tra lại";
                    }
                }
                else
                {
                    //trường hợp mssv đã bị sửa
                    return "MSSV không khớp với dữ liệu trong CSDL";
                }
            }
            else
            {
                return "Mày chơi tao không được đâu";
            }


        }

        //public string get_All()
        //{
        //    APIResult_ett<List<tbl_SV>> rs = new APIResult_ett<List<tbl_SV>>();
        //    try
        //    {
        //        //truy vấn db để lấy toàn bộ dữ liệu về ds sinh viên
        //        var qr = db.tbl_SVs.Where(o=> o.isDelete == null || o.isDelete == 0);
        //        if (qr.Any())
        //        {
        //            //có dữ liệu => chính là dssv
        //            rs.ErrCode = EnumErrCode.Success;
        //            rs.ErrDesc = "Lấy DSSV thành công";
        //            rs.Data = qr.ToList();
        //        }
        //        else
        //        {
        //            //không có dữ liệu thỏa mãn
        //            rs.ErrCode = EnumErrCode.Empty;
        //            rs.ErrDesc = "DSSV rỗng";
        //            rs.Data = null;
        //        }                
        //    }
        //    catch (Exception ex)
        //    {
        //        rs.ErrCode = EnumErrCode.Error;
        //        rs.ErrDesc = "Có lỗi xảy ra trong quá trình lấy về DSSV. Chi tiết lỗi: " + ex.Message;
        //        rs.Data = null;
        //    }

        //    return JsonConvert.SerializeObject(rs);
        //}

        public string Search_SV()
        {
            APIResult_ett<List<tbl_SV>> rs = new APIResult_ett<List<tbl_SV>>();
            try
            {
                string search_val = Request["search_val"];
                string search_type = Request["search_type"];

                if (!string.IsNullOrEmpty(search_val) && !string.IsNullOrEmpty(search_type))
                {
                    //truy vấn db để lấy toàn bộ dữ liệu về ds sinh viên
                    IQueryable<tbl_SV> qr = null;

                    switch (search_type)
                    {
                        case "mssv":
                            qr = db.tbl_SVs.Where(o => o.MSSV == search_val && (o.isDelete == null || o.isDelete == 0));
                            break;
                        case "hoten":
                            qr = db.tbl_SVs.Where(o => o.HoTen.Contains(search_val) && (o.isDelete == null || o.isDelete == 0));
                            break;
                        default:
                            break;
                    }

                    if (qr.Any())
                    {
                        //có dữ liệu => chính là dssv
                        rs.ErrCode = EnumErrCode.Success;
                        rs.ErrDesc = "Tìm kiếm sinh viên thành công";
                        rs.Data = qr.ToList();
                    }
                    else
                    {
                        //không có dữ liệu thỏa mãn
                        rs.ErrCode = EnumErrCode.Empty;
                        rs.ErrDesc = "Không tìm thấy sinh viên thỏa mãn điều kiện tìm kiếm";
                        rs.Data = null;
                    }
                }
                else
                {
                    //get all
                    var qr = db.tbl_SVs.Where(o => o.isDelete == null || o.isDelete == 0);
                    if (qr.Any())
                    {
                        //có dữ liệu => chính là dssv
                        rs.ErrCode = EnumErrCode.Success;
                        rs.ErrDesc = "Lấy DSSV thành công";
                        rs.Data = qr.ToList();
                    }
                    else
                    {
                        //không có dữ liệu thỏa mãn
                        rs.ErrCode = EnumErrCode.Empty;
                        rs.ErrDesc = "DSSV rỗng";
                        rs.Data = null;
                    }

                    //rs.ErrCode = EnumErrCode.InputEmpty;
                    //rs.ErrDesc = "Vui lòng nhập đầy đủ giá trị và tiêu chí cần tìm kiếm";
                    //rs.Data = null;
                }
                
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình lấy về DSSV. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }

            return JsonConvert.SerializeObject(rs);
        }
        //public ActionResult DSSV()
        //{
        //    return View();
        //}

        public string Del_SV()
        {
            APIResult_ett<string> rs = new APIResult_ett<string>();

            try
            {
                //xử lý trường hợp xóa
                //lấy về mssv cần xóa
                string mssv = Request["mssv"];
                if (!string.IsNullOrEmpty(mssv))
                {
                    //thực hiện xóa và nên xóa mềm
                    var qr = db.tbl_SVs.Where( o=> o.MSSV == mssv );
                    if (qr.Any())
                    {
                        //trường hợp có dữ liệu
                        tbl_SV del_obj = qr.SingleOrDefault();
                        del_obj.isDelete = 1;
                        del_obj.DeleteTime = DateTime.Now.ToString();

                        db.SubmitChanges();

                        rs.ErrCode = EnumErrCode.Success;
                        rs.ErrDesc = "Xóa SV có MSSV " + mssv + " thành công";
                        rs.Data = del_obj.HoTen;
                    }
                    else
                    {
                        rs.ErrCode = EnumErrCode.NotExistent;
                        rs.ErrDesc = "Xóa SV có MSSV " + mssv + " thất bại do không tìm thấy";
                        rs.Data = null;

                    }
                }
                else
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "Vui lòng nhập MSSV cần xóa";
                    rs.Data = null;
                }
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Xóa sinh viên thất bại. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }

            return JsonConvert.SerializeObject(rs);
        }
    }
}