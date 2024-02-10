using AutoMapper;
using UserManagement.Apps.Users.Data;

namespace UserManagement.Apps.Users;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserCreateDto, UserModel>();
    }
}

