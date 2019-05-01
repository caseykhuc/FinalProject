namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Bookings", "Package_Id", "dbo.Packages");
            DropIndex("dbo.Bookings", new[] { "Customer_Id" });
            DropIndex("dbo.Bookings", new[] { "Package_Id" });
            RenameColumn(table: "dbo.Bookings", name: "Customer_Id", newName: "CustomerId");
            RenameColumn(table: "dbo.Bookings", name: "Package_Id", newName: "PackageId");
            AlterColumn("dbo.Bookings", "CustomerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Bookings", "PackageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bookings", "CustomerId");
            CreateIndex("dbo.Bookings", "PackageId");
            AddForeignKey("dbo.Bookings", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Bookings", "PackageId", "dbo.Packages", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "PackageId", "dbo.Packages");
            DropForeignKey("dbo.Bookings", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Bookings", new[] { "PackageId" });
            DropIndex("dbo.Bookings", new[] { "CustomerId" });
            AlterColumn("dbo.Bookings", "PackageId", c => c.Int());
            AlterColumn("dbo.Bookings", "CustomerId", c => c.Int());
            RenameColumn(table: "dbo.Bookings", name: "PackageId", newName: "Package_Id");
            RenameColumn(table: "dbo.Bookings", name: "CustomerId", newName: "Customer_Id");
            CreateIndex("dbo.Bookings", "Package_Id");
            CreateIndex("dbo.Bookings", "Customer_Id");
            AddForeignKey("dbo.Bookings", "Package_Id", "dbo.Packages", "Id");
            AddForeignKey("dbo.Bookings", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
