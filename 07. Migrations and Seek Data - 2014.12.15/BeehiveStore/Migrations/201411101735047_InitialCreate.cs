namespace BeehiveStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        StoreID = c.Int(),
                        ParentID = c.Int(),
                        Name = c.String(nullable: false),
                        SeoName = c.String(maxLength: 60),
                        Description = c.String(storeType: "ntext"), // 65536
                        SeoDescription = c.String(maxLength: 180),
                        IsApproved = c.Boolean(),
                        Type = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID)
                .ForeignKey("dbo.Categories", t => t.ParentID)
                .ForeignKey("dbo.Stories", t => t.StoreID)
                .Index(t => t.StoreID)
                .Index(t => t.ParentID);
            
            CreateTable(
                "dbo.Stories",
                c => new
                    {
                        StoreID = c.Int(nullable: false, identity: true),
                        Brand = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Description = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StoreID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "StoreID", "dbo.Stories");
            DropForeignKey("dbo.Categories", "ParentID", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "ParentID" });
            DropIndex("dbo.Categories", new[] { "StoreID" });
            DropTable("dbo.Stories");
            DropTable("dbo.Categories");
        }
    }
}
