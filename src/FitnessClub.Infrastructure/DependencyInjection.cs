using FitnessClub.Application.Memberships;
using FitnessClub.Infrastructure.DbContexts;
using FitnessClub.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessClub.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructures(
        this IServiceCollection service,
        IConfiguration configuration)
    {
        service
            .AddDatabaseContext()
            .AddRepositories()
            .AddDbContexts();

        return service;
    }
    private static IServiceCollection AddDbContexts(this IServiceCollection service)
    {
        service.AddScoped<ApplicationDbContext>();
        return service;
    }
    private static IServiceCollection AddDatabaseContext(this IServiceCollection service)
    {
        service.AddScoped<IUnitOfWork, UnitOfWork>();

        return service;
    }
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IMembershipRepository, MembershipsRepository>();
        return services;
    }
}