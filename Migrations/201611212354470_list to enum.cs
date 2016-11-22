namespace HomeChef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class listtoenum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ingredients", "Measurement", c => c.Int(nullable: false));
            AddColumn("dbo.Equipments", "Temperature", c => c.Int(nullable: false));
            AlterColumn("dbo.Meals", "MealTime", c => c.Int(nullable: false));
            AlterColumn("dbo.Meals", "MealType", c => c.Int(nullable: false));
            AlterColumn("dbo.Meals", "HolidayMeal", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Meals", "HolidayMeal", c => c.String());
            AlterColumn("dbo.Meals", "MealType", c => c.String());
            AlterColumn("dbo.Meals", "MealTime", c => c.String());
            DropColumn("dbo.Equipments", "Temperature");
            DropColumn("dbo.Ingredients", "Measurement");
        }
    }
}
