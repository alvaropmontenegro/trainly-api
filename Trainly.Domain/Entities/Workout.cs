namespace Trainly.Domain.Entities;

/// <summary>
/// Representa um treino na academia
/// </summary>
public class Workout
{
    /// <summary>
    /// Identificador único do treino
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nome do treino (ex: "Treino A - Peito e Tríceps")
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Descrição detalhada do treino
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Nível de dificuldade (Iniciante, Intermediário, Avançado)
    /// </summary>
    public string DifficultyLevel { get; set; } = "Iniciante";

    /// <summary>
    /// Duração estimada em minutos
    /// </summary>
    public int DurationMinutes { get; set; }

    /// <summary>
    /// Indica se o treino está ativo
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Data de criação do registro
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Data da última atualização
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}