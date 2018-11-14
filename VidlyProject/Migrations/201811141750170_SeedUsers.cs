namespace VidlyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4257d021-ad91-47bc-ae87-354f0fc181ec', N'administrator@vidlyproject.com', 0, N'ANTYxCJHfvrhr7vIHh7rH4HC1IbN7+4WC9Vp3RFsG9rp5QKiLnbOJcZa4QOblCcCjw==', N'6fff473a-e5d0-4a5b-be32-a9b24e0e4fa0', NULL, 0, 0, NULL, 1, 0, N'administrator@vidlyproject.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4813c706-d9ac-4341-a2ab-df6c1ab89fea', N'admin@vidlyproject.com', 0, N'AA6OUiPznMfnrNyN4YyN09FaYDeClK+1Ik86qOfzfWr18AmExF4LYTUCmeHYh2KevA==', N'62a78fee-54d8-4d05-8dd0-dccaddee5269', NULL, 0, 0, NULL, 1, 0, N'admin@vidlyproject.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8036153b-1019-4bd1-a3d8-58c16878e28a', N'guest@vidlyproject.com', 0, N'AKXR68yaG4ZL1cQZoNQ6OrJ3HEWwh6j+FsBNpHP96/rWoLljJMeQYF8iYVYvEgAYXQ==', N'6187488a-b5c3-4581-b225-553f3bcb80f7', NULL, 0, 0, NULL, 1, 0, N'guest@vidlyproject.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'cc36c6e4-4066-415f-8d11-46eb4f2c49e5', N'CanManageMovie')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'24e1d836-189b-4bed-8a7f-a113bbd4d787', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4257d021-ad91-47bc-ae87-354f0fc181ec', N'24e1d836-189b-4bed-8a7f-a113bbd4d787')


");
        }
        
        public override void Down()
        {
        }
    }
}
