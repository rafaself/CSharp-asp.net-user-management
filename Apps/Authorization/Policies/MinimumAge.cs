using Microsoft.AspNetCore.Authorization;

namespace UserManagement.Apps.Authorization.Policies;

public class MinimumAge : IAuthorizationRequirement
{

    public int Age { get; set; }

    public MinimumAge(int age)
    {
        Age = age;
    }
}
