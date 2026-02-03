namespace Trainly.Domain.Entities;

public class Member
{
   public int Id { get; set; }
   public string Name { get; set; } = string.Empty;
   public int Age { get; set; }
   public string Identity { get; set; } = string.Empty;
   public string Restrictions { get; set; } = string.Empty;
   public string Email { get; set; } = string.Empty;
   public string Phone { get; set; } = string.Empty;
   public string Goal { get; set; } = string.Empty;
   public string Notes { get; set; } = string.Empty;
   public int Registration { get; set; }
   public string Plan { get; set; } = string.Empty;
}