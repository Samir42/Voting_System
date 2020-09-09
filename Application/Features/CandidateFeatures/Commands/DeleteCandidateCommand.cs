using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CandidateFeatures.Commands
{
    public class DeleteCandidateCommand : IRequest
    {
        public int CandidateId { get; set; }

        public DeleteCandidateCommand(int candidateId)
        {
            CandidateId = candidateId;
        }

        internal sealed class DeleteCandidateCommandHandler : IRequestHandler<DeleteCandidateCommand>
        {
            private readonly ICandidateRepository _candidateRepository;

            public DeleteCandidateCommandHandler(ICandidateRepository candidateRepository)
            {
                _candidateRepository = candidateRepository;
            }

            public async Task<Unit> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
            {
                var candidateToDelete = await _candidateRepository.FindAsync(request.CandidateId);

                _candidateRepository.Remove(candidateToDelete);

                return Unit.Value;
            }
        }
    }
}
