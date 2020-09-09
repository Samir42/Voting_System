using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CandidateFeatures.Queries
{
    public class GetAllCandidatesQuery : IRequest<IEnumerable<Candidate>>
    {
        internal class GetAllCandidatesQueryHandler : IRequestHandler<GetAllCandidatesQuery, IEnumerable<Candidate>>
        {
            private readonly ICandidateRepository _candidateRepository;

            public GetAllCandidatesQueryHandler(ICandidateRepository candidateRepository)
            {
                _candidateRepository = candidateRepository;
            }

            public async Task<IEnumerable<Candidate>> Handle(GetAllCandidatesQuery request, CancellationToken cancellationToken)
            {
                var candidatesFromDb = await _candidateRepository.GetAllAsync();

                return candidatesFromDb;
            }
        }
    }
}
