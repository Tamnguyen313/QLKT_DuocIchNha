using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLKT_DuocIchNhan.Areas.Admin.Models;

namespace QLKT_DuocIchNhan.Areas.Admin.Controllers
{
    public class PhieunhapsController : Controller
    {
        private Model db = new Model();

        // GET: Admin/Phieunhaps
        public ActionResult Index()
        {
            return View(db.Phieunhaps.ToList());
        }

        public List<TonKho> gettonkho()
        {
            var model = from p in db.Chitietphieunhaps
                        join b in db.Chitietphieuxuats on p.Mathuoc equals b.Mathuoc
                        join c in db.Handungs on p.Mathuoc equals c.Mathuoc
                        join t in db.Thuocs on p.Mathuoc equals t.Mathuoc
                        where p.Mathuoc == b.Mathuoc
                        select new TonKho()
                        {
                            Maphieuxuat = b.Maphieuxuat,
                            Mathuoc = p.Mathuoc,
                            Soluongnhap = p.Soluongnhap,
                            Soluongxuat = b.Soluongxuat,
                            Ton_kho = p.Soluongnhap - b.Soluongxuat,
                            //Canh_bao = (db.Chitietphieunhaps.Sum(x => x.Soluongnhap) - db.Chitietphieuxuats.Sum(x => x.Soluongxuat)) < 5 ? "Yêu cầu nhập" : (db.Chitietphieunhaps.Sum(x => x.Soluongnhap) - db.Chitietphieuxuats.Sum(x => x.Soluongxuat)) > 50 ? "Yêu cầu xuất" : "",
                            Canh_bao = (p.Soluongnhap - b.Soluongxuat) < t.Soluongtoithieu ? "Yêu cầu nhập" : (p.Soluongnhap - b.Soluongxuat) > t.Soluongtoida ? "Yêu cầu xuất" : "",
                            Het_han = c.Ngayhethan < DateTime.Now ? "Hết hạn" : "Chưa hết hạn",
                            So_ngay_hh = c.Ngayhethan.Day - DateTime.Now.Day,
                            Sl_het_han = db.Handungs.Where(x => x.Ngayhethan < DateTime.Now).Count()
                        };
            return model.Distinct().ToList();
        }

        public ActionResult Tonkho()
        {
            var model = gettonkho();
            return View(model);
        }

        // GET: Admin/Phieunhaps/Details/5
        public ActionResult Details(string id)
        {
            return View(db.Chitietphieunhaps.Where(x => x.Maphieunhap == id).ToList());
        }

        // GET: Admin/Phieunhaps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Phieunhaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Maphieunhap,Manhacungcap,Nguoilapphieu,Ngaylapphieu,Ghichu")] Phieunhap phieunhap)
        {
            if (ModelState.IsValid)
            {
                db.Phieunhaps.Add(phieunhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phieunhap);
        }

        // GET: Admin/Phieunhaps/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phieunhap phieunhap = db.Phieunhaps.Find(id);
            if (phieunhap == null)
            {
                return HttpNotFound();
            }
            return View(phieunhap);
        }

        // POST: Admin/Phieunhaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Maphieunhap,Manhacungcap,Nguoilapphieu,Ngaylapphieu,Ghichu")] Phieunhap phieunhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieunhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phieunhap);
        }

        // GET: Admin/Phieunhaps/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phieunhap phieunhap = db.Phieunhaps.Find(id);
            if (phieunhap == null)
            {
                return HttpNotFound();
            }
            return View(phieunhap);
        }

        // POST: Admin/Phieunhaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Phieunhap phieunhap = db.Phieunhaps.Find(id);
            var ct = db.Chitietphieunhaps.Where(x => x.Maphieunhap == id).ToList();
            db.Phieunhaps.Remove(phieunhap);
            db.Chitietphieunhaps.RemoveRange(ct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
