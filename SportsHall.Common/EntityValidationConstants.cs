namespace SportsHall.Common
{
    public static class EntityValidationConstants
    {
        public static class Sport
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 30;

            public const int DescriptionMinLength = 7;
            public const int DescriptionMaxLength = 300;
        }

        public static class Coach
        {
            public const int FirstNameMaxLength = 20;
            public const int LastNameMaxLength = 40;

            public const int PhoneMaxLength = 10;

            public const string EmailRegex = "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$";

            public const int ExpirienceMaxLength = 300;
        }
    }
}
