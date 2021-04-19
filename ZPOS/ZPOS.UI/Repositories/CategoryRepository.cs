using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool AddCategory(Category category)
        {
            _context.Categories.Add(category);

            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);


            return Save();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories;
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.Include(c => c.Products).FirstOrDefault(c => c.ID ==id);
        }

        public bool UpdateCategory(Category category)
        {
            _context.Categories.Update(category);

            return Save();
        }

        private bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
