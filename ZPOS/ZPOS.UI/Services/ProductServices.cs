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
    }
}
