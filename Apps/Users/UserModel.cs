﻿using Microsoft.AspNetCore.Identity;

namespace UserManagement.Apps.Users;

public class UserModel : IdentityUser
{
    public DateTime BirthDate { get; set; }
    public UserModel() : base() { }

}
