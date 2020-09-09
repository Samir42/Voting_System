using System;
using System.Collections.Generic;

namespace VotingSystem.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Candidates = new HashSet<Candidates>();
            VotersCandidates = new HashSet<VotersCandidates>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Candidates> Candidates { get; set; }
        public virtual ICollection<VotersCandidates> VotersCandidates { get; set; }
    }
}
