namespace GarageMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParkedVehicles2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VehiclesModels", "Model", c => c.String(nullable: false));
            AlterColumn("dbo.VehiclesModels", "Brand", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VehiclesModels", "Brand", c => c.String());
            AlterColumn("dbo.VehiclesModels", "Model", c => c.String());
        }
    }
}
