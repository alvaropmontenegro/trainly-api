using Microsoft.EntityFrameworkCore;
using Trainly.Domain.Entities;
<<<<<<< Updated upstream
using Trainly.Infrastructure.Data.Configurations;
=======
>>>>>>> Stashed changes

namespace Trainly.Infrastructure.Data;

/// <summary>
/// Contexto principal do Entity Framework Core
/// Responsável por gerenciar as entidades e a conexão com o banco de dados
/// </summary>
public class TrainlyDbContext : DbContext
{
    public TrainlyDbContext(DbContextOptions<TrainlyDbContext> options)
        : base(options)
    {
    }

    // DbSets - Representam as tabelas do banco
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<User> Users {get; set;}

    /// <summary>
    /// Configuração do modelo usando Fluent API
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Aplica todas as configurações do assembly atual
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TrainlyDbContext).Assembly);
    }
}