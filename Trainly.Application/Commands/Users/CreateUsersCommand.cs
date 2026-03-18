using System.ComponentModel.DataAnnotations;
using Trainly.Domain.Enums;
namespace Trainly.Application.Commands.Users;

public class InsertUserCommand
{
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email é obrigatório.")]
    [EmailAddress(ErrorMessage = "Email em formato inválido.")]
    public string Email { get; set; } = string.Empty;

    public string? Password { get; set; }

    [Required(ErrorMessage = "Papel do usuário é obrigatório.")]
    [EnumDataType(typeof(RoleType), ErrorMessage = "Papel do usuário em formato inválido.")]
    public string Role { get; set; } = string.Empty;   

    [Required(ErrorMessage = "Telefone é obrigatório.")]
    [Phone(ErrorMessage = "Telefone em formato inválido.")]
    public string Phone { get; set; } = string.Empty;

    public string? Avatar { get; set; }  
    //public LanguageTypes Language { get; set; }
    public DateTime CreatedAt { get; set; }
}