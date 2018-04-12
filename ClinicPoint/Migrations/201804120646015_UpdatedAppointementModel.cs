namespace ClinicPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedAppointementModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Appointments", name: "Patient_Id", newName: "PatientId");
            RenameColumn(table: "dbo.Appointments", name: "Physician_Id", newName: "PhysicianID");
            RenameIndex(table: "dbo.Appointments", name: "IX_Patient_Id", newName: "IX_PatientId");
            RenameIndex(table: "dbo.Appointments", name: "IX_Physician_Id", newName: "IX_PhysicianID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Appointments", name: "IX_PhysicianID", newName: "IX_Physician_Id");
            RenameIndex(table: "dbo.Appointments", name: "IX_PatientId", newName: "IX_Patient_Id");
            RenameColumn(table: "dbo.Appointments", name: "PhysicianID", newName: "Physician_Id");
            RenameColumn(table: "dbo.Appointments", name: "PatientId", newName: "Patient_Id");
        }
    }
}
