using Microsoft.AspNetCore.Mvc;
using Trainly.Application.Commands.Workout;
using Trainly.Application.DTOs;
using Trainly.Application.Interfaces;
using Trainly.Application.Queries.GetWorkout;

namespace Trainly.API.Controllers;

/// <summary>
/// Controller responsável pelos endpoints de Treinos
/// Demonstra o padrão CQRS com Commands e Queries
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class WorkoutsController : ControllerBase
{
    private readonly ILogger<WorkoutsController> _logger;
    private readonly ICommandHandler<CreateWorkoutCommand, WorkoutDto> _createHandler;
    private readonly IQueryHandler<GetWorkoutQuery, WorkoutDto> _getHandler;

    public WorkoutsController(
        ILogger<WorkoutsController> logger,
        ICommandHandler<CreateWorkoutCommand, WorkoutDto> createHandler,
        IQueryHandler<GetWorkoutQuery, WorkoutDto> getHandler)
    {
        _createHandler = createHandler;
        _getHandler = getHandler;
        _logger = logger;
    }

    /// <summary>
    /// Busca um treino por ID (QUERY - apenas leitura)
    /// </summary>
    /// <param name="id">ID do treino</param>
    /// <returns>Dados do treino ou 404 se não encontrado</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        int id)
    {
        var query = new GetWorkoutQuery(id);
        var result = await _getHandler.Handle(query);

        if (result == null)
        {
            _logger.LogError("Treino {Id} não encontrado", id);
            return NotFound(new { message = $"Treino com ID {id} não encontrado" });
        }

        return Ok(result);
    }

    /// <summary>
    /// Cria um novo treino (COMMAND - altera estado)
    /// </summary>
    /// <param name="command">Dados do treino a ser criado</param>
    /// <returns>Treino criado com status 201</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateWorkoutCommand command)
    {
        try
        {
            var result = await _createHandler.Handle(command);

            _logger.LogInformation("Treino criado com sucesso: {Id}", result.Id);

            // Retorna 201 Created com location header apontando para o recurso criado
            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Id },
                result);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError("Validação falhou ao criar treino: {Message}", ex.Message);
            return BadRequest(new { message = ex.Message });
        }
    }
}