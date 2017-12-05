using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageMVC.Models
{
    public class VehiclesModel
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string RegNo { get; set; }
        public string Brand { get; set; }
        public int NoOfWheels { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
       
    }
}