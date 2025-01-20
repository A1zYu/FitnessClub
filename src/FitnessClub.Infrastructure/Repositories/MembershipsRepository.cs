using FitnessClub.Application.Memberships;
using FitnessClub.Domain;
using FitnessClub.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace FitnessClub.Infrastructure.Repositories;

public class MembershipsRepository : IMembershipRepository
{
    private readonly ApplicationDbContext _context;
    public MembershipsRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Guid> Add(Membership membership, CancellationToken cancellationToken = default)
    {
        await _context.Memberships.AddAsync(membership,cancellationToken);
        return membership.Id;
    }
    public Task Delete(Membership membership)
    {
        _context.Memberships.Remove(membership);
        return Task.CompletedTask;
    }

    public async Task<Membership?> GetById(Guid id, CancellationToken cancellationToken)
    {
        var membership =await _context.Memberships
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return membership ?? null;
    }
}