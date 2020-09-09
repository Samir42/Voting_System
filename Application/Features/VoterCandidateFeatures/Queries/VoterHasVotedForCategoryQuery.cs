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
    public class VoterHasVotedForCategoryQuery : IRequest<bool>
    {
        public int VoterId { get; private set; }
        public int CategoryId { get; private set; }

        public VoterHasVotedForCategoryQuery(int voterId, int categoryId)
        {
            VoterId = voterId;
            CategoryId = categoryId;
        }

        internal sealed class VoterHasVoterForCategoryQueryHandler : IRequestHandler<VoterHasVotedForCategoryQuery, bool>
        {
            private readonly IVoterCandidateRepository _voterCandidateRepository;
            private readonly IMapper _mapper;

            public VoterHasVoterForCategoryQueryHandler(IVoterCandidateRepository voterCandidateRepository, IMapper mapper)
            {
                _voterCandidateRepository = voterCandidateRepository;
                _mapper = mapper;
            }

            public async Task<bool> Handle(VoterHasVotedForCategoryQuery request, CancellationToken cancellationToken)
            {
                return await _voterCandidateRepository.ExistsAsync(x => x.VoterId == request.VoterId && x.CategoryId == request.CategoryId);
            }
        }
    }
}
