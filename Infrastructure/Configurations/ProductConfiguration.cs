using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(product => product.Id);

        builder.HasAlternateKey(product => product.UserId);

        builder.Property(product => product.Name).IsRequired().HasMaxLength(30);

        builder.Property(product => product.Description).IsRequired().HasMaxLength(500);

        builder.Property(product => product.Price).IsRequired().HasColumnType("decimal(18, 2)");

        builder.Property(product => product.CreatedAt).IsRequired();

        builder.Property(product => product.UpdatedAt).IsRequired(false);
    }
}
