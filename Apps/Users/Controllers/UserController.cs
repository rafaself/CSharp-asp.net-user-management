using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Apps.Users.Data;
using UserManagement.Apps.Users.Models;

namespace UserManagement.Apps.Users.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private IMapper _mapper;
    private UserManager<UserModel> _userManager;

    public UserController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserDto userData)
    {
        UserModel user = _mapper.Map<UserModel>(userData);
        var result = await _userManager.CreateAsync(user, userData.Password);
        if (result.Succeeded) { return Ok(new { message = "Usuário criado com sucesso." }); }
        throw new ApplicationException("Falha ao cadastrar usuário.");
    }

}
