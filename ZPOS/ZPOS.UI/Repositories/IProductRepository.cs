using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using ZPOS.UI.Context;
using ZPOS.UI.Entities;
using ZPOS.UI.Interfaces;

namespace ZPOS.UI.Repositories
{
    public class IProductRepository : IProduct
    {
        private readonly ZposContext _context;

        public IProductRepository(ZposContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.Include(p => p.Categories).Include(p =>p.Brands);
        }
    }
}
