namespace AulaWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDriveLicensetoApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "drivingLicense", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "drivingLicense");
        }
    }
}
