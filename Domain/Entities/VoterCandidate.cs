using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class VoterCandidate
    {
        public int Id { get; set; }
        public int VoterId { get; set; }
        public int CategoryId { get; set; }
        public int CandidateId { get; set; }

        public virtual Candidate Ca { get; set; }
        public virtual Category Category { get; set; }
        public virtual Voter Voter { get; set; }
    }
}
