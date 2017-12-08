using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageMVC.Models.ViewModel
{
    public class Receipt
    {
        public int ID { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime Checkout { get; set; }
        public string Type { get; set; }
        public string RegNo { get; set; }
        public TimeSpan TotalTime { get; set; }
        public int Price { get; set; }

        public Receipt()
        {

        }

        public Receipt(VehiclesModel VehicleRec)
        {
            ID = VehicleRec.ID;
            CheckIn = VehicleRec.CheckInTime;
            Checkout = DateTime.Now;
            Type = VehicleRec.Type.ToString();
            RegNo = VehicleRec.RegNo;
            TotalTime = DateTime.Now - VehicleRec.CheckInTime;
            Price = 20;


        }
    }
}