using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace rentee.Models
{
    public class MyDBContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Category> Categories{ get; set; }

        public DbSet<Rental> rentals { get; set; }


        public MyDBContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static MyDBContext Create()
        {
            return new MyDBContext();
        }
    }
}