﻿using Microsoft.AspNetCore.Mvc;
using UserManagement.Apps.Users.Data;

namespace UserManagement.Apps.Users.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateUser (CreateUserDTO userData)
    {
        throw new NotImplementedException();
    }
}
