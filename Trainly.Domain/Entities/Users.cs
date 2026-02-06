using Trainly.Domain.Enums;
namespace Trainly.Domain.Entities;

public class User 
{
    public Guid Id { get; set; }
    public Guid TenantId {get; set;}
    public Tenant? Tenant {get; set;}
    public RoleType Role { get; set; }  //duvida se é necessário enum
    public string Name { get; set; } = string.Empty;
    public string Email { get; set;} = string.Empty;
    public string? Avatar { get; set; } //duvida se é assim
    public string? PasswordHash { get; set; } //duvida se é assim
    public string Phone{ get; set; } = string.Empty;
    public LanguageTypes Language { get; set; }
    public DateTime CreatedAt { get; set; }
}