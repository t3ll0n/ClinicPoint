namespace ClinicPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPhysicianAndSpecialtyModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Physicians", "Specialty_Id", "dbo.Specialties");
            DropIndex("dbo.Physicians", new[] { "Specialty_Id" });
            AlterColumn("dbo.Physicians", "Specialty_Id", c => c.Int());
            CreateIndex("dbo.Physicians", "Specialty_Id");
            AddForeignKey("dbo.Physicians", "Specialty_Id", "dbo.Specialties", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Physicians", "Specialty_Id", "dbo.Specialties");
            DropIndex("dbo.Physicians", new[] { "Specialty_Id" });
            AlterColumn("dbo.Physicians", "Specialty_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Physicians", "Specialty_Id");
            AddForeignKey("dbo.Physicians", "Specialty_Id", "dbo.Specialties", "Id", cascadeDelete: true);
        }
    }
}
