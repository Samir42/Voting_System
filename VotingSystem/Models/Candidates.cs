using System;
using System.Collections.Generic;

namespace VotingSystem.Models
{
    public partial class Candidates
    {
        public Candidates()
        {
            VotersCandidates = new HashSet<VotersCandidates>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CategoryId { get; set; }

        public virtual Categories Category { get; set; }
        public virtual ICollection<VotersCandidates> VotersCandidates { get; set; }
    }
}
