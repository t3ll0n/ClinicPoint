namespace ClinicPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPatientModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        SocialSecurityNumber = c.Int(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        Phone = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Patients");
        }
    }
}
