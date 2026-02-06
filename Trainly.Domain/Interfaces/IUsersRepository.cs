using Trainly.Domain.Entities;
namespace Trainly.Domain.Interfaces;

public interface IUsersRepository
{
    Task<User> AddAsync(User user);
}