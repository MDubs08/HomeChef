namespace HomeChef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RecipeReviews", "AverageRating", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RecipeReviews", "AverageRating", c => c.Int(nullable: false));
        }
    }
}
