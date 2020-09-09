using Application.Dtos.Candidate;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CandidateFeatures.Queries
{
    public class GetCandidateByIdQuery : IRequest<CandidateDto>
    {
        public int Id { get; private set; }

        public GetCandidateByIdQuery(int id)
        {
            Id = id;
        }


        internal sealed class GetCandidateByIdQueryHandler : IRequestHandler<GetCandidateByIdQuery, CandidateDto>
        {
            private readonly ICandidateRepository _candidateRepository;
            private readonly IMapper _mapper;

            public GetCandidateByIdQueryHandler(ICandidateRepository candidateRepository, IMapper mapper)
            {
                _candidateRepository = candidateRepository;
                _mapper = mapper;
            }
            public async Task<CandidateDto> Handle(GetCandidateByIdQuery request, CancellationToken cancellationToken)
            {
                var candidateFromDb = await _candidateRepository.FindAsync(request.Id);

                var candidateAfterMappingToReturn = _mapper.Map<CandidateDto>(candidateFromDb);

                return candidateAfterMappingToReturn;
            }
        }
    }
}
