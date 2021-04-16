using System.Collections.Generic;
using ZPOS.UI.Entities;

namespace ZPOS.UI.Interfaces
{
    public interface ICategory
    {
        IEnumerable<Category> GetCategories();
    }
}
