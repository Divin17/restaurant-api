using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace RestaurantApi.Models
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options)
            : base(options)
        {
        }

        public DbSet<RestaurantItem> RestaurantItems { get; set; } = null!;
        public DbSet<Owner> Owners { get; set; } = null!;
         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            modelBuilder.Entity<Owner>()
                  .HasMany(b => b.Restaurants)
                  .WithOne();
         }
    }
}