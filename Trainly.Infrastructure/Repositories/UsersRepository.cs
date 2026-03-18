using Microsoft.Extensions.Logging;
using Trainly.Domain.Entities;
using Trainly.Domain.Interfaces;
using Trainly.Infrastructure.Data;

namespace Trainly.Infrastructure.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly TrainlyDbContext _context;
    private readonly ILogger<UsersRepository> _logger;
    public UsersRepository(ILogger<UsersRepository> logger, TrainlyDbContext context)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<User> AddAsync(User user)
    {
        _logger.LogInformation("Criando novo usuário: {UserName}", user.Name);

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Usuário criado com sucesso. ID: {UserId}", user.Id);
        return user;
    }
}