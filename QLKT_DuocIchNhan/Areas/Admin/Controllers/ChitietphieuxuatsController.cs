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
    public class ChitietphieuxuatsController : Controller
    {
        private Model db = new Model();

        // GET: Admin/Chitietphieuxuats
        public ActionResult Index()
        {
            return View(db.Chitietphieuxuats.ToList());
        }

        // GET: Admin/Chitietphieuxuats/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietphieuxuat chitietphieuxuat = db.Chitietphieuxuats.Find(id);
            if (chitietphieuxuat == null)
            {
                return HttpNotFound();
            }
            return View(chitietphieuxuat);
        }

        // GET: Admin/Chitietphieuxuats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Chitietphieuxuats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Maphieuxuat,Mathuoc,Tenthuoc,Malothuoc,Soluongxuat,Donvitinh,Dongia,Thue,Thanhtien,Ghichu")] Chitietphieuxuat chitietphieuxuat)
        {
            var model = from p in db.Chitietphieunhaps
                        join b in db.Chitietphieuxuats on p.Mathuoc equals b.Mathuoc
                        join c in db.Handungs on p.Mathuoc equals c.Mathuoc
                        where p.Mathuoc == b.Mathuoc
                        select new TonKho()
                        {
                            Maphieuxuat = b.Maphieuxuat,
                            Mathuoc = p.Mathuoc,
                            Soluongnhap = p.Soluongnhap,
                            Soluongxuat = b.Soluongxuat,
                            Ton_kho = p.Soluongnhap - b.Soluongxuat,
                            Het_han = c.Ngayhethan < DateTime.Now ? "Hết hạn" : "Chưa hết hạn",
                            Sl_het_han = db.Handungs.Where(x => x.Ngayhethan < DateTime.Now).Count()
                        };
            model = model.Distinct();
            var groups = model.GroupBy(v => v.Mathuoc);

            int? ton_kho = 0;
            foreach(var i in groups)
            {
                if(i.Count() >= 2)
                {
                    ton_kho = model.Where(x => x.Mathuoc == i.Key).Sum(x => x.Ton_kho);
                }
            }

            foreach (var item in model)
            {
                if(item.Mathuoc == chitietphieuxuat.Mathuoc && ton_kho < chitietphieuxuat.Soluongxuat)
                {
                    ModelState.AddModelError("","Số lượng xuất lớn hơn tồn kho!");
                    break;
                }
            }

            if (ModelState.IsValid)
            {
                db.Chitietphieuxuats.Add(chitietphieuxuat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chitietphieuxuat);
        }

        // GET: Admin/Chitietphieuxuats/Edit/5
        public ActionResult Edit(string id, string id1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietphieuxuat chitietphieuxuat = db.Chitietphieuxuats.Find(id, id1);
            if (chitietphieuxuat == null)
            {
                return HttpNotFound();
            }
            return View(chitietphieuxuat);
        }

        // POST: Admin/Chitietphieuxuats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Maphieuxuat,Mathuoc,Tenthuoc,Malothuoc,Soluongxuat,Donvitinh,Dongia,Thue,Thanhtien,Ghichu")] Chitietphieuxuat chitietphieuxuat)
        {
            var model = from p in db.Chitietphieunhaps
                        join b in db.Chitietphieuxuats on p.Mathuoc equals b.Mathuoc
                        join c in db.Handungs on p.Mathuoc equals c.Mathuoc
                        where p.Mathuoc == b.Mathuoc
                        select new TonKho()
                        {
                            Maphieuxuat = b.Maphieuxuat,
                            Mathuoc = p.Mathuoc,
                            Soluongnhap = p.Soluongnhap,
                            Soluongxuat = b.Soluongxuat,
                            Ton_kho = p.Soluongnhap - b.Soluongxuat,
                            Het_han = c.Ngayhethan < DateTime.Now ? "Hết hạn" : "Chưa hết hạn",
                            Sl_het_han = db.Handungs.Where(x => x.Ngayhethan < DateTime.Now).Count()
                        };
            model = model.Distinct();
            var groups = model.GroupBy(v => v.Mathuoc);

            int? sl_xuatOld = db.Chitietphieuxuats.Where(x => x.Maphieuxuat == chitietphieuxuat.Maphieuxuat && x.Mathuoc == chitietphieuxuat.Mathuoc).Sum(x => x.Soluongxuat);
            int? ton_kho = 0;
            foreach (var i in groups)
            {
                if (i.Count() >= 2)
                {
                    ton_kho = model.Where(x => x.Mathuoc == i.Key).Sum(x => x.Ton_kho);
                }
            }

            foreach (var item in model)
            {
                if (item.Mathuoc == chitietphieuxuat.Mathuoc && (ton_kho + sl_xuatOld) < chitietphieuxuat.Soluongxuat)
                {
                    ModelState.AddModelError("", "Số lượng xuất lớn hơn tồn kho!");
                    break;
                }
            }

            if (ModelState.IsValid)
            {
                db.Entry(chitietphieuxuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chitietphieuxuat);
        }

        // GET: Admin/Chitietphieuxuats/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietphieuxuat chitietphieuxuat = db.Chitietphieuxuats.Find(id);
            if (chitietphieuxuat == null)
            {
                return HttpNotFound();
            }
            return View(chitietphieuxuat);
        }

        // POST: Admin/Chitietphieuxuats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Chitietphieuxuat chitietphieuxuat = db.Chitietphieuxuats.Find(id);
            db.Chitietphieuxuats.Remove(chitietphieuxuat);
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
