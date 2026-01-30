using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Trainly.Domain.Entities;
using Trainly.Domain.Interfaces;
using Trainly.Infrastructure.Data;

namespace Trainly.Infrastructure.Repositories;

/// <summary>
/// Implementação do repositório de Workouts
/// Responsável pelo acesso aos dados no banco
/// </summary>
public class WorkoutRepository : IWorkoutRepository
{
    private readonly TrainlyDbContext _context;
    private readonly ILogger<WorkoutRepository> _logger;

    public WorkoutRepository(TrainlyDbContext context, ILogger<WorkoutRepository> logger){
        _context = context;
        _logger = logger;
    }

    public async Task<Workout?> GetByIdAsync(int id)
    {
        _logger.LogInformation("Buscando treino com ID: {WorkoutId}", id);

        var workout = await _context.Workouts
            .AsNoTracking() // Melhor performance para consultas read-only
            .FirstOrDefaultAsync(w => w.Id == id && w.IsActive);

        if (workout == null)
        {
            _logger.LogWarning("Treino com ID {WorkoutId} não encontrado", id);
        }

        return workout;
    }

    public async Task<IEnumerable<Workout>> GetAllAsync()
    {
        _logger.LogInformation("Listando todos os treinos ativos");

        return await _context.Workouts
            .AsNoTracking()
            .Where(w => w.IsActive)
            .OrderByDescending(w => w.CreatedAt)
            .ToListAsync();
    }

    public async Task<Workout> AddAsync(Workout workout)
    {
        _logger.LogInformation("Criando novo treino: {WorkoutName}", workout.Name);

        workout.CreatedAt = DateTime.UtcNow;
        workout.IsActive = true;

        await _context.Workouts.AddAsync(workout);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Treino criado com sucesso. ID: {WorkoutId}", workout.Id);

        return workout;
    }

    public async Task UpdateAsync(Workout workout)
    {
        _logger.LogInformation("Atualizando treino ID: {WorkoutId}", workout.Id);

        workout.UpdatedAt = DateTime.UtcNow;

        _context.Workouts.Update(workout);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Treino atualizado com sucesso");
    }

    public async Task DeleteAsync(int id)
    {
        _logger.LogInformation("Removendo treino ID: {WorkoutId}", id);

        var workout = await _context.Workouts.FindAsync(id);

        if (workout != null)
        {
            // Soft delete - apenas marca como inativo
            workout.IsActive = false;
            workout.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            _logger.LogInformation("Treino removido com sucesso");
        }
        else
        {
            _logger.LogWarning("Tentativa de remover treino inexistente: {WorkoutId}", id);
        }
    }
}