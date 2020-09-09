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
    public class UpdateVoterCommand : IRequest
    {
        public int VoterId { get; set; }
        public VoterForUpdateDto VoterForUpdateDto { get; private set; }

        public UpdateVoterCommand(int voterId, VoterForUpdateDto voterForUpdateDto)
        {
            VoterId = voterId;
            VoterForUpdateDto = voterForUpdateDto;
        }



        internal sealed class UpdateVoterCommandHandler : IRequestHandler<UpdateVoterCommand>
        {
            private readonly IVoterRepository _voterRepository;
            private readonly IMapper _mapper;

            public UpdateVoterCommandHandler(IVoterRepository voterRepository, IMapper mapper)
            {
                _voterRepository = voterRepository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateVoterCommand request, CancellationToken cancellationToken)
            {
                var voterFromDb = await _voterRepository.FindAsync(request.VoterId);

                await _voterRepository.UpdateAgeAsync(request.VoterId, request.VoterForUpdateDto.Age);

                return Unit.Value;
            }
        }
    }
}
