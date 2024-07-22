namespace TaxiApp.Application.Constants
{
    public static class DomainErrors
    {
        public const string EmailAlreadyInUse = "Email is already in use.";
        public const string UsernameAlreadyInUse = "Username is already in use.";
        public const string InvalidCredentials = "Invalid credentials.";
        public const string InvalidRoleName = "That role does not exist.";
        public const string InvalidRefreshToken = "Refresh token is not valid.";
        public const string InvalidVerificationToken = "Verification token is not valid.";
        public const string UserDoesNotExist = "User does not exist.";
        public const string IncorrectPassowrd = "Password is incorrect.";
        public const string RefreshTokenExpired = "Refresh token has expired.";

        public const string ForbiddenOperation = "This operation is forbidden.";

        public const string UserEmailIsNotVerified = "Users email has not been verified yet.";        
    }
}
