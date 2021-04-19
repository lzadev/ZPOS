using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ZPOS.UI.Interfaces;
using ZPOS.UI.Models;
using ZPOS.UI.Services;

namespace ZPOS.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IBrandServices _brandServices;

        public HomeController(ILogger<HomeController> logger, IProductServices productServices,ICategoryServices categoryServices,
            IBrandServices brandServices)
        {
            _logger = logger;
            _productServices = productServices ?? throw new ArgumentNullException(nameof(productServices));
            _categoryServices = categoryServices ?? throw new ArgumentNullException(nameof(categoryServices));
            _brandServices = brandServices ?? throw new ArgumentNullException(nameof(brandServices));
        }

        public IActionResult Index()
        {
            var dashBoard = new DashboardVM
            {
                TotalOfPorducts = _productServices.GetProducts().Count(),
                TotalOfCategries = _categoryServices.GetCategories().Count(),
                TotalOfBrands = _brandServices.GetBrands().Count()
            };

            return View(dashBoard);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
