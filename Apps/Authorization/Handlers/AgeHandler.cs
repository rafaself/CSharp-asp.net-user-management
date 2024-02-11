using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using UserManagement.Apps.Authorization.Policies;

namespace UserManagement.Apps.Authorization.Handlers;

public class AgeHandler : AuthorizationHandler<MinimumAge>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAge requirement)
    {
        var birthDataClaim = context.User.FindFirst(
            claim => claim.Type == ClaimTypes.DateOfBirth
        );

        if (birthDataClaim == null )
        {
            return Task.CompletedTask;
        }

        var birthDate = Convert.ToDateTime(birthDataClaim.Value);

        var userAge = DateTime.Today.Year - birthDate.Year;

        if (birthDate > DateTime.Today.AddYears(-userAge)) userAge--;

        if (userAge >= requirement.Age) context.Succeed(requirement);

        return Task.CompletedTask;

    }
}
