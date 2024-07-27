using Application.Core.Abstractions.Data;
using Domain.Orders;
using Domain.Products;
using Domain.Users;
using Infrastructure.Caching;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastrcure(this IServiceCollection services, IConfiguration configuration)
    {
        // Add DbCotnext service.
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            string? connection = configuration.GetConnectionString("Docker-Postgres");

            options.UseNpgsql(connection);
        });

        services.AddScoped<IDbContext>(serviceProvider => serviceProvider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<ApplicationDbContext>());


        services.AddMemoryCache();

        // Cached User Repository.
        services.AddScoped<UserRepository>();
        services.AddScoped<IUserRepository>(serviceProvider =>
        {
            var decorated = serviceProvider.GetRequiredService<UserRepository>();

            var memoryCache = serviceProvider.GetRequiredService<IMemoryCache>();

            return new CachedUserRepository(decorated, memoryCache);
        });

        // Cached Product Repository.
        services.AddScoped<ProductRepository>();
        services.AddScoped<IProductRepository>(serviceProvider =>
        {
            var decorated = serviceProvider.GetRequiredService<ProductRepository>();

            var memoryCache = serviceProvider.GetRequiredService<IMemoryCache>();

            return new CachedProductRepository(decorated, memoryCache);
        });

        // Cached Order Repository.
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IUserRepository>(serviceProvider =>
        {
            var decorated = serviceProvider.GetRequiredService<UserRepository>();

            var memoryCache = serviceProvider.GetRequiredService<IMemoryCache>();

            return new CachedUserRepository(decorated, memoryCache);
        });

        return services;
    }
}
