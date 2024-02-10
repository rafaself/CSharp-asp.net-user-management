using AutoMapper;
using UserManagement.Apps.Users.Data;
using UserManagement.Apps.Users.Models;

namespace UserManagement.Apps.Users.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, UserModel>();
    }
}

