namespace Shops.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductBrands",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Brand_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Brand_Id })
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Brands", t => t.Brand_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Brand_Id);
            
            AddColumn("dbo.AspNetUsers", "MobilePhone", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductBrands", "Brand_Id", "dbo.Brands");
            DropForeignKey("dbo.ProductBrands", "Product_Id", "dbo.Products");
            DropIndex("dbo.ProductBrands", new[] { "Brand_Id" });
            DropIndex("dbo.ProductBrands", new[] { "Product_Id" });
            DropColumn("dbo.AspNetUsers", "MobilePhone");
            DropTable("dbo.ProductBrands");
            DropTable("dbo.Products");
            DropTable("dbo.Brands");
        }
    }
}
