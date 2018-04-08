namespace ClinicPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAppointmentModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Time = c.String(nullable: false),
                        Patient_Id = c.Int(nullable: false),
                        Physician_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .ForeignKey("dbo.Physicians", t => t.Physician_Id, cascadeDelete: true)
                .Index(t => t.Patient_Id)
                .Index(t => t.Physician_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Physician_Id", "dbo.Physicians");
            DropForeignKey("dbo.Appointments", "Patient_Id", "dbo.Patients");
            DropIndex("dbo.Appointments", new[] { "Physician_Id" });
            DropIndex("dbo.Appointments", new[] { "Patient_Id" });
            DropTable("dbo.Appointments");
        }
    }
}
