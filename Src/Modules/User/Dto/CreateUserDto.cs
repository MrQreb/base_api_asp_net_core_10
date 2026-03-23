using System.ComponentModel.DataAnnotations;

namespace WepAPI.Src.Modules.Users.Dtos;

public class CreateUserDto
{
    [Required]
    [MinLength(2)]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;
}