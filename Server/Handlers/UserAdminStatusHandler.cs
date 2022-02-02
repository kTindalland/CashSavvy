using CashSavvy.Server.Helpers;
using CashSavvy.Server.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace CashSavvy.Server.Handlers;

public class UserAdminStatusHandler : AuthorizationHandler<UserAdminRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserAdminRequirement requirement)
    {
        if (!context.User.HasClaim(c => c.Type == "IsAdmin" && c.Issuer == TokenHelper.Issuer))
        {
            return Task.CompletedTask;
        }
 
        string value = context.User.FindFirst(c => c.Type == "IsAdmin" && c.Issuer == TokenHelper.Issuer).Value;
        var customerBlockedStatus = Convert.ToBoolean(value);
 
        if (customerBlockedStatus == requirement.IsAdmin)
        {
            context.Succeed(requirement);
        }
 
        return Task.CompletedTask;
    }
}