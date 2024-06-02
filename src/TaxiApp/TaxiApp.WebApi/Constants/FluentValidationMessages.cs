namespace TaxiApp.WebApi.Constants
{
    public sealed class FluentValidationMessages
    {
        public const string EmailIsRequired = "Email is a required field.";
        public const string EmailFormatIncorrect = "Email format is invalid.";
        public const string UsernameIsRequired = "Username is a required field.";
        public const string NameIsRequired = "Name is a required field.";
        public const string SurnameIsRequired = "Surname is a required field.";
        public const string PasswordIsRequired = "Password is a required field.";
        public const string PasswordLengthInvalid = $"Password length invalid.";
        public const string RepeatPasswordIsRequired = "Repeat password is a required field.";
        public const string PasswordsDoNotMatch = "Passwords do not match.";
        public const string DateOfBirthIsRequired = "Date of birth is a required field.";
        public const string DateOfBirthInvalid = "Date of birth can not be less than now.";
        public const string AddressIsRequired = "Address is a required field.";
    }
}
