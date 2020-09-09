using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CandidateFeatures.Queries
{
    public class GetSharpsForCandidateQuery : IRequest<int>
    {
        public int CandidateId { get; private set; }

        public GetSharpsForCandidateQuery(int candidateId)
        {
            CandidateId = candidateId;
        }


        internal sealed class GetSharpForCandidateQueryHandler : IRequestHandler<GetSharpsForCandidateQuery,int>
        {
            private readonly IVoterCandidateRepository _voterCandidateRepository;
            private readonly IMapper _mapper;

            public GetSharpForCandidateQueryHandler(IVoterCandidateRepository voterCandidateRepository, IMapper mapper)
            {
                _voterCandidateRepository = voterCandidateRepository;
                _mapper = mapper;
            }

            public async Task<int> Handle(GetSharpsForCandidateQuery request, CancellationToken cancellationToken)
            {
                var voterCandidates = await _voterCandidateRepository.GetAllAsync(x => x.CandidateId == request.CandidateId);

                int sharpOfVotes = voterCandidates.Count();

                return sharpOfVotes;
            }
        }
    }
}
