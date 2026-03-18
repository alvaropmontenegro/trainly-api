<<<<<<< HEAD
// using Microsoft.Extensions.Logging;
// using Trainly.Application.Commands.Tenants;
// using Trainly.Application.DTOs;
// using Trainly.Application.Interfaces;
// using Trainly.Domain.Entities;
// using Trainly.Domain.Interfaces;
// namespace Trainly.Application.Commands.Tenants;

// public class InsertTenantHandler : ICommandHandler<InsertTenantCommand, TenantDto>
// {
//     private readonly ITenantRepository _repository;
//     private readonly ILogger<InsertTenantHandler> _logger;
//     public InsertTenantHandler(ITenantRepository repository, ILogger<InsertTenantHandler> logger)
//     {
//         _repository = repository;
//         _logger = logger;
//     }
//     public async Task<TenantDto> Handle(InsertTenantCommand command)
//     {
//         _logger.LogInformation("Iniciando Inserção de Centro de Treinamento: {TenantName}", command.Name);

//         if (string.IsNullOrWhiteSpace(command.Name))
//         {
//             _logger.LogError("Tentativa de criar Centro de Treinamento sem nome");
//             throw new ArgumentException("O nome do Centro de Treinamento é obrigatório", nameof(command.Name));
//         }

//         var newTenant = new Tenant
//         {
//             Name = command.Name,
//             Email = command.Email,
//             Phone = command.Phone,
//             Address = command.Address,
//             Plan = command.Plan,
//             PlanExpirationDate = command.PlanExpirationDate,
//             Language = command.Language,
//             Theme = command.Theme
//         };

//         var insertTenant = await _repository.AddAsync(newTenant);

//         _logger.LogInformation("Centro de Treinamento Inserido com sucesso. ID: {TenantId}", insertTenant.Id);
//         return new TenantDto
//         {
//             Id = insertTenant.Id,
//             Name = insertTenant.Name,
//             Email = insertTenant.Email,
//             Phone = insertTenant.Phone,
//             Address = insertTenant.Address,
//             Plan = insertTenant.Plan,
//             PlanExpirationDate = insertTenant.PlanExpirationDate,
//             Language = insertTenant.Language,
//             Theme = insertTenant.Theme
//         };
//     }
// }
=======
using Microsoft.Extensions.Logging;
using Trainly.Application.Commands.Tenants;
using Trainly.Application.DTOs;
using Trainly.Application.Interfaces;
using Trainly.Domain.Entities;
using Trainly.Domain.Interfaces;

namespace Trainly.Application.Commands.Tenants;

public class InsertTenantHandler : ICommandHandler<InsertTenantCommand, TenantDto>
{
    private readonly ITenantRepository _repository;
    private readonly ILogger<InsertTenantHandler> _logger;
    public InsertTenantHandler(ITenantRepository repository, ILogger<InsertTenantHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    public async Task<TenantDto> Handle(InsertTenantCommand command)
    {
        _logger.LogInformation("Iniciando Inserção de Centro de Treinamento: {TenantName}", command.Name);

        if (string.IsNullOrWhiteSpace(command.Name))
        {
            _logger.LogError("Tentativa de criar Centro de Treinamento sem nome");
            throw new ArgumentException("O nome do Centro de Treinamento é obrigatório", nameof(command.Name));
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

        var insertTenant = await _repository.AddAsync(newTenant);

        _logger.LogInformation("Centro de Treinamento Inserido com sucesso. ID: {TenantId}", insertTenant.Id);
        return new TenantDto
        {
            Id = insertTenant.Id,
            Name = insertTenant.Name,
            Email = insertTenant.Email,
            Phone = insertTenant.Phone,
            Address = insertTenant.Address,
            Plan = insertTenant.Plan,
            PlanExpirationDate = insertTenant.PlanExpirationDate,
            Language = insertTenant.Language,
            Theme = insertTenant.Theme
        };
    }
}
>>>>>>> 69aa3987ff0113a281cf745946a58eca33dd1d0c
