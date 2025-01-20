using FitnessClub.Domain;
using FitnessClub.Infrastructure;

namespace FitnessClub.Application.Memberships.Commands.AddMembership;

public class CreateMembershipHandler
{
    private readonly IMembershipRepository _membershipRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateMembershipHandler(IUnitOfWork unitOfWork, IMembershipRepository membershipRepository)
    {
        _unitOfWork = unitOfWork;
        _membershipRepository = membershipRepository;
    }

    public async Task<Guid> Handle(CreateMembershipCommand command, CancellationToken token)
    {
        var membership = Membership.Create(command.Name,command.Description,command.Price,command.TypeOfMembership,command.Days);
        var result =await _membershipRepository.Add(membership,token);
        await _unitOfWork.SaveChangesAsync(token);
        return result;
    }
}