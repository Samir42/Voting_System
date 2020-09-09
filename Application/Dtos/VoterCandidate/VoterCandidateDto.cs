using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.VoterCandidate
{
    public class VoterCandidateDto
    {
        public int Id { get; set; }
        public int VoterId { get; set; }
        public int CategoryId { get; set; }
        public int CandidateId { get; set; }

        public static VoterCandidateDto EmptyVoterCandidate = new VoterCandidateDto();
    }
}
