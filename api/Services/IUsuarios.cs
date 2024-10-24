using api.Entities;

namespace api.Services
{
    public interface IUsuarios
    {
        Task<int> AddAsync(Usuario usuario);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(int id);
        string Usuario();
    }
}
