using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZPOS.UI.Entities
{
    public class Brand
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
