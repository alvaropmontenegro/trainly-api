using Microsoft.AspNetCore.Mvc;
using Trainly.Application.Commands.Tenants;
using Trainly.Application.DTOs;
using Trainly.Application.Interfaces;


namespace Trainly.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TenantsController : ControllerBase
{
    public readonly ICommandHandler<InsertTenantCommand, TenantDto> _insertHandler;
    public readonly ILogger<TenantsController> _logger;
    public TenantsController(ICommandHandler<InsertTenantCommand, TenantDto> insertHandler, ILogger<TenantsController> logger)
    {
        _insertHandler = insertHandler;
        _logger = logger;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Insert([FromBody] InsertTenantCommand tenant)
    {
        try
        {
            var result = await _insertHandler.Handle(tenant);
            _logger.LogInformation("Centro de Treinamento criado com sucesso: {Id}", result.Id);
            return CreatedAtAction(nameof(Insert), new { id = result.Id }, result);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError("Erro ao registrar Centro de Treinamento: {ErrorMessage}", ex.Message);
            return BadRequest(new { message = "Dados inválidos para registro de Centro de Treinamento." });
        }
    }
}