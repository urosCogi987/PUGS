﻿namespace TaxiApp.WebApi.Constants
{
    public static class FluentValidationMessages
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
        public const string RoleNameIsRequired = "Role name is a required field.";
        public const string ValidRoleNames = "Please only use: ";

        public const string RefreshTokenIsRequired = "Refresh token is a required field.";

        public const string VerificationTokenIsRequired = "Verification token is a required field.";

        public const string UserStatusIsRequired = "User status is a required field.";
        public const string ValidUserStatuses = "Please only use: ";

        public const string OldPasswordIsRequired = "Old password is a required field.";

        public static readonly string PasswordConstaints
            = $"Must be between {StringLengths.MinPasswordLength} and {StringLengths.MaxPasswordLength} characters.";

        public const string FromAddressIsRequired = "From address is a required field.";
        public const string ToAddressIsRequired = "To address is a required field.";
        public const string DriverArrivingTimeIsRequired = "Driver ariving time is a required field.";
        public const string DriverArrivingTimeGreaterThanZero = "Driver ariving time has to be greater than 0.";
        
        public const string DistanceIsRequired = "Distance is a required field.";
        public const string DistanceHasToBeRealNumber = "Distance has to be a real number.";

        public const string EstimatedDurationIsRequired = "Estimated duration is a required field.";
        public const string EstimatedDurationHasToBeRealNumber = "Estimated duration has to be a real number.";
    }
}
