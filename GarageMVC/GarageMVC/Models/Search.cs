using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageMVC.Models
{
    public class Search
    {
        public int ID { get; set; }
        public Type Type { get; set; }
        public string RegNo { get; set; }
        public color Color { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public int NoOfWheels { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }

        public enum type
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
}