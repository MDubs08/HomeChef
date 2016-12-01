namespace HomeChef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class review : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipes", "RecipeReviewID", "dbo.RecipeReviews");
            DropIndex("dbo.Recipes", new[] { "RecipeReviewID" });
            AddColumn("dbo.Recipes", "ReviewID", c => c.Int(nullable: false));
            CreateIndex("dbo.Recipes", "ReviewID");
            AddForeignKey("dbo.Recipes", "ReviewID", "dbo.Reviews", "ID", cascadeDelete: true);
            DropColumn("dbo.Recipes", "RecipeReviewID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "RecipeReviewID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Recipes", "ReviewID", "dbo.Reviews");
            DropIndex("dbo.Recipes", new[] { "ReviewID" });
            DropColumn("dbo.Recipes", "ReviewID");
            CreateIndex("dbo.Recipes", "RecipeReviewID");
            AddForeignKey("dbo.Recipes", "RecipeReviewID", "dbo.RecipeReviews", "ID", cascadeDelete: true);
        }
    }
}
