using WepAPI.Src.Modules.Users.Entities;

namespace WepAPI.Src.Modules.Users.Repositories;

/// <summary>
/// Define las operaciones de acceso a datos para la entidad User.
/// </summary>
public interface IUserRepository: ICrudRepository<User, Guid>
{
    
}