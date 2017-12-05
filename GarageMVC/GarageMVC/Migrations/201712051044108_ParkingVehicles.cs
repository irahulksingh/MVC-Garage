namespace GarageMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParkingVehicles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehiclesModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        RegNo = c.String(),
                        Brand = c.String(),
                        NoOfWheels = c.Int(nullable: false),
                        TimeIn = c.DateTime(nullable: false),
                        TimeOut = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VehiclesModels");
        }
    }
}
