using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTinTuc.Controllers
{
    public class QLTTController : Controller
    {
        // GET: QLTT
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ThemTinTuc()
        {
            return View();
        }

        public ActionResult SuaTinTuc()
        {
            return View();
        }
        public ActionResult XoaTinTuc()
        {
            return View();
        }
    }
}