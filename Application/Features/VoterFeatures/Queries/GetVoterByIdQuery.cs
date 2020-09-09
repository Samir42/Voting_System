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
    public class GetVoterByIdQuery : IRequest<VoterDto>
    {
        public int Id { get; set; }

        public GetVoterByIdQuery(int id)
        {
            Id = id;
        }


        internal sealed class GetVoterByIdQueryHandler : IRequestHandler<GetVoterByIdQuery, VoterDto>
        {
            private readonly IVoterRepository _voterRepository;
            private readonly IMapper _mapper;

            public GetVoterByIdQueryHandler(IVoterRepository voterRepository, IMapper mapper)
            {
                _voterRepository = voterRepository;
                _mapper = mapper;
            }

            public async Task<VoterDto> Handle(GetVoterByIdQuery request, CancellationToken cancellationToken)
            {
                var voterFromDb = await _voterRepository.FindAsync(request.Id);

                var voterAfterMappingToReturn = _mapper.Map<VoterDto>(voterFromDb);

                return voterAfterMappingToReturn;
            }
        }
    }
}
