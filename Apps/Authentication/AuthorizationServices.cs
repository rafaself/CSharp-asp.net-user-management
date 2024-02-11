using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserManagement.Apps.Authentication.Dtos;
using UserManagement.Apps.Users;
using UserManagement.Apps.Users.Data;

namespace UserManagement.Apps.Authentication;

public class AuthorizationServices
{

    IMapper _mapper;
    SignInManager<UserModel> _signInManager;

    public AuthorizationServices(
        SignInManager<UserModel> signInManager,
        IMapper mapper
    )
    {
        _mapper = mapper;
        _signInManager = signInManager;
    }

    public async Task Login(LoginDto loginData)
    {
        string username = loginData.Username;
        string password = loginData.Password;

        var result = await _signInManager
            .PasswordSignInAsync(username, password, false, false);

        if (!result.Succeeded)
        {
            throw new ApplicationException("Falha ao autenticar o usuário.");
        }

    }

    public string GenerateToken(UserModel userData)
    {
        Claim[] claims =
        [
            new Claim("username", userData.UserName),
            new Claim("id", userData.Id),
            new Claim(ClaimTypes.DateOfBirth, userData.BirthDate.ToString())
        ];

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("DASdsdasSADSADASDASDA325314565!!DADADADSADA"));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            expires: DateTime.Now.AddMinutes(10),
            claims: claims,
            signingCredentials: signingCredentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
