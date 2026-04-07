using Microsoft.Extensions.Logging;
using Trainly.Application.Commands.Users;
using Trainly.Application.DTOs;
using Trainly.Application.Interfaces;
using Trainly.Domain.Entities;
using Trainly.Domain.Interfaces;

namespace Trainly.Application.Commands.Users;

public class InsertUserHandler : ICommandHandler<InsertUserCommand, UserDto>
{
    public readonly IUsersRepository _repository;
    private readonly ILogger<InsertUserHandler> _logger;
    private readonly ITenantRepository _tenantRepository;
    public InsertUserHandler(IUsersRepository repository, ILogger<InsertUserHandler> logger, ITenantRepository tenantRepository)
    {
        _repository = repository;
        _logger = logger;
        _tenantRepository = tenantRepository;
    }
    public async Task<UserDto> Handle(InsertUserCommand command)
    {
        //Verificar existência do tenant_id no banco antes de criar o usuário
        var tenantId = await _tenantRepository.GetByIdAsync(command.TenantId);
        if(tenantId is null)
        {
            _logger.LogError("Id do Centro Inválido ou não existe!");
            throw new ArgumentException("Impossivel Inserir um usuário sem um Centro de Treinamento válido");
        }
        

        _logger.LogInformation("Iniciando inserção de usuário: {UserName}", command.Name);

        if (string.IsNullOrEmpty(command.Name))
        {
            _logger.LogError("Tentativa de criar usuário sem nome");
            throw new ArgumentException("O nome do usuário é obrigatório", nameof(command.Name));
        }

        var newUser = new User
        {
            Name = command.Name,
            TenantId = command.TenantId,
            Role = command.Role,
            Email = command.Email,
            Avatar = command.Avatar,
            Password = command.Password,
            Phone = command.Phone,
            Language = command.Language,
            CreatedAt = DateTime.UtcNow
        };

        var existingUser = await _repository.GetByEmailAsync(command.Email);
        if (existingUser != null)
        {
            _logger.LogError("Tentativa de criar usuário com email já existente: {Email}", command.Email);
            throw new ArgumentException("Já existe um usuário com este email", nameof(command.Email));
        }

        var insertUser = await _repository.AddAsync(newUser);

        _logger.LogInformation("Usuário inserido com sucesso. ID: {UserId}", insertUser.Id);
        return new UserDto
        {
            Id = insertUser.Id,
            Name = insertUser.Name,
            TenantId = insertUser.TenantId,
            Role = insertUser.Role,
            Email = insertUser.Email,
            Avatar = insertUser.Avatar,
            Phone = insertUser.Phone,
            Language = insertUser.Language,
            CreatedAt = insertUser.CreatedAt
        };
    }
}