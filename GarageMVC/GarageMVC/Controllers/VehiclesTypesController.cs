using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GarageMVC.DataAccessLayer;
using GarageMVC.Models;

namespace GarageMVC.Controllers
{
    public class VehiclesTypesController : Controller
    {
        private DatabaseConnection db = new DatabaseConnection();

        // GET: VehiclesTypes
        public ActionResult Index()
        {
            return View(db.VehiclesTypes.ToList());
        }

        // GET: VehiclesTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehiclesType vehiclesType = db.VehiclesTypes.Find(id);
            if (vehiclesType == null)
            {
                return HttpNotFound();
            }
            return View(vehiclesType);
        }

        // GET: VehiclesTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehiclesTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RegNo,VehicleType")] VehiclesType vehiclesType)
        {
            if (ModelState.IsValid)
            {
                db.VehiclesTypes.Add(vehiclesType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehiclesType);
        }

        // GET: VehiclesTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehiclesType vehiclesType = db.VehiclesTypes.Find(id);
            if (vehiclesType == null)
            {
                return HttpNotFound();
            }
            return View(vehiclesType);
        }

        // POST: VehiclesTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RegNo,VehicleType")] VehiclesType vehiclesType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiclesType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehiclesType);
        }

        // GET: VehiclesTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehiclesType vehiclesType = db.VehiclesTypes.Find(id);
            if (vehiclesType == null)
            {
                return HttpNotFound();
            }
            return View(vehiclesType);
        }

        // POST: VehiclesTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehiclesType vehiclesType = db.VehiclesTypes.Find(id);
            db.VehiclesTypes.Remove(vehiclesType);
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
