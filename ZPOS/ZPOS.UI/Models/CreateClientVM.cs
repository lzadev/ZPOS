using System.ComponentModel.DataAnnotations;

namespace ZPOS.UI.Models
{
    public class CreateClientVM
    {
        [Required(ErrorMessage = "campo requerido")]
        [MaxLength(20)]
        public string Document { get; set; }
        [Required(ErrorMessage = "campo requerido")]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "campo requerido")]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "campo requerido")]
        [MaxLength(50)]
        [EmailAddress(ErrorMessage = "email invalido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "campo requerido")]
        [MaxLength(12)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "campo requerido")]
        [MaxLength(400)]
        public string Address { get; set; }
    }
}
