using api.Entities;
using api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarios _repository;
       
        public UsuariosController(IUsuarios repository) 
        {
            _repository = repository;            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            try
            {
                var usuarios = await _repository.GetAllAsync();
                return Ok(usuarios);
            }
            catch (Exception ex)
            { 
               throw new Exception($"Error en GetUsuarios. {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario([FromBody] Usuario usuario)
        {
            try
            {

                var nuevoUsuario = await _repository.AddAsync(usuario);

                return CreatedAtAction(nameof(GetUsuario), new { id = nuevoUsuario }, usuario);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en PostUsuario. {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            try
            {
                var usuario = await _repository.GetByIdAsync(id);

                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en GetUsuario. {ex.Message}");
            }
        }
    }
}
