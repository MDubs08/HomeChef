namespace HomeChef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StepsRecipeIngredient : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipes", "IngredientID", "dbo.Ingredients");
            DropIndex("dbo.Recipes", new[] { "IngredientID" });
            CreateTable(
                "dbo.Steps",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Steps = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RecipeIngredients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IngredientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ingredients", t => t.IngredientID, cascadeDelete: true)
                .Index(t => t.IngredientID);
            
            AddColumn("dbo.Instructions", "StepID", c => c.Int(nullable: false));
            AddColumn("dbo.Recipes", "RecipeIngredientID", c => c.Int(nullable: false));
            CreateIndex("dbo.Instructions", "StepID");
            CreateIndex("dbo.Recipes", "RecipeIngredientID");
            AddForeignKey("dbo.Instructions", "StepID", "dbo.Steps", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Recipes", "RecipeIngredientID", "dbo.RecipeIngredients", "ID", cascadeDelete: true);
            DropColumn("dbo.Instructions", "Steps");
            DropColumn("dbo.Recipes", "IngredientID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "IngredientID", c => c.Int(nullable: false));
            AddColumn("dbo.Instructions", "Steps", c => c.String());
            DropForeignKey("dbo.Recipes", "RecipeIngredientID", "dbo.RecipeIngredients");
            DropForeignKey("dbo.RecipeIngredients", "IngredientID", "dbo.Ingredients");
            DropForeignKey("dbo.Instructions", "StepID", "dbo.Steps");
            DropIndex("dbo.RecipeIngredients", new[] { "IngredientID" });
            DropIndex("dbo.Recipes", new[] { "RecipeIngredientID" });
            DropIndex("dbo.Instructions", new[] { "StepID" });
            DropColumn("dbo.Recipes", "RecipeIngredientID");
            DropColumn("dbo.Instructions", "StepID");
            DropTable("dbo.RecipeIngredients");
            DropTable("dbo.Steps");
            CreateIndex("dbo.Recipes", "IngredientID");
            AddForeignKey("dbo.Recipes", "IngredientID", "dbo.Ingredients", "ID", cascadeDelete: true);
        }
    }
}
