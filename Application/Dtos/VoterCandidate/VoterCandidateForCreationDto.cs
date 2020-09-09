using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.VoterCandidate
{
    public class VoterCandidateForCreationDto 
    {
        public int VoterId { get; set; }
        public int CategoryId { get; set; }
        public int CandidateId { get; set; }
    }
}
