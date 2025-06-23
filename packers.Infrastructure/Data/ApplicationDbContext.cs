using Microsoft.EntityFrameworkCore;
using Packer.Domain.Entities;

namespace Packer.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PasswordHash).IsRequired();
                entity.Property(e => e.Role).IsRequired().HasMaxLength(20);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.IsVerified)
                    .IsRequired()
                    .HasDefaultValue(false);

                // Configure reset token properties
                entity.Property(e => e.ResetToken).HasMaxLength(100);
                entity.Property(e => e.ResetTokenExpiry);
                entity.Property(e => e.IsResetTokenUsed)
                    .IsRequired()
                    .HasDefaultValue(false);
            });
        }
    }
} 