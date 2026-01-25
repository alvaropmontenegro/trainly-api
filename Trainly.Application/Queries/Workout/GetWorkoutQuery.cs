namespace Trainly.Application.Queries.GetWorkout;

/// <summary>
/// Query para buscar um treino por ID
/// Representa a INTENÇÃO de consultar dados
/// </summary>
public class GetWorkoutQuery
{
    public int Id { get; set; }

    public GetWorkoutQuery(int id)
    {
        Id = id;
    }
}