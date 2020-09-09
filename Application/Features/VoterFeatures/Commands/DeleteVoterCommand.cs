using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.VoterFeatures.Commands
{
    public class DeleteVoterCommand : IRequest
    {
        public int VoterId { get; set; }

        public DeleteVoterCommand(int voterId)
        {
            VoterId = voterId;
        }


        internal sealed class DeleteVoterCommandHandler : IRequestHandler<DeleteVoterCommand>
        {
            private readonly IVoterRepository _voterRepository;

            public DeleteVoterCommandHandler(IVoterRepository voterRepository)
            {
                _voterRepository = voterRepository;
            }

            public async Task<Unit> Handle(DeleteVoterCommand request, CancellationToken cancellationToken)
            {
                var voterToDelete = await _voterRepository.FindAsync(request.VoterId);

                _voterRepository.Delete(voterToDelete);


                return Unit.Value;
            }
        }
    }
}
