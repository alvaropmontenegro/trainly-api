namespace Trainly.API.Configuration.Middleware;

/// <summary>
/// Configuração do pipeline de requisições HTTP
/// </summary>
public static class PipelineConfiguration
{
    public static WebApplication ConfigureMiddleware(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        var corsPolicy = app.Environment.IsDevelopment() ? "Development" : "Production";
        app.UseCors(corsPolicy);

        return app;
    }

    public static WebApplication ConfigureEndpoints(this WebApplication app)
    {
        app.MapControllers();
        app.MapHealthChecks("/health");

        if (app.Environment.IsDevelopment())
        {
            app.MapGet("/", () => Results.Redirect("/swagger"))
                .ExcludeFromDescription();
        }

        return app;
    }
}