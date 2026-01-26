using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Trainly.Infrastructure.Data;


namespace Trainly.API.Configuration.DependencyInjection;

/// <summary>
/// Configurações relacionadas ao banco de dados
/// Suporta múltiplos providers com detecção automática
/// </summary>
public static class DatabaseConfig
{
    public static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException(
                "Connection string 'DefaultConnection' não encontrada");
        }

        // Detecta o provider automaticamente
        var provider = DetectDatabaseProvider(connectionString);

        // Configura o DbContext baseado no provider detectado
        services.AddDbContext<TrainlyDbContext>(options =>
        {
            ConfigureDbContext(options, provider, connectionString);
        });

        // Log do provider detectado (útil para debug)
        Console.WriteLine($"[Database] Provider detectado: {provider}");
        Console.WriteLine($"[Database] Connection String: {MaskConnectionString(connectionString)}");

        return services;
    }

    /// <summary>
    /// Detecta qual provider usar baseado na connection string
    /// </summary>
    private static DatabaseProvider DetectDatabaseProvider(string connectionString)
    {
        // SQLite: "Data Source=arquivo.db"
        if (connectionString.Contains("Data Source=", StringComparison.OrdinalIgnoreCase) &&
            !connectionString.Contains("Server=", StringComparison.OrdinalIgnoreCase) &&
            connectionString.EndsWith(".db", StringComparison.OrdinalIgnoreCase))
        {
            return DatabaseProvider.SQLite;
        }

        // SQL Server: "Server=..." ou "Data Source=...;Database=..."
        if (connectionString.Contains("Server=", StringComparison.OrdinalIgnoreCase) ||
            (connectionString.Contains("Data Source=", StringComparison.OrdinalIgnoreCase) &&
             connectionString.Contains("Database=", StringComparison.OrdinalIgnoreCase)))
        {
            return DatabaseProvider.SqlServer;
        }

        // PostgreSQL: "Host=..." (suporte futuro)
        if (connectionString.Contains("Host=", StringComparison.OrdinalIgnoreCase))
        {
            return DatabaseProvider.PostgreSQL;
        }

        throw new NotSupportedException(
            $"Connection string não reconhecida. Providers suportados: SQLite, SQL Server");
    }

    /// <summary>
    /// Configura o DbContext baseado no provider
    /// </summary>
    private static void ConfigureDbContext(
        DbContextOptionsBuilder options,
        DatabaseProvider provider,
        string connectionString)
    {
        switch (provider)
        {
            case DatabaseProvider.SQLite:
                options.UseSqlite(
                    connectionString,
                    sqlOptions => sqlOptions.MigrationsAssembly("Trainly.Infrastructure")
                );
                break;

            case DatabaseProvider.SqlServer:
                options.UseSqlServer(
                    connectionString,
                    sqlOptions => sqlOptions.MigrationsAssembly("Trainly.Infrastructure")
                );
                break;

            case DatabaseProvider.PostgreSQL:
                // Suporte futuro
                throw new NotImplementedException("PostgreSQL ainda não implementado");

            case DatabaseProvider.MySQL:
                // Suporte futuro
                throw new NotImplementedException("MySQL ainda não implementado");

            default:
                throw new NotSupportedException($"Provider {provider} não suportado");
        }
    }

    /// <summary>
    /// Mascara informações sensíveis da connection string para logs
    /// </summary>
    private static string MaskConnectionString(string connectionString)
    {
        // Esconde passwords em logs
        if (connectionString.Contains("Password=", StringComparison.OrdinalIgnoreCase))
        {
            var parts = connectionString.Split(';');
            var masked = parts.Select(part =>
                part.Contains("Password=", StringComparison.OrdinalIgnoreCase)
                    ? "Password=***"
                    : part
            );
            return string.Join(";", masked);
        }

        return connectionString;
    }
}