using Domain.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Database;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get;set; }
    public DbSet<Office> Offices { get; set; }
    public DbSet<Country> Countries { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
}
