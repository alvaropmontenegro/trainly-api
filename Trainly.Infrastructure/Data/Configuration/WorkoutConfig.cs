using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trainly.Domain.Entities;

namespace Trainly.Infrastructure.Data.Configurations;

/// <summary>
/// Configuração do Entity Framework para a entidade Workout
/// Usando Fluent API ao invés de Data Annotations
/// </summary>
public class WorkoutConfig : IEntityTypeConfiguration<Workout>
{
    public void Configure(EntityTypeBuilder<Workout> builder)
    {
        // Nome da tabela no banco
        builder.ToTable("Workouts");

        // Chave primária
        builder.HasKey(w => w.Id);

        // Configuração das colunas
        builder.Property(w => w.Name)
            .IsRequired()
            .HasMaxLength(200)
            .HasComment("Nome do treino");

        builder.Property(w => w.Description)
            .HasMaxLength(1000)
            .HasComment("Descrição detalhada do treino");

        builder.Property(w => w.DifficultyLevel)
            .IsRequired()
            .HasMaxLength(50)
            .HasDefaultValue("Iniciante")
            .HasComment("Nível de dificuldade");

        builder.Property(w => w.DurationMinutes)
            .IsRequired()
            .HasComment("Duração estimada em minutos");

        builder.Property(w => w.IsActive)
            .IsRequired()
            .HasDefaultValue(true)
            .HasComment("Indica se o treino está ativo");

        builder.Property(w => w.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()")
            .HasComment("Data de criação");

        builder.Property(w => w.UpdatedAt)
            .HasComment("Data da última atualização");

        // Índices para melhorar performance de consultas
        builder.HasIndex(w => w.IsActive);
        builder.HasIndex(w => w.CreatedAt);
    }
}