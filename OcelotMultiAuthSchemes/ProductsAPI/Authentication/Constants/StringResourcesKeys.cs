namespace ProductsAPI.Authentication.Constants;

public static class StringResourcesKeys
{
    #region user

    public const string UserNotFound = "UserNotFound";

    #endregion

    #region Zone group

    public const string ZoneGroupNotFound = "ZoneGroupNotFound";

    #endregion

    #region rider

    public const string RiderNotFound = "RiderNotFound";

    public const string CivilNoShouldBeUnique = "CivilNoShouldBeUnique";

    public const string DriverLicenseNoShouldBeUnique = "DriverLicenseNoShouldBeUnique";

    public const string EmployeeIdShouldBeUnique = "EmployeeIdShouldBeUniquee";

    public const string EmailOrPasswordIsIncorrect = "EmailOrPasswordIsIncorrect";

    #endregion

    #region Zone

    public const string ZoneNotFound = "ZoneNotFound";

    public const string TheRiderIsUnassignedToAnyZone = "TheRiderIsUnassignedToAnyZone";

    public const string CurrentlyAssignedZoneNotFound = "CurrentlyAssignedZoneNotFound";

    #endregion

    #region Rider Location

    public const string WeCanStoreRiderLocationOnlyWhenTheRiderCheckedIn = "WeCanStoreRiderLocationOnlyWhenTheRiderCheckedIn";
    public const string InvalidDataTheRiderHasNoAttendanceHistoryYet = "InvalidDataTheRiderHasNoAttendanceHistoryYet";
    public const string TheRiderWasCheckedOut= "TheRiderWasCheckedOut";

    #endregion

    #region Status

    public const string TheRiderHasNoCheckInOrCheckOutHistories = "TheRiderHasNoCheckInOrCheckOutHistories";
    public const string TheRiderAlreadyIs = "TheRiderAlreadyIs";
    public const string TheRiderAlreadyCheckedIn = "TheRiderAlreadyCheckedIn";
    public const string TheRiderAlreadyCheckedOut = "TheRiderAlreadyCheckedOut";
    public const string TheRiderLocationIsNotValidToCheckIn = "TheRiderLocationIsNotValidToCheckIn";

    #endregion
}