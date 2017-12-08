namespace GarageMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParkedVehicles3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Receipts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CheckIn = c.DateTime(nullable: false),
                        Checkout = c.DateTime(nullable: false),
                        Type = c.String(),
                        RegNo = c.String(),
                        TotalTime = c.Time(nullable: false, precision: 7),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Receipts");
        }
    }
}
