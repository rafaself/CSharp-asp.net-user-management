using System.ComponentModel.DataAnnotations;

namespace UserManagement.Apps.Users.Data;

public class CreateUserDto
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string BirthDate { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [Compare("Password")]
    public string ConfirmPassword { get; set;}
}
