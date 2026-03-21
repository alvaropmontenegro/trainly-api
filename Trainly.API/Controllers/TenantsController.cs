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

    [HttpPut("{id:Guid}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(UpdateTenantCommand tenant, Guid id)
    {
        if (Guid.Empty(id))
        {
            _logger.LogError("Formato de Id Invalido: {TenantId}", id);
            return BadRequest(new {message = "Id em formato invalido"});
        }
        else if(id != tenant.Id)
        {
            _logger.LogError("Erro ao procurar o Id: {TenantId}", id);
            return NotFound(new {message = "Id não existe no banco de dados"});
        }

        //fazer a logica para atualizar se passou nos ids

    }
}
