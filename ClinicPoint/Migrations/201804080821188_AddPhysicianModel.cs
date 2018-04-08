namespace ClinicPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhysicianModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Physicians",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        SocialSecurityNumber = c.Int(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        Phone = c.Int(nullable: false),
                        Email = c.String(),
                        Specialty_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Specialties", t => t.Specialty_Id, cascadeDelete: true)
                .Index(t => t.Specialty_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Physicians", "Specialty_Id", "dbo.Specialties");
            DropIndex("dbo.Physicians", new[] { "Specialty_Id" });
            DropTable("dbo.Physicians");
        }
    }
}
