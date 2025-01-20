using FitnessClub.Application.Memberships.Commands.AddMembership;
using FitnessClub.Application.Memberships.Commands.Delete;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessClub.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplications(this IServiceCollection service)
    {
        service.AddScoped<CreateMembershipHandler>();
        service.AddScoped<DeleteMembershipHandler>();
        return service;
    }
}