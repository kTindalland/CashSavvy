using Microsoft.AspNetCore.Authorization;

namespace CashSavvy.Server.Requirements;

public class UserAdminRequirement : IAuthorizationRequirement
{
    public bool IsAdmin { get; }

    public UserAdminRequirement(bool isAdmin)
    {
        IsAdmin = isAdmin;
    }
}