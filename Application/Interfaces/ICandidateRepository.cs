using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICandidateRepository : IRepository<Candidate>
    {
        Task<Candidate> FindByIDNumberAsync(string IDNumber);
        void Remove(Candidate candidate);
    }
}
