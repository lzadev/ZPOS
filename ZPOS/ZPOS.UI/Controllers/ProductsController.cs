using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZPOS.UI.Interfaces;
using ZPOS.UI.Models;

namespace ZPOS.UI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;

        public ProductsController(IProductServices productServices, IMapper mapper)
        {
            _productServices = productServices ?? throw new ArgumentNullException(nameof(productServices));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); ;
        }
        public IActionResult Index()
        {
            var productsFromServices = _productServices.GetProducts();

            var productsToReturn = _mapper.Map<IEnumerable<ProductVM>>(productsFromServices);

            return Ok(productsToReturn);
        }
    }
}
