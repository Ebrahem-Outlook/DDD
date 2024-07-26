using Domain.Products;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // Table name.
        builder.ToTable("Products");

        // Primary Key.
        builder.HasKey(product => product.Id);

        // Properties.
        builder.Property(product => product.Name)
               .IsRequired()
               .HasMaxLength(Product.MaxLength_Name);

        builder.Property(product => product.Description)
               .IsRequired()
               .HasMaxLength(Product.MaxLength_Description);

        builder.Property(product => product.Price)
               .IsRequired()
               .HasColumnType("decimal(18,2)");

        builder.Property(product => product.CreatedAt)
               .IsRequired();

        builder.Property(product => product.UpdatedAt)
               .IsRequired(false);

        // Relationships.
        builder.HasOne<User>()
               .WithMany(user => user.Products)
               .HasForeignKey(user => user.Id)
               .OnDelete(DeleteBehavior.Cascade);

        // Ignore domain event.
        builder.Ignore(product => product.DomainEvents);
    }
}
