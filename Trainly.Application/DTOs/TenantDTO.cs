using Trainly.Domain.Enums;

namespace Trainly.Application.DTOs;

public class TenantDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Admin {get; set;} = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public PlanTypes Plan { get; set; }
    public DateOnly PlanExpirationDate { get; set; }
    public LanguageTypes Language { get; set; }
    public ThemeTypes Theme { get; set; }
}