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
        public ActionResult Index()
        {
            return View(db.VehiclesModel.ToList());
        }

        //public ActionResult Index(string s,string q)
        //{
        //    //var vehicles = from r in db.VehiclesModel select r;
        //    //int id = Convert.ToInt32(Request["search type"]);
        //    //var SearchParameter = "Searching";

        //    //if (!string.IsNullOrWhiteSpace(s))
        //    //{
        //    //    switch (id)
        //    //    {
        //    //        case 0:
        //    //            int Type = int.Parse(s)
        //    //                vehicles = vehicles.Where(r => r.ID.Equals(Type));
        //    //            SearchParameter += "ID for' " + s + "'";
        //    //            break;
        //    //        default:
        //    //            break;
        //    //    }

        //    }

        //    return View(vehicles);

        //}
        public ActionResult ParkedVehicles()
        {
            List<VehiclesInGarage> MdVeh = new List<VehiclesInGarage>();
            foreach (var v in db.VehiclesModel.Where(no=> no.NoOfWheels >= 0))
            {
                MdVeh.Add(new VehiclesInGarage(v));
            }
            return View(MdVeh);
        }

        //public ActionResult CalculateTimeandCost( int ? ID)
        //{
        //    VehiclesModel vehmod = db.VehiclesModel.Find(ID);
        //    TimeSpan TotalTime = (vehmod.CheckOutTime - vehmod.CheckInTime);

        //    return View(TotalTime);
        //}

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
            var TotalTimeandPrice = new Receipt();
            TotalTimeandPrice.Type = vehiclesModel.Type.ToString();
            TotalTimeandPrice.RegNo = vehiclesModel.RegNo;
            TotalTimeandPrice.CheckIn = vehiclesModel.CheckInTime;
            TotalTimeandPrice.Checkout = DateTime.Now;
            TotalTimeandPrice.TotalTime = (DateTime.Now - vehiclesModel.CheckInTime);
            double TTforCal = TotalTimeandPrice.TotalTime.TotalHours;
            if(TTforCal <= 1)
            {
                TotalTimeandPrice.Price = 40;

            }
            else
            {
                TotalTimeandPrice.Price = 40*Convert.ToInt32(TTforCal);

            }

            
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
