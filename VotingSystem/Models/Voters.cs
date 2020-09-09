using System;
using System.Collections.Generic;

namespace VotingSystem.Models
{
    public partial class Voters
    {
        public Voters()
        {
            VotersCandidates = new HashSet<VotersCandidates>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public virtual ICollection<VotersCandidates> VotersCandidates { get; set; }
    }
}
