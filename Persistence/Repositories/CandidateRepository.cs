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
    public class CandidateRepository : ICandidateRepository
    {
        private readonly IVotingSystemContext _context;

        public CandidateRepository(IVotingSystemContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Candidate entity)
        {
            await _context.Candidates.AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public Task<bool> ExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Candidate> FindAsync(int id)
        {
            return await _context.Candidates.FindAsync((object)id);
        }

        public async Task<Candidate> FindByIDNumberAsync(string IDNumber)
        {
            return await _context.Candidates.FirstOrDefaultAsync(x => x.IdNumber == IDNumber);
        }

        public async Task<IEnumerable<Candidate>> GetAllAsync(Expression<Func<Candidate, bool>> predicate)
        {
            return await _context.Candidates.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<Candidate>> GetAllAsync()
        {
            return await _context.Candidates.ToListAsync();
        }

        public void Remove(Candidate candidate)
        {
            _context.Candidates.Remove(candidate);

            _context.SaveChangesAsync().Wait();
        }

        public async Task UpdateAsync(Candidate entity)
        {
            _context.Candidates.Update(entity);

            await _context.SaveChangesAsync();
        }
    }
}
