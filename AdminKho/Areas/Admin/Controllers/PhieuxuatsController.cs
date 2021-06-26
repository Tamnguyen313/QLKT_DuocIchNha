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
    public class PhieuxuatsController : Controller
    {
        private Model db = new Model();

        // GET: Admin/Phieuxuats
        public ActionResult Index()
        {
            return View(db.Phieuxuats.ToList());
        }

        // GET: Admin/Phieuxuats/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phieuxuat phieuxuat = db.Phieuxuats.Find(id);
            if (phieuxuat == null)
            {
                return HttpNotFound();
            }
            return View(phieuxuat);
        }

        // GET: Admin/Phieuxuats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Phieuxuats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Maphieuxuat,Mathuoc,Malothuoc,Soluong,Donvitinh,Dongia,Thanhtien,Ngayxuat,Ghichu")] Phieuxuat phieuxuat)
        {
            if (ModelState.IsValid)
            {
                db.Phieuxuats.Add(phieuxuat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phieuxuat);
        }

        // GET: Admin/Phieuxuats/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phieuxuat phieuxuat = db.Phieuxuats.Find(id);
            if (phieuxuat == null)
            {
                return HttpNotFound();
            }
            return View(phieuxuat);
        }

        // POST: Admin/Phieuxuats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Maphieuxuat,Mathuoc,Malothuoc,Soluong,Donvitinh,Dongia,Thanhtien,Ngayxuat,Ghichu")] Phieuxuat phieuxuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuxuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phieuxuat);
        }

        // GET: Admin/Phieuxuats/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phieuxuat phieuxuat = db.Phieuxuats.Find(id);
            if (phieuxuat == null)
            {
                return HttpNotFound();
            }
            return View(phieuxuat);
        }

        // POST: Admin/Phieuxuats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Phieuxuat phieuxuat = db.Phieuxuats.Find(id);
            db.Phieuxuats.Remove(phieuxuat);
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
