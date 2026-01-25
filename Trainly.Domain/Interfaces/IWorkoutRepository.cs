using Trainly.Domain.Entities;

namespace Trainly.Domain.Interfaces;

/// <summary>
/// Contrato para operações de acesso a dados de Workouts
/// </summary>
public interface IWorkoutRepository
{
    /// <summary>
    /// Busca um treino por ID
    /// </summary>
    Task<Workout?> GetByIdAsync(int id);

    /// <summary>
    /// Lista todos os treinos ativos
    /// </summary>
    Task<IEnumerable<Workout>> GetAllAsync();

    /// <summary>
    /// Adiciona um novo treino
    /// </summary>
    Task<Workout> AddAsync(Workout workout);

    /// <summary>
    /// Atualiza um treino existente
    /// </summary>
    Task UpdateAsync(Workout workout);

    /// <summary>
    /// Remove um treino (soft delete - marca como inativo)
    /// </summary>
    Task DeleteAsync(int id);
}