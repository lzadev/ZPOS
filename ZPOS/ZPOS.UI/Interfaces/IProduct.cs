using System.Collections.Generic;
using ZPOS.UI.Entities;

namespace ZPOS.UI.Interfaces
{
    public interface IProduct
    {
        IEnumerable<Product> GetProducts();
        bool addProduct(Product product);
        bool ExistsCode(string code);

        Product GetPrductById(int id);

        bool DeleteProduct(Product product);
        bool UpdateProduct(Product product);
    }
}
