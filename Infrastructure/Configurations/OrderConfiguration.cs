using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(order => order.Id);

        builder.HasAlternateKey(order => order.UserId);

        builder.HasMany(order => order.Products).WithOne();

        builder.Property(order => order.CreatedAt).IsRequired();

        builder.Property(order => order.TotalPrice).IsRequired().HasColumnType("decimal(18, 2)");
    }
}
