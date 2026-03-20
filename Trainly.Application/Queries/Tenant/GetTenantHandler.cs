using Microsoft.Extensions.Logging;
using Trainly.Application.DTOs;
using Trainly.Application.Interfaces;
using Trainly.Domain.Interfaces;

namespace Trainly.Application.Queries.Tenant;

public class GetTenantHandler : IQueryHandler<GetTenantQuery, TenantDto>
{
    private readonly ITenantRepository _repository;
    private readonly ILogger<GetTenantHandler> _logger;
    public GetTenantHandler(ITenantRepository repository, ILogger<GetTenantHandler> logger)
    {
        _repository = repository;
        _logger = logger;    
    }
    public async Task<TenantDto?> Handle(GetTenantQuery query)
    {
        _logger.LogInformation("Processando a query de busca por id");
        var tenant = await _repository.GetById(query.Id);

        if(tenant is null)
        {
            _logger.LogWarning("Centro de treinamento não encontrado: {TenantId}", query.Id);
            return null;
        }

        _logger.LogInformation("Centro de treinamento encontrado");

        return new TenantDto
        {
            Id = tenant.Id,
            Name = tenant.Name,
            Admin = tenant.Admin,
            Email = tenant.Email,
            Phone = tenant.Phone,
            Address = tenant.Address,
            Plan = tenant.Plan,
            PlanExpirationDate = tenant.PlanExpirationDate,
            Language = tenant.Language,
            Theme = tenant.Theme
        };
    }
}