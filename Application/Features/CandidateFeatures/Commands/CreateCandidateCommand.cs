using Application.Dtos.Candidate;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CandidateFeatures.Commands
{
    public class CreateCandidateCommand :IRequest<CandidateDto>
    {
        private readonly  CandidateForCreationDto _candidateForCreationDto;

        public CreateCandidateCommand(CandidateForCreationDto candidateForCreationDto)
        {
            _candidateForCreationDto = candidateForCreationDto;
        }


        internal sealed class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommand, CandidateDto>
        {
            private readonly ICandidateRepository _candidateRepository;
            private readonly IMapper _mapper;

            public CreateCandidateCommandHandler(ICandidateRepository candidateRepository, IMapper mapper)
            {
                _candidateRepository = candidateRepository;
                _mapper = mapper;
            }


            public async Task<CandidateDto> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
            {
                var candidateEntity = _mapper.Map<Candidate>(request._candidateForCreationDto);

                await _candidateRepository.AddAsync(candidateEntity);

                var candidateDtoToReturn = _mapper.Map<CandidateDto>(candidateEntity);

                return candidateDtoToReturn;
            }
        }
    }
}
