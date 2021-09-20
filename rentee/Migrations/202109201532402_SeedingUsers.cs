namespace rentee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2fbd3005-2021-4e38-bbe7-0a2c974af89c', N'admin@rentee.com', 0, N'AN01wNUNKSSLjJSzLsM0IfDCu9FQLfkc8OYqQEDaUWTiYMc8r5zQ7Wy0twlTH6yRVw==', N'81f03664-0e9b-40ed-99c4-066875b0fa7d', NULL, 0, 0, NULL, 1, 0, N'admin@rentee.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'50efb5ed-44c8-4dea-a097-ee888608d4e3', N'bepro.store@gmail.com', 0, N'ANcV21RmnO3fsM1jWCOmjUzGDZ+oai1StAZFzuK1kPbH8NmjZVuwE14sdyqrNV01Qw==', N'48b95b19-9e1d-4d9d-a885-000992d64758', NULL, 0, 0, NULL, 1, 0, N'bepro.store@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'cfa8223f-e40e-4b46-abd2-d5f6bf4513ab', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2fbd3005-2021-4e38-bbe7-0a2c974af89c', N'cfa8223f-e40e-4b46-abd2-d5f6bf4513ab')

");
        }
        
        public override void Down()
        {
        }
    }
}
