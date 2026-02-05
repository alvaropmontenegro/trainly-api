using Trainly.Domain.Enums;
namespace Trainly.Domain.Entities;

public class Tenant
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Admin { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public Plantypes Plan { get; set; } //duvida sobre o plano, se é string ou enum
    public DateOnly PlanExpirationDate { get; set; } 
    public LanguageTypes Language { get; set; } //duvida sobre o idioma, se é string ou enum
    public string Theme { get; set; } = default!; //duvida sobre o tema, se é string ou enum
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}