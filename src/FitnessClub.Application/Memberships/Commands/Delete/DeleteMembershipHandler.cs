using FitnessClub.Infrastructure;

namespace FitnessClub.Application.Memberships.Commands.Delete;

public class DeleteMembershipHandler
{
    private readonly IMembershipRepository _membershipRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteMembershipHandler(IMembershipRepository membershipRepository, IUnitOfWork unitOfWork)
    {
        _membershipRepository = membershipRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<bool> Handle(Guid id, CancellationToken token)
    {
        var membership =await _membershipRepository.GetById(id,token);
        if (membership is null)
        {
             return false;
        }
        await _membershipRepository.Delete(membership);
        await _unitOfWork.SaveChangesAsync(token);
        return true;
    }
}