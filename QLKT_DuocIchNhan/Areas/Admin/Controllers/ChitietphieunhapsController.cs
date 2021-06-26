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
    public class ChitietphieunhapsController : Controller
    {
        private Model db = new Model();

        // GET: Admin/Chitietphieunhaps
        public ActionResult Index()
        {
            return View(db.Chitietphieunhaps.ToList());
        }

        // GET: Admin/Chitietphieunhaps/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietphieunhap chitietphieunhap = db.Chitietphieunhaps.Find(id);
            if (chitietphieunhap == null)
            {
                return HttpNotFound();
            }
            return View(chitietphieunhap);
        }

        // GET: Admin/Chitietphieunhaps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Chitietphieunhaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Maphieunhap,Mathuoc,Tenthuoc,Tennhacungcap,Malothuoc,Soluongnhap,Donvitinh,Dongia,Thue,Thanhtien,Ghichu")] Chitietphieunhap chitietphieunhap)
        {
            if (ModelState.IsValid)
            {
                db.Chitietphieunhaps.Add(chitietphieunhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chitietphieunhap);
        }

        // GET: Admin/Chitietphieunhaps/Edit/5
        public ActionResult Edit(string id, string id1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietphieunhap chitietphieunhap = db.Chitietphieunhaps.Find(id, id1);
            if (chitietphieunhap == null)
            {
                return HttpNotFound();
            }
            return View(chitietphieunhap);
        }

        // POST: Admin/Chitietphieunhaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Maphieunhap,Mathuoc,Tenthuoc,Tennhacungcap,Malothuoc,Soluongnhap,Donvitinh,Dongia,Thue,Thanhtien,Ghichu")] Chitietphieunhap chitietphieunhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitietphieunhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chitietphieunhap);
        }

        // GET: Admin/Chitietphieunhaps/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietphieunhap chitietphieunhap = db.Chitietphieunhaps.Find(id);
            if (chitietphieunhap == null)
            {
                return HttpNotFound();
            }
            return View(chitietphieunhap);
        }

        // POST: Admin/Chitietphieunhaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Chitietphieunhap chitietphieunhap = db.Chitietphieunhaps.Find(id);
            db.Chitietphieunhaps.Remove(chitietphieunhap);
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
