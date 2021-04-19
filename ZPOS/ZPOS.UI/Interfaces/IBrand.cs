using System.Collections.Generic;
using ZPOS.UI.Entities;

namespace ZPOS.UI.Interfaces
{
    public interface IBrand
    {
        IEnumerable<Brand> GetBrands();

        Brand GetBrandById(int id);

        bool AddBrand(Brand brand);

        bool DeleteBrand(Brand brand);

        bool UpdateBrand(Brand brand);
    }
}
