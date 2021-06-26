using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdminKho.Areas.Admin.Models;

namespace AdminKho.Areas.Admin.Controllers
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
            var model = from p in db.Phieunhaps
                        join b in db.Phieuxuats on p.Mathuoc equals b.Mathuoc
                        join c in db.Lothuocs on p.Mathuoc equals c.Mathuoc
                        where p.Mathuoc == b.Mathuoc
                        select new TonKho()
                        {
                            Mathuoc = p.Mathuoc,
                            Soluongnhap = p.Soluongnhap,
                            Soluong = b.Soluong,
                            Ton_kho = p.Soluongnhap - b.Soluong,
                            Het_han = c.Ngayhethan < DateTime.Now ? "Hết hạn" : "Chưa hết hạn",
                            Sl_het_han = db.Lothuocs.Where(x => x.Ngayhethan < DateTime.Now).Count()
                        };
            return model.ToList();
        }

        public ActionResult Tonkho()
        {
            var model = gettonkho();
            return View(model);
        }

        // GET: Admin/Phieunhaps/Details/5
        public ActionResult Details(string id)
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
        public ActionResult Create([Bind(Include = "Maphieunhap,Mathuoc,Malothuoc,Soluongnhap,Donvitinh,Dongia,Thanhtien,Ngaynhap,Ghichu")] Phieunhap phieunhap)
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
        public ActionResult Edit([Bind(Include = "Maphieunhap,Mathuoc,Malothuoc,Soluongnhap,Donvitinh,Dongia,Thanhtien,Ngaynhap,Ghichu")] Phieunhap phieunhap)
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
            db.Phieunhaps.Remove(phieunhap);
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
