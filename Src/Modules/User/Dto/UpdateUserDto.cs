using System.ComponentModel.DataAnnotations;

namespace WepAPI.Src.Modules.Users.Dtos;

public class UpdateUserDto
{
    [MinLength(2)]
    [MaxLength(100)]
    public string? Name { get; set; }

    [EmailAddress]
    [MaxLength(255)]
    public string? Email { get; set; }

    public bool? IsActive { get; set; }
}