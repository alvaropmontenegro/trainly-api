using Trainly.Domain.Entities;
namespace Trainly.Domain.Interfaces;

public interface ITenantRepository
{
    Task<Tenant> AddAsync(Tenant tenant);
    Task UpdateAsync(Tenant tenant);
}