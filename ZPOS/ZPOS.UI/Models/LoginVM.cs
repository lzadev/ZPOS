using System.ComponentModel.DataAnnotations;

namespace ZPOS.UI.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "campo requerido")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "campo requerido")]
        public string Password { get; set; }

        public string returnUrl { get; set; }
    }
}
