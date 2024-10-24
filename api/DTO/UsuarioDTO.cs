using System.ComponentModel.DataAnnotations;

namespace api.DTO
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage = "Obligatorio")]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [EmailAddress(ErrorMessage = "Formatro de correo icorreto")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public int Edad { get; set; }
    }
}
