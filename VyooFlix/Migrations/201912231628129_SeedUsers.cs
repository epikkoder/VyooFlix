namespace VyooFlix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c928999b-0f49-4d12-9fd3-34d3075158b3', N'guest@vyooflix.com', 0, N'AKx3TMtABWnxYshm3OGKcS9Wg4y1pjt1uFVkw7dLMpoRLKkdYgQYARp3cohW6jpt2A==', N'ef5f3dfb-499d-4530-9175-a8b5afa95178', NULL, 0, 0, NULL, 1, 0, N'guest@vyooflix.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fddb9ab4-7a47-4455-aac6-a17c39154512', N'admin@vyooflix.com', 0, N'AHomZ7sr1/4qAD7ctv22+y+GTJhIQhPR02/+HB2ZTjgd8XBX+M+/bdjmOscOGPD+EA==', N'4ac56702-8a7f-4f51-b51b-a0073abacb13', NULL, 0, 0, NULL, 1, 0, N'admin@vyooflix.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b44c03a1-145d-426a-8d6d-94694349be21', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fddb9ab4-7a47-4455-aac6-a17c39154512', N'b44c03a1-145d-426a-8d6d-94694349be21')");
        }

        public override void Down()
        {
        }
    }
}
