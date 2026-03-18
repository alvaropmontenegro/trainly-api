using Microsoft.Extensions.Logging;
using Trainly.Domain.Entities;
using Trainly.Domain.Interfaces;
using Trainly.Infrastructure.Data;
namespace Trainly.Infrastructure.Repositories;

public class TenantRepository : ITenantRepository
{
    private readonly TrainlyDbContext _context;
    private readonly ILogger<TenantRepository> _logger;
    public TenantRepository(TrainlyDbContext context, ILogger<TenantRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<Tenant> AddAsync(Tenant tenant)
    {
        _logger.LogInformation("Inserindo novo Centro de Treinamento: {TenantName}", tenant.Name);

        await _context.Tenants.AddAsync(tenant);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Centro de Treinamento inserido com sucesso. ID: {TenantId}", tenant.Id);
        return tenant;
    }
}