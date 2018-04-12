namespace ClinicPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameAndUpdatedSpecialtyModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Specialties", newName: "SpecialtyTypes");
            DropForeignKey("dbo.Physicians", "Specialty_Id", "dbo.Specialties");
            DropIndex("dbo.Physicians", new[] { "Specialty_Id" });
            RenameColumn(table: "dbo.Physicians", name: "Specialty_Id", newName: "SpecialtyTypeId");
            AlterColumn("dbo.Physicians", "SpecialtyTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Physicians", "SpecialtyTypeId");
            AddForeignKey("dbo.Physicians", "SpecialtyTypeId", "dbo.SpecialtyTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Physicians", "SpecialtyTypeId", "dbo.SpecialtyTypes");
            DropIndex("dbo.Physicians", new[] { "SpecialtyTypeId" });
            AlterColumn("dbo.Physicians", "SpecialtyTypeId", c => c.Int());
            RenameColumn(table: "dbo.Physicians", name: "SpecialtyTypeId", newName: "Specialty_Id");
            CreateIndex("dbo.Physicians", "Specialty_Id");
            AddForeignKey("dbo.Physicians", "Specialty_Id", "dbo.Specialties", "Id");
            RenameTable(name: "dbo.SpecialtyTypes", newName: "Specialties");
        }
    }
}
