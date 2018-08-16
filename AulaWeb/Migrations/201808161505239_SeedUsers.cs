namespace AulaWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2425c984-b89c-4b10-9897-e5a6aa67f434', N'adm@teste.com', 0, N'AHAtzYQF5H27C6dRdgkI0iZAVmIewcYPtJ57ciZRq+1HwoakRFZ0gsQ3VCySvBVImg==', N'778b0b48-a278-4991-9491-8796016a0a43', NULL, 0, 0, NULL, 1, 0, N'adm@teste.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3a378ea4-ceb9-4658-805d-49a9c562e37c', N'guest@teste.com', 0, N'AJ/LotCFIzawhWvIStDpNBqnYUq0eyzKCd6ByEY7FqdNRqfHk2hKPVhPNkIXjdrAlw==', N'ffd30717-cf54-45e2-8c7b-b841729fcdc7', NULL, 0, 0, NULL, 1, 0, N'guest@teste.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4aead511-a8ec-411f-9d74-6c34543d99aa', N'douglas@asdf.com', 0, N'ABlZGIkSHpeQH11FXcIex6vcZfzC4Bmfiz2Waheg7CHEiJ+0t/vCgdkROf1h55grhQ==', N'423b5e51-d720-455d-9eff-7f543ee89efd', NULL, 0, 0, NULL, 1, 0, N'douglas@asdf.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'86ba39a4-5802-4fa4-a288-60139f569f4a', N'canManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2425c984-b89c-4b10-9897-e5a6aa67f434', N'86ba39a4-5802-4fa4-a288-60139f569f4a')

");
        }
        
        public override void Down()
        {
        }
    }
}
