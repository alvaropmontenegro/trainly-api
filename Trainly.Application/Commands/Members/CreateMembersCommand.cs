namespace Trainly.Application.Commands.Members;

///<sumary>
/// Command para criar um novo membro
/// Representa a INTENÇÃO de criar um membro
/// </summary>
public class InsertMemberCommand
{
  public string FullName { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string Identity { get; set; } = string.Empty;
  public int Age { get; set; }
  public string Plan { get; set; } = string.Empty;
  public string Phone { get; set; } = string.Empty;
  public string Goal { get; set; } = string.Empty;
  public string Notes { get; set; } = string.Empty;
}