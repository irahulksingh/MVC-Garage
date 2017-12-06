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
    public class VehiclesModelsController : Controller
    {
        private DatabaseConnection db = new DatabaseConnection();

        // GET: VehiclesModels
        public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.TypeSortParm = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewBag.RegNoSortParm = String.IsNullOrEmpty(sortOrder) ? "regNo_desc" : "";
            ViewBag.ColorSortParm = String.IsNullOrEmpty(sortOrder) ? "color_desc" : "";
            ViewBag.BrandSortParm = String.IsNullOrEmpty(sortOrder) ? "brand_desc" : "";
            ViewBag.ModelSortParm = String.IsNullOrEmpty(sortOrder) ? "model_desc" : "";
            ViewBag.NoOfWheelsSortParm = sortOrder == "Int" ? "noOfWheels_desc" : "Int";
            ViewBag.CheckInTimeSortParm = sortOrder == "CheckInTime" ? "checkInTime_desc" : "CheckInTime";
            ViewBag.CheckOutTimeSortParm = sortOrder == "CheckOutTime" ? "checktOutTime_desc" : "CheckOutTime";
            var vehicles = from v in db.VehiclesModel
                           select v;
            if (!String.IsNullOrEmpty(searchString))
            {
                vehicles = vehicles.Where(v => 
                    v.RegNo.Contains(searchString)
                 || v.Type.Equals(searchString)
                 || v.Color.Equals(searchString)
                 || v.Brand.Contains(searchString)
                 || v.Model.Contains(searchString)
                 || v.NoOfWheels.Equals(searchString)
                 || v.CheckInTime.Equals(searchString)
                 || v.CheckOutTime.Equals(searchString));

            }                         
                switch (sortOrder)
            {
                case "regNo_desc":
                    vehicles = vehicles.OrderByDescending(v => v.RegNo);
                    break;
                case "Type":
                    vehicles = vehicles.OrderBy(v => v.Type);
                    break;
                case "type_desc":
                    vehicles = vehicles.OrderByDescending(v => v.Type);
                    break;
                case "CheckInTime":
                    vehicles = vehicles.OrderBy(v => v.CheckInTime);
                    break;
                case "checkInTime_desc":
                    vehicles = vehicles.OrderByDescending(v => v.CheckInTime);
                    break;
                case "CheckOutTime":
                    vehicles = vehicles.OrderBy(v => v.CheckOutTime);
                    break;
                case "checkOutTime_desc":
                    vehicles = vehicles.OrderByDescending(v => v.CheckOutTime);
                    break;
                case "Color":
                    vehicles = vehicles.OrderBy(v => v.Color);
                    break;
                case "color_desc":
                    vehicles = vehicles.OrderByDescending(v => v.Color);
                    break;
                case "Brand":
                    vehicles = vehicles.OrderBy(v => v.Brand);
                    break;
                case "brand_desc":
                    vehicles = vehicles.OrderByDescending(v => v.Brand);
                    break;
                case "Model":
                    vehicles = vehicles.OrderBy(v => v.Model);
                    break;
                case "model_desc":
                    vehicles = vehicles.OrderByDescending(v => v.Model);
                    break;
                case "NoOfWheels":
                    vehicles = vehicles.OrderBy(v => v.NoOfWheels);
                    break;
                case "noOfWheels_desc":
                    vehicles = vehicles.OrderByDescending(v => v.NoOfWheels);
                    break;
                default:
                    vehicles = vehicles.OrderBy(v => v.RegNo);
                    break;
            }
            return View(vehicles.ToList());
        }

        // GET: VehiclesModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehiclesModel vehiclesModel = db.VehiclesModel.Find(id);
            if (vehiclesModel == null)
            {
                return HttpNotFound();
            }
            return View(vehiclesModel);
        }

        // GET: VehiclesModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehiclesModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Type,RegNo,Color,Model,Brand,NoOfWheels,CheckInTime,CheckOutTime")] VehiclesModel vehiclesModel)
        {
            if (ModelState.IsValid)
            {
                db.VehiclesModel.Add(vehiclesModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehiclesModel);
        }

        // GET: VehiclesModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehiclesModel vehiclesModel = db.VehiclesModel.Find(id);
            if (vehiclesModel == null)
            {
                return HttpNotFound();
            }
            return View(vehiclesModel);
        }

        // POST: VehiclesModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Type,RegNo,Color,Model,Brand,NoOfWheels,CheckInTime,CheckOutTime")] VehiclesModel vehiclesModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiclesModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehiclesModel);
        }

        // GET: VehiclesModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehiclesModel vehiclesModel = db.VehiclesModel.Find(id);
            if (vehiclesModel == null)
            {
                return HttpNotFound();
            }
            return View(vehiclesModel);
        }

        // POST: VehiclesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehiclesModel vehiclesModel = db.VehiclesModel.Find(id);
            db.VehiclesModel.Remove(vehiclesModel);
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
