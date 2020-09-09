using static CommonInfrastructure.Utility.ValidationConstants;
using System;
using System.Collections.Generic;


namespace Application.Dtos.Candidate
{
    public class CandidateForCreationDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdNumber { get; set; }
        public int CategoryId { get; set; }

        public IReadOnlyList<string> ValidateCandidateForCreationDto()
        {
            var errorsToReturn = new List<string>();


            if (String.IsNullOrEmpty(Name))
                errorsToReturn.Add(NAME_CAN_NOT_BE_EMPTY);

            if (Name.Length < 3 || Name.Length >= 20)
                errorsToReturn.Add(INVALID_NAME_LENGTH);

            if (String.IsNullOrEmpty(Surname))
                errorsToReturn.Add(SURNAME_CAN_NOT_BE_EMPTY);

            if (Surname.Length < 3 || Surname.Length >= 20)
                errorsToReturn.Add(INVALID_SURNAME_LENGTH);

            if (IdNumber.Length < 6 || IdNumber.Length >= 15)
                errorsToReturn.Add(INVALID_ID_NUMBER_LENGTH);

            if (CategoryId < 1)
                errorsToReturn.Add(ID_MUST_BE_GREATER_THAN_ZERO);

            return errorsToReturn;
        }
    }
}
