using Microsoft.Extensions.Logging;
using Trainly.Application.DTOs;
using Trainly.Application.Interfaces;
using Trainly.Domain.Interfaces;

namespace Trainly.Application.Queries.GetWorkout;

/// <summary>
/// Handler responsável por processar a query GetWorkoutQuery
/// Busca e retorna os dados de um treino específico
/// </summary>
public class GetWorkoutHandler : IQueryHandler<GetWorkoutQuery, WorkoutDto>
{
    private readonly IWorkoutRepository _repository;
    private readonly ILogger<GetWorkoutHandler> _logger;

    public GetWorkoutHandler(
        IWorkoutRepository repository,
        ILogger<GetWorkoutHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    /// <summary>
    /// Processa a query e retorna o DTO do treino ou null se não encontrado
    /// </summary>
    public async Task<WorkoutDto?> Handle(GetWorkoutQuery query)
    {
        _logger.LogInformation("Processando query GetWorkout para ID: {WorkoutId}", query.Id);

        var workout = await _repository.GetByIdAsync(query.Id);

        if (workout == null)
        {
            _logger.LogInformation("Treino não encontrado: {WorkoutId}", query.Id);
            return null;
        }

        _logger.LogInformation("Treino encontrado: {WorkoutName}", workout.Name);

        // Mapeia Entidade para DTO
        return new WorkoutDto
        {
            Id = workout.Id,
            Name = workout.Name,
            Description = workout.Description,
            DifficultyLevel = workout.DifficultyLevel,
            DurationMinutes = workout.DurationMinutes,
            CreatedAt = workout.CreatedAt
        };
    }
}