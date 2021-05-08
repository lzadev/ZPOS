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

        public void AddProduct(Product product)
        {
           _productRepository.AddProduct(product);
        }

        public Product GetPrductById(int id)
        {
            return _productRepository.GetPrductById(id);
        }

        public bool DeleteProduct(Product product)
        {
            return _productRepository.DeleteProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.UpdateProduct(product);
        }

        public bool Exists(string description)
        {
            return _productRepository.Exists(description);
        }

        public bool Save()
        {
            return _productRepository.Save();
        }

        public IEnumerable<Product> GetProductHistorial(string ProductCode)
        {
            return _productRepository.GetProductHistorial(ProductCode);
        }
    }
}
