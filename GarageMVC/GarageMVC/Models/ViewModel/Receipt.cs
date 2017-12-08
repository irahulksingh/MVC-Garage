using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GarageMVC.Models.ViewModel;
using System.Web.Mvc;
using System.ComponentModel;

namespace GarageMVC.Views
{
    public class Receipt : Models.VehiclesInGarage
    {
        // Columns from VehiclesInGarage table
        //[Key]
        //[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        private bool v;
        public new string RegNo { get; set; }
        public string Type { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public int ParkingPeriod { get; set; }
        public int ParkingPrice { get; set; }

        public Receipt()
        {
        }
        public Receipt(VehiclesInGarage Veh)
        {
            RegNo = Veh.RegNo;
            Type = Veh.Type.ToString();
            //CheckInTime = DateTime.Now;
            CheckOutTime = DateTime.Now;
            ParkingPeriod = DateTime.Now-Veh.CheckInTime;
            ParkingPrice = Veh.ParkingPrice;
        }

        public Receipt(bool v)
        {
            this.v = v;
        }
    }
}