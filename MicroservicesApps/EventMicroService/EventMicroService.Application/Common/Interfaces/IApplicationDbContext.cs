using EventMicroService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventMicroService.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Category> Categories { get; }
    DbSet<Event> Events { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
