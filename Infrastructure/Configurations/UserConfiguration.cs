using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Table name.
        builder.ToTable("Users");

        // Primary key.
        builder.HasKey(user => user.Id);

        // properties.
        builder.Property(user => user.FirstName)
               .IsRequired()
               .HasMaxLength(User.MaxLength);

        builder.Property(user => user.LastName)
               .IsRequired()
               .HasMaxLength(User.MaxLength);

        builder.Property(user => user.Email)
               .IsRequired()
               .HasMaxLength(User.MaxLength);

        builder.Property(user => user.Password)
               .IsRequired()
               .HasMaxLength(User.MaxLength);

        // Relationships.
        builder.HasMany(user => user.Orders)
               .WithOne()
               .HasForeignKey("UserId")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(user => user.Products)
               .WithOne()
               .HasForeignKey("UserId")
               .OnDelete(DeleteBehavior.Cascade);

        // Ignore domain events.
        builder.Ignore(user => user.DomainEvents);

        // Private collections.
        builder.Metadata.FindNavigation(nameof(User.Orders))!
                        .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Metadata.FindNavigation(nameof(User.Products))!
                        .SetPropertyAccessMode(PropertyAccessMode.Field); 
    }
}
