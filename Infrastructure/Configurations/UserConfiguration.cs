using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);

        builder.Property(user => user.FirstName).IsRequired().HasMaxLength(30);

        builder.Property(user => user.LastName).IsRequired().HasMaxLength(30);

        builder.Property(user => user.Email).IsRequired().HasMaxLength(30);

        builder.Property(user => user.Password).IsRequired().HasMaxLength(30);
    }
}
