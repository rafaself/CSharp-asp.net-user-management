using System.ComponentModel.DataAnnotations;

namespace UserManagement.Apps.Users.Data;

public class UserReadDto
{
    public string ID { get;  }
    public string Username { get; set; }
    public DateTime BirthDate { get; set; }
}
