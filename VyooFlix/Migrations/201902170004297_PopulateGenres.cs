namespace VyooFlix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
			Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Comedy')");
			Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Action')");
			Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Drama')");
			Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Romance')");
			Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Horror')");
		}
        
        public override void Down()
        {
        }
    }
}
