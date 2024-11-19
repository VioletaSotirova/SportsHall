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

            public const string NoImageUrl = "/images/defaultSportImage.jpg";
            public const int ImageMinLength = 8;
            public const int ImageMaxLength = 2083;
        }

        public static class Coach
        {
            public const int FirstNameMaxLength = 20;
            public const int LastNameMaxLength = 40;

            public const int PhoneMaxLength = 10;

            public const string EmailValidation = "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$";
            public const string NoPhoto = "/images/NoPhoto.jpg";

            public const int ExpirienceMaxLength = 300;
        }

        public static class Training
        {
            public const string DateFormat = "yyyy-MM-dd hh:mm";

            public const int LocationMaxLength = 150;

        }

        public static class ApplicationUser
        {
            public const int FirstNameMaxLength = 30;
            public const int LastNameMaxLength = 50;

            public const string EmailValidation = "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$";

            public const int PhoneMaxLength = 10;

        }

        public static class Reservation
        {
            public const string DateFormat = "yyyy-MM-dd hh:mm";
        }
    }
}
