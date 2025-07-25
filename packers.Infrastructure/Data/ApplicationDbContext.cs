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
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<CustomerOrders> CustomerOrders { get; set; }
        public DbSet<Tracking> Tracking { get; set; }
        public DbSet<OrderTracking> OrderTrackings { get; set; }
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


            //Orderid Sequences
            modelBuilder.HasSequence<int>("Seq_Orders")
                .StartsAt(1)
                .IncrementsBy(1);

            modelBuilder.Entity<Orders>()
                .Property(t => t.id)
                .HasDefaultValueSql("NEXT VALUE FOR Seq_Orders");

            modelBuilder.Entity<Orders>()
                .Property(t => t.order_id)
                .HasComputedColumnSql("'OID' + RIGHT('000000' + CAST([id] AS VARCHAR), 6)", stored: true);

            modelBuilder.Entity<Orders>()
                .Property(t => t.delivery_date)
                .IsRequired();

            // Configure new driver assignment properties
            modelBuilder.Entity<Orders>()
                .Property(t => t.DriverAssignmentStatus)
                .HasMaxLength(30)
                .HasDefaultValue("NotAssigned");
            modelBuilder.Entity<Orders>()
                .Property(t => t.DriverId)
                .IsRequired(false);
            // Optional: Add FK relationship if you want navigation
            // modelBuilder.Entity<Orders>()
            //     .HasOne<Driver>()
            //     .WithMany()
            //     .HasForeignKey(o => o.DriverId)
            //     .OnDelete(DeleteBehavior.SetNull);


            //CustomerId Sequence
            modelBuilder.HasSequence<int>("Seq_Customer")
                .StartsAt(1)
                .IncrementsBy(1);

            modelBuilder.Entity<Customers>()
                .Property(t => t.id)
                .HasDefaultValueSql("NEXT VALUE FOR Seq_Customer");

            modelBuilder.Entity<Customers>()
                .Property(t => t.customer_id)
                .HasComputedColumnSql("'CUS' + RIGHT('000000' + CAST([id] AS VARCHAR), 6)", stored: true);


            //TrackingId Sequence
            modelBuilder.HasSequence<int>("Seq_Tracking")
                .StartsAt(1)
                .IncrementsBy(1);

            modelBuilder.Entity<Tracking>()
                .Property(t => t.id)
                .HasDefaultValueSql("NEXT VALUE FOR Seq_Tracking");

            modelBuilder.Entity<Tracking>()
                .Property(t => t.tracking_id)
                .HasComputedColumnSql("'TID' + RIGHT('000000' + CAST([id] AS VARCHAR), 6)", stored: true);
        }

    }
}
