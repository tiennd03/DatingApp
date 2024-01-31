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

        public DataClasses2DataContext db = new DataClasses2DataContext();

        // GET: QLSV
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ThemSV()
        {
            return View();
        }

        public ActionResult SuaSV()
        {
            return View();
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
    }
}