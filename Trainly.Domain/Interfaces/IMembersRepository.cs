using Trainly.Domain.Entities;
namespace Trainly.Domain.Interfaces;

public interface IMembersRepository
{
    Task<Member> AddAsync(Member member);
}