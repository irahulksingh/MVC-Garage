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
using GarageMVC.Models.ViewModel;

namespace GarageMVC.Controllers
{
    public class VehiclesModelsController : Controller
    {
        private DatabaseConnection db = new DatabaseConnection();



        public ActionResult Redirect()
        {
            //return RedirectToAction("Receipt");
            return Redirect("~/VehiclesModels/Receipts");

        }

        // GET: VehiclesModels
        public ActionResult Index(int? page)
        {
            return View(db.VehiclesModel.ToList());
        }

        public ActionResult ParkedVehicles()
        {

            List<VehiclesInGarage> MdVeh = new List<VehiclesInGarage>();
            foreach (var v in db.VehiclesModel.Where(no=> no.NoOfWheels >= 0))
            {
                MdVeh.Add(new VehiclesInGarage(v));
            }
            return View(MdVeh);
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
            var TotalTimeandPrice = new Receipt(vehiclesModel);
            //TotalTimeandPrice.Type = vehiclesModel.Type.ToString();
            //TotalTimeandPrice.RegNo = vehiclesModel.RegNo;
            //TotalTimeandPrice.CheckIn = vehiclesModel.CheckInTime;
            ////TotalTimeandPrice.Checkout = DateTime.Now;
            //TotalTimeandPrice.TotalTime = (DateTime.Now - vehiclesModel.CheckInTime);
            
            //double TTforCal = TotalTimeandPrice.TotalTime.TotalHours;
            //if(TTforCal <= 1)
            //{
            //    TotalTimeandPrice.Price = 40;

            //}
            //else
            //{
            //    TotalTimeandPrice.Price = 20*Convert.ToInt32(TTforCal)+20;

            //}
                    
            db.VehiclesModel.Remove(vehiclesModel);
            db.SaveChanges();
            return View("DeleteConfirmed", TotalTimeandPrice);
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
