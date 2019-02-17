namespace VyooFlix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNumInStockToMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumInStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumInStock");
        }
    }
}
