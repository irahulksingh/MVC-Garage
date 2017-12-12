using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GarageMVC.Models.ViewModel;
using GarageMVC.Models;
using GarageMVC.DataAccessLayer;

namespace GarageMVC.Controllers
{
    public class SearchController : Controller
    {
        private DatabaseConnection db = new DatabaseConnection();
        // GET: Search
        public ActionResult Index( string SearchString,string SearchModel,string Searchbrand)
        {
            var Vehicles = from v in db.VehiclesModel
                           select v;
            if (!string.IsNullOrWhiteSpace(SearchString))
            {
                 Vehicles = Vehicles.Where(s => s.RegNo.Contains(SearchString));
            }
            if (!string.IsNullOrWhiteSpace(SearchModel))
            {
                Vehicles = Vehicles.Where(s => s.Model.Contains(SearchModel));
            }
            if (!string.IsNullOrWhiteSpace(Searchbrand))
            {
                Vehicles = Vehicles.Where(s => s.Brand.Contains(Searchbrand));
            }
            return View(Vehicles);

        }
    }
}