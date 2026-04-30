namespace Trainly.Application.Queries.Tenant;

/// <summary>
/// Query para buscar um centro de treinamento por ID
/// Representa a INTENÇÃO de consultar dados
/// </summary>
public class GetTenantQuery
{
    public Guid Id { get; }

    public GetTenantQuery(Guid id)
    {
        Id = id;
    }
}