using FitnessClub.Domain;

namespace FitnessClub.Application.Memberships.Commands.AddMembership;

public record CreateMembershipCommand(
    string Name,
    string Description,
    decimal Price,
    TypeOfMembership TypeOfMembership,
    int Days);