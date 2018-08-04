namespace AulaWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingMovieGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MoviesGenres (Name) VALUES ('Action')");
            Sql("INSERT INTO MoviesGenres (Name) VALUES ('Thriller')");
            Sql("INSERT INTO MoviesGenres (Name) VALUES ('Family')");
            Sql("INSERT INTO MoviesGenres (Name) VALUES ('Romance')");
            Sql("INSERT INTO MoviesGenres (Name) VALUES ('Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
