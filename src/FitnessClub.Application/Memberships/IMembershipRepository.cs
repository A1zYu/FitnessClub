using FitnessClub.Domain;

namespace FitnessClub.Application.Memberships;

public interface IMembershipRepository
{
    public Task<Guid> Add(Membership membership,CancellationToken cancellationToken);
    public Task Delete(Membership membership);
    public Task<Membership?> GetById(Guid id,CancellationToken cancellationToken);
}