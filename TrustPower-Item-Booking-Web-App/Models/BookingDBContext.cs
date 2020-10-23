using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TrustPower_Item_Booking_Web_App.Models
{
    public partial class BookingDBContext : DbContext
    {
        public BookingDBContext()
        {
        }

        public BookingDBContext(DbContextOptions<BookingDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<Applicants> Applicants { get; set; }
        public virtual DbSet<Bookings> Bookings { get; set; }
        public virtual DbSet<Depots> Depots { get; set; }

        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Tracking> Tracking { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.HasKey(e => e.AddressId)
                    .HasName("Addresses_pk")
                    .IsClustered(false);

                entity.HasIndex(e => e.AddressId)
                    .HasName("Addresses_AddressId_uindex")
                    .IsUnique();

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.PostCode)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.StreetName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Suburb)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Applicants>(entity =>
            {
                entity.HasKey(e => e.ApplicantId)
                    .HasName("Applicants_pk")
                    .IsClustered(false);

                entity.HasIndex(e => e.ApplicantId)
                    .HasName("Applicants_ApplicantId_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("Applicants_Email_uindex")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.OrganisationName).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Applicants)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Applicants_Addresses_AddressId_fk");
            });

            modelBuilder.Entity<Bookings>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("Bookings_pk")
                    .IsClustered(false);

                entity.HasIndex(e => e.BookingId)
                    .HasName("Bookings_BookingId_uindex")
                    .IsUnique();

                entity.Property(e => e.DateOfApproval).HasColumnType("date");

                entity.Property(e => e.DateReceived).HasColumnType("date");

                entity.Property(e => e.DisapprovedDescription)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.EvenStatus)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EventDescription)
                    .IsRequired()
                    .HasMaxLength(2048)
                    .IsUnicode(false);

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fees)
                    .HasColumnType("decimal(18, 0)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PickUpDate).HasColumnType("date");

                entity.Property(e => e.ReturnDate).HasColumnType("date");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Bookings_Addresses_AddressId_fk");

                entity.HasOne(d => d.Applicants)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.ApplicantsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Bookings_Applicants_ApplicantId_fk");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("Bookings_Staff_StaffId_fk");
            });

            modelBuilder.Entity<Depots>(entity =>
            {
                entity.HasKey(e => e.DepotId)
                    .HasName("Depots_pk")
                    .IsClustered(false);

                entity.HasIndex(e => e.DepotId)
                    .HasName("Depots_DepotId_uindex")
                    .IsUnique();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);
                               

                entity.Property(e => e.DepotName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.PostCode)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.StreetName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Suburb)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("Items_pk")
                    .IsClustered(false);

                entity.HasIndex(e => e.ItemId)
                    .HasName("Items_ItemId_uindex")
                    .IsUnique();

                entity.Property(e => e.ItemDescription)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Depot)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.DepotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Items_Depots_DepotId_fk");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasKey(e => e.StaffId)
                    .HasName("Staff_pk")
                    .IsClustered(false);

                entity.HasIndex(e => e.StaffId)
                    .HasName("Staff_StaffId_uindex")
                    .IsUnique();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tracking>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.BookingId })
                    .HasName("Tracking_pk")
                    .IsClustered(false);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Tracking)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Tracking_Bookings_BookingId_fk");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Tracking)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Tracking_Items_ItemId_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
