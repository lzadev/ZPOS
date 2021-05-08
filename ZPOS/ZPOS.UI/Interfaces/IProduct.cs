using System.Collections.Generic;
using ZPOS.UI.Entities;

namespace ZPOS.UI.Interfaces
{
    public interface IProduct
    {
        bool Exists(string description);
        IEnumerable<Product> GetProducts();
        void AddProduct(Product product);
        bool ExistsCode(string code);

        Product GetPrductById(int id);

        bool DeleteProduct(Product product);
        void UpdateProduct(Product product);
        bool Save();

        IEnumerable<Product> GetProductHistorial(string ProductCode);
    }
}
