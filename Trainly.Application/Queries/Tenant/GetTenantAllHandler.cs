using Microsoft.Extensions.Logging;
using Trainly.Application.DTOs;
using Trainly.Application.Interfaces;
using Trainly.Domain.Interfaces;

namespace Trainly.Application.Queries.Tenant;

public class GetTenantAllHandler : IQueryHandler<GetTenantAllQuery, IEnumerable<TenantDto>>
{
    private readonly ITenantRepository _repository;
    private readonly ILogger<GetTenantAllHandler> _logger;
    public GetTenantAllHandler(ITenantRepository repository, ILogger<GetTenantAllHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<IEnumerable<TenantDto>> Handle(GetTenantAllQuery query)
    {
        var tenants = await _repository.GetAll();
        var listaDto = new List<TenantDto>();

        foreach(var t in tenants)
        {
            var dto = new TenantDto
            {
                Id = t.Id,
                Name = t.Name
            };
            listaDto.Add(dto);
        }
        return listaDto;
    }
}