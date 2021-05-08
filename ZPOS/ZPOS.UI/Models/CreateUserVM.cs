using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZPOS.UI.Models
{
    public class CreateUserVM
    {
        public string FirstName { get; set; }
        [Required(ErrorMessage = "campo requerido")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "campo requerido")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "campo requerido")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "las contraseñas deben coincidir.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "campo requerido")]
        public string Role { get; set; }

        public List<RoleVM> Roles { get; set; } = new List<RoleVM>();
    }
}
