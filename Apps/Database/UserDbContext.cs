using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserManagement.Apps.Users;

namespace UserManagement.Apps.Database;

public class UserDbContext : IdentityDbContext<UserModel>
{
    public UserDbContext(DbContextOptions<UserDbContext> opts) : base(opts) { }
}
