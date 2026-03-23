using WepAPI.Src.Modules.Users.Entities;

namespace WepAPI.Src.Modules.Users.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(Guid id);
    Task AddAsync(User user);
    Task SaveChangesAsync();
}