using Application.Dtos;
using Application.Dtos.Voter;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.VoterFeatures.Commands
{
    public class CreateVoterCommand : IRequest<VoterDto>
    {
        private readonly VoterForCreationDto _voterForCreationDto;

        public CreateVoterCommand(VoterForCreationDto voterForCreationDto)
        {
            _voterForCreationDto = voterForCreationDto;
        }


        internal sealed class CreateVoterCommandHandler : IRequestHandler<CreateVoterCommand, VoterDto>
        {

            private readonly IVoterRepository _voterRepository;
            private readonly IMapper _mapper;

            public CreateVoterCommandHandler(IVoterRepository voterRepository, IMapper mapper)
            {
                _voterRepository = voterRepository;
                _mapper = mapper;
            }

            public async Task<VoterDto> Handle(CreateVoterCommand request, CancellationToken cancellationToken)
            {
                var voterEntity = _mapper.Map<Voter>(request._voterForCreationDto);

                await _voterRepository.AddAsync(voterEntity);


                var voterDtoToReturn = _mapper.Map<VoterDto>(voterEntity);

                return voterDtoToReturn;
            }

        }
    }
}
