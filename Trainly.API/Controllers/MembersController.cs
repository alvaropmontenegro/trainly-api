using Microsoft.AspNetCore.Mvc;

namespace Trainly.API.Controllers;

/// <summary>
/// Controller responsável por endpoints relacionados a membros
/// Gerencia operações CRUD e autenticação de membros
/// </summary>
[ApiController]
[Route("api/[controller]")] 

public class MembersController : ControllerBase
{
    //public readonly InsertMembersHandler _insertHandler;
    public readonly ILogger<MembersController> _logger;
    public MembersController(ILogger<MembersController> logger)
    {
        _logger = logger;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register()
    {
        _logger.LogInformation("Endpoint de registro de membro chamado.");
        return Ok();
    }

}