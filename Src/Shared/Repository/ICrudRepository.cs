using Microsoft.EntityFrameworkCore;

namespace WepAPI.Src
{
    /// <summary>
    /// Contiene los metodos para un basico 'CRUD'. Para aplicarlo en una interfaz de repositorio  
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICrudRepository<T, TKey> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(TKey id);
        Task <T> Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<bool> CheckIfExistById(TKey id);
        Task SaveAsyncChanges();
    }
}