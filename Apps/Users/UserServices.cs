using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UserManagement.Apps.Users.Data;

namespace UserManagement.Apps.Users;

public class UserServices
{
    private IMapper _mapper;
    private UserManager<UserModel> _userManager;

    public UserServices(IMapper mapper, UserManager<UserModel> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task CreateUserService(UserCreateDto userData)
    {
        UserModel user = _mapper.Map<UserModel>(userData);
        IdentityResult result = await _userManager.CreateAsync(user, userData.Password);
        if (!result.Succeeded)
        {
            throw new ApplicationException("Falha ao cadastrar usuário.");
        }
    }
}
