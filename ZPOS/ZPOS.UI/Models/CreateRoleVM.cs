using System.ComponentModel.DataAnnotations;

namespace ZPOS.UI.Models
{
    public class CreateRoleVM
    {
        [Required(ErrorMessage = "Campo requerido")]
        public string Name { get; set; }
    }
}
