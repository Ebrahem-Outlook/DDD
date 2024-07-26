using Application.Core.Abstractions.Data;
using Domain.Orders;
using Domain.Products;
using Domain.Users;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastrcure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            string? connection = configuration.GetConnectionString("Local-SqlServer");

            options.UseSqlServer(connection);
        });
        
        services.AddScoped<IDbContext>(serviceProvider => serviceProvider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<ApplicationDbContext>());


        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}
