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
    public class HandungsController : Controller
    {
        private Model db = new Model();

        // GET: Admin/Handungs
        public ActionResult Index()
        {
            return View(db.Handungs.ToList());
        }

        // GET: Admin/Handungs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Handung handung = db.Handungs.Find(id);
            if (handung == null)
            {
                return HttpNotFound();
            }
            return View(handung);
        }

        // GET: Admin/Handungs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Handungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mathuoc,Ngaysanxuat,Ngayhethan,Ghichu")] Handung handung)
        {
            if (ModelState.IsValid)
            {
                db.Handungs.Add(handung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(handung);
        }

        // GET: Admin/Handungs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Handung handung = db.Handungs.Find(id);
            if (handung == null)
            {
                return HttpNotFound();
            }
            return View(handung);
        }

        // POST: Admin/Handungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mathuoc,Ngaysanxuat,Ngayhethan,Ghichu")] Handung handung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(handung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(handung);
        }

        // GET: Admin/Handungs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Handung handung = db.Handungs.Find(id);
            if (handung == null)
            {
                return HttpNotFound();
            }
            return View(handung);
        }

        // POST: Admin/Handungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Handung handung = db.Handungs.Find(id);
            db.Handungs.Remove(handung);
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
