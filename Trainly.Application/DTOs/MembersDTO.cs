namespace Trainly.Application.DTOs;

public class MembersDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    //public DateTime JoinedAt { get; set; }
}