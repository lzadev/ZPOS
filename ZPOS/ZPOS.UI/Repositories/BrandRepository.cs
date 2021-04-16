using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZPOS.UI.Context;
using ZPOS.UI.Entities;
using ZPOS.UI.Interfaces;

namespace ZPOS.UI.Repositories
{
    public class BrandRepository:IBrand
    {
        private readonly ZposContext _context;

        public BrandRepository(ZposContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Brand> GetBrands()
        {
            return _context.Brands;
        }
    }
}
