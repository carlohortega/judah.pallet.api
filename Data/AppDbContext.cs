using Eis.Pallet.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Eis.Pallet.Api.Data 
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Models.Pallet> Pallets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder
                .Entity<AppUser>()
                .HasMany(p => p.Pallets)
                .WithOne(p => p.AppUser!)
                .HasForeignKey(p => p.AppUserId);

            modelBuilder
                .Entity<Models.Pallet>()
                .HasOne(p => p.AppUser)
                .WithMany(p => p.Pallets)
                .HasForeignKey(p => p.AppUserId);  

        }
    }
}