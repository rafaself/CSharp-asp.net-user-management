using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Apps.Authentication.Dtos;
using UserManagement.Apps.Users;

namespace UserManagement.Apps.Authentication;

[ApiController]
[Route("login")]
public class AuthorizationControllers : ControllerBase
{

    AuthorizationServices _authServices;
    SignInManager<UserModel> _signInManager;

    public AuthorizationControllers(AuthorizationServices authServices, SignInManager<UserModel> signInManager)
    {
        _authServices = authServices;
        _signInManager = signInManager;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto loginData)
    {
        await _authServices.Login(loginData);

        var userData = _signInManager
            .UserManager
            .Users
            .FirstOrDefault(user => user.NormalizedUserName == loginData.Username.ToUpper());

        string token = _authServices.GenerateToken(userData);

        return Ok(token);

    }
}
