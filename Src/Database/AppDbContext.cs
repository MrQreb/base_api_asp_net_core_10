using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace WepAPI.Src.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // aplica automáticamente todas las IEntityTypeConfiguration del assembly
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}