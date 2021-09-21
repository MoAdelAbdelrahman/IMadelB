namespace rentee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "availableCopies", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "availableCopies");
        }
    }
}
