using Microsoft.Extensions.Logging;
using Trainly.Application.DTOs;
using Trainly.Application.Interfaces;
using Trainly.Domain.Entities;
using Trainly.Domain.Enums;
using Trainly.Domain.Interfaces;

namespace Trainly.Application.Commands.Tenants;

public class UpdateTenantHandler : ICommandHandler<UpdateTenantCommand, TenantDto>
{
    private readonly ITenantRepository _repository;
    private readonly ILogger<UpdateTenantHandler> _logger;
    public UpdateTenantHandler(ITenantRepository repository, ILogger<UpdateTenantHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    public async Task<TenantDto?> Handle(UpdateTenantCommand command)
    {
        _logger.LogInformation("Iniciando a atualização do Centro");

        var tenant = _repository.GetByIdAsync(command.Id);
        if(tenant is null)
        {
            _logger.LogError("Id inexistente");
            throw new ArgumentException("O Id do Centro de Treinamento não existe", nameof(command.Id));
        }
        var newTenant = new Tenant
        {
            Name = command.Name,
            Email = command.Email,
            Phone = command.Phone,
            Address = command.Address,
            Plan = command.Plan,
            PlanExpirationDate = command.PlanExpirationDate,
            Language = command.Language,
            Theme = command.Theme
        };

    }  
}