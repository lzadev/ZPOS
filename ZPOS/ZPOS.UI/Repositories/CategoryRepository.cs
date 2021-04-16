using System;
using System.Collections.Generic;
using ZPOS.UI.Context;
using ZPOS.UI.Entities;
using ZPOS.UI.Interfaces;

namespace ZPOS.UI.Repositories
{
    public class CategoryRepository : ICategory
    {
        private readonly ZposContext _context;

        public CategoryRepository(ZposContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories;
        }
    }
}
