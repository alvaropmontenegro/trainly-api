namespace Trainly.API.Configuration.DependencyInjection;

/// <summary>
/// Configurações de CORS
/// </summary>
public static class CorsConfiguration
{
    public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("Development", policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });

            options.AddPolicy("Production", policy =>
            {
                policy.WithOrigins("https://trainly.com")
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .AllowCredentials();
            });
        });

        return services;
    }
}