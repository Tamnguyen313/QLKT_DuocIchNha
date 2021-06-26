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
    public class ThuocsController : Controller
    {
        private Model db = new Model();

        // GET: Admin/Thuocs
        public ActionResult Index()
        {
            return View(db.Thuocs.ToList());
        }

        // GET: Admin/Thuocs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thuoc thuoc = db.Thuocs.Find(id);
            if (thuoc == null)
            {
                return HttpNotFound();
            }
            return View(thuoc);
        }

        // GET: Admin/Thuocs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Thuocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mathuoc,Tenthuoc,Manhomthuoc,Malothuoc,Manhacungcap,Soluongtoithieu,Soluongtoida,Donvitinh,Gia,Ghichu")] Thuoc thuoc)
        {
            if (ModelState.IsValid)
            {
                db.Thuocs.Add(thuoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thuoc);
        }

        // GET: Admin/Thuocs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thuoc thuoc = db.Thuocs.Find(id);
            if (thuoc == null)
            {
                return HttpNotFound();
            }
            return View(thuoc);
        }

        // POST: Admin/Thuocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mathuoc,Tenthuoc,Manhomthuoc,Malothuoc,Manhacungcap,Soluongtoithieu,Soluongtoida,Donvitinh,Gia,Ghichu")] Thuoc thuoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thuoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thuoc);
        }

        // GET: Admin/Thuocs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thuoc thuoc = db.Thuocs.Find(id);
            if (thuoc == null)
            {
                return HttpNotFound();
            }
            return View(thuoc);
        }

        // POST: Admin/Thuocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Thuoc thuoc = db.Thuocs.Find(id);
            db.Thuocs.Remove(thuoc);
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
