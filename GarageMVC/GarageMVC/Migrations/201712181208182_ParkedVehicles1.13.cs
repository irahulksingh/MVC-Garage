namespace GarageMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParkedVehicles113 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.VehiclesTypes", "RegNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VehiclesTypes", "RegNo", c => c.String());
        }
    }
}
