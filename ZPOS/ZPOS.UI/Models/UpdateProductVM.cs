using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZPOS.UI.Models
{
    public class UpdateProductVM
    {
        [Required]
        public int ID { get; set; }

        public bool Status { get; set; }

        [Required(ErrorMessage = "campo requerido")]
        public string Code { get; set; }
        [Required(ErrorMessage = "campo requerido")]
        [MaxLength(200)]
        public string Description { get; set; }
        [Required(ErrorMessage = "campo requerido")]
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "campo requerido")]
        public int BrandID { get; set; }
        [Required(ErrorMessage = "campo requerido")]
        public decimal BuyPrice { get; set; }
        [Required(ErrorMessage = "campo requerido")]
        public decimal SellPrice { get; set; }
        public DateTime CreationDate { get; set; }

        public ICollection<CategoryVM> Categories { get; set; } = new List<CategoryVM>();

        public ICollection<BrandVM> Brands { get; set; } = new List<BrandVM>();
    }
}
