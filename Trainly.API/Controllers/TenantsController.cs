using Microsoft.AspNetCore.Mvc;
using Trainly.Application.Commands.Tenants;
using Trainly.Application.DTOs;
using Trainly.Application.Interfaces;
using Trainly.Application.Queries.Tenant;

namespace Trainly.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TenantsController : ControllerBase
{
    public readonly ICommandHandler<InsertTenantCommand, TenantDto> _insertHandler;
    public readonly IQueryHandler<GetTenantQuery, TenantDto> _getHandler;
     public readonly IQueryHandler<GetTenantAllQuery, IEnumerable<TenantDto>> _getAllHandler;
    public readonly ILogger<TenantsController> _logger;
    public TenantsController(ICommandHandler<InsertTenantCommand, TenantDto> insertHandler, ILogger<TenantsController> logger,  IQueryHandler<GetTenantQuery, TenantDto> getHandler, IQueryHandler<GetTenantAllQuery, IEnumerable<TenantDto>> getAllHandler)
    {
        _insertHandler = insertHandler;
        _getHandler = getHandler;
        _getAllHandler = getAllHandler;
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

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetTenantQuery(id);
        var result = await _getHandler.Handle(query);

        if(result is null)
        {
            _logger.LogError("Centro {Id} não encontrado", id);
            return NotFound(new { message = $"Centro com ID {id} não encontrado" });
        }

        _logger.LogInformation("Centro encontrado");
        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult?> GetAll()
    {
        var query = new GetTenantAllQuery();
        var result = await _getAllHandler.Handle(query);

        if(result is null)
        {
            _logger.LogError("Lista de Centros não encontrado");
            return null;
        }
        _logger.LogInformation("Lista Centro encontrado");
        return Ok(result);
    }
}