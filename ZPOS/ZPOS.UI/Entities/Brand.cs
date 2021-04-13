using System.Collections.Generic;

namespace ZPOS.UI.Entities
{
    public class Brand
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
