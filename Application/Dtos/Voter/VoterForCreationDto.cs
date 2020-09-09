using static CommonInfrastructure.Utility.ValidationConstants;
using System.Collections.Generic;

namespace Application.Dtos.Voter
{
    public class VoterForCreationDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }


        public IReadOnlyCollection<string> ValidateVoter()
        {
            var errorMessages = new List<string>();

            if (Age < 18)
                errorMessages.Add(VOTER_IS_NOT_SUITABLE);

            return errorMessages;
        }
    }
}
