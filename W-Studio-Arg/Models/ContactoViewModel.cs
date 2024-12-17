using System.ComponentModel.DataAnnotations;

namespace W_Studio_Arg.Models
{
    public class ContactoViewModel
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El mensaje es obligatorio.")]
        [StringLength(500, ErrorMessage = "El mensaje no puede tener más de 500 caracteres.")]
        public string Mensaje { get; set; }
    }
}

