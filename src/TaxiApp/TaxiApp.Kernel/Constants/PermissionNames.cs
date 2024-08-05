namespace TaxiApp.Kernel.Constants
{
    public static class PermissionNames
    {
        // admin
        public const string RoleAdmin = nameof(RoleAdmin);
        public const string CanViewAllUsers = nameof(CanViewAllUsers);
        public const string CanViewAllDrives = nameof(CanViewAllDrives);
        // user
        public const string CanRequestDrive = nameof(CanRequestDrive);
        // driver
        public const string CanAcceptDrive = nameof(CanAcceptDrive);
        // admin + driver
        public const string CanViewNewDrives = nameof(CanViewNewDrives);  
        // all
        public const string CanViewHisDrives = nameof(CanViewHisDrives);
        public const string CanUpdateProfile = nameof(CanUpdateProfile);   
        public const string CanViewDriveDetails = nameof(CanViewDriveDetails);
    }
}
