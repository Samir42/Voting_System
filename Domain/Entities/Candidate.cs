using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Candidate
    {
        public Candidate()
        {
            VotersCandidates = new HashSet<VoterCandidate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CategoryId { get; set; }
        public string IdNumber { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<VoterCandidate> VotersCandidates { get; set; }
    }
}
