namespace JohannMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustReleaseDateColumnName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Movies", "ReleasdDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "ReleasdDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Movies", "ReleaseDate");
        }
    }
}
