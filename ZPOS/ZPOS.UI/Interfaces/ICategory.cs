using System.Collections.Generic;
using ZPOS.UI.Entities;

namespace ZPOS.UI.Interfaces
{
    public interface ICategory
    {
        IEnumerable<Category> GetCategories();

        Category GetCategoryById(int id);

        bool AddCategory(Category category);

        bool DeleteCategory(Category category);

        bool UpdateCategory(Category category);
    }
}
