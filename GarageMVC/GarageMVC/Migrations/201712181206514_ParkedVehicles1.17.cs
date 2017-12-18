namespace GarageMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParkedVehicles117 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberName = c.String(),
                        MemberEmail = c.String(),
                        MemberPhone = c.String(),
                        Address = c.String(),
                        VehicleType_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehiclesModels", t => t.VehicleType_ID)
                .Index(t => t.VehicleType_ID);
            
            CreateTable(
                "dbo.VehiclesModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VehicleType = c.Int(nullable: false),
                        RegNo = c.String(nullable: false),
                        Color = c.Int(nullable: false),
                        Model = c.String(nullable: false),
                        Brand = c.String(nullable: false),
                        NoOfWheels = c.Int(nullable: false),
                        CheckInTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CheckOutTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.VehiclesTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RegNo = c.String(),
                        VehicleType = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "VehicleType_ID", "dbo.VehiclesModels");
            DropIndex("dbo.Members", new[] { "VehicleType_ID" });
            DropTable("dbo.VehiclesTypes");
            DropTable("dbo.VehiclesModels");
            DropTable("dbo.Members");
        }
    }
}
