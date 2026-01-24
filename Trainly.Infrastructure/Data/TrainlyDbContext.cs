using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Trainly.Infrastructure.Data;

/// <summary>
/// Contexto principal do Entity Framework Core
/// Responsável por gerenciar as entidades e a conexão com o banco de dados
/// </summary>
public class TrainlyDbContext : DbContext
{
    // Constructor que recebe as opções de configuração do DbContext
    // Essas opções são injetadas pelo DI Container
    public TrainlyDbContext(DbContextOptions<TrainlyDbContext> options)
        : base(options)
    {
    }

    // DbSets serão adicionados aqui conforme criamos as entidades
    // Exemplo: public DbSet<Workout> Workouts { get; set; }

    /// <summary>
    /// Método chamado quando o modelo está sendo criado
    /// Usado para configurar relacionamentos, índices, constraints, etc.
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurações de entidades serão adicionadas aqui
        // Exemplo: modelBuilder.ApplyConfiguration(new WorkoutConfiguration());
    }
}