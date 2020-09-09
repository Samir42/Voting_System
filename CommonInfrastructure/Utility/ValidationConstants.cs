namespace CommonInfrastructure.Utility
{
    public class ValidationConstants
    {
        public const string NAME_CAN_NOT_BE_EMPTY = "Name can not be empty";
        public const string SURNAME_CAN_NOT_BE_EMPTY = "Surname can not be empty";
        public const string INVALID_NAME_LENGTH = "The length of name must be greater than 1 and smaller than 20";
        public const string INVALID_CATEGORY_NAME_LENGTH = "The length of category name must be greater than 3 and smaller than 20";
        public const string INVALID_SURNAME_LENGTH = "The length of Surname must be greater than 3 and smaller than 20";
        public const string INVALID_ID_NUMBER_LENGTH = "The length of Identity number must be greater than 6 and smaller than 15";

        public const string NO_CATEGORY_FOUND = "No category found for given ID";
        public const string NO_CANDIDATE_FOUND = "No candidate found for given ID";
        public const string NO_VOTER_FOUND = "No voter found for given ID";
        public const string CONFLICT_WITH_EXISTING_CANDIDATE = "Candidate with given ID number is already exists";
        public const string CONFLICT_WITH_EXISTING_CATEGORY = "Category with given Name is already exists";
        public const string VOTER_ALREADY_VOTED_FOR_CATEGORY = "This voter has already voted for the category with given ID";
        public const string VOTER_ALREADY_VOTED_FOR_CANDIDATE = "This voter has already voted for the candidate with given ID";

        public const string ID_MUST_BE_GREATER_THAN_ZERO = "ID must be greater than 0";
        public const string VOTER_IS_NOT_SUITABLE = "The age of voter can not be less than 18";
    }
}
