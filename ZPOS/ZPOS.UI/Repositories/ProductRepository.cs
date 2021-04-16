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

        public bool addProduct(Product product)
        {
            _context.Add(product);

            return Save();
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
            return _context.Products.Include(p => p.Categories).Include(p =>p.Brands);
        }

        public bool UpdateProduct(Product product)
        {
            _context.Products.Update(product);

            return Save();
        }

        private bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
