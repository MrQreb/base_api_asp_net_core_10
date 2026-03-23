using Microsoft.EntityFrameworkCore;
using WepAPI.Src.Database;
using WepAPI.Src.Modules.Users.Dtos;
using WepAPI.Src.Modules.Users.Entities;

namespace WepAPI.Src.Modules.Users;

public class UsersService
{
    private readonly AppDbContext _db;

    public UsersService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<UserResponseDto>> FindAllAsync() =>
        await _db.Set<User>()
            .Where(u => u.IsActive)
            .Select(u => UserResponseDto.FromEntity(u))
            .ToListAsync();

    public async Task<UserResponseDto?> FindOneAsync(Guid id)
    {
        var user = await _db.Set<User>().FindAsync(id);
        return user is null ? null : UserResponseDto.FromEntity(user);
    }

    public async Task<UserResponseDto> CreateAsync(CreateUserDto dto)
    {
        var user = new User
        {
            Name  = dto.Name,
            Email = dto.Email,
        };

        _db.Set<User>().Add(user);
        await _db.SaveChangesAsync();

        return UserResponseDto.FromEntity(user);
    }

    public async Task<UserResponseDto?> UpdateAsync(Guid id, UpdateUserDto dto)
    {
        var user = await _db.Set<User>().FindAsync(id);
        if (user is null) return null;

        if (dto.Name     is not null) user.Name     = dto.Name;
        if (dto.Email    is not null) user.Email    = dto.Email;
        if (dto.IsActive is not null) user.IsActive = dto.IsActive.Value;

        user.UpdatedAt = DateTime.UtcNow;
        await _db.SaveChangesAsync();

        return UserResponseDto.FromEntity(user);
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        var user = await _db.Set<User>().FindAsync(id);
        if (user is null) return false;

        // Soft delete
        user.IsActive  = false;
        user.UpdatedAt = DateTime.UtcNow;

        await _db.SaveChangesAsync();
        return true;
    }
}