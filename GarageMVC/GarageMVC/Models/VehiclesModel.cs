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
        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "Special character should not be entered")]
        public string RegNo { get; set; }

        public color Color { get; set; }
        [Required(ErrorMessage = "An Model is required")]
        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "Special character should not be entered")]
        public string Model { get; set; }
        [Required(ErrorMessage = "An Brand is required")]
        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "Special character should not be entered")]
        public string Brand { get; set; }
        [Range(0, Int32.MaxValue, ErrorMessage = "Value should be greater than or equal to 0")]
        [DisplayName("No. Of Wheels")]
        public int NoOfWheels { get; set; }
        [DisplayName("Parked In")]
        public DateTime CheckInTime { get; set; }
        [DisplayName("Parked Out")]
        public DateTime CheckOutTime { get; set; }
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