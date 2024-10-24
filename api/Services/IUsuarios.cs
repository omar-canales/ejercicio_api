using api.DTO;

namespace api.Services
{
    public interface IUsuarios
    {
        Task<int> AddAsync(UsuarioDTO usuario);
        Task<IEnumerable<UsuarioDTO>> GetAllAsync();
        Task<UsuarioDTO> GetByIdAsync(int id);
        string Usuario();
    }
}
