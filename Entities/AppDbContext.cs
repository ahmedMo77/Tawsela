using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Tawsela.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Contract
            modelBuilder.Entity<Contract>()
                .HasOne(c => c.BusinessOwner)
                .WithMany()
                .HasForeignKey(c => c.BusinessOwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contract>()
                .HasOne(c => c.ShippingCompany)
                .WithMany()
                .HasForeignKey(c => c.ShippingCompanyId)
                .OnDelete(DeleteBehavior.Restrict);


            // Shipment
            modelBuilder.Entity<Shipment>()
                .HasOne(s => s.Sender)
                .WithMany()
                .HasForeignKey(s => s.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Shipment>()
                .HasOne(s => s.Courier)
                .WithMany()
                .HasForeignKey(s => s.CourierId)
                .OnDelete(DeleteBehavior.Restrict);


            // Review
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Reviewer)
                .WithMany()
                .HasForeignKey(r => r.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.ReviewedUser)
                .WithMany()
                .HasForeignKey(r => r.ReviewedUserId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);
        }

    }
}
