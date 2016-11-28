namespace HomeChef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RatingsReview : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "RecipeID", "dbo.Recipes");
            DropIndex("dbo.Reviews", new[] { "RecipeID" });
            CreateTable(
                "dbo.RecipeReviews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AverageRating = c.Int(nullable: false),
                        ReviewID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Reviews", t => t.ReviewID, cascadeDelete: true)
                .Index(t => t.ReviewID);
            
            AddColumn("dbo.Recipes", "RecipeReviewID", c => c.Int(nullable: false));
            CreateIndex("dbo.Recipes", "RecipeReviewID");
            AddForeignKey("dbo.Recipes", "RecipeReviewID", "dbo.RecipeReviews", "ID", cascadeDelete: true);
            DropColumn("dbo.Recipes", "Rating");
            DropColumn("dbo.Reviews", "RecipeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "RecipeID", c => c.Int(nullable: false));
            AddColumn("dbo.Recipes", "Rating", c => c.Int(nullable: false));
            DropForeignKey("dbo.Recipes", "RecipeReviewID", "dbo.RecipeReviews");
            DropForeignKey("dbo.RecipeReviews", "ReviewID", "dbo.Reviews");
            DropIndex("dbo.RecipeReviews", new[] { "ReviewID" });
            DropIndex("dbo.Recipes", new[] { "RecipeReviewID" });
            DropColumn("dbo.Recipes", "RecipeReviewID");
            DropTable("dbo.RecipeReviews");
            CreateIndex("dbo.Reviews", "RecipeID");
            AddForeignKey("dbo.Reviews", "RecipeID", "dbo.Recipes", "ID", cascadeDelete: true);
        }
    }
}
