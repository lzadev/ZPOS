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

        public bool AddBrand(Brand brand)
        {
            return _brandRepository.AddBrand(brand);
        }

        public bool DeleteBrand(Brand brand)
        {
            return _brandRepository.DeleteBrand(brand);
        }

        public Brand GetBrandById(int id)
        {
            return _brandRepository.GetBrandById(id);
        }

        public IEnumerable<Brand> GetBrands()
        {
            return _brandRepository.GetBrands();
        }

        public bool UpdateBrand(Brand brand)
        {
            return _brandRepository.UpdateBrand(brand);
        }
    }
}
