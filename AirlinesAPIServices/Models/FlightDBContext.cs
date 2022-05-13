using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AirlinesAPIServices.Models
{
    public partial class FlightDBContext : DbContext
    {
        public FlightDBContext()
        {
        }

        public FlightDBContext(DbContextOptions<FlightDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FlightDetail> FlightDetails { get; set; }
        public virtual DbSet<BookingDetail> BookingDetails { get; set; }

        public virtual DbSet<Login> Logins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer("Server=JRDOTNETFSECO-2;Initial Catalog=DB2504;Persist Security Info=False;User Id=sa; Password=pass@word1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlightDetail>(entity =>
            {
                entity.HasIndex(e => e.FlightNumber, "IX_FlightDetails")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Airline)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("airline");

                entity.Property(e => e.BusinessSeats).HasColumnName("business Seats");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("Date");

                entity.Property(e => e.FlightNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("flight number");

                entity.Property(e => e.FromPlace)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("from Place");

                entity.Property(e => e.InstrumentUsed)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("instrument Used");

                entity.Property(e => e.Meal)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("meal");

                entity.Property(e => e.NonBusinessSeats).HasColumnName("nonBusiness Seats");

                entity.Property(e => e.Rows).HasColumnName("rows");

                entity.Property(e => e.ScheduledDays)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("scheduled Days");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("status");

                entity.Property(e => e.Tag)
                    .IsRequired()
                    .HasMaxLength(50);
                modelBuilder.Entity<BookingDetail>(entity =>
                {
                    entity.HasKey(e => e.Pnr)
                        .HasName("PK_BookingDetails_1");

                    entity.HasIndex(e => e.Id, "IX_BookingDetails");

                    entity.Property(e => e.Pnr)
                        .HasMaxLength(50)
                        .HasColumnName("PNR");

                    entity.Property(e => e.EmailId)
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnName("email Id");

                    entity.Property(e => e.FlightNumber)
                        .HasMaxLength(50)
                        .HasColumnName("flight Number");

                    entity.Property(e => e.Id).ValueGeneratedOnAdd();

                    entity.Property(e => e.Meal)
                        .HasMaxLength(50)
                        .HasColumnName("meal");

                    entity.Property(e => e.NoOfSeats).HasColumnName("no of Seats");

                    entity.Property(e => e.SeatNo)
                        .HasMaxLength(50)
                        .HasColumnName("seat no");

                    entity.HasOne(d => d.FlightNumberNavigation)
                        .WithMany(p => p.BookingDetails)
                        .HasPrincipalKey(p => p.FlightNumber)
                        .HasForeignKey(d => d.FlightNumber)
                        .HasConstraintName("FK_BookingDetails_FlightDetails");
                });

                modelBuilder.Entity<FlightDetail>(entity =>
                {
                    entity.HasIndex(e => e.FlightNumber, "IX_FlightDetails")
                        .IsUnique();

                    entity.Property(e => e.Id).HasColumnName("id");

                    entity.Property(e => e.Airline)
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnName("airline");

                    entity.Property(e => e.BusinessSeats).HasColumnName("business Seats");

                    entity.Property(e => e.Date)
                        .HasColumnType("datetime")
                        .HasColumnName("date");

                    entity.Property(e => e.FlightNumber)
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnName("flight number");

                    entity.Property(e => e.FromPlace)
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnName("from Place");

                    entity.Property(e => e.InstrumentUsed)
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnName("instrument Used");

                    entity.Property(e => e.Meal)
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnName("meal");

                    entity.Property(e => e.NonBusinessSeats).HasColumnName("nonBusiness Seats");

                    entity.Property(e => e.Rows).HasColumnName("rows");

                    entity.Property(e => e.ScheduledDays)
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnName("scheduled Days");

                    entity.Property(e => e.Status)
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnName("status");

                    entity.Property(e => e.Tag)
                        .IsRequired()
                        .HasMaxLength(50);

                    entity.Property(e => e.TicketCost).HasColumnName("ticket Cost");

                    entity.Property(e => e.ToPlace)
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnName("to Place");
                });

                entity.Property(e => e.TicketCost).HasColumnName("ticket Cost");

                entity.Property(e => e.ToPlace)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("to Place");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.UserName);

                entity.ToTable("Login");

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
