namespace rentee.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rentalsa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        dateRented = c.DateTime(nullable: false),
                        dateReturned = c.DateTime(),
                        customer_customerID = c.Int(nullable: false),
                        movie_movieID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.customer_customerID, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.movie_movieID, cascadeDelete: true)
                .Index(t => t.customer_customerID)
                .Index(t => t.movie_movieID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "movie_movieID", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "customer_customerID", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "movie_movieID" });
            DropIndex("dbo.Rentals", new[] { "customer_customerID" });
            DropTable("dbo.Rentals");
        }
    }
}
