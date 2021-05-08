using System;

namespace ZPOS.UI.Models
{
    public class AuditProductVM
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool Status { get; set; }
        public bool Updated { get; set; }
    }
}
