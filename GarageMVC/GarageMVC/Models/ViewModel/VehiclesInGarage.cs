using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageMVC.Models.ViewModel
{
    public class VehiclesInGarage
    {
        private bool p;

        public int ID { get; set; }
        public string RegNo { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
       
        public VehiclesInGarage()
        {

        }

        public VehiclesInGarage(VehiclesModel Vehicle)
        {
            ID = Vehicle.ID;
            RegNo = Vehicle.RegNo;
            Brand = Vehicle.Brand;
            Model = Vehicle.Model;

        }

        public VehiclesInGarage(bool p)
        {
            this.p = p;
        }
    }

   

}