using System.ComponentModel.DataAnnotations;

namespace ZPOS.UI.Models
{
    public class CreateCategoryVM
    {
        [Required(ErrorMessage ="campo requerido")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
