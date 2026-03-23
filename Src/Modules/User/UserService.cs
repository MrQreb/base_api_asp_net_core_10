using WepAPI.Src.Modules.Users.Dtos;
using WepAPI.Src.Modules.Users.Entities;
using WepAPI.Src.Modules.Users.Repositories;

namespace WepAPI.Src.Modules.Users;

public class UsersService
{
    private readonly IUserRepository _repo;


    public UsersService(IUserRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<UserResponseDto>> FindAllAsync()
    {
        var users = await _repo.GetAllAsync();

        return users
            .Where(u => u.IsActive)
            .Select(UserResponseDto.FromEntity)
            .ToList();
    }

    public async Task<UserResponseDto?> FindOneAsync(Guid id)
    {
        var user = await _repo.GetByIdAsync(id);
        return user is null ? null : UserResponseDto.FromEntity(user);
    }

    public async Task<UserResponseDto> CreateAsync(CreateUserDto dto)
    {
        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
        };

        await _repo.AddAsync(user);
        await _repo.SaveChangesAsync();

        return UserResponseDto.FromEntity(user);
    }

    public async Task<UserResponseDto?> UpdateAsync(Guid id, UpdateUserDto dto)
    {
        var user = await _repo.GetByIdAsync(id);
        if (user is null) return null;

        if (dto.Name is not null) user.Name = dto.Name;
        if (dto.Email is not null) user.Email = dto.Email;
        if (dto.IsActive is not null) user.IsActive = dto.IsActive.Value;

        user.UpdatedAt = DateTime.UtcNow;

        await _repo.SaveChangesAsync();

        return UserResponseDto.FromEntity(user);
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        var user = await _repo.GetByIdAsync(id);
        if (user is null) return false;

        user.IsActive = false;
        user.UpdatedAt = DateTime.UtcNow;

        await _repo.SaveChangesAsync();
        return true;
    }
}