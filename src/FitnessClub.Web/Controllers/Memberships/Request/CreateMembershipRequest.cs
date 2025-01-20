using FitnessClub.Application.Memberships.Commands.AddMembership;
using FitnessClub.Domain;

namespace FitnessClub.Web.Controllers.Memberships.Request;

public record CreateMembershipRequest(
    string Name,
    string Description,
    decimal Price,
    TypeOfMembership TypeOfMembership,
    int Days
)
{
    public CreateMembershipCommand ToCommand() =>new (Name, Description, Price, TypeOfMembership, Days);
};