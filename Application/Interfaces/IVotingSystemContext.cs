using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IVotingSystemContext
    {
        DbSet<Candidate> Candidates { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Voter> Voters { get; set; }
        DbSet<VoterCandidate> VotersCandidates { get; set; }

        Task<int> SaveChangesAsync();
    }
}
