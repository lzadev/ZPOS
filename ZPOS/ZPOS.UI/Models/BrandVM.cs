using System.ComponentModel.DataAnnotations;

namespace ZPOS.UI.Models
{
    public class BrandVM
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "campo requerido")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
