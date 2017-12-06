using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GarageMVC.Models
{
    public class VehiclesModel
    {
        public int ID { get; set; }
        public Type Type { get; set; }
        [DisplayName("Registration No.")]
        [Required(ErrorMessage = "An Registration No. is required")]
        public string RegNo { get; set; }
        
        public color  Color { get; set; }
        [Required(ErrorMessage = "An Model is required")]
        public string Model { get; set; }
        [Required(ErrorMessage = "An Brand is required")]
        public string Brand { get; set; }
        //[Required(ErrorMessage = "An Brand Number is required")]
        [DisplayName("No. Of Wheels")]
        public int NoOfWheels { get; set; }
        [DisplayName("Parked In")]
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
          
        //public VehiclesModel( DateTime? CheckIn)
        //{
        //    //CheckInTime = DateTime.Now;
        //    //CheckOutTime = DateTime.Now;
        //    this.CheckInTime = CheckIn ?? DateTime.Now;
        //}
       }


    public enum Type
    {
        Van,
        Car,
        Bus,
        Boat,
        Airplane,
        Motorcycle       
    }
    public enum color
    {
        Black,
        White,
        Silver,
        Yellow,
        Blue,
        Red,
        Pink,
        Brown,
        DarkRed,
        Gold
    }
}