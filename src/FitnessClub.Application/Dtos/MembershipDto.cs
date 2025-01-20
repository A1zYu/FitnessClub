using FitnessClub.Domain;

namespace FitnessClub.Application.Dtos;

public record MembershipDto(string Name,string Description,decimal Price,TypeOfMembership TypeOfMembership,int Days);