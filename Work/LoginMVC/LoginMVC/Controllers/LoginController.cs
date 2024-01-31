using LoginMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginMVC.Controllers
{
    public class LoginController : Controller
    {
        private DataBase_DangNhapDataContext db = new DataBase_DangNhapDataContext();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LoginAdmin(DangNhap_Admin admin)
        {
            try
            {
                var user = db.DangNhap_Admins.SingleOrDefault(u => u.TaiKhoan == admin.TaiKhoan && u.MatKhau == admin.MatKhau);

                if (user != null)
                {
                    // Lấy quyền của người dùng
                    var role = user.PhanQuyen.ID_PhanQuyen;

                    // Kiểm tra quyền
                    if (role == 0)
                    {
                        // Đăng nhập Admin thành công, trả về thông tin và redirect URL
                        return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
                    }
                    else
                    {
                        // Người dùng không có quyền Admin, trả về thông báo lỗi
                        return Json(new { success = false, message = "Tài khoản không có quyền Admin." });
                    }
                }
                else
                {
                    // Đăng nhập thất bại, trả về thông báo lỗi
                    return Json(new { success = false, message = "Tài khoản hoặc mật khẩu không đúng." });
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về thông báo lỗi
                return Json(new { success = false, message = "Đã xảy ra lỗi trong quá trình xử lý đăng nhập." });
            }
        }

        [HttpPost]
        public JsonResult LoginPV(DangNhap_PhongVien pv)
        {
            try
            {
                var user = db.DangNhap_PhongViens.SingleOrDefault(u => u.TaiKhoan == pv.TaiKhoan && u.MatKhau == pv.MatKhau);

                if (user != null)
                {
                    // Lấy quyền của người dùng
                    var role = user.PhanQuyen.ID_PhanQuyen;

                    // Kiểm tra quyền
                    if (role == 1)
                    {
                        // Đăng nhập PV thành công, trả về thông tin và redirect URL
                        return Json(new { success = true, redirectUrl = Url.Action("Contact", "Home") });
                    }
                    else
                    {
                        // Người dùng không có quyền PhongVien, trả về thông báo lỗi
                        return Json(new { success = false, message = "Tài khoản không có quyền Phóng viên." });
                    }
                }
                else
                {
                    // Đăng nhập thất bại, trả về thông báo lỗi
                    return Json(new { success = false, message = "Tài khoản hoặc mật khẩu không đúng." });
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và trả về thông báo lỗi
                return Json(new { success = false, message = "Đã xảy ra lỗi trong quá trình xử lý đăng nhập." });
            }
        }
    }
}