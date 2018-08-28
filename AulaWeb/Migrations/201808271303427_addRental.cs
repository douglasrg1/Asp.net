namespace AulaWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRental : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "numberAvaible", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "numberAvaible");
        }
    }
}
