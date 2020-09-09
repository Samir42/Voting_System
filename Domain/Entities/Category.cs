using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Category
    {
        public Category()
        {
            Candidates = new HashSet<Candidate>();
            VotersCandidates = new HashSet<VoterCandidate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Candidate> Candidates { get; set; }
        public virtual ICollection<VoterCandidate> VotersCandidates { get; set; }
    }
}
