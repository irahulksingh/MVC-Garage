﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GarageMVC.DataAccessLayer
{
    public class DatabaseConnection:DbContext
    {
        public DatabaseConnection() : base("ParkingDetails")
        { }

        public System.Data.Entity.DbSet<GarageMVC.Models.VehiclesModel> VehiclesModel { get; set; }

        //public System.Data.Entity.DbSet<GarageMVC.Models.ViewModel.VehiclesInGarage> VehiclesInGarages { get; set; }
    }
}