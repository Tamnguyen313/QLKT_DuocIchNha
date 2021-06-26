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
    public class LothuocsController : Controller
    {
        private Model db = new Model();

        // GET: Admin/Lothuocs
        public ActionResult Index()
        {
            return View(db.Lothuocs.ToList());
        }

        // GET: Admin/Lothuocs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lothuoc lothuoc = db.Lothuocs.Find(id);
            if (lothuoc == null)
            {
                return HttpNotFound();
            }
            return View(lothuoc);
        }

        // GET: Admin/Lothuocs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Lothuocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Malothuoc,Tenlothuoc,Manhacungcap,Ghichu")] Lothuoc lothuoc)
        {
            if (ModelState.IsValid)
            {
                db.Lothuocs.Add(lothuoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lothuoc);
        }

        // GET: Admin/Lothuocs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lothuoc lothuoc = db.Lothuocs.Find(id);
            if (lothuoc == null)
            {
                return HttpNotFound();
            }
            return View(lothuoc);
        }

        // POST: Admin/Lothuocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Malothuoc,Tenlothuoc,Manhacungcap,Ghichu")] Lothuoc lothuoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lothuoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lothuoc);
        }

        // GET: Admin/Lothuocs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lothuoc lothuoc = db.Lothuocs.Find(id);
            if (lothuoc == null)
            {
                return HttpNotFound();
            }
            return View(lothuoc);
        }

        // POST: Admin/Lothuocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Lothuoc lothuoc = db.Lothuocs.Find(id);
            db.Lothuocs.Remove(lothuoc);
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
