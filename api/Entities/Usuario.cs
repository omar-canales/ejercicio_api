using System.ComponentModel.DataAnnotations;

namespace api.Entities
{
    public class Usuario
    {
        [Required(ErrorMessage = "El nombre Obligatorio")]
        [MaxLength(50, ErrorMessage = "El nombre debe ser máximo de 50 caracteres")]
        public string Nombre { get; set; }

      
        [EmailAddress(ErrorMessage = "Formato de correo incorreto")]
        public string Email { get; set; }

       
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Sólo se permiten números")]
        public string Edad { get; set; }
    }
}
