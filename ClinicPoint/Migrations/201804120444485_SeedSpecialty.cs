namespace ClinicPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedSpecialty : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Specialties (Name) VALUES ('Family Practice')");
            Sql("INSERT INTO Specialties (Name) VALUES ('Pediatrics')");
            Sql("INSERT INTO Specialties (Name) VALUES ('Cardiology')");
            Sql("INSERT INTO Specialties (Name) VALUES ('Gynecology')");
            Sql("INSERT INTO Specialties (Name) VALUES ('General Surgery')");
        }
        
        public override void Down()
        {
        }
    }
}
