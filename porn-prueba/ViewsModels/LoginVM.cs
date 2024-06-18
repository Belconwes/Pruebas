using System.ComponentModel.DataAnnotations;

namespace porn_prueba.ViewsModels
{
    public class LoginVM
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        public string? Contraseña { get; set; }
    }
}
