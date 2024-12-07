namespace SportsHall.Common
{
    public static class EntityValidationMessages
    {
        public static class Sport
        {
            public const string NameRequiredMessage = "Name is required.";
            public const string NameMinLengthMessage = "The name must be at least {1} characters long.";
            public const string NameMaxLengthMessage = "The name cannot be longer than {1} characters.";
            public const string DescriptionRequiredMessage = "Description is required.";
            public const string DescriptionMinLengthMessage = "The description must be at least {1} characters long.";
            public const string DescriptionMaxLengthMessage = "The descriprion cannot be longer than {1} characters.";
            public const string MaxParticipantsMessage = "Max participants must be greater than 0.";
        }

        public static class Coach
        {
            public const string FirstNameRequiredMessage = "First name is required.";
            public const string FirstNameMaxLengthMessage = "First name cannot be longer than {1} characters.";
            public const string LastNameRequiredMessage = "Last name is required.";
            public const string LastNameMaxLengthMessage = "Last name cannot be longer than {1} characters.";
            public const string InvalidEmailMessage = "This email is invalid!";
            public const string PhoneRequiredMessage = "Phone number is required.";
            public const string ExpirienceRequiredMessage = "Expirience is required.";
            public const string ExpirienceMaxLengthMessage = "Expirience cannot be longer than {1} characters.";
        }

        public static class Training
        {
            public const string ChooseMessage = "You must choose an option!";
            public const string LocationRequiredMessage = "Location is required.";
            public const string LocationMaxLengthMessage = "Location cannot be longer than {1} characters.";
            public const string DurationRequiredMessage = "Duration is required.";
            public const string DurationMinLengthMessage = "Duration can not be less than 20 minutes!";
        }
    }
}
