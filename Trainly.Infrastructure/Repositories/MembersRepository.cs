using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Trainly.Domain.Entities;
using Trainly.Domain.Interfaces;
using Trainly.Infrastructure.Data;
namespace Trainly.Infrastructure.Repositories;

public class MembersRepository : IMembersRepository
{
    private readonly TrainlyDbContext _context;
    private readonly ILogger<MembersRepository> _logger;
}