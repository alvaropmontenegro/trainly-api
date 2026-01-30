using Trainly.Application.Commands.Workout;
using Trainly.Application.Queries.GetWorkout;
using Trainly.Domain.Interfaces;
using Trainly.Infrastructure.Repositories;

namespace Trainly.API.Configuration.DependencyInjection;

/// <summary>
/// Configuração de serviços da camada de aplicação
/// </summary>
public static class ApplicationServicesConfig
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Repositories - Scoped (uma instância por requisição)
        services.AddScoped<IWorkoutRepository, WorkoutRepository>();

        // Handlers - Scoped
        services.AddScoped<CreateWorkoutHandler>();
        services.AddScoped<GetWorkoutHandler>();

        return services;
    }
}