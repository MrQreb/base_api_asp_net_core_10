using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WepAPI.Src.Modules.Users.Entities;

namespace WepAPI.Src.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{

    //Mapear las entidades
    public DbSet<User> Users => Set<User>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        modelBuilder.Entity<User>();


        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}