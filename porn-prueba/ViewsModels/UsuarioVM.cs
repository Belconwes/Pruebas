using System.ComponentModel.DataAnnotations;

namespace porn_prueba.ViewsModels
{
    public class UsuarioVM
    {

        public string? Rol { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        public string? Contraseña { get; set; }
        public string? Confirmar_contraseña { get; set; }
    }
}
