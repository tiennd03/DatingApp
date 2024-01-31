using DemoASPNetBasic.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoASPNetBasic.Controllers
{
    public class TaiKhoanController : Controller
    {
        DatabaseDataContext db = new DatabaseDataContext();
        // GET: TaiKhoan
        public ActionResult DangNhap()
        {
            return View();
        }

        public string DangNhap_action()
        {
            APIResult_ett<string> rs = new APIResult_ett<string>();

            try
            {
                //xử lý trường hợp xóa
                //lấy về mssv cần xóa
                string tk = Request["txt_tk"];
                string mk = Request["txt_mk"];

                if (!string.IsNullOrEmpty(tk) && !string.IsNullOrEmpty(mk))
                {
                    //thực hiện xóa và nên xóa mềm
                    var qr = db.tbl_taikhoans.Where(o => o.TaiKhoan == tk && o.MatKhau == mk);
                    if (qr.Any())
                    {
                        Session["is_login"] = true; 

                        //trường hợp có dữ liệu                        
                        rs.ErrCode = EnumErrCode.Success;
                        rs.ErrDesc = "Đăng nhập hệ thống thành công";
                        rs.Data = "";
                    }
                    else
                    {
                        rs.ErrCode = EnumErrCode.NotExistent;
                        rs.ErrDesc = "Đăng nhập thất bại";
                        rs.Data = null;

                    }
                }
                else
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "Vui lòng nhập tài khoản và mật khẩu";
                    rs.Data = null;
                }
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình đăng nhập hệ thống. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }

            return JsonConvert.SerializeObject(rs);
        }
    }
}