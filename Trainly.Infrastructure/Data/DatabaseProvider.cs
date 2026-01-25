namespace Trainly.Infrastructure.Data;

/// <summary>
/// Enumerador dos providers de banco de dados suportados
/// </summary>
public enum DatabaseProvider
{
    SQLite,
    SqlServer,
    PostgreSQL,  // Suporte futuro
    MySQL        // Suporte futuro
}