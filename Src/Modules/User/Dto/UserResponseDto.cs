using WepAPI.Src.Modules.Users.Entities;

namespace WepAPI.Src.Modules.Users.Dtos;

public class UserResponseDto
{
    public Guid     Id        { get; init; }
    public string   Name      { get; init; } = string.Empty;
    public string   Email     { get; init; } = string.Empty;
    public bool     IsActive  { get; init; }
    public DateTime CreatedAt { get; init; }

    // Método de mapeo estático — sin AutoMapper, sin dependencias extra
    public static UserResponseDto FromEntity(User user) => new()
    {
        Id        = user.Id,
        Name      = user.Name,
        Email     = user.Email,
        IsActive  = user.IsActive,
        CreatedAt = user.CreatedAt,
    };
}