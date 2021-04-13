using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZPOS.UI.Entities
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        public Category Categories { get; set; }
        [Required]
        public int CategoryID { get; set; }
        public Brand Brands { get; set; }
        [Required]
        public int BrandID { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal BuyPrice { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SellPrice { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
    }
}
