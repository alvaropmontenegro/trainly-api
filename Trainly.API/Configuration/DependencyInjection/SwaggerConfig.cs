namespace Trainly.API.Configuration.DependencyInjection;

/// <summary>
/// Configurações do Swagger/OpenAPI
/// </summary>
public static class SwaggerConfig
{
    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new()
            {
                Title = "Trainly API",
                Version = "v1",
                Description = "API para gerenciamento de treinos e academias",
                Contact = new()
                {
                    Name = "Trainly Team",
                    Email = "contato@trainly.com"
                }
            });
        });

        return services;
    }

    public static WebApplication UseSwaggerDocumentation(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
            return app;

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Trainly API V1");
            c.DocumentTitle = "Trainly API - Documentação";
        });

        return app;
    }
}