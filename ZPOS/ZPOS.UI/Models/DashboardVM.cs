using System.Collections.Generic;

namespace ZPOS.UI.Models
{
    public class DashboardVM
    {
        public int TotalOfPorducts { get; set; }

        public int TotalOfCategries { get; set; }

        public int TotalOfBrands { get; set; }

        public int TotalOfClients { get; set; }
        public List<ProductVM> LastAddedProducts { get; set; } = new List<ProductVM>();
    }
}
