namespace rentee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelUpdate1 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET availableCopies = numberInStock");
        }
        
        public override void Down()
        {
        }
    }
}
