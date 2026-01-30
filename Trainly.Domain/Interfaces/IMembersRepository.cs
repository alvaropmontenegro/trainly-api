using Trainly.Domain.Entities;
namespace Trainly.Domain.Interfaces;

public interface IMembersRepository
{
    //Task<Member?> GetByIdAsync(int id);
    //Task<IEnumerable<Member>> GetAllAsync();
    Task<Member> AddAsync(Member member);
    //Task UpdateAsync(Member member);
    //Task DeleteAsync(int id);
}