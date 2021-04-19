using System.ComponentModel.DataAnnotations;

namespace ZPOS.UI.Models
{
    public class CreateBrandVM
    {
        [Required(ErrorMessage = "campo requerido")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
