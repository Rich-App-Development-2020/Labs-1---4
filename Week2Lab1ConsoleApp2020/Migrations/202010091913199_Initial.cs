namespace Week2Lab1ConsoleApp2020.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateFirstissued = c.DateTime(nullable: false),
                        Description = c.String(),
                        UnitPrice = c.Single(nullable: false),
                        QuantityInStock = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.SupplierProducts",
                c => new
                    {
                        SupplierID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        DateFirstSupplied = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.SupplierID, t.ProductID })
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierID, cascadeDelete: true)
                .Index(t => t.SupplierID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(),
                        SupplierAddressLine1 = c.String(),
                        SupplierAddressLine2 = c.String(),
                    })
                .PrimaryKey(t => t.SupplierID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SupplierProducts", "SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.SupplierProducts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.SupplierProducts", new[] { "ProductID" });
            DropIndex("dbo.SupplierProducts", new[] { "SupplierID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.SupplierProducts");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
