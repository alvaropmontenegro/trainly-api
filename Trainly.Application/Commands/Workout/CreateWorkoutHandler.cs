using Microsoft.Extensions.Logging;
using Trainly.Application.Commands.Workout;
using Trainly.Application.DTOs;
using Trainly.Domain.Entities;
using Trainly.Domain.Interfaces;

namespace Trainly.Application.Commands.CreateWorkout;

/// <summary>
/// Handler responsável por processar o comando CreateWorkoutCommand
/// Contém a lógica de negócio para criar um treino
/// </summary>
public class CreateWorkoutHandler
{
    private readonly IWorkoutRepository _repository;
    private readonly ILogger<CreateWorkoutHandler> _logger;

    public CreateWorkoutHandler(
        IWorkoutRepository repository,
        ILogger<CreateWorkoutHandler> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    /// <summary>
    /// Processa o comando e retorna o DTO do treino criado
    /// </summary>
    public async Task<WorkoutDto> Handle(CreateWorkoutCommand command)
    {
        _logger.LogInformation("Iniciando criação de treino: {WorkoutName}", command.Name);

        // Validações de negócio
        if (string.IsNullOrWhiteSpace(command.Name))
        {
            _logger.LogWarning("Tentativa de criar treino sem nome");
            throw new ArgumentException("O nome do treino é obrigatório", nameof(command.Name));
        }

        if (command.DurationMinutes <= 0)
        {
            _logger.LogWarning("Tentativa de criar treino com duração inválida: {Duration}",
                command.DurationMinutes);
            throw new ArgumentException("A duração deve ser maior que zero",
                nameof(command.DurationMinutes));
        }

        // Mapeia Command para Entidade
        var workout = new Workout
        {
            Name = command.Name,
            Description = command.Description,
            DifficultyLevel = command.DifficultyLevel,
            DurationMinutes = command.DurationMinutes
        };

        // Persiste no banco
        var createdWorkout = await _repository.AddAsync(workout);

        _logger.LogInformation("Treino criado com sucesso. ID: {WorkoutId}", createdWorkout.Id);

        // Mapeia Entidade para DTO
        return new WorkoutDto
        {
            Id = createdWorkout.Id,
            Name = createdWorkout.Name,
            Description = createdWorkout.Description,
            DifficultyLevel = createdWorkout.DifficultyLevel,
            DurationMinutes = createdWorkout.DurationMinutes,
            CreatedAt = createdWorkout.CreatedAt
        };
    }
}