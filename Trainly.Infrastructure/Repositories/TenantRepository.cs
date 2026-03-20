using Microsoft.EntityFrameworkCore;
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

    public async Task<Tenant?> GetById(Guid id)
    {
        _logger.LogInformation("Buscando Centro de treinamento pelo Id: {TenantId}", id);

        var tenants = await _context.Tenants
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);
        
        if(tenants is null)
        {
            _logger.LogWarning("Centro de treinamento não encontrado!");
        }

        return tenants;
    }
}