using Microsoft.AspNetCore.Mvc;
using Trainly.Application.Commands.Members;
using Trainly.Application.DTOs;
using Trainly.Application.Interfaces;

namespace Trainly.API.Controllers;

/// <summary>
/// Controller responsável por endpoints relacionados a membros
/// Gerencia operações CRUD e autenticação de membros
/// </summary>
[ApiController]
[Route("api/[controller]")] 
public class MembersController : ControllerBase
{
    public readonly ICommandHandler<InsertMemberCommand, MembersDto> _insertHandler;
    public readonly ILogger<MembersController> _logger;
    public MembersController(ICommandHandler<InsertMemberCommand, MembersDto> insertHandler, ILogger<MembersController> logger)
    {
        _insertHandler = insertHandler;
        _logger = logger;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Insert([FromBody] InsertMemberCommand member)
    {
        try
        {
            var result = await _insertHandler.Handle(member);
            _logger.LogInformation("Membro criado com sucesso: {Id}", result.Id);
           return CreatedAtAction(nameof(Insert), new { id = result.Id }, result);  
        }
        catch (ArgumentException ex)
        {
            _logger.LogError("Erro ao registrar membro: {ErrorMessage}", ex.Message);
            return BadRequest(new { message = "Dados inválidos para registro de membro." });
        }
    }
}