namespace JohannMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Adventure')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Drama')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Horror')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'War')");
        }
        
        public override void Down()
        {
        }
    }
}
