using Trainly.Domain.Enums;
namespace Trainly.Domain.Entities;

public class UserDto 
{
    public Guid Id { get; set; }
    public Guid TenantId {get; set;}
    public Tenant? Tenant {get; set;}
    public RoleType Role { get; set; }  
    public string Name { get; set; } = string.Empty;
    public string Email { get; set;} = string.Empty;
    public string? Avatar { get; set; } 
    public string? PasswordHash { get; set; } 
    public string Phone{ get; set; } = string.Empty;
    public LanguageTypes Language { get; set; }
    public DateTime CreatedAt { get; set; }
}