using System.ComponentModel;

namespace DAL.Enums
{
    public enum UserRoles
    {
        [Description("Admin")]
        Admin = 1,
        [Description("Manager")]
        Manager = 2,
        [Description("User")]
        User = 3,
    }
}
