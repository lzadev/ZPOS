using System.ComponentModel.DataAnnotations;

namespace ZPOS.UI.Models
{
    public class UpdateProductVM : CreateProductVM
    {
        [Required]
        public int ID { get; set; }

        public bool Status { get; set; }
    }
}
