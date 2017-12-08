namespace GarageMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParkedVehicles1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehiclesModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        RegNo = c.String(nullable: false),
                        Color = c.Int(nullable: false),
                        Model = c.String(nullable: false),
                        Brand = c.String(nullable: false),
                        NoOfWheels = c.Int(nullable: false),
                        CheckInTime = c.DateTime(nullable: false),
                        CheckOutTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VehiclesModels");
        }
    }
}
