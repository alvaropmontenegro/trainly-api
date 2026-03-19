using Microsoft.AspNetCore.Mvc;
using Trainly.Application.Commands.Users;
using Trainly.Application.Interfaces;
using Trainly.Domain.Entities;

namespace Trainly.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ICommandHandler<InsertUserCommand, UserDto> _insertHandler;
    private readonly ILogger<UsersController> _logger;
    public UsersController(ICommandHandler<InsertUserCommand, UserDto> insertHandler, ILogger<UsersController> logger)
    {
        _insertHandler = insertHandler;
        _logger = logger;
    }

    [HttpPost("/users")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Insert([FromBody] InsertUserCommand user)
    {
        try
        {
            var result = await _insertHandler.Handle(user);
            _logger.LogInformation("Usuário criado com sucesso: {Id}", result.Id);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError("Erro ao registrar usuário: {ErrorMessage}", ex.Message);
            return BadRequest(new { message = ex.Message }); 
}
    }
}