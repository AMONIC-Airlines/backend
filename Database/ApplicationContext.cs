using Database.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Database;

public partial class ApplicationContext : DbContext
{
    public ApplicationContext() { }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Office> Offices { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("utf8mb4_unicode_ci").HasCharSet("utf8mb4");

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
