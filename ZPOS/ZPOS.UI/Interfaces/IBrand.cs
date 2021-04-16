using System.Collections.Generic;
using ZPOS.UI.Entities;

namespace ZPOS.UI.Interfaces
{
    public interface IBrand
    {
        IEnumerable<Brand> GetBrands();
    }
}
