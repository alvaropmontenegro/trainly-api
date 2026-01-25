namespace Trainly.Application.Commands.Workout;

/// <summary>
/// Command para criar um novo treino
/// Representa a INTENÇÃO de criar um treino
/// </summary>
public class CreateWorkoutCommand
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string DifficultyLevel { get; set; } = "Iniciante";
    public int DurationMinutes { get; set; }
}