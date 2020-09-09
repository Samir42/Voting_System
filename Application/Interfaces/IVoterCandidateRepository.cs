using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IVoterCandidateRepository : IRepository<VoterCandidate>
    {
        Task<VoterCandidate> GetAsync(Expression<Func<VoterCandidate, bool>> predicate);
        Task<bool> ExistsAsync(Expression<Func<VoterCandidate, bool>> predicate);
    }
}
