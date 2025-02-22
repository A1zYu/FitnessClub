﻿namespace FitnessClub.Infrastructure;

public interface IUnitOfWork
{
    public Task SaveChangesAsync(CancellationToken cancellationToken = default);
}