using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageMVC.Models
{
    public class Members
    {
        public int Id { get; set; }
        public string MemberName { get; set; }
        public string MemberEmail { get; set; }
        public string MemberPhone { get; set; }
        public string Address { get; set; }

        public virtual VehiclesModel VehicleType { get; set; }

    }
}