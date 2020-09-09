using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class VoterRepository : IVoterRepository
    {
        private readonly IVotingSystemContext _context;

        public VoterRepository(IVotingSystemContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Voter entity)
        {
            await _context.Voters.AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public void Delete(Voter entity)
        {
            _context.Voters.Remove(entity);
            _context.SaveChangesAsync().Wait();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Voters.AnyAsync(x => x.Id == id);
        }

        public async Task<Voter> FindAsync(int id)
        {
            return await _context.Voters.FindAsync((object)id);
        }

        public async Task<IEnumerable<Voter>> GetAllAsync()
        {
            return await _context.Voters.ToListAsync();
        }

        public async Task<IEnumerable<Voter>> GetAllAsync(Expression<Func<Voter, bool>> predicate)
        {
            return await _context.Voters.Where(predicate).ToListAsync();
        }

        public async Task UpdateAgeAsync(int voterId, int age)
        {
            var voterFromDb = await _context.Voters.FirstOrDefaultAsync(x => x.Id == voterId);

            voterFromDb.Age = age;

            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(Voter entity)
        {
            throw new NotImplementedException();
        }
    }
}
