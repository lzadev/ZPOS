using System;
using System.Collections.Generic;
using ZPOS.UI.Entities;
using ZPOS.UI.Interfaces;

namespace ZPOS.UI.Services
{

    public class ProductServices : IProductServices
    {
        private readonly IProduct _productRepository;

        public ProductServices(IProduct productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.GetProducts();

        }

        public bool ExistsCode(string code)
        {
            return _productRepository.ExistsCode(code);
        }

        public bool AddProduct(Product product)
        {
            return _productRepository.AddProduct(product);
        }

        public Product GetPrductById(int id)
        {
            return _productRepository.GetPrductById(id);
        }

        public bool DeleteProduct(Product product)
        {
            return _productRepository.DeleteProduct(product);
        }

        public bool UpdateProduct(Product product)
        {
            return _productRepository.UpdateProduct(product);
        }
    }
}
