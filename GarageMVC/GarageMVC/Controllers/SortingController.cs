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
    public class SortingController : Controller
    {
        private DatabaseConnection db = new DatabaseConnection();

        // GET: Sorting
        public ActionResult Index(string sortingCriteria)
        {
            ViewBag.Typesort = sortingCriteria == "Type" ? "Type_Desc" : "Type";
            ViewBag.Colorsort = sortingCriteria == "Color" ? "Color_Desc" : "Color";
            ViewBag.Brandsort = sortingCriteria == "Brand" ? "Brand_Desc" : "Brand";
            ViewBag.Modelsort = sortingCriteria == "Model" ? "Model_Desc" : "Model";

            List<GarageMVC.Models.VehiclesModel> VehicleType;
            switch (sortingCriteria)
            {
                case "Type":
                    VehicleType = db.VehiclesModel.OrderByDescending(t => t.Type.ToString()).ToList();
                    break;
                case "Type_Desc":
                    VehicleType = db.VehiclesModel.OrderBy(t => t.Type.ToString()).ToList();
                    break;
                case "Color":
                    VehicleType = db.VehiclesModel.OrderByDescending(t => t.Color.ToString()).ToList();
                    break;
                case "Color_Desc":
                    VehicleType = db.VehiclesModel.OrderBy(t => t.Color.ToString()).ToList();
                    break;
                case "Model":
                    VehicleType = db.VehiclesModel.OrderByDescending(t => t.Model).ToList();
                    break;
                case "Model_Desc":
                    VehicleType = db.VehiclesModel.OrderBy(t => t.Model.ToString()).ToList();
                    break;
                case "Brand":
                    VehicleType = db.VehiclesModel.OrderByDescending(t => t.Brand).ToList();
                    break;
                case "Brand_Desc":
                    VehicleType = db.VehiclesModel.OrderBy(t => t.Brand.ToString()).ToList();
                    break;
                default:
                    VehicleType = db.VehiclesModel.OrderBy(t => t.Color).ToList();

                    break;
            }

            return View(VehicleType);

        }
        //public ActionResult Paging()
        //{
        //    ViewBag.CurrentPage = 1;
        //    return View("Index",db.VehiclesModel.Take(5));
        //}
        //public ActionResult Paging(int CurrentPage)
        //{
        //    ViewBag.CurrentPage = CurrentPage;
        //    return View("Index", db.VehiclesModel.Skip((CurrentPage - 1) * 5).Take(5));


        //}
                // GET: Sorting/Details/5
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

        // GET: Sorting/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sorting/Create
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

        // GET: Sorting/Edit/5
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

        // POST: Sorting/Edit/5
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

        // GET: Sorting/Delete/5
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

        // POST: Sorting/Delete/5
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
