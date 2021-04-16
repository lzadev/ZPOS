using System;
using System.Collections.Generic;
using ZPOS.UI.Entities;
using ZPOS.UI.Interfaces;

namespace ZPOS.UI.Services
{
    public class BrandServices : IBrandServices
    {
        private readonly IBrand _brandRepository;

        public BrandServices(IBrand brandRepository)
        {
            _brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
        }

        public IEnumerable<Brand> GetBrands()
        {
            return _brandRepository.GetBrands();
        }
    }
}
