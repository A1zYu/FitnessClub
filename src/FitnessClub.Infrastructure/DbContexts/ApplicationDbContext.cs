using FitnessClub.Domain;
using FitnessClub.Infrastructure.Configurations.Write;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FitnessClub.Infrastructure.DbContexts;

public class ApplicationDbContext(IConfiguration configuration) : DbContext
{
    public const string DATABASE = "fitnessClubDb";
    public DbSet<Membership> Memberships => Set<Membership>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(configuration.GetConnectionString(DATABASE));
        optionsBuilder.UseLoggerFactory(CreateLoggerFactory);
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.UseSnakeCaseNamingConvention();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly,
            type=>type.FullName?.Contains("Configurations.Write") ?? false);
        base.OnModelCreating(modelBuilder);
    }
    private ILoggerFactory CreateLoggerFactory =>
        LoggerFactory.Create(builder => { builder.AddConsole(); });
}