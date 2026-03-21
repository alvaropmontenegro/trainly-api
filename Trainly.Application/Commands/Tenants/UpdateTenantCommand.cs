using System.ComponentModel.DataAnnotations;
using Trainly.Domain.Enums;

namespace Trainly.Application.Commands.Tenants;

public class UpdateTenantCommand
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Admin { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email é obrigatório.")]
    [EmailAddress(ErrorMessage = "Email em formato inválido.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Telefone é obrigatório.")]
    [Phone(ErrorMessage = "Telefone em formato inválido.")]
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    [Required(ErrorMessage = "Plano é obrigatório.")]
    [EnumDataType(typeof(PlanTypes), ErrorMessage = "Plano inválido.")]
    public PlanTypes Plan { get; set; }

    public DateOnly PlanExpirationDate { get; set; }
    public LanguageTypes Language { get; set; }
    public ThemeTypes Theme { get; set; }
}

