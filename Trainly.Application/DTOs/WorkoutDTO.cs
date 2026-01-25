namespace Trainly.Application.DTOs;

/// <summary>
/// DTO (Data Transfer Object) para transferir dados de Workout
/// Usado para expor apenas os dados necessários pela API
/// </summary>
public class WorkoutDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string DifficultyLevel { get; set; } = string.Empty;
    public int DurationMinutes { get; set; }
    public DateTime CreatedAt { get; set; }
}