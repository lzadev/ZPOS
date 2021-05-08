using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ZPOS.UI.Context;
using ZPOS.UI.Entities;
using ZPOS.UI.Interfaces;

namespace ZPOS.UI.Repositories
{
    public class BrandRepository : IBrand
    {
        private readonly ZposContext _context;

        public BrandRepository(ZposContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool AddBrand(Brand Brand)
        {
            _context.Brands.Add(Brand);

            return Save();
        }

        public bool DeleteBrand(Brand Brand)
        {
            _context.Brands.Remove(Brand);
            return Save();
        }

        public Brand GetBrandById(int id)
        {
            return _context.Brands.Include(b => b.Products).FirstOrDefault(b => b.ID == id);
        }

        public IEnumerable<Brand> GetBrands()
        {

            return _context.Brands;
        }

        public bool UpdateBrand(Brand Brand)
        {
            _context.Brands.Update(Brand);

            return Save();
        }

        private bool Save() => _context.SaveChanges() > 0;
    }
}
