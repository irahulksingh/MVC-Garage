namespace GarageMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParkedVehicles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehiclesModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        RegNo = c.String(),
                        Color = c.Int(nullable: false),
                        Model = c.String(),
                        Brand = c.String(),
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
