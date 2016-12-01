namespace HomeChef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noreviews : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipes", "ReviewID", "dbo.Reviews");
            DropIndex("dbo.Recipes", new[] { "ReviewID" });
            DropColumn("dbo.Recipes", "ReviewID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "ReviewID", c => c.Int(nullable: false));
            CreateIndex("dbo.Recipes", "ReviewID");
            AddForeignKey("dbo.Recipes", "ReviewID", "dbo.Reviews", "ID", cascadeDelete: true);
        }
    }
}
