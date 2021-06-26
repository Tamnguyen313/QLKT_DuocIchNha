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
    public class NhomthuocsController : Controller
    {
        private Model db = new Model();

        // GET: Admin/Nhomthuocs
        public ActionResult Index()
        {
            return View(db.Nhomthuocs.ToList());
        }

        // GET: Admin/Nhomthuocs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhomthuoc nhomthuoc = db.Nhomthuocs.Find(id);
            if (nhomthuoc == null)
            {
                return HttpNotFound();
            }
            return View(nhomthuoc);
        }

        // GET: Admin/Nhomthuocs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Nhomthuocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Manhomthuoc,Malothuoc,Tennhomthuoc,Ghichu")] Nhomthuoc nhomthuoc)
        {
            if (ModelState.IsValid)
            {
                db.Nhomthuocs.Add(nhomthuoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhomthuoc);
        }

        // GET: Admin/Nhomthuocs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhomthuoc nhomthuoc = db.Nhomthuocs.Find(id);
            if (nhomthuoc == null)
            {
                return HttpNotFound();
            }
            return View(nhomthuoc);
        }

        // POST: Admin/Nhomthuocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Manhomthuoc,Malothuoc,Tennhomthuoc,Ghichu")] Nhomthuoc nhomthuoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhomthuoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhomthuoc);
        }

        // GET: Admin/Nhomthuocs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhomthuoc nhomthuoc = db.Nhomthuocs.Find(id);
            if (nhomthuoc == null)
            {
                return HttpNotFound();
            }
            return View(nhomthuoc);
        }

        // POST: Admin/Nhomthuocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Nhomthuoc nhomthuoc = db.Nhomthuocs.Find(id);
            db.Nhomthuocs.Remove(nhomthuoc);
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
