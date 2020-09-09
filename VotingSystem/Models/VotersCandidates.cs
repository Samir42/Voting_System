using System;
using System.Collections.Generic;

namespace VotingSystem.Models
{
    public partial class VotersCandidates
    {
        public int Id { get; set; }
        public int VoterId { get; set; }
        public int CategoryId { get; set; }
        public int CandidateId { get; set; }

        public virtual Candidates Candidate { get; set; }
        public virtual Categories Category { get; set; }
        public virtual Voters Voter { get; set; }
    }
}
