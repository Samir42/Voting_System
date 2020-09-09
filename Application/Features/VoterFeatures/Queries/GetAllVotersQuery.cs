using Application.Dtos.Voter;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.VoterFeatures.Queries
{
    public class GetAllVotersQuery : IRequest<IEnumerable<VoterDto>>
    {
        internal sealed class GetAllVotersQueryHandler : IRequestHandler<GetAllVotersQuery, IEnumerable<VoterDto>>
        {
            private readonly IVoterRepository _voterRepository;
            private readonly IMapper _mapper;

            public GetAllVotersQueryHandler(IMapper mapper, IVoterRepository voterRepository)
            {
                _mapper = mapper;
                _voterRepository = voterRepository;
            }

            public async Task<IEnumerable<VoterDto>> Handle(GetAllVotersQuery request, CancellationToken cancellationToken)
            {
                var votersFromDb = await _voterRepository.GetAllAsync();

                var votersAfterMappingToReturn = _mapper.Map<IEnumerable<VoterDto>>(votersFromDb);

                return votersAfterMappingToReturn;
            }
        }
    }
}
