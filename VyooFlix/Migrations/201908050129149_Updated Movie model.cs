namespace VyooFlix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedMoviemodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "NumInStock", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "NumInStock", c => c.Int(nullable: false));
        }
    }
}
