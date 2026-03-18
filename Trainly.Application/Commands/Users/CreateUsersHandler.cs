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
    public InsertUserHandler(IUsersRepository repository, ILogger<InsertUserHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    public async Task<UserDto> Handle(InsertUserCommand command)
    {
        _logger.LogInformation("Iniciando inserção de usuário: {UserName}", command.Name);

        if (string.IsNullOrEmpty(command.Name))
        {
            _logger.LogError("Tentativa de criar usuário sem nome");
            throw new ArgumentException("O nome do usuário é obrigatório", nameof(command.Name));
        }

        var newUser = new User
        {
            Name = command.Name,
            //Role = command.Role,
            Email = command.Email,
            Avatar = command.Avatar,
            PasswordHash = command.PasswordHash,
            Phone = command.Phone,
            //Language = command.Language,
            CreatedAt = DateTime.UtcNow
        };

        var insertUser = await _repository.AddAsync(newUser);

        _logger.LogInformation("Usuário inserido com sucesso. ID: {UserId}", insertUser.Id);
        return new UserDto
        {
            Id = insertUser.Id,
            Name = insertUser.Name,
            //Role = insertUser.Role,
            Email = insertUser.Email,
            Avatar = insertUser.Avatar,
            Phone = insertUser.Phone,
            //Language = insertUser.Language,
            CreatedAt = insertUser.CreatedAt
        };
    }
}