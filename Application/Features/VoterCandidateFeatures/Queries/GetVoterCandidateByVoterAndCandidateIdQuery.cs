using Application.Dtos.VoterCandidate;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.VoterCandidateFeatures.Queries
{
    public class GetVoterCandidateByVoterAndCandidateIdQuery : IRequest<VoterCandidateDto> 
    {
        public int VoterId { get; private set; }
        public int CandidateId{ get; private set; }

        public GetVoterCandidateByVoterAndCandidateIdQuery(int candidateId, int voterId)
        {
            CandidateId = candidateId;
            VoterId = voterId;
        }


        internal sealed class GetVoterCandidateByVoterAndCandidateIdQueryHandler : IRequestHandler<GetVoterCandidateByVoterAndCandidateIdQuery, VoterCandidateDto>
        {
            private readonly IVoterCandidateRepository _voterCandidateRepository;
            private readonly IMapper _mapper;

            public GetVoterCandidateByVoterAndCandidateIdQueryHandler(IVoterCandidateRepository voterCandidateRepository, IMapper mapper)
            {
                _voterCandidateRepository = voterCandidateRepository;
                _mapper = mapper;
            }



            public async Task<VoterCandidateDto> Handle(GetVoterCandidateByVoterAndCandidateIdQuery request, CancellationToken cancellationToken)
            {
                var voterCandidateFromDb = await _voterCandidateRepository.GetAsync(x => x.CandidateId == request.CandidateId && x.VoterId == request.VoterId);

                var voterCandidateDtoToReturn = _mapper.Map<VoterCandidateDto>(voterCandidateFromDb);

                return voterCandidateDtoToReturn;
            }
        }
    }
}
