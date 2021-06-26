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
            return View(db.Chitietphieuxuats.Where(x => x.Maphieuxuat == id).ToList());
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
        public ActionResult Create([Bind(Include = "Maphieuxuat,Madonvinhan,Nguoilapphieu,Ngayxuatphieu,Ghichu")] Phieuxuat phieuxuat)
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
        public ActionResult Edit([Bind(Include = "Maphieuxuat,Madonvinhan,Nguoilapphieu,Ngayxuatphieu,Ghichu")] Phieuxuat phieuxuat)
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
            var ct = db.Chitietphieuxuats.Where(x => x.Maphieuxuat == id).ToList();
            db.Phieuxuats.Remove(phieuxuat);
            db.Chitietphieuxuats.RemoveRange(ct);
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
