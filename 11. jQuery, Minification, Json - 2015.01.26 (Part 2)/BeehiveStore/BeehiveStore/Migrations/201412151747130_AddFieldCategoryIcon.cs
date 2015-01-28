namespace BeehiveStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldCategoryIcon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Icon", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Icon");
        }
    }
}
