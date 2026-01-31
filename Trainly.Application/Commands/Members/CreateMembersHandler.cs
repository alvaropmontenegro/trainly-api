using Microsoft.Extensions.Logging;
using Trainly.Application.DTOs;
using Trainly.Domain.Interfaces;
using Trainly.Domain.Entities;
namespace Trainly.Application.Commands.Members;

public class InsertMembersHandler
{
    private readonly IMembersRepository _repository;
    private readonly ILogger<InsertMembersHandler> _logger;
    public InsertMembersHandler(IMembersRepository repository, ILogger<InsertMembersHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<MembersDto> Handle(InsertMemberCommand command)
    {
        _logger.LogInformation("Iniciando Inserção de membro: {MemberName}", command.FullName);

        if (string.IsNullOrWhiteSpace(command.FullName))
        {
            _logger.LogWarning("Tentativa de criar membro sem nome");
            throw new ArgumentException("O nome completo do membro é obrigatório", nameof(command.FullName));
        }

        var newMember = new Member
        {
            Name = command.FullName,
            Email = command.Email,
            Age = command.Age,
            Identity = command.Identity,
            Plan = command.Plan,
            Fone = command.Fone,
        };
        var insertMember = await _repository.AddAsync(newMember);
        _logger.LogInformation("Membro Inserido com sucesso. ID: {MemberId}", insertMember.Id);
        return new MembersDto
        {
            Id = insertMember.Id,
            Name = insertMember.Name,
            Email = insertMember.Email,
            Age = insertMember.Age,
            Identity = insertMember.Identity,
            Plan = insertMember.Plan,
            Fone = insertMember.Fone
        };
    }
}