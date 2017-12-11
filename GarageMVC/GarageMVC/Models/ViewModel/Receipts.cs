using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GarageMVC.Models.ViewModel
{
    public class Receipt
    {
        public int ID { get; set; }
        
        [DisplayName("Parked in at:")]
        public DateTime CheckIn { get; set; }

        [DisplayName("Parked out at:")]
        public DateTime Checkout { get; set; }

        [DisplayName("Vehicle type:")]
        public string Type { get; set; }

        [DisplayName("Registration No.:")]
        public string RegNo { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = false)]
        [DisplayName("Total time in garage:")]
        public TimeSpan TotalTime { get; set; }

        [DisplayName("Amount payable:")]
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
            TimeSpan Timeafter = new TimeSpan(00,01,00);
            Price = 40;
            //int TotalPrice = Convert.ToInt32(TotalTime - Timeafter);
            //if (TotalTime >= Timeafter)
            //{
            //    Price = 40 * TotalPrice;

            //}
            //else
            //{
            //    
            //}


        }
    }
}