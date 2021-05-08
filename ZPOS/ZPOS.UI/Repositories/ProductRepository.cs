using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ZPOS.UI.Context;
using ZPOS.UI.Entities;
using ZPOS.UI.Interfaces;

namespace ZPOS.UI.Repositories
{
    public class ProductRepository : IProduct
    {
        private readonly ZposContext _context;

        public ProductRepository(ZposContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool Exists(string description)
        {
            var product = _context.Products.FirstOrDefault(p => p.Description.ToLower() == description.ToLower());

            return product == null;
        }

        public void AddProduct(Product product)
        {
            _context.Add(product);
        }

        public bool DeleteProduct(Product product)
        {
            _context.Products.Remove(product);

            return Save();
        }

        public bool ExistsCode(string code)
        {

            return _context.Products.Any(p => p.Code == code);
        }

        public Product GetPrductById(int id)
        {
            return _context.Products.Find(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            //sp_ListProducts
            var products = _context.Products.Include(p => p.Categories).Include(p => p.Brands).Where(p => p.Deleted == false);

            products = products.Where(p => p.Updated == false);

            return products;
        }

        public IEnumerable<Product> GetProductHistorial(string ProductCode)
        {
            var productHistorial = _context.Products.Include(p => p.Categories).Include(p => p.Brands).Where(p => p.Code == ProductCode);

            return productHistorial;
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
