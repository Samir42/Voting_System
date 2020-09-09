using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IVoterRepository : IRepository<Voter>
    {
        Task UpdateAgeAsync(int voterId, int age);
        void Delete(Voter entity);
    }
}
