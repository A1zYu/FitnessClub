using FitnessClub.Domain;

namespace FitnessClub.Web.Controllers.Memberships.Request;

public record UpdateInfoRequest(
    string Name,
    string Description,
    decimal Price,
    TypeOfMembership Type,
    int Days
    );