using Microsoft.Extensions.Logging;
//using Trainly.Application.Commands.Members;
using Trainly.Application.DTOs;
using Trainly.Domain.Interfaces;
using Trainly.Domain.Entities;
namespace Trainly.Application.Commands.Members;

public class CreateMembersHandler
{
    private readonly IMembersRepository _repository;
    private readonly ILogger<CreateMembersHandler> _logger;

}