using Trainly.Application.Commands.Members;
using Trainly.Application.Commands.Users;
using Trainly.Application.Commands.Workout;
using Trainly.Application.Commands.Tenants;
using Trainly.Application.DTOs;
using Trainly.Application.Interfaces;
using Trainly.Application.Queries.GetWorkout;
using Trainly.Domain.Entities;
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
        services.AddScoped<IMembersRepository, MembersRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<ITenantRepository, TenantRepository>();

        // Handlers - Scoped
        services.AddScoped<ICommandHandler<CreateWorkoutCommand, WorkoutDto>, CreateWorkoutHandler>();
        services.AddScoped<IQueryHandler<GetWorkoutQuery, WorkoutDto>, GetWorkoutHandler>();

        services.AddScoped<ICommandHandler<InsertMemberCommand, MembersDto>, InsertMembersHandler>();

        services.AddScoped<ICommandHandler<InsertTenantCommand, TenantDto>, InsertTenantHandler>();

        services.AddScoped<ICommandHandler<InsertUserCommand, UserDto>, InsertUserHandler>();

        return services;
    }
}