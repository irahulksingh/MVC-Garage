namespace GarageMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParkedVehicles1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VehiclesModels", "RegNo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VehiclesModels", "RegNo", c => c.String());
        }
    }
}
