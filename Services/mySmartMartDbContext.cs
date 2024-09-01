using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using myOnlineMart.Models;

namespace myOnlineMart.Services
{
    public class mySmartMartDbContext : IdentityDbContext<AppUser>
    {
        public mySmartMartDbContext(DbContextOptions<mySmartMartDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var admin = new IdentityRole("admin")
            {
                NormalizedName = "ADMIN"
            };

            var customer = new IdentityRole("customer")
            {
                NormalizedName = "CUSTOMER"
            };

            modelBuilder.Entity<IdentityRole>().HasData(admin, customer);
        }
    }
}
