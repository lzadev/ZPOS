using System;

namespace ZPOS.UI.Models
{
    public class ProductVM
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
