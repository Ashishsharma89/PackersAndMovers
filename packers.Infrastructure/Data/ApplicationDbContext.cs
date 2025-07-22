using Microsoft.EntityFrameworkCore;
using Packer.Domain.Entities;
using packers.Domain.Entities;

namespace packers.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<MoveRequest> MoveRequests { get; set; } = null!;
        public DbSet<TrackingEvent> TrackingEvents { get; set; } = null!;
        public DbSet<Driver> Drivers { get; set; } = null!;
        public DbSet<CustomerFormSubmissions> CustomerFormSubmissions { get; set; } = null!;

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

            modelBuilder.Entity<MoveRequest>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.SourceAddress).IsRequired().HasMaxLength(200);
                entity.Property(e => e.DestinationAddress).IsRequired().HasMaxLength(200);
                entity.Property(e => e.MoveDate).IsRequired();
                entity.Property(e => e.Items).IsRequired();
                entity.Property(e => e.Status).IsRequired().HasMaxLength(20);
                entity.Property(e => e.EstimatedPrice).HasColumnType("decimal(18,2)");
                entity.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(20);
                entity.Property(e => e.ValueAddedServices).HasMaxLength(200);
                entity.Property(e => e.SelectedServices).HasMaxLength(200);
                entity.Property(e => e.MoveTime);
                entity.HasOne<User>()
                      .WithMany()
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
} 