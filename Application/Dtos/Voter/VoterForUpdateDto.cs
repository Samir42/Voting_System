using static CommonInfrastructure.Utility.ValidationConstants;
using System.Collections.Generic;

namespace Application.Dtos.Voter
{
    public class VoterForUpdateDto
    {
        public int Age { get; set; }


        public IReadOnlyList<string> Validate()
        {
            var errors = new List<string>();

            if (Age < 18)
                errors.Add(VOTER_IS_NOT_SUITABLE);

            return errors;
        }
    }
}
