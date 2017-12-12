namespace GarageMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GarageMVC.DataAccessLayer.DatabaseConnection>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GarageMVC.DataAccessLayer.DatabaseConnection context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.VehiclesModel.AddOrUpdate(n => n.RegNo, new Models.VehiclesModel()
            {

                RegNo = "Car123",
                //Color = 
                Brand = "New",
                Model = "2010",
                NoOfWheels = 4,

            });
            context.VehiclesModel.AddOrUpdate(n => n.RegNo, new Models.VehiclesModel()
            {

                RegNo = "AZP123",
                //Color = 
                Brand = "New1",
                Model = "2002",
                NoOfWheels = 4,

            });
            context.VehiclesModel.AddOrUpdate(n => n.RegNo, new Models.VehiclesModel()
            {

                RegNo = "AZP123",
                //Color = 
                Brand = "New2",
                Model = "20021",
                NoOfWheels = 4,

            });
            context.VehiclesModel.AddOrUpdate(n => n.RegNo, new Models.VehiclesModel()
            {

                RegNo = "AZP123",
                //Color = 
                Brand = "New3",
                Model = "20024",
                NoOfWheels = 4,

            });
            context.VehiclesModel.AddOrUpdate(n => n.RegNo, new Models.VehiclesModel()
            {

                RegNo = "AZP123",
                //Color = 
                Brand = "New1",
                Model = "2002",
                NoOfWheels = 4,

            });
            context.VehiclesModel.AddOrUpdate(n => n.RegNo, new Models.VehiclesModel()
            {

                RegNo = "AZP123",
                //Color = 
                Brand = "New",
                Model = "2002",
                NoOfWheels = 4,

            });
            context.VehiclesModel.AddOrUpdate(n => n.RegNo, new Models.VehiclesModel()
            {

                RegNo = "AZP123",
                //Color = 
                Brand = "New",
                Model = "2002",
                NoOfWheels = 4,

            });
            context.VehiclesModel.AddOrUpdate(n => n.RegNo, new Models.VehiclesModel()
            {

                RegNo = "AZP123",
                //Color = 
                Brand = "New",
                Model = "2002",
                NoOfWheels = 4,

            });
            context.VehiclesModel.AddOrUpdate(n => n.RegNo, new Models.VehiclesModel()
            {

                RegNo = "AZP123",
                //Color = 
                Brand = "New",
                Model = "2002",
                NoOfWheels = 4,

            });



        }
    }
}
