using Database.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Database;

public partial class ApplicationContext : DbContext
{
    public ApplicationContext() { }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    public virtual DbSet<Aircraft> Aircrafts { get; set; }

    public virtual DbSet<Airport> Airports { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Office> Offices { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Route> Routes { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("utf8mb4_unicode_ci").HasCharSet("utf8mb4");

        modelBuilder.Entity<Aircraft>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("aircrafts").HasCharSet("utf8mb3").UseCollation("utf8mb3_bin");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("ID");
            entity.Property(e => e.BusinessSeats).HasColumnType("int(11)");
            entity.Property(e => e.EconomySeats).HasColumnType("int(11)");
            entity.Property(e => e.MakeModel).HasMaxLength(10);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.TotalSeats).HasColumnType("int(11)");
        });

        modelBuilder.Entity<Airport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("airports").HasCharSet("utf8mb3").UseCollation("utf8mb3_bin");

            entity.HasIndex(e => e.CountryId, "FK_AirPort_Country");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("ID");
            entity.Property(e => e.CountryId).HasColumnType("int(11)").HasColumnName("CountryID");
            entity.Property(e => e.Iatacode).HasMaxLength(3).HasColumnName("IATACode");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity
                .HasOne(d => d.Country)
                .WithMany(p => p.Airports)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AirPort_Country");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("countries").HasCharSet("utf8mb3").UseCollation("utf8mb3_bin");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Office>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("offices").HasCharSet("utf8mb3").UseCollation("utf8mb3_bin");

            entity.HasIndex(e => e.CountryId, "FK_Office_Country");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("ID");
            entity.Property(e => e.Contact).HasMaxLength(250);
            entity.Property(e => e.CountryId).HasColumnType("int(11)").HasColumnName("CountryID");
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);

            entity
                .HasOne(d => d.Country)
                .WithMany(p => p.Offices)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Office_Country");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("roles").HasCharSet("utf8mb3").UseCollation("utf8mb3_bin");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("ID");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Route>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("routes").HasCharSet("utf8mb3").UseCollation("utf8mb3_bin");

            entity.HasIndex(e => e.DepartureAirportId, "FK_Routes_Airports2");

            entity.HasIndex(e => e.ArrivalAirportId, "FK_Routes_Airports3");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("ID");
            entity
                .Property(e => e.ArrivalAirportId)
                .HasColumnType("int(11)")
                .HasColumnName("ArrivalAirportID");
            entity
                .Property(e => e.DepartureAirportId)
                .HasColumnType("int(11)")
                .HasColumnName("DepartureAirportID");
            entity.Property(e => e.Distance).HasColumnType("int(11)");
            entity.Property(e => e.FlightTime).HasColumnType("int(11)");

            entity
                .HasOne(d => d.ArrivalAirport)
                .WithMany(p => p.RouteArrivalAirports)
                .HasForeignKey(d => d.ArrivalAirportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Routes_Airports3");

            entity
                .HasOne(d => d.DepartureAirport)
                .WithMany(p => p.RouteDepartureAirports)
                .HasForeignKey(d => d.DepartureAirportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Routes_Airports2");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("schedules").HasCharSet("utf8mb3").UseCollation("utf8mb3_bin");

            entity.HasIndex(e => e.AircraftId, "FK_Schedule_AirCraft");

            entity.HasIndex(e => e.RouteId, "FK_Schedule_Routes");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("ID");
            entity.Property(e => e.AircraftId).HasColumnType("int(11)").HasColumnName("AircraftID");
            entity.Property(e => e.FlightNumber).HasMaxLength(10);
            entity.Property(e => e.RouteId).HasColumnType("int(11)").HasColumnName("RouteID");
            entity.Property(e => e.Time).HasColumnType("time");

            entity
                .HasOne(d => d.Aircraft)
                .WithMany(p => p.Schedules)
                .HasForeignKey(d => d.AircraftId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Schedule_AirCraft");

            entity
                .HasOne(d => d.Route)
                .WithMany(p => p.Schedules)
                .HasForeignKey(d => d.RouteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Schedule_Routes");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users").HasCharSet("utf8mb3").UseCollation("utf8mb3_bin");

            entity.HasIndex(e => e.OfficeId, "FK_Users_Offices");

            entity.HasIndex(e => e.RoleId, "FK_Users_Roles");

            entity.Property(e => e.Id).HasColumnType("int(11)").HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.OfficeId).HasColumnType("int(11)").HasColumnName("OfficeID");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.RoleId).HasColumnType("int(11)").HasColumnName("RoleID");

            entity
                .HasOne(d => d.Office)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.OfficeId)
                .HasConstraintName("FK_Users_Offices");

            entity
                .HasOne(d => d.Role)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
