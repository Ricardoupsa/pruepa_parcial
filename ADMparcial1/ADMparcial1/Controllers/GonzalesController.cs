using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ADMparcial1.Models;

namespace ADMparcial1.Controllers
{
    public class GonzalesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Gonzales
        public ActionResult Index()
        {
            return View(db.Gonzales.ToList());
        }

        // GET: Gonzales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gonzales gonzales = db.Gonzales.Find(id);
            if (gonzales == null)
            {
                return HttpNotFound();
            }
            return View(gonzales);
        }

        // GET: Gonzales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gonzales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GonzalesID,FriendofRicardo,place,Email,Birthdate")] Gonzales gonzales)
        {
            if (ModelState.IsValid)
            {
                db.Gonzales.Add(gonzales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gonzales);
        }

        // GET: Gonzales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gonzales gonzales = db.Gonzales.Find(id);
            if (gonzales == null)
            {
                return HttpNotFound();
            }
            return View(gonzales);
        }

        // POST: Gonzales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GonzalesID,FriendofRicardo,place,Email,Birthdate")] Gonzales gonzales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gonzales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gonzales);
        }

        // GET: Gonzales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gonzales gonzales = db.Gonzales.Find(id);
            if (gonzales == null)
            {
                return HttpNotFound();
            }
            return View(gonzales);
        }

        // POST: Gonzales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gonzales gonzales = db.Gonzales.Find(id);
            db.Gonzales.Remove(gonzales);
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
