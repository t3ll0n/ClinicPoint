namespace ClinicPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamePhysicianIDToPhysicianId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Appointments", new[] { "PhysicianID" });
            CreateIndex("dbo.Appointments", "PhysicianId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Appointments", new[] { "PhysicianId" });
            CreateIndex("dbo.Appointments", "PhysicianID");
        }
    }
}
