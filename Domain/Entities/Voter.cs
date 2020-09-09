using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Voter
    {
        public Voter()
        {
            VotersCandidates = new HashSet<VoterCandidate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public virtual ICollection<VoterCandidate> VotersCandidates { get; set; }
    }
}
