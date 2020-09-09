using Application.Dtos.Voter;
using Application.Dtos.VoterCandidate;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.VoterCandidateFeatures.Commands
{
    public class CreateVoteCandidateCommand : IRequest<VoterCandidateDto>
    {
        public int VoterId { get; private set; }
        public VoteForCandidateDto VoteForCandidateDto { get; private set; }

        public CreateVoteCandidateCommand(int voterId, VoteForCandidateDto voteForCandidateDto)
        {
            VoterId = voterId;
            VoteForCandidateDto = voteForCandidateDto;
        }

        internal sealed class CreateVoteCandidateCommandHandler : IRequestHandler<CreateVoteCandidateCommand, VoterCandidateDto>
        {

            private readonly IVoterCandidateRepository _voterCandidateRepository;
            private readonly ICandidateRepository _candidateRepository;
            private readonly IMapper _mapper;

            public CreateVoteCandidateCommandHandler(IVoterCandidateRepository voterCandidateRepository, ICandidateRepository candidateRepository,
                IMapper mapper)
            {
                _voterCandidateRepository = voterCandidateRepository;
                _mapper = mapper;
                _candidateRepository = candidateRepository;
            }


            public async Task<VoterCandidateDto> Handle(CreateVoteCandidateCommand request, CancellationToken cancellationToken)
            {
                //Take candidate from db to get his/her categoryId
                var candidateFromDb = await _candidateRepository.FindAsync(request.VoteForCandidateDto.CandidateId);

                int categoryId = candidateFromDb.CategoryId;

                var voterCandidateForCreationDto = new VoterCandidateForCreationDto()
                {
                    VoterId = request.VoterId,
                    CandidateId = request.VoteForCandidateDto.CandidateId,
                    CategoryId = categoryId
                };

                var voterCandidateEntity = _mapper.Map<VoterCandidate>(voterCandidateForCreationDto);

                await _voterCandidateRepository.AddAsync(voterCandidateEntity);

                var voterCandidateDtoToReturn = _mapper.Map<VoterCandidateDto>(voterCandidateEntity);


                return voterCandidateDtoToReturn;
            }
        }
    }
}
