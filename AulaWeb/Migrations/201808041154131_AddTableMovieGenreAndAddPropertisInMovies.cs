namespace AulaWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableMovieGenreAndAddPropertisInMovies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        MoviesGenreId = c.Int(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        NumberInStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MoviesGenres", t => t.MoviesGenreId, cascadeDelete: true)
                .Index(t => t.MoviesGenreId);
            
            CreateTable(
                "dbo.MoviesGenres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MoviesGenreId", "dbo.MoviesGenres");
            DropIndex("dbo.Movies", new[] { "MoviesGenreId" });
            DropTable("dbo.MoviesGenres");
            DropTable("dbo.Movies");
        }
    }
}
