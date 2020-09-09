using Application.Dtos.Candidate;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CandidateFeatures.Queries
{
    public class GetCandidateByIDNumberQuery : IRequest<CandidateDto>
    {
        public  string IDNumber { get; private set; }

        public GetCandidateByIDNumberQuery(string iDNumber)
        {
            IDNumber = iDNumber;
        }

        internal sealed class GetCandidateByIDNumberQueryHandler : IRequestHandler<GetCandidateByIDNumberQuery, CandidateDto>
        {
            private readonly ICandidateRepository _candidateRepository;
            private readonly IMapper _mapper;

            public GetCandidateByIDNumberQueryHandler(ICandidateRepository candidateRepository, IMapper mapper)
            {
                _candidateRepository = candidateRepository;
                _mapper = mapper;
            }



            public async Task<CandidateDto> Handle(GetCandidateByIDNumberQuery request, CancellationToken cancellationToken)
            {
                var candidateFromDb = await _candidateRepository.FindByIDNumberAsync(request.IDNumber);

                var candidateAfterMappingToReturn = _mapper.Map<CandidateDto>(candidateFromDb);

                return candidateAfterMappingToReturn;
            }
        }
    }
}
