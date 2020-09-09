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
    public class VoterCandidateRepository : IVoterCandidateRepository
    {
        private readonly IVotingSystemContext _context;

        public VoterCandidateRepository(IVotingSystemContext context)
        {
            _context = context;
        }

        public async Task AddAsync(VoterCandidate entity)
        {
            await _context.VotersCandidates.AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.VotersCandidates.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> ExistsAsync(Expression<Func<VoterCandidate, bool>> predicate)
        {
            return await _context.VotersCandidates.AnyAsync(predicate);
        }

        public  async Task<VoterCandidate> FindAsync(int id)
        {
            return await _context.VotersCandidates.FindAsync(id);
        }

        public async Task<IEnumerable<VoterCandidate>> GetAllAsync()
        {
            return await _context.VotersCandidates.ToListAsync();
        }

        public async Task<IEnumerable<VoterCandidate>> GetAllAsync(Expression<Func<VoterCandidate, bool>> predicate)
        {
            return await _context.VotersCandidates.Where(predicate).ToListAsync();
        }

        public async Task<VoterCandidate> GetAsync(Expression<Func<VoterCandidate, bool>> predicate)
        {
            return await _context.VotersCandidates.FirstOrDefaultAsync(predicate);
        }

        public Task UpdateAsync(VoterCandidate entity)
        {
            throw new NotImplementedException();
        }
    }
}
