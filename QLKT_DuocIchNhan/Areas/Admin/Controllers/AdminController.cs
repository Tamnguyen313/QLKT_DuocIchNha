using QLKT_DuocIchNhan.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLKT_DuocIchNhan.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private Model db = new Model();
        // GET: Admin/Home
        public ActionResult Index()
        {
            ViewBag.totalNhap = db.Chitietphieunhaps.Sum(x => x.Thanhtien);
            ViewBag.totalXuat = db.Chitietphieuxuats.Sum(x => x.Thanhtien);
            ViewBag.totalTon = db.Chitietphieunhaps.Sum(x => x.Thanhtien) - db.Chitietphieuxuats.Sum(x => x.Thanhtien);
            return View();
        }
    }
}