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
    public class VoterExistsQuery : IRequest<bool>
    {
        public int voterId { get; set; }

        public VoterExistsQuery(int voterId)
        {
            this.voterId = voterId;
        }



        internal sealed class VoterExistsQueryHandler : IRequestHandler<VoterExistsQuery, bool>
        {

            private readonly IVoterRepository _voterRepository;

            public VoterExistsQueryHandler(IVoterRepository voterRepository)
            {
                _voterRepository = voterRepository;
            }

            public async Task<bool> Handle(VoterExistsQuery request, CancellationToken cancellationToken)
            {
                return await _voterRepository.ExistsAsync(request.voterId);
            }
        }
    }
}
