using Microsoft.Extensions.Logging;
using Trainly.Domain.Entities;
using Trainly.Domain.Interfaces;
using Trainly.Infrastructure.Data;
namespace Trainly.Infrastructure.Repositories;

public class MembersRepository : IMembersRepository
{
    private readonly TrainlyDbContext _context;
    private readonly ILogger<MembersRepository> _logger;
    public MembersRepository(TrainlyDbContext context, ILogger<MembersRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<Member> AddAsync(Member member)
    {
        _logger.LogInformation("Inserindo novo membro: {MemberName}", member.Name);

        await _context.Members.AddAsync(member);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Membro inserido com sucesso. ID: {MemberId}", member.Id);
        return member;
    }
}