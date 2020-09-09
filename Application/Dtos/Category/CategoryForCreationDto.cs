using static CommonInfrastructure.Utility.ValidationConstants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos.Category
{
    public class CategoryForCreationDto
    {
        public string Name { get; set; }



        public IReadOnlyList<string> Validate()
        {
            var errorsToReturn = new List<string>();

            if (String.IsNullOrEmpty(Name))
                errorsToReturn.Add(NAME_CAN_NOT_BE_EMPTY);

            if (Name.Length < 3 || Name.Length > 20)
                errorsToReturn.Add(INVALID_CATEGORY_NAME_LENGTH);

            return errorsToReturn;
        }
    }
}
