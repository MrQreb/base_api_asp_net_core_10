using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WepAPI.Src.Modules.Users.Entities;

namespace WepAPI.Src.Database.Configurations;



/// <summary>
/// Configuración de la entidad User en la base de datos.
/// </summary>
public class UserConfiguration : IEntityTypeConfiguration<User>
{

    /// <summary>
    /// Configura la estructura de la tabla, columnas, índices y restricciones
    /// para la entidad User.
    /// </summary>
    /// <param name="builder">Constructor de la entidad User.</param>
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()"); // mejor rendimiento en índices que NEWID()

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.Property(u => u.IsActive)
            .HasDefaultValue(true);

        builder.Property(u => u.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAdd();

        builder.Property(u => u.UpdatedAt)
            .ValueGeneratedOnUpdate();
    }
}