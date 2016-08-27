namespace ToyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        cartID = c.Int(nullable: false, identity: true),
                        itemID = c.Int(nullable: false),
                        userID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.cartID)
                .ForeignKey("dbo.Items", t => t.itemID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.userID, cascadeDelete: true)
                .Index(t => t.itemID)
                .Index(t => t.userID);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        itemID = c.Int(nullable: false, identity: true),
                        itemName = c.String(),
                        itemCost = c.Single(nullable: false),
                        itemFileName = c.String(),
                        itemQuantitySold = c.Int(nullable: false),
                        itemQuantityStock = c.Int(nullable: false),
                        itemDescription = c.String(),
                        categoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.itemID)
                .ForeignKey("dbo.Categories", t => t.categoryID, cascadeDelete: true)
                .Index(t => t.categoryID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        categoryID = c.Int(nullable: false, identity: true),
                        categoryName = c.String(),
                    })
                .PrimaryKey(t => t.categoryID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userID = c.Int(nullable: false, identity: true),
                        userName = c.String(nullable: false, maxLength: 32),
                        userPassword = c.String(nullable: false, maxLength: 32),
                        userConfirmPassword = c.String(nullable: false),
                        userEmail = c.String(nullable: false, maxLength: 256),
                        userGuest = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.userID)
                .Index(t => t.userName, unique: true)
                .Index(t => t.userEmail, unique: true);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        saleID = c.Int(nullable: false, identity: true),
                        itemID = c.Int(nullable: false),
                        saleDiscount = c.Single(nullable: false),
                        saleStart = c.DateTime(nullable: false),
                        saleEnd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.saleID)
                .ForeignKey("dbo.Items", t => t.itemID, cascadeDelete: true)
                .Index(t => t.itemID);
            

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "itemID", "dbo.Items");
            DropForeignKey("dbo.Carts", "userID", "dbo.Users");
            DropForeignKey("dbo.Carts", "itemID", "dbo.Items");
            DropForeignKey("dbo.Items", "categoryID", "dbo.Categories");
            DropIndex("dbo.Sales", new[] { "itemID" });
            DropIndex("dbo.Users", new[] { "userEmail" });
            DropIndex("dbo.Users", new[] { "userName" });
            DropIndex("dbo.Items", new[] { "categoryID" });
            DropIndex("dbo.Carts", new[] { "userID" });
            DropIndex("dbo.Carts", new[] { "itemID" });
            DropTable("dbo.Sales");
            DropTable("dbo.Users");
            DropTable("dbo.Categories");
            DropTable("dbo.Items");
            DropTable("dbo.Carts");
        }
    }
}
