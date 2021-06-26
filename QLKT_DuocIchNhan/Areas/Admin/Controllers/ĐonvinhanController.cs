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
    public class DonvinhansController : Controller
    {
        private Model db = new Model();

        // GET: Admin/Donvinhans
        public ActionResult Index()
        {
            return View(db.Donvinhans.ToList());
        }

        // GET: Admin/Donvinhans/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donvinhan donvinhan = db.Donvinhans.Find(id);
            if (donvinhan == null)
            {
                return HttpNotFound();
            }
            return View(donvinhan);
        }

        // GET: Admin/Donvinhans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Donvinhans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Madonvinhan,Tendonvinhan,Sodienthoai,Email,Ghichu")] Donvinhan donvinhan)
        {
            if (ModelState.IsValid)
            {
                db.Donvinhans.Add(donvinhan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donvinhan);
        }

        // GET: Admin/Donvinhans/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donvinhan donvinhan = db.Donvinhans.Find(id);
            if (donvinhan == null)
            {
                return HttpNotFound();
            }
            return View(donvinhan);
        }

        // POST: Admin/Donvinhans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Madonvinhan,Tendonvinhan,Sodienthoai,Email,Ghichu")] Donvinhan donvinhan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donvinhan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donvinhan);
        }

        // GET: Admin/Donvinhans/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donvinhan donvinhan = db.Donvinhans.Find(id);
            if (donvinhan == null)
            {
                return HttpNotFound();
            }
            return View(donvinhan);
        }

        // POST: Admin/Donvinhans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Donvinhan donvinhan = db.Donvinhans.Find(id);
            db.Donvinhans.Remove(donvinhan);
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
