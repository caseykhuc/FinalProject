namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seedusers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'043865f1-ce3c-4555-b9cc-f27c98975180', N'guest@gmail.com', 0, N'AJLP/kHxcF1ieB3L6JdA6Y53kaycpkZizp41GIDnCsdRQhUL2bS4YIk6GVEfaqDQuQ==', N'baf3d531-ba44-4b7b-916f-abc8b9bebdde', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6cfe5f7d-f776-453b-8037-eadf745b99ab', N'admin@gmail.com', 0, N'ANj56O6ea4ZM1o8/VDLsEBzX3m8l+AQfYTXpwyqNuDhcMSkYnbWQFA3hvkNqoca49g==', N'8d9f7890-9b19-42ba-9e24-55a89488c54b', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'280eb6c4-3953-41e3-937d-5ea25254e810', N'CanManagePackages')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6cfe5f7d-f776-453b-8037-eadf745b99ab', N'280eb6c4-3953-41e3-937d-5ea25254e810')
");
        
}
        
        public override void Down()
        {
        }
    }
}
