using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Apps.Users.Data;

namespace UserManagement.Apps.Users;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private UserServices _userServices;

    public UserController(UserServices userService)
    {
        _userServices = userService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(UserCreateDto userData)
    {
        await _userServices.CreateUserService(userData);
        return Ok();
    }

}
