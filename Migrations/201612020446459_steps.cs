namespace HomeChef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class steps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instructions", "Steps", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Instructions", "Steps");
        }
    }
}
